using System;
using System.Windows.Forms;

namespace DIEFER.UI
{
    // Punto de entrada de la aplicación DIEFER.
    static class Program_593CM
    {
        [STAThread]
        static void Main()
        {
            try
            {
                Application.EnableVisualStyles();
                Application.SetCompatibleTextRenderingDefault(false);
                Application.Run(new FormLogin_593CM());
            }
            catch (Exception ex)
            {
                MessageBox.Show(
                    "Error al iniciar la aplicación:\n\n" + ex.Message,
                    "Error",
                    MessageBoxButtons.OK,
                    MessageBoxIcon.Error);
            }
        }
    }
}