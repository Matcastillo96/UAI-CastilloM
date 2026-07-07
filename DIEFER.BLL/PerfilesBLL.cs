using System.Collections.Generic;
using System.Linq;
using DIEFER.DAL;
using DIEFER.DAL.Interfaces;
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
        private readonly IFamiliaDAL_593CM _familiaDAL_593CM;
        private readonly IPatenteDAL_593CM _patenteDAL_593CM;
        private readonly IRolPermisoDAL_593CM _rolPermisoDAL_593CM;

        public PerfilesBLL_593CM()
            : this(new FamiliaDAL_593CM(), new PatenteDAL_593CM(), new RolPermisoDAL_593CM()) { }

        /// <summary>Constructor para inyección de dependencias (testing).</summary>
        public PerfilesBLL_593CM(
            IFamiliaDAL_593CM familiaDAL,
            IPatenteDAL_593CM patenteDAL,
            IRolPermisoDAL_593CM rolPermisoDAL)
        {
            _familiaDAL_593CM = familiaDAL;
            _patenteDAL_593CM = patenteDAL;
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
            {
                if (!string.IsNullOrEmpty(p.Permiso_593CM))
                    resultado.Add(p.Permiso_593CM);
            }

            foreach (var f in _rolPermisoDAL_593CM.ObtenerFamiliasDirectas_593CM(idRol))
            {
                foreach (var idP in GrafoFamiliasAlgoritmos_593CM.BfsPatentes_593CM(f.ID_familia_593CM, grafo))
                {
                    if (todasPatentes.TryGetValue(idP, out string permiso) &&
                        !string.IsNullOrEmpty(permiso))
                    {
                        resultado.Add(permiso);
                    }
                }
            }

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
            var idsEfectivos = GrafoFamiliasAlgoritmos_593CM.BfsPatentes_593CM(idFamilia, grafo);

            var disponibles = new List<IPermiso_593CM>();

            foreach (var f in _familiaDAL_593CM.ListarTodas_593CM())
            {
                if (f.ID_familia_593CM == idFamilia) continue;
                if (idsFamiliasDir.Contains(f.ID_familia_593CM)) continue;
                if (GrafoFamiliasAlgoritmos_593CM.CreariaCirculo_593CM(idFamilia, f.ID_familia_593CM, grafo)) continue;

                var idsNuevas = GrafoFamiliasAlgoritmos_593CM.BfsPatentes_593CM(f.ID_familia_593CM, grafo);

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

            var idsFamiliasDir = new HashSet<int>(
                familiasDir.Select(f => f.ID_familia_593CM));

            // Patentes efectivas actuales del rol:
            // patentes directas + patentes contenidas en familias directas.
            var idsEfectivos = new HashSet<int>(
                patentesDir.Select(p => p.ID_patente_593CM));

            foreach (var f in familiasDir)
                idsEfectivos.UnionWith(GrafoFamiliasAlgoritmos_593CM.BfsPatentes_593CM(f.ID_familia_593CM, grafo));

            var disponibles = new List<IPermiso_593CM>();

            foreach (var f in _familiaDAL_593CM.ListarTodas_593CM())
            {
                if (idsFamiliasDir.Contains(f.ID_familia_593CM)) continue;

                var idsF = GrafoFamiliasAlgoritmos_593CM.BfsPatentes_593CM(f.ID_familia_593CM, grafo);

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
            var idsEfectivos = GrafoFamiliasAlgoritmos_593CM.BfsPatentes_593CM(idFamilia, grafo);

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

            if (GrafoFamiliasAlgoritmos_593CM.CreariaCirculo_593CM(idFamiliaPadre, idFamiliaHija, grafo)) return false;

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
            var idsHija = GrafoFamiliasAlgoritmos_593CM.BfsPatentes_593CM(idFamiliaHija, grafo);

            // Patentes directas del padre que la nueva subfamilia ya cubre.
            var idsPatentesAQuitar = patentesDirectasPadre
                .Where(p => idsHija.Contains(p.ID_patente_593CM))
                .Select(p => p.ID_patente_593CM)
                .ToList();

            // Subfamilias directas del padre que quedaron completamente cubiertas
            // por la nueva subfamilia.
            var idsFamiliasAQuitar = familiasDirectasPadre
                .Where(f =>
                {
                    var idsFamiliaExistente = GrafoFamiliasAlgoritmos_593CM.BfsPatentes_593CM(f.ID_familia_593CM, grafo);
                    return idsFamiliaExistente.Count > 0 && idsFamiliaExistente.IsSubsetOf(idsHija);
                })
                .Select(f => f.ID_familia_593CM)
                .ToList();

            return _familiaDAL_593CM.AgregarSubFamiliaConLimpieza_593CM(
                idFamiliaPadre, idFamiliaHija, idsPatentesAQuitar, idsFamiliasAQuitar);
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

            var idsEfectivos = new HashSet<int>(
                patentesDir.Select(p => p.ID_patente_593CM));

            foreach (var f in familiasDir)
                idsEfectivos.UnionWith(GrafoFamiliasAlgoritmos_593CM.BfsPatentes_593CM(f.ID_familia_593CM, grafo));

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
            var idsNuevas = GrafoFamiliasAlgoritmos_593CM.BfsPatentes_593CM(idFamilia, grafo);

            // Patentes directas del rol que la nueva familia ya cubre.
            var idsPatentesAQuitar = patentesDir
                .Where(p => idsNuevas.Contains(p.ID_patente_593CM))
                .Select(p => p.ID_patente_593CM)
                .ToList();

            // Familias directas del rol que quedaron completamente cubiertas
            // por la nueva familia.
            var idsFamiliasAQuitar = familiasDir
                .Where(f =>
                {
                    var idsFamiliaExistente = GrafoFamiliasAlgoritmos_593CM.BfsPatentes_593CM(f.ID_familia_593CM, grafo);
                    return idsFamiliaExistente.Count > 0 && idsFamiliaExistente.IsSubsetOf(idsNuevas);
                })
                .Select(f => f.ID_familia_593CM)
                .ToList();

            return _rolPermisoDAL_593CM.AgregarFamiliaConLimpieza_593CM(
                idRol, idFamilia, idsPatentesAQuitar, idsFamiliasAQuitar);
        }

        public bool QuitarPatenteDeRol_593CM(int idRol, int idPatente) =>
            _rolPermisoDAL_593CM.QuitarPatente_593CM(idRol, idPatente);

        public bool QuitarFamiliaDeRol_593CM(int idRol, int idFamilia) =>
            _rolPermisoDAL_593CM.QuitarFamilia_593CM(idRol, idFamilia);
    }
}
