using System.Collections.Generic;

namespace DIEFER.BE
{
    // Leaf del patrón Composite: permiso atómico.
    public class Patente_593CM : IPermiso_593CM
    {
        public int    ID_patente_593CM { get; set; }
        public string Nombre_593CM     { get; set; }
        public string Permiso_593CM    { get; set; }  // cadena de permiso (ej: "usuarios.crear")

        public IEnumerable<int> ObtenerIdsPatente_593CM() => new[] { ID_patente_593CM };
    }
}
