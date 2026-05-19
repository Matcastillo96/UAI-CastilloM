using System.Configuration;
using System.Data.SqlClient;

namespace DIEFER.DAL
{
    // Proveedor de conexiones SQL. Inicializar antes de cualquier operación de base de datos.
    public static class ConexionDB_593CM
    {
        private static string _connectionString_593CM;

        public static void Inicializar_593CM(string connectionString)
        {
            _connectionString_593CM = connectionString;
        }

        public static SqlConnection ObtenerConexion_593CM()
        {
            if (string.IsNullOrEmpty(_connectionString_593CM))
                _connectionString_593CM = ConfigurationManager.ConnectionStrings["DIEFER"]?.ConnectionString
                    ?? throw new ConfigurationErrorsException("ConnectionString 'DIEFER' no encontrada.");

            return new SqlConnection(_connectionString_593CM);
        }
    }
}
