using System.Collections.Generic;
using DIEFER.Servicios.Interfaces;

namespace DIEFER.DAL.Interfaces
{
    /// <summary>
    /// Contrato DAL para persistencia de DV. Expone también los proveedores
    /// <see cref="ITablaControlada_593CM"/> registrados para cada tabla controlada.
    /// </summary>
    public interface IDVDAL_593CM : IDVRepositorio_593CM
    {
        /// <summary>
        /// Proveedores de tablas controladas indexados por nombre de tabla.
        /// El motor de DV los usa para leer los datos actuales y recalcular.
        /// </summary>
        IReadOnlyDictionary<string, ITablaControlada_593CM> Proveedores_593CM { get; }
    }
}
