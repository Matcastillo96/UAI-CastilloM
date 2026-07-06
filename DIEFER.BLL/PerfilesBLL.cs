using System.Collections.Generic;
using System.Linq;
using System.Transactions;
using DIEFER.DAL;
using DIEFER.Servicios;

namespace DIEFER.BLL
{
    /// <summary>
    /// Capa de negocio para la gestión de perfiles (patrón Composite):
    /// composición de Familias (composite) y Patentes (leaf), y su
    /// asignación a Roles. Garantiza las invariantes del modelo:
    /// ausencia de ciclos en el grafo de familias y no-duplicación
    /// de permisos efectivos.
    /// </summary>
    public class PerfilesBLL_593CM
    {
        private readonly IFamiliaDAL_593CM    _familiaDAL_593CM;
        private readonly IPatenteDAL_593CM    _patenteDAL_593CM;
        private readonly IRolPermisoDAL_593CM _rolPermisoDAL_593CM;

        public PerfilesBLL_593CM()
            : this(new FamiliaDAL_593CM(), new PatenteDAL_593CM(), new RolPermisoDAL_593CM()) { }

        /// <summary>Constructor para inyección de dependencias (testing).</summary>
        public PerfilesBLL_593CM(IFamiliaDAL_593CM familiaDAL, IPatenteDAL_593CM patenteDAL,
                                  IRolPermisoDAL_593CM rolPermisoDAL)
        {
            _familiaDAL_593CM    = familiaDAL;
            _patenteDAL_593CM    = patenteDAL;
            _rolPermisoDAL_593CM = rolPermisoDAL;
        }

        // ── Consultas Familia ────────────────────────────────────────────────────────

        /// <summary>Lista todas las familias registradas, sin sus componentes.</summary>
        public List<Familia_593CM> ListarFamilias_593CM() =>
            _familiaDAL_593CM.ListarTodas_593CM();

        /// <summary>Carga una familia con sus componentes directos (un nivel).</summary>
        public Familia_593CM CargarFamiliaConComponentes_593CM(int idFamilia) =>
            _familiaDAL_593CM.CargarConComponentes_593CM(idFamilia);

        // ── Consultas Rol ────────────────────────────────────────────────────────────

        /// <summary>Componentes (familias y patentes) asignados directamente a un rol.</summary>
        public List<IPermiso_593CM> ObtenerComponentesDeRol_593CM(int idRol)
        {
            var resultado = new List<IPermiso_593CM>();
            resultado.AddRange(_rolPermisoDAL_593CM.ObtenerFamiliasDirectas_593CM(idRol)
                                                   .Cast<IPermiso_593CM>());
            resultado.AddRange(_rolPermisoDAL_593CM.ObtenerPatentesDirectas_593CM(idRol)
                                                   .Cast<IPermiso_593CM>());
            return resultado;
        }

        /// <summary>
        /// Cadenas de permiso efectivas de un rol: las de sus patentes directas
        /// más las alcanzables transitivamente a través de sus familias.
        /// </summary>
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

        /// <summary>
        /// Ítems asignables a una familia. Excluye: la propia familia, componentes
        /// ya asignados directamente, familias que generarían un ciclo y familias
        /// cuyas patentes efectivas ya están todas cubiertas.
        /// </summary>
        public List<IPermiso_593CM> GetDisponiblesParaFamilia_593CM(int idFamilia)
        {
            var grafo = _familiaDAL_593CM.CargarGrafo_593CM();
            var familiaActual = _familiaDAL_593CM.CargarConComponentes_593CM(idFamilia);

            var idsFamiliasDir = new HashSet<int>(
                familiaActual.Componentes_593CM
                    .OfType<Familia_593CM>()
                    .Select(f => f.ID_familia_593CM));

            // Patentes efectivas actuales de la familia:
            // patentes directas + patentes contenidas en subfamilias.
            var idsEfectivos = BfsPatentes_593CM(idFamilia, grafo);

            var disponibles = new List<IPermiso_593CM>();

            foreach (var f in _familiaDAL_593CM.ListarTodas_593CM())
            {
                if (f.ID_familia_593CM == idFamilia) continue;
                if (idsFamiliasDir.Contains(f.ID_familia_593CM)) continue;
                if (CreariaCirculo_593CM(idFamilia, f.ID_familia_593CM, grafo)) continue;

                var idsNuevas = BfsPatentes_593CM(f.ID_familia_593CM, grafo);

                // Si la familia candidata no aporta ninguna patente nueva, no se muestra.
                if (idsNuevas.Count > 0 && idsNuevas.IsSubsetOf(idsEfectivos)) continue;

                disponibles.Add(f);
            }

            foreach (var p in _patenteDAL_593CM.ListarTodas_593CM())
            {
                // Antes se validaba solo contra patentes directas.
                // Ahora se valida contra patentes efectivas.
                if (idsEfectivos.Contains(p.ID_patente_593CM)) continue;

                disponibles.Add(p);
            }

            return disponibles;
        }

        // ── Disponibles para Rol ─────────────────────────────────────────────────────

        /// <summary>
        /// Ítems asignables a un rol. Excluye componentes ya asignados directamente
        /// y familias cuyas patentes efectivas ya están todas cubiertas en el rol.
        /// </summary>
        public List<IPermiso_593CM> GetDisponiblesParaRol_593CM(int idRol)
        {
            var grafo = _familiaDAL_593CM.CargarGrafo_593CM();
            var familiasDir = _rolPermisoDAL_593CM.ObtenerFamiliasDirectas_593CM(idRol);
            var patentesDir = _rolPermisoDAL_593CM.ObtenerPatentesDirectas_593CM(idRol);

            var idsFamiliasDir = new HashSet<int>(familiasDir.Select(f => f.ID_familia_593CM));

            // Patentes efectivas actuales del rol:
            // patentes directas + patentes contenidas en familias directas.
            var idsEfectivos = new HashSet<int>(patentesDir.Select(p => p.ID_patente_593CM));

            foreach (var f in familiasDir)
                idsEfectivos.UnionWith(BfsPatentes_593CM(f.ID_familia_593CM, grafo));

            var disponibles = new List<IPermiso_593CM>();

            foreach (var f in _familiaDAL_593CM.ListarTodas_593CM())
            {
                if (idsFamiliasDir.Contains(f.ID_familia_593CM)) continue;

                var idsF = BfsPatentes_593CM(f.ID_familia_593CM, grafo);

                // Si esta familia no aporta ninguna patente nueva, no se muestra.
                if (idsF.Count > 0 && idsF.IsSubsetOf(idsEfectivos)) continue;

                disponibles.Add(f);
            }

            foreach (var p in _patenteDAL_593CM.ListarTodas_593CM())
            {
                // Antes se validaba solo contra patentes directas.
                // Ahora se valida contra patentes efectivas.
                if (idsEfectivos.Contains(p.ID_patente_593CM)) continue;

                disponibles.Add(p);
            }

            return disponibles;
        }

        // ── Asignación Familia ────────────────────────────────────────────────────────

        /// <summary>Agrega una patente a una familia si no está ya asignada directamente.</summary>
        public bool AgregarPatenteAFamilia_593CM(int idFamilia, int idPatente)
        {
            var grafo = _familiaDAL_593CM.CargarGrafo_593CM();

            // Patentes efectivas actuales de la familia:
            // directas + las que vienen por subfamilias.
            var idsEfectivos = BfsPatentes_593CM(idFamilia, grafo);

            // Si ya está cubierta directa o indirectamente, no se agrega.
            if (idsEfectivos.Contains(idPatente)) return false;

            return _familiaDAL_593CM.AgregarPatente_593CM(idFamilia, idPatente);
        }

        /// <summary>
        /// Agrega una sub-familia validando que no se genere un ciclo, y quita
        /// las patentes directas del padre que la sub-familia ya cubre.
        /// La operación completa es atómica (transacción).
        /// </summary>
        public bool AgregarSubFamiliaAFamilia_593CM(int idFamiliaPadre, int idFamiliaHija)
        {
            if (idFamiliaPadre == idFamiliaHija) return false;

            var grafo = _familiaDAL_593CM.CargarGrafo_593CM();

            if (CreariaCirculo_593CM(idFamiliaPadre, idFamiliaHija, grafo)) return false;

            var familiaPadre = _familiaDAL_593CM.CargarConComponentes_593CM(idFamiliaPadre);

            var patentesDirectasPadre = familiaPadre.Componentes_593CM
                .OfType<Patente_593CM>()
                .ToList();

            var familiasDirectasPadre = familiaPadre.Componentes_593CM
                .OfType<Familia_593CM>()
                .ToList();

            if (familiasDirectasPadre.Any(f => f.ID_familia_593CM == idFamiliaHija))
                return false;

            // Patentes que aporta la familia hija nueva.
            var idsHija = BfsPatentes_593CM(idFamiliaHija, grafo);

            using (var scope = new TransactionScope())
            {
                if (!_familiaDAL_593CM.AgregarSubFamilia_593CM(idFamiliaPadre, idFamiliaHija))
                    return false;

                // 1) Quita patentes directas del padre que la nueva subfamilia ya cubre.
                foreach (var p in patentesDirectasPadre)
                    if (idsHija.Contains(p.ID_patente_593CM))
                        _familiaDAL_593CM.QuitarPatente_593CM(idFamiliaPadre, p.ID_patente_593CM);

                // 2) Quita subfamilias directas del padre que quedaron completamente
                // cubiertas por la nueva subfamilia.
                foreach (var f in familiasDirectasPadre)
                {
                    var idsFamiliaExistente = BfsPatentes_593CM(f.ID_familia_593CM, grafo);

                    if (idsFamiliaExistente.Count > 0 &&
                        idsFamiliaExistente.IsSubsetOf(idsHija))
                    {
                        _familiaDAL_593CM.QuitarSubFamilia_593CM(
                            idFamiliaPadre,
                            f.ID_familia_593CM);
                    }
                }

                scope.Complete();
            }

            return true;
        }

        public bool QuitarPatenteDeFamilia_593CM(int idFamilia, int idPatente) =>
            _familiaDAL_593CM.QuitarPatente_593CM(idFamilia, idPatente);

        public bool QuitarSubFamiliaDeFamilia_593CM(int idFamiliaPadre, int idFamiliaHija) =>
            _familiaDAL_593CM.QuitarSubFamilia_593CM(idFamiliaPadre, idFamiliaHija);

        /// <summary>Crea una familia. Retorna el ID generado, o -1 si falla.</summary>
        public int CrearFamilia_593CM(string nombre) =>
            _familiaDAL_593CM.Crear_593CM(nombre);

        // ── Asignación Rol ────────────────────────────────────────────────────────────

        /// <summary>Agrega una patente a un rol si no está ya asignada directamente.</summary>
        public bool AgregarPatenteARol_593CM(int idRol, int idPatente)
        {
            var grafo = _familiaDAL_593CM.CargarGrafo_593CM();
            var familiasDir = _rolPermisoDAL_593CM.ObtenerFamiliasDirectas_593CM(idRol);
            var patentesDir = _rolPermisoDAL_593CM.ObtenerPatentesDirectas_593CM(idRol);

            var idsEfectivos = new HashSet<int>(patentesDir.Select(p => p.ID_patente_593CM));

            foreach (var f in familiasDir)
                idsEfectivos.UnionWith(BfsPatentes_593CM(f.ID_familia_593CM, grafo));

            // Si la patente ya está directa o cubierta por una familia, no se agrega.
            if (idsEfectivos.Contains(idPatente)) return false;

            return _rolPermisoDAL_593CM.AgregarPatente_593CM(idRol, idPatente);
        }

        /// <summary>
        /// Agrega una familia a un rol y quita las patentes directas del rol
        /// que la familia ya cubre. La operación completa es atómica (transacción).
        /// </summary>
        public bool AgregarFamiliaARol_593CM(int idRol, int idFamilia)
        {
            var familiasDir = _rolPermisoDAL_593CM.ObtenerFamiliasDirectas_593CM(idRol);
            if (familiasDir.Any(f => f.ID_familia_593CM == idFamilia)) return false;

            var grafo = _familiaDAL_593CM.CargarGrafo_593CM();
            var patentesDir = _rolPermisoDAL_593CM.ObtenerPatentesDirectas_593CM(idRol);

            // Patentes que aporta la familia nueva.
            var idsNuevas = BfsPatentes_593CM(idFamilia, grafo);

            using (var scope = new TransactionScope())
            {
                if (!_rolPermisoDAL_593CM.AgregarFamilia_593CM(idRol, idFamilia))
                    return false;

                // 1) Quita patentes directas que la nueva familia ya cubre.
                foreach (var p in patentesDir)
                    if (idsNuevas.Contains(p.ID_patente_593CM))
                        _rolPermisoDAL_593CM.QuitarPatente_593CM(idRol, p.ID_patente_593CM);

                // 2) Quita familias directas que quedaron completamente cubiertas
                // por la nueva familia.
                foreach (var f in familiasDir)
                {
                    var idsFamiliaExistente = BfsPatentes_593CM(f.ID_familia_593CM, grafo);

                    if (idsFamiliaExistente.Count > 0 &&
                        idsFamiliaExistente.IsSubsetOf(idsNuevas))
                    {
                        _rolPermisoDAL_593CM.QuitarFamilia_593CM(idRol, f.ID_familia_593CM);
                    }
                }

                scope.Complete();
            }

            return true;
        }

        public bool QuitarPatenteDeRol_593CM(int idRol, int idPatente) =>
            _rolPermisoDAL_593CM.QuitarPatente_593CM(idRol, idPatente);

        public bool QuitarFamiliaDeRol_593CM(int idRol, int idFamilia) =>
            _rolPermisoDAL_593CM.QuitarFamilia_593CM(idRol, idFamilia);

        // ── Helpers internos ─────────────────────────────────────────────────────────

        /// <summary>
        /// BFS en memoria sobre el grafo precargado: retorna todos los IDs de
        /// patentes alcanzables desde la familia indicada.
        /// </summary>
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

                foreach (var idP in grafo.GetPatentes_593CM(actual))
                    resultado.Add(idP);

                foreach (var idH in grafo.GetHijas_593CM(actual))
                    if (!visitados.Contains(idH))
                        cola.Enqueue(idH);
            }

            return resultado;
        }

        /// <summary>Verifica en ambas direcciones si vincular padre→hija generaría un ciclo.</summary>
        private static bool CreariaCirculo_593CM(int idPadre, int idHija, GrafoFamilias_593CM grafo)
        {
            return DesciendeDe_593CM(idPadre, idHija, grafo)
                || DesciendeDe_593CM(idHija, idPadre, grafo);
        }

        /// <summary>BFS: true si idFamilia desciende (directa o transitivamente) de idAncestro.</summary>
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

                foreach (var hijo in grafo.GetHijas_593CM(actual))
                    if (!visitados.Contains(hijo))
                        cola.Enqueue(hijo);
            }

            return false;
        }
    }
}
