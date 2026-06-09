using System;
using System.Windows.Forms;
using DIEFER.BLL;

namespace DIEFER.UI
{
    // Formulario para que el usuario cambie su propia clave de acceso.
    public partial class FormCambiarClave_593CM : Form
    {
        private readonly UsuarioBLL_593CM _ctrl_593CM;

        public FormCambiarClave_593CM()
        {
            InitializeComponent();
            _ctrl_593CM = new UsuarioBLL_593CM();
        }

        private void btnActualizar_Click_593CM(object sender, EventArgs e)
        {
            var res = _ctrl_593CM.CambiarClave_593CM(
                txtActual_593CM.Text, txtNueva_593CM.Text, txtConfirmar_593CM.Text);
            switch (res)
            {
                case UsuarioBLL_593CM.ResultadoCambiarClave_593CM.Exitoso:
                    MessageBox.Show("Clave actualizada exitosamente.", "Cambiar Clave",
                        MessageBoxButtons.OK, MessageBoxIcon.Information);
                    Close();
                    break;
                case UsuarioBLL_593CM.ResultadoCambiarClave_593CM.ClaveActualIncorrecta:
                    MostrarError_593CM("La clave actual no es correcta.");
                    txtActual_593CM.Clear(); txtActual_593CM.Focus();
                    break;
                case UsuarioBLL_593CM.ResultadoCambiarClave_593CM.ConfirmacionNoCoincide:
                    MostrarError_593CM("La nueva clave y su confirmación no coinciden.");
                    txtNueva_593CM.Clear(); txtConfirmar_593CM.Clear(); txtNueva_593CM.Focus();
                    break;
                case UsuarioBLL_593CM.ResultadoCambiarClave_593CM.NuevaClaveInvalida:
                    MostrarError_593CM("La nueva clave debe tener mínimo 8 caracteres, 1 número y 1 mayúscula.");
                    txtNueva_593CM.Clear(); txtConfirmar_593CM.Clear(); txtNueva_593CM.Focus();
                    break;
            }
        }

        private void btnCancelar_Click_593CM(object sender, EventArgs e) => Close();

        private void MostrarError_593CM(string msg)
        {
            lblError_593CM.Text    = msg;
            lblError_593CM.Visible = true;
        }
    }
}
