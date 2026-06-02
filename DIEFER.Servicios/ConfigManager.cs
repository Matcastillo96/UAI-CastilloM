using System.Configuration;

namespace DIEFER.Servicios
{
    // Acceso centralizado a la configuración de la aplicación (App.config).
    public static class ConfigManager_593CM
    {
        public static string ClaveAES_593CM =>
            ConfigurationManager.AppSettings["ClaveAES"]
            ?? throw new ConfigurationErrorsException("ClaveAES no configurada en App.config");

        public static string ConnectionString_593CM =>
            ConfigurationManager.ConnectionStrings["DIEFER"]?.ConnectionString
            ?? throw new ConfigurationErrorsException("ConnectionString 'DIEFER' no encontrada en App.config");
    }
}
