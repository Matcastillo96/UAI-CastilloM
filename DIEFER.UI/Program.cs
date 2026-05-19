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
            // Apuntar |DataDirectory| a la carpeta de la aplicación (donde se crea DIEFER.mdf)
            string appDir = Path.GetDirectoryName(System.Reflection.Assembly.GetExecutingAssembly().Location);
            AppDomain.CurrentDomain.SetData("DataDirectory", appDir);

            // Inicializar conexión y base de datos (crea tablas + admin semilla si no existen)
            ConexionDB_593CM.Inicializar_593CM(ConfigManager_593CM.ConnectionString_593CM);
            DatabaseInitializer_593CM.InicializarBD_593CM();

            Application.EnableVisualStyles();
            Application.SetCompatibleTextRenderingDefault(false);
            Application.Run(new FormLogin_593CM());
        }
    }
}
