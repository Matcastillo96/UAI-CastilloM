using System;
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
        private const string ConnectionStringInterno_593CM =
            @"Data Source=.\SQLEXPRESS;Initial Catalog=DIEFER;Integrated Security=True;Connect Timeout=10;MultipleActiveResultSets=True";

        public static string ConnectionString_593CM
        {
            get
            {
                return ConnectionStringInterno_593CM;
            }
        }


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
