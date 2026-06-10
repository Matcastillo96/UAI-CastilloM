using System.Configuration;
using System.Data.SqlClient;

namespace DIEFER.DAL
{
    // Proveedor central de conexiones SQL y parámetros de configuración de la aplicación.
    public static class ConexionDB_593CM
    {
        private static string _connectionString_593CM;
        private static string _claveAES_593CM;

        // Permite inicializar el connection string y la clave AES directamente en la clase,
        // sin depender exclusivamente de App.config.
        public static void Inicializar_593CM(string connectionString, string claveAES = null)
        {
            if (!string.IsNullOrWhiteSpace(connectionString))
                _connectionString_593CM = connectionString;
            if (!string.IsNullOrWhiteSpace(claveAES))
                _claveAES_593CM = claveAES;
        }

        public static string ConnectionString_593CM =>
            _connectionString_593CM
            ?? ConfigurationManager.ConnectionStrings["DIEFER"]?.ConnectionString
            ?? throw new ConfigurationErrorsException("ConnectionString 'DIEFER' no encontrada en App.config ni inicializada.");

        public static string ClaveAES_593CM =>
            _claveAES_593CM
            ?? ConfigurationManager.AppSettings["ClaveAES"]
            ?? throw new ConfigurationErrorsException("ClaveAES no configurada en App.config ni inicializada.");

        public static SqlConnection ObtenerConexion_593CM() =>
            new SqlConnection(ConnectionString_593CM);

        public static void VerificarConexion_593CM()
        {
            using (var conn = ObtenerConexion_593CM())
                conn.Open();
        }
    }
}
