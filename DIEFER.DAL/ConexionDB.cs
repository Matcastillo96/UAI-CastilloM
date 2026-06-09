using System.Configuration;
using System.Data.SqlClient;

namespace DIEFER.DAL
{
    // Proveedor central de conexiones SQL y parámetros de configuración de la aplicación.
    public static class ConexionDB_593CM
    {
        private static string _connectionString_593CM;

        public static string ConnectionString_593CM =>
            _connectionString_593CM
            ?? ConfigurationManager.ConnectionStrings["DIEFER"]?.ConnectionString
            ?? throw new ConfigurationErrorsException("ConnectionString 'DIEFER' no encontrada en App.config.");

        public static string ClaveAES_593CM =>
            ConfigurationManager.AppSettings["ClaveAES"]
            ?? throw new ConfigurationErrorsException("ClaveAES no configurada en App.config.");

        public static SqlConnection ObtenerConexion_593CM()
        {
            if (string.IsNullOrEmpty(_connectionString_593CM))
                _connectionString_593CM = ConfigurationManager.ConnectionStrings["DIEFER"]?.ConnectionString
                    ?? throw new ConfigurationErrorsException("ConnectionString 'DIEFER' no encontrada en App.config.");

            return new SqlConnection(_connectionString_593CM);
        }

        public static void VerificarConexion_593CM()
        {
            using (var conn = ObtenerConexion_593CM())
                conn.Open();
        }
    }
}
