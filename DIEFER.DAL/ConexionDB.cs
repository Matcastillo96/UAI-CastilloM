using System;
using System.Configuration;
using System.Data.SqlClient;

namespace DIEFER.DAL
{
    /// <summary>
    /// Proveedor central de conexiones SQL y parámetros de configuración.
    /// Toda la información relacionada con la conexión a la base de datos
    /// queda encapsulada dentro de esta clase.
    /// </summary>
    public static class ConexionDB_593CM
    {
        private static string _connectionString_593CM;
        private static string _claveAES_593CM;

        /// <summary>
        /// Permite inicializar el connection string y la clave AES directamente en la clase,
        /// sin depender exclusivamente de App.config.
        /// </summary>
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

        private static SqlConnection ObtenerConexion_593CM()
        {
            return new SqlConnection(ConnectionString_593CM);
        }

        public static SqlConnection AbrirConexion_593CM()
        {
            try
            {
                SqlConnection conn = ObtenerConexion_593CM();
                conn.Open();
                return conn;
            }
            catch (SqlException ex)
            {
                throw new Exception(
                    "No se pudo conectar a la base de datos.\n\n" +
                    "Servidor: " + ObtenerServidor_593CM() + "\n" +
                    "Error: " + ex.Message,
                    ex);
            }
        }

        private static string ObtenerServidor_593CM()
        {
            try
            {
                var builder = new SqlConnectionStringBuilder(ConnectionString_593CM);
                return builder.DataSource;
            }
            catch
            {
                return "desconocido";
            }
        }
    }
}
