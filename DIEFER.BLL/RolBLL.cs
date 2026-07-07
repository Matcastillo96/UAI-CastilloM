using System.Collections.Generic;
using System.Linq;
using DIEFER.DAL;
using DIEFER.DAL.Interfaces;
using DIEFER.Servicios;
using DIEFER.Servicios.Interfaces;

namespace DIEFER.BLL
{
    public class RolBLL_593CM
    {
        private readonly IRolDAL_593CM _rolDAL_593CM;
        private readonly IRolPermisoDAL_593CM _rolPermisoDAL_593CM;
        private readonly IDVBLL_593CM _dvBLL_593CM;

        public RolBLL_593CM() : this(new RolDAL_593CM(), new RolPermisoDAL_593CM(), null) { }

        public RolBLL_593CM(IRolDAL_593CM rolDAL, IRolPermisoDAL_593CM rolPermisoDAL,
                            IDVBLL_593CM dvBLL)
        {
            _rolDAL_593CM = rolDAL;
            _rolPermisoDAL_593CM = rolPermisoDAL;
            _dvBLL_593CM = dvBLL ?? new DVBLL_593CM();
        }

        public List<Rol_593CM> ListarTodos_593CM() => _rolDAL_593CM.ListarTodos_593CM();

        public int ObtenerIDPorNombre_593CM(string nombre) =>
            _rolDAL_593CM.ObtenerIDPorNombre_593CM(nombre);

        public int CrearRol_593CM(string nombre) =>
            _rolDAL_593CM.Crear_593CM(nombre);

        public enum ResultadoCrearRol_593CM { Exitoso, NombreRequerido, PermisoRequerido, NombreDuplicado }

        /// <summary>
        /// Crea un rol exigiendo al menos una familia o patente.
        /// </summary>
        public ResultadoCrearRol_593CM CrearRolConPermisos_593CM(string nombre,
                                                                  IEnumerable<int> idsPatente,
                                                                  IEnumerable<int> idsFamilia,
                                                                  out int idRolCreado)
        {
            idRolCreado = -1;

            if (string.IsNullOrWhiteSpace(nombre))
                return ResultadoCrearRol_593CM.NombreRequerido;

            var patentes = idsPatente ?? Enumerable.Empty<int>();
            var familias = idsFamilia ?? Enumerable.Empty<int>();

            if (!patentes.Any() && !familias.Any())
                return ResultadoCrearRol_593CM.PermisoRequerido;

            int id = _rolDAL_593CM.Crear_593CM(nombre.Trim());
            if (id < 0)
                return ResultadoCrearRol_593CM.NombreDuplicado;

            idRolCreado = id;

            foreach (int idPatente in patentes.Distinct())
                _rolPermisoDAL_593CM.AgregarPatente_593CM(id, idPatente);

            foreach (int idFamilia in familias.Distinct())
                _rolPermisoDAL_593CM.AgregarFamilia_593CM(id, idFamilia);

            RecalcularDVRol_593CM("Crear Rol");

            return ResultadoCrearRol_593CM.Exitoso;
        }

        public enum ResultadoRenombrarRol_593CM { Exitoso, NombreRequerido, NombreDuplicado }

        public ResultadoRenombrarRol_593CM RenombrarRol_593CM(int idRol, string nombre)
        {
            if (string.IsNullOrWhiteSpace(nombre))
                return ResultadoRenombrarRol_593CM.NombreRequerido;

            if (!_rolDAL_593CM.Renombrar_593CM(idRol, nombre.Trim()))
                return ResultadoRenombrarRol_593CM.NombreDuplicado;

            _dvBLL_593CM.RecalcularTablaConBitacora_593CM(
                "ROLES",
                LoginActual_593CM(),
                "Perfiles",
                "Renombrar Rol",
                2);

            return ResultadoRenombrarRol_593CM.Exitoso;
        }

        public enum ResultadoEliminarRol_593CM { Exitoso, Referenciado }

        public ResultadoEliminarRol_593CM EliminarRol_593CM(int idRol)
        {
            int usuarios = _rolDAL_593CM.ContarUsuarios_593CM(idRol);
            if (usuarios > 0)
                return ResultadoEliminarRol_593CM.Referenciado;

            _rolPermisoDAL_593CM.QuitarTodasLasPatentes_593CM(idRol);
            _rolPermisoDAL_593CM.QuitarTodasLasFamilias_593CM(idRol);
            _rolDAL_593CM.Eliminar_593CM(idRol);

            RecalcularDVRol_593CM("Eliminar Rol");

            return ResultadoEliminarRol_593CM.Exitoso;
        }

        private void RecalcularDVRol_593CM(string evento)
        {
            _dvBLL_593CM.RecalcularTabla_593CM("ROLES");
            _dvBLL_593CM.RecalcularTabla_593CM("Rol_Patente");
            _dvBLL_593CM.RecalcularTabla_593CM("Rol_Familia");
            _dvBLL_593CM.RecalcularTablaConBitacora_593CM(
                "EVENTOS",
                LoginActual_593CM(),
                "Perfiles",
                evento,
                2);
        }

        private static string LoginActual_593CM()
        {
            return SessionManager_593CM.GetInstancia_593CM().UsuarioActual_593CM?.Login_593CM
                   ?? "Sistema";
        }
    }
}
