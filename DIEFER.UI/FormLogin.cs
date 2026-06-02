using System;
using System.Windows.Forms;
using DIEFER.BLL;
using DIEFER.DAL;

namespace DIEFER.UI
{
    // Formulario de inicio de sesión — primer punto de contacto del usuario con DIEFER.
    public partial class FormLogin_593CM : Form
    {
        private readonly UsuarioController_593CM _usuarioCtrl_593CM;
        private readonly bool _esModoReLogin_593CM;

        // Constructor para el login inicial al arrancar la app
        public FormLogin_593CM() : this(false) { }

        // Constructor para Re-Login desde el menú (no cierra la app)
        public FormLogin_593CM(bool esModoReLogin)
        {
            InitializeComponent();
            _esModoReLogin_593CM = esModoReLogin;
            var usuarioDB  = new UsuarioDB_593CM();
            var eventoDB   = new EventoDAL_593CM();
            var eventoBLL  = new EventoBLL_593CM(eventoDB, usuarioDB);
            _usuarioCtrl_593CM = new UsuarioController_593CM(usuarioDB, eventoBLL);
        }

        private void btnEntrar_Click_593CM(object sender, EventArgs e)
        {
            string login = txtLogin_593CM.Text.Trim();
            string pass  = txtPassword_593CM.Text;

            if (string.IsNullOrEmpty(login) || string.IsNullOrEmpty(pass))
            {
                MostrarError_593CM("Ingrese Login y Contraseña.");
                return;
            }

            var resultado = _usuarioCtrl_593CM.Autenticar_593CM(login, pass, out var usuario);

            switch (resultado)
            {
                case UsuarioController_593CM.ResultadoLogin_593CM.Exitoso:
                    MostrarError_593CM(string.Empty);
                    if (_esModoReLogin_593CM)
                    {
                        // Re-Login: solo cierra este formulario; el FormPrincipal_593CM ya está abierto
                        DialogResult = DialogResult.OK;
                        Close();
                    }
                    else
                    {
                        var principal = new FormPrincipal_593CM();
                        Hide();
                        principal.FormClosed += (s, args) => Close();
                        principal.Show();
                    }
                    break;

                case UsuarioController_593CM.ResultadoLogin_593CM.Bloqueado:
                    MostrarError_593CM("Cuenta bloqueada por 3 intentos fallidos. Contacte al Administrador.");
                    LimpiarCampos_593CM();
                    break;

                case UsuarioController_593CM.ResultadoLogin_593CM.CuentaNoExistente:
                    MostrarError_593CM("La cuenta ingresada no existe.");
                    LimpiarCampos_593CM();
                    break;

                case UsuarioController_593CM.ResultadoLogin_593CM.CuentaInactivaBloqueada:
                    MostrarError_593CM("Cuenta inactiva o bloqueada. Contacte al Administrador.");
                    LimpiarCampos_593CM();
                    break;

                case UsuarioController_593CM.ResultadoLogin_593CM.ErrorIntegridad:
                    MostrarError_593CM("Error de integridad de datos detectado. Contacte al Administrador.");
                    LimpiarCampos_593CM();
                    break;

                default:
                    MostrarError_593CM("Credenciales incorrectas.");
                    txtPassword_593CM.Clear();
                    txtPassword_593CM.Focus();
                    break;
            }
        }

        private void txtPassword_KeyDown_593CM(object sender, KeyEventArgs e)
        {
            if (e.KeyCode == Keys.Enter)
                btnEntrar_Click_593CM(sender, EventArgs.Empty);
        }

        private void MostrarError_593CM(string mensaje)
        {
            lblError_593CM.Text    = mensaje;
            lblError_593CM.Visible = !string.IsNullOrEmpty(mensaje);
        }

        private void LimpiarCampos_593CM()
        {
            txtLogin_593CM.Clear();
            txtPassword_593CM.Clear();
            txtLogin_593CM.Focus();
        }
    }
}
