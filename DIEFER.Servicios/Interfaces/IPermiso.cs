using System.Collections.Generic;

namespace DIEFER.Servicios
{
<<<<<<< HEAD
    /// <summary>
    /// Component del patrón Composite: abstracción común entre
    /// <see cref="Patente_593CM"/> (leaf) y <see cref="Familia_593CM"/> (composite).
    /// </summary>
    public interface IPermiso_593CM
    {
        string Nombre_593CM { get; }

        /// <summary>IDs de todas las patentes alcanzables desde este componente.</summary>
=======
    // Component del patrón Composite.
    public interface IPermiso_593CM
    {
        string Nombre_593CM { get; }
>>>>>>> origin/dev
        IEnumerable<int> ObtenerIdsPatente_593CM();
    }
}
