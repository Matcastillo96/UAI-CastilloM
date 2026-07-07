using System.Collections.Generic;

namespace DIEFER.Servicios.Interfaces
{
    /// <summary>
    /// Contrato de persistencia del Dígito Verificador (DVH/DVV).
    /// Desacopla el motor de DV de la tecnología de almacenamiento.
    /// </summary>
    public interface IDVRepositorio_593CM
    {
        /// <summary>Lista los nombres de tablas controladas registradas en DV.</summary>
        List<string> ListarTablasControladas_593CM();

        /// <summary>Obtiene el DVV almacenado para una tabla, o null si no existe.</summary>
        string ObtenerDVV_593CM(string nombreTabla);

        /// <summary>Guarda o actualiza el DVV de una tabla.</summary>
        void GuardarDVV_593CM(string nombreTabla, string dvv);

        /// <summary>Obtiene el DVH almacenado para una clave de registro, o null si no existe.</summary>
        string ObtenerDVH_593CM(string nombreTabla, string claveRegistro);

        /// <summary>Guarda o actualiza el DVH de un registro.</summary>
        void GuardarDVH_593CM(string nombreTabla, string claveRegistro, string dvh);

        /// <summary>Elimina los DVH de una tabla (útil al recalcular desde cero).</summary>
        void EliminarDVHsDeTabla_593CM(string nombreTabla);

        /// <summary>Obtiene todos los DVH de una tabla ordenados por clave de registro.</summary>
        List<(string clave, string dvh)> ObtenerDVHsDeTabla_593CM(string nombreTabla);
    }
}
