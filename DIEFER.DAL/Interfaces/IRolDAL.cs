using System.Collections.Generic;
using DIEFER.Servicios;

namespace DIEFER.DAL
{
    /// <summary>Contrato de acceso a datos para la entidad Rol.</summary>
    public interface IRolDAL_593CM
    {
        List<Rol_593CM> ListarTodos_593CM();

        /// <summary>Retorna el ID del rol con ese nombre, o 0 si no existe.</summary>
        int ObtenerIDPorNombre_593CM(string nombre);

        /// <summary>Crea un rol. Retorna el ID generado, o -1 si falla.</summary>
        int Crear_593CM(string nombre);

        /// <summary>Renombra un rol. Retorna true si fue exitoso.</summary>
        bool Renombrar_593CM(int idRol, string nombre);

        /// <summary>Elimina un rol. Retorna true si fue exitoso.</summary>
        bool Eliminar_593CM(int idRol);

        /// <summary>Cuenta los usuarios que tienen asignado el rol.</summary>
        int ContarUsuarios_593CM(int idRol);
    }
}
