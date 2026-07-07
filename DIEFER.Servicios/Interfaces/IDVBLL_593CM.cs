using System.Collections.Generic;

namespace DIEFER.Servicios.Interfaces
{
    /// <summary>
    /// Contrato de negocio para operaciones de Dígito Verificador.
    /// </summary>
    public interface IDVBLL_593CM
    {
        List<string> VerificarIntegridad_593CM();
        void RecalcularTabla_593CM(string nombreTabla);
        void RecalcularTablaConBitacora_593CM(string nombreTabla, string login,
                                              string modulo, string evento, int criticidad);
        List<string> RecalcularTodo_593CM(string login);
    }
}
