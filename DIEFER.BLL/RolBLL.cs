using System.Collections.Generic;
using DIEFER.DAL;
using DIEFER.Servicios;

namespace DIEFER.BLL
{
    public class RolBLL_593CM
    {
        private readonly IRolDAL_593CM _rolDAL_593CM;

        public RolBLL_593CM() : this(new RolDAL_593CM()) { }

        public RolBLL_593CM(IRolDAL_593CM rolDAL)
        {
            _rolDAL_593CM = rolDAL;
        }

        public List<Rol_593CM> ListarTodos_593CM() => _rolDAL_593CM.ListarTodos_593CM();

        public int ObtenerIDPorNombre_593CM(string nombre) =>
            _rolDAL_593CM.ObtenerIDPorNombre_593CM(nombre);

        public int CrearRol_593CM(string nombre) =>
            _rolDAL_593CM.Crear_593CM(nombre);
    }
}
