using System.Collections.Generic;
using DIEFER.BE;
using DIEFER.DAL;

namespace DIEFER.BLL
{
    public class RolBLL_593CM
    {
        private readonly IRolDB_593CM _rolDB_593CM;

        public RolBLL_593CM(IRolDB_593CM rolDB)
        {
            _rolDB_593CM = rolDB;
        }

        public List<Rol_593CM> ListarTodos_593CM() => _rolDB_593CM.ListarTodos_593CM();

        public int ObtenerIDPorNombre_593CM(string nombre) =>
            _rolDB_593CM.ObtenerIDPorNombre_593CM(nombre);
    }
}
