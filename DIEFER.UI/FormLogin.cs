using System;
using System.IO;
using System.Windows.Forms;
using DIEFER.BLL;
using DIEFER.Servicios;

namespace DIEFER.UI
{
    public partial class FormLogin_593CM : Form
    {
        private readonly UsuarioBLL_593CM _usuarioCtrl_593CM;
        private readonly bool _esModoReLogin_593CM;

        // Constructor para el login inicial al arrancar la app
        public FormLogin_593CM() : this(false) { }

        // Constructor para Re-Login desde el menú (no cierra la app)
        public FormLogin_593CM(bool esModoReLogin)
        {
            InitializeComponent();

            _esModoReLogin_593CM = esModoReLogin;
            _usuarioCtrl_593CM = new UsuarioBLL_593CM();

            Load += FormLogin_Load_593CM;
        }

        private void FormLogin_Load_593CM(object sender, EventArgs e)
        {
            try
            {
                InicializarIdiomas_593CM();
            }
            catch (Exception ex)
            {
                MessageBox.Show(
                    "No se pudieron cargar los idiomas.\n\n" + ex.Message,
                    "Error",
                    MessageBoxButtons.OK,
                    MessageBoxIcon.Error);

                Close();
            }
        }

        private void InicializarIdiomas_593CM()
        {
            string appDir = AppDomain.CurrentDomain.BaseDirectory;
            string carpetaIdiomas = Path.Combine(appDir, "idiomas");

            IdiomaService_593CM.GetInstancia_593CM()
                .CargarIdiomas_593CM(carpetaIdiomas);
        }

        private void btnEntrar_Click_593CM(object sender, EventArgs e)
        {
            try
            {
                string login = txtLogin_593CM.Text.Trim();
                string pass = txtPassword_593CM.Text;

                if (string.IsNullOrEmpty(login) || string.IsNullOrEmpty(pass))
                {
                    MostrarError_593CM("Ingrese Login y Contraseña.");
                    return;
                }

                var resultado = _usuarioCtrl_593CM.Autenticar_593CM(login, pass, out var usuario);

                switch (resultado)
                {
                    case UsuarioBLL_593CM.ResultadoLogin_593CM.Exitoso:
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

                    case UsuarioBLL_593CM.ResultadoLogin_593CM.Bloqueado:
                        MostrarError_593CM("Cuenta bloqueada por 3 intentos fallidos. Contacte al Administrador.");
                        LimpiarCampos_593CM();
                        break;

                    case UsuarioBLL_593CM.ResultadoLogin_593CM.CuentaNoExistente:
                        MostrarError_593CM("La cuenta ingresada no existe.");
                        LimpiarCampos_593CM();
                        break;

                    case UsuarioBLL_593CM.ResultadoLogin_593CM.CuentaInactivaBloqueada:
                        MostrarError_593CM("Cuenta inactiva o bloqueada. Contacte al Administrador.");
                        LimpiarCampos_593CM();
                        break;

                    case UsuarioBLL_593CM.ResultadoLogin_593CM.ErrorIntegridad:
                        ManejarErrorIntegridad_593CM(usuario);
                        break;

                    default:
                        MostrarError_593CM("Credenciales incorrectas.");
                        txtPassword_593CM.Clear();
                        txtPassword_593CM.Focus();
                        break;
                }
            }
            catch (Exception ex)
            {
                MostrarError_593CM(ex.Message);
                txtPassword_593CM.Clear();
                txtPassword_593CM.Focus();
            }
        }

        private void txtPassword_KeyDown_593CM(object sender, KeyEventArgs e)
        {
            if (e.KeyCode == Keys.Enter)
                btnEntrar_Click_593CM(sender, EventArgs.Empty);
        }

        private void MostrarError_593CM(string mensaje)
        {
            lblError_593CM.Text = mensaje;
            lblError_593CM.Visible = !string.IsNullOrEmpty(mensaje);
        }

        private void LimpiarCampos_593CM()
        {
            txtLogin_593CM.Clear();
            txtPassword_593CM.Clear();
            txtLogin_593CM.Focus();
        }

        private void ManejarErrorIntegridad_593CM(Usuario_593CM usuario)
        {
            var perfilesBLL = new PerfilesBLL_593CM();
            var permisos = perfilesBLL.GetPermisosEfectivosDeRol_593CM(usuario.ID_rol_593CM);

            if (permisos.Contains("INTEGRIDAD_GESTIONAR"))
            {
                var dvBLL = new DVBLL_593CM();
                var afectadas = dvBLL.VerificarIntegridad_593CM();

                using (var form = new FormReparacionDV_593CM(afectadas))
                {
                    form.ShowDialog(this);
                }
            }
            else
            {
                MessageBox.Show(
                    "El sistema no se encuentra disponible. Contacte a un administrador.",
                    "Error de integridad",
                    MessageBoxButtons.OK,
                    MessageBoxIcon.Error);
            }

            LimpiarCampos_593CM();
        }
    }
}