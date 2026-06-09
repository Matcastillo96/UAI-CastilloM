using System;
using System.IO;
using System.Windows.Forms;
using DIEFER.DAL;
using DIEFER.Servicios;

namespace DIEFER.UI
{
    // Punto de entrada de la aplicación DIEFER.
    static class Program_593CM
    {
        [STAThread]
        static void Main()
        {
            string appDir = Path.GetDirectoryName(System.Reflection.Assembly.GetExecutingAssembly().Location);
            AppDomain.CurrentDomain.SetData("DataDirectory", appDir);

            IdiomaService_593CM.GetInstancia_593CM()
                .CargarIdiomas_593CM(Path.Combine(appDir, "idiomas"));

            try
            {
                ConexionDB_593CM.VerificarConexion_593CM();
            }
            catch (System.Data.SqlClient.SqlException ex)
            {
                MessageBox.Show(
                    $"No se pudo conectar a la base de datos.\n\n" +
                    $"Servidor: {ObtenerServidor()}\n" +
                    $"Error: {ex.Message}",
                    "Error de conexión",
                    MessageBoxButtons.OK,
                    MessageBoxIcon.Error);
                return;
            }
            catch (Exception ex)
            {
                MessageBox.Show(
                    $"Error al iniciar la aplicación:\n\n{ex.Message}",
                    "Error",
                    MessageBoxButtons.OK,
                    MessageBoxIcon.Error);
                return;
            }

            Application.EnableVisualStyles();
            Application.SetCompatibleTextRenderingDefault(false);
            Application.Run(new FormLogin_593CM());
        }

        private static string ObtenerServidor()
        {
            try
            {
                var builder = new System.Data.SqlClient.SqlConnectionStringBuilder(ConexionDB_593CM.ConnectionString_593CM);
                return builder.DataSource;
            }
            catch { return "desconocido"; }
        }
    }
}
