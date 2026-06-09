using System.Collections.Generic;

namespace DIEFER.Servicios
{
    public interface IRol_593CM
    {
        List<Rol_593CM> ListarTodos_593CM();
        int ObtenerIDPorNombre_593CM(string nombre);
        bool Crear_593CM(string nombre);
    }
}
