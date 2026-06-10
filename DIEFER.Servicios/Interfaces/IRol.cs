using System.Collections.Generic;

namespace DIEFER.Servicios
{
    /// <summary>Contrato de acceso a datos para la entidad Rol.</summary>
    public interface IRol_593CM
    {
        List<Rol_593CM> ListarTodos_593CM();

        /// <summary>Retorna el ID del rol con ese nombre, o 0 si no existe.</summary>
        int ObtenerIDPorNombre_593CM(string nombre);

        /// <summary>Crea un rol. Retorna el ID generado, o -1 si falla.</summary>
        int Crear_593CM(string nombre);
    }
}
