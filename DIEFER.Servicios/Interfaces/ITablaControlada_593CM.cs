using System.Collections.Generic;

namespace DIEFER.Servicios.Interfaces
{
    /// <summary>
    /// Abstracción de una tabla controlada por el Dígito Verificador.
    /// Permite extender el mecanismo de DV agregando implementaciones
    /// (Open/Closed): cada proveedor sabe leer su tabla y armar la cadena
    /// base de cada registro en orden fijo.
    /// </summary>
    public interface ITablaControlada_593CM
    {
        string NombreTabla_593CM { get; }

        /// <summary>
        /// Retorna todos los registros de la tabla como pares
        /// (clave única del registro, cadena base para calcular DVH).
        /// La cadena debe concatenar los campos relevantes en orden fijo
        /// separados por '|', sin incluir el DVH mismo.
        /// </summary>
        IEnumerable<(string clave, string cadena)> ObtenerRegistros_593CM();
    }
}
