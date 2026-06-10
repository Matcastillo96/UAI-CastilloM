using System.Collections.Generic;
using System.Linq;
using DIEFER.DAL;
using DIEFER.Servicios;

namespace DIEFER.BLL
{
    public class PerfilesBLL_593CM
    {
        private readonly IFamilia_593CM    _familiaDAL_593CM;
        private readonly IPatente_593CM    _patenteDAL_593CM;
        private readonly IRolPermiso_593CM _rolPermisoDAL_593CM;

        public PerfilesBLL_593CM()
            : this(new FamiliaDAL_593CM(), new PatenteDAL_593CM(), new RolPermisoDAL_593CM()) { }

        public PerfilesBLL_593CM(IFamilia_593CM familiaDAL, IPatente_593CM patenteDAL,
                                  IRolPermiso_593CM rolPermisoDAL)
        {
            _familiaDAL_593CM    = familiaDAL;
            _patenteDAL_593CM    = patenteDAL;
            _rolPermisoDAL_593CM = rolPermisoDAL;
        }

        // ── Consultas Familia ────────────────────────────────────────────────────────

        public List<Familia_593CM> ListarFamilias_593CM() =>
            _familiaDAL_593CM.ListarTodas_593CM();

        public Familia_593CM CargarFamiliaConComponentes_593CM(int idFamilia) =>
            _familiaDAL_593CM.CargarConComponentes_593CM(idFamilia);

        // ── Consultas Rol ────────────────────────────────────────────────────────────

        public List<IPermiso_593CM> ObtenerComponentesDeRol_593CM(int idRol)
        {
            var resultado = new List<IPermiso_593CM>();
            resultado.AddRange(_rolPermisoDAL_593CM.ObtenerFamiliasDirectas_593CM(idRol)
                                                   .Cast<IPermiso_593CM>());
            resultado.AddRange(_rolPermisoDAL_593CM.ObtenerPatentesDirectas_593CM(idRol)
                                                   .Cast<IPermiso_593CM>());
            return resultado;
        }

        // ── Permisos efectivos de un Rol ─────────────────────────────────────────────

        public HashSet<string> GetPermisosEfectivosDeRol_593CM(int idRol)
        {
            var resultado = new HashSet<string>(System.StringComparer.OrdinalIgnoreCase);
            var todasPatentes = _patenteDAL_593CM.ListarTodas_593CM()
                .ToDictionary(p => p.ID_patente_593CM, p => p.Permiso_593CM);
            var grafo = _familiaDAL_593CM.CargarGrafo_593CM();

            foreach (var p in _rolPermisoDAL_593CM.ObtenerPatentesDirectas_593CM(idRol))
                if (!string.IsNullOrEmpty(p.Permiso_593CM))
                    resultado.Add(p.Permiso_593CM);

            foreach (var f in _rolPermisoDAL_593CM.ObtenerFamiliasDirectas_593CM(idRol))
                foreach (var idP in BfsPatentes_593CM(f.ID_familia_593CM, grafo))
                    if (todasPatentes.TryGetValue(idP, out string permiso) && !string.IsNullOrEmpty(permiso))
                        resultado.Add(permiso);

            return resultado;
        }

        // ── Disponibles para Familia ─────────────────────────────────────────────────

        public List<IPermiso_593CM> GetDisponiblesParaFamilia_593CM(int idFamilia)
        {
            var grafo = _familiaDAL_593CM.CargarGrafo_593CM();
            var familiaActual = _familiaDAL_593CM.CargarConComponentes_593CM(idFamilia);

            var idsPatentesDir = new HashSet<int>(
                familiaActual.Componentes_593CM
                    .OfType<Patente_593CM>().Select(p => p.ID_patente_593CM));
            var idsFamiliasDir = new HashSet<int>(
                familiaActual.Componentes_593CM
                    .OfType<Familia_593CM>().Select(f => f.ID_familia_593CM));

            var idsEfectivos = BfsPatentes_593CM(idFamilia, grafo);
            var disponibles  = new List<IPermiso_593CM>();

            foreach (var f in _familiaDAL_593CM.ListarTodas_593CM())
            {
                if (f.ID_familia_593CM == idFamilia) continue;
                if (idsFamiliasDir.Contains(f.ID_familia_593CM)) continue;
                if (CreariaCirculo_593CM(idFamilia, f.ID_familia_593CM, grafo)) continue;

                var idsNuevas = BfsPatentes_593CM(f.ID_familia_593CM, grafo);
                if (idsNuevas.Count > 0 && idsNuevas.IsSubsetOf(idsEfectivos)) continue;

                disponibles.Add(f);
            }

            foreach (var p in _patenteDAL_593CM.ListarTodas_593CM())
            {
                if (idsPatentesDir.Contains(p.ID_patente_593CM)) continue;
                disponibles.Add(p);
            }

            return disponibles;
        }

        // ── Disponibles para Rol ─────────────────────────────────────────────────────

        public List<IPermiso_593CM> GetDisponiblesParaRol_593CM(int idRol)
        {
            var grafo       = _familiaDAL_593CM.CargarGrafo_593CM();
            var familiasDir = _rolPermisoDAL_593CM.ObtenerFamiliasDirectas_593CM(idRol);
            var patentesDir = _rolPermisoDAL_593CM.ObtenerPatentesDirectas_593CM(idRol);

            var idsFamiliasDir = new HashSet<int>(familiasDir.Select(f => f.ID_familia_593CM));
            var idsPatentesDir = new HashSet<int>(patentesDir.Select(p => p.ID_patente_593CM));

            var idsEfectivos = new HashSet<int>(idsPatentesDir);
            foreach (var f in familiasDir)
                idsEfectivos.UnionWith(BfsPatentes_593CM(f.ID_familia_593CM, grafo));

            var disponibles = new List<IPermiso_593CM>();

            foreach (var f in _familiaDAL_593CM.ListarTodas_593CM())
            {
                if (idsFamiliasDir.Contains(f.ID_familia_593CM)) continue;
                var idsF = BfsPatentes_593CM(f.ID_familia_593CM, grafo);
                if (idsF.Count > 0 && idsF.IsSubsetOf(idsEfectivos)) continue;
                disponibles.Add(f);
            }

            foreach (var p in _patenteDAL_593CM.ListarTodas_593CM())
            {
                if (idsPatentesDir.Contains(p.ID_patente_593CM)) continue;
                disponibles.Add(p);
            }

            return disponibles;
        }

        // ── Asignación Familia ────────────────────────────────────────────────────────

        public bool AgregarPatenteAFamilia_593CM(int idFamilia, int idPatente)
        {
            var familia = _familiaDAL_593CM.CargarConComponentes_593CM(idFamilia);
            bool yaDirecta = familia.Componentes_593CM
                .OfType<Patente_593CM>().Any(p => p.ID_patente_593CM == idPatente);
            if (yaDirecta) return false;
            return _familiaDAL_593CM.AgregarPatente_593CM(idFamilia, idPatente);
        }

        public bool AgregarSubFamiliaAFamilia_593CM(int idFamiliaPadre, int idFamiliaHija)
        {
            if (idFamiliaPadre == idFamiliaHija) return false;

            var grafo = _familiaDAL_593CM.CargarGrafo_593CM();
            if (CreariaCirculo_593CM(idFamiliaPadre, idFamiliaHija, grafo)) return false;

            var familiaPadre = _familiaDAL_593CM.CargarConComponentes_593CM(idFamiliaPadre);
            var patentesDirectasPadre = familiaPadre.Componentes_593CM
                .OfType<Patente_593CM>().ToList();

            if (!_familiaDAL_593CM.AgregarSubFamilia_593CM(idFamiliaPadre, idFamiliaHija)) return false;

            var idsHija = BfsPatentes_593CM(idFamiliaHija, grafo);
            foreach (var p in patentesDirectasPadre)
                if (idsHija.Contains(p.ID_patente_593CM))
                    _familiaDAL_593CM.QuitarPatente_593CM(idFamiliaPadre, p.ID_patente_593CM);

            return true;
        }

        public bool QuitarPatenteDeFamilia_593CM(int idFamilia, int idPatente) =>
            _familiaDAL_593CM.QuitarPatente_593CM(idFamilia, idPatente);

        public bool QuitarSubFamiliaDeFamilia_593CM(int idFamiliaPadre, int idFamiliaHija) =>
            _familiaDAL_593CM.QuitarSubFamilia_593CM(idFamiliaPadre, idFamiliaHija);

        // Retorna el ID de la nueva familia, o -1 si falla.
        public int CrearFamilia_593CM(string nombre) =>
            _familiaDAL_593CM.Crear_593CM(nombre);

        // ── Asignación Rol ────────────────────────────────────────────────────────────

        public bool AgregarPatenteARol_593CM(int idRol, int idPatente)
        {
            var patentesDir = _rolPermisoDAL_593CM.ObtenerPatentesDirectas_593CM(idRol);
            if (patentesDir.Any(p => p.ID_patente_593CM == idPatente)) return false;
            return _rolPermisoDAL_593CM.AgregarPatente_593CM(idRol, idPatente);
        }

        public bool AgregarFamiliaARol_593CM(int idRol, int idFamilia)
        {
            var familiasDir = _rolPermisoDAL_593CM.ObtenerFamiliasDirectas_593CM(idRol);
            if (familiasDir.Any(f => f.ID_familia_593CM == idFamilia)) return false;

            var grafo       = _familiaDAL_593CM.CargarGrafo_593CM();
            var patentesDir = _rolPermisoDAL_593CM.ObtenerPatentesDirectas_593CM(idRol);

            if (!_rolPermisoDAL_593CM.AgregarFamilia_593CM(idRol, idFamilia)) return false;

            var idsNuevas = BfsPatentes_593CM(idFamilia, grafo);
            foreach (var p in patentesDir)
                if (idsNuevas.Contains(p.ID_patente_593CM))
                    _rolPermisoDAL_593CM.QuitarPatente_593CM(idRol, p.ID_patente_593CM);

            return true;
        }

        public bool QuitarPatenteDeRol_593CM(int idRol, int idPatente) =>
            _rolPermisoDAL_593CM.QuitarPatente_593CM(idRol, idPatente);

        public bool QuitarFamiliaDeRol_593CM(int idRol, int idFamilia) =>
            _rolPermisoDAL_593CM.QuitarFamilia_593CM(idRol, idFamilia);

        // ── Helpers internos ─────────────────────────────────────────────────────────

        // BFS en memoria sobre el grafo precargado: retorna todos los IDs de patentes alcanzables.
        private static HashSet<int> BfsPatentes_593CM(int idFamilia, GrafoFamilias_593CM grafo)
        {
            var resultado = new HashSet<int>();
            var visitados = new HashSet<int>();
            var cola      = new Queue<int>();
            cola.Enqueue(idFamilia);

            while (cola.Count > 0)
            {
                int actual = cola.Dequeue();
                if (!visitados.Add(actual)) continue;

                foreach (var idP in grafo.GetPatentes(actual))
                    resultado.Add(idP);

                foreach (var idH in grafo.GetHijas(actual))
                    if (!visitados.Contains(idH))
                        cola.Enqueue(idH);
            }

            return resultado;
        }

        private static bool CreariaCirculo_593CM(int idPadre, int idHija, GrafoFamilias_593CM grafo)
        {
            return DesciendeDe_593CM(idPadre, idHija, grafo)
                || DesciendeDe_593CM(idHija, idPadre, grafo);
        }

        private static bool DesciendeDe_593CM(int idFamilia, int idAncestro, GrafoFamilias_593CM grafo)
        {
            var visitados = new HashSet<int>();
            var cola      = new Queue<int>();
            cola.Enqueue(idFamilia);

            while (cola.Count > 0)
            {
                int actual = cola.Dequeue();
                if (!visitados.Add(actual)) continue;
                if (actual == idAncestro) return true;

                foreach (var hijo in grafo.GetHijas(actual))
                    if (!visitados.Contains(hijo))
                        cola.Enqueue(hijo);
            }

            return false;
        }
    }
}
