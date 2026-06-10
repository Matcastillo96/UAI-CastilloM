using System.Collections.Generic;
using System.Linq;

namespace DIEFER.Servicios
{
    /// <summary>
    /// Composite del patrón Composite: agrupa Patentes y/o sub-Familias,
    /// permitiendo componer permisos en estructuras jerárquicas.
    /// </summary>
    public class Familia_593CM : IPermiso_593CM
    {
        public int    ID_familia_593CM { get; set; }
        public string Nombre_593CM     { get; set; }

        private readonly List<IPermiso_593CM> _componentes = new List<IPermiso_593CM>();

        /// <summary>Componentes directos (solo lectura). Mutar via Agregar/Quitar.</summary>
        public IReadOnlyList<IPermiso_593CM> Componentes_593CM => _componentes.AsReadOnly();

        public void Agregar_593CM(IPermiso_593CM componente) => _componentes.Add(componente);
        public void Quitar_593CM(IPermiso_593CM componente)  => _componentes.Remove(componente);

        /// <summary>IDs de todas las patentes alcanzables en el árbol (recursivo).</summary>
        public IEnumerable<int> ObtenerIdsPatente_593CM()
            => _componentes.SelectMany(c => c.ObtenerIdsPatente_593CM()).Distinct();
    }
}
