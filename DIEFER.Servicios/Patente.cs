using System.Collections.Generic;

namespace DIEFER.Servicios
{
    /// <summary>
    /// Leaf del patrón Composite: permiso atómico e indivisible.
    /// </summary>
    public class Patente_593CM : IPermiso_593CM
    {
        public int    ID_patente_593CM { get; set; }
        public string Nombre_593CM     { get; set; }

        /// <summary>Cadena de permiso consumida por la UI (ej: "admin.usuarios").</summary>
        public string Permiso_593CM    { get; set; }

        public IEnumerable<int> ObtenerIdsPatente_593CM() => new[] { ID_patente_593CM };
    }
}
