using System.Collections.Generic;
using DIEFER.BE;

namespace DIEFER.DAL
{
    public interface IRolDB_593CM
    {
        List<Rol_593CM> ListarTodos_593CM();
        int ObtenerIDPorNombre_593CM(string nombre);
    }
}
