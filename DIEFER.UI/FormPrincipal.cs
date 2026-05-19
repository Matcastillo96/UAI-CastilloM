using System;
using System.Windows.Forms;
using DIEFER.BE;
using DIEFER.BLL;
using DIEFER.DAL;

namespace DIEFER.UI
{
    // Formulario MDI principal — contenedor de todos los módulos de DIEFER.
    public partial class FormPrincipal_593CM : Form
    {
        private readonly UsuarioController_593CM _usuarioCtrl_593CM;
        private readonly EventoBLL_593CM         _eventoBLL_593CM;

        public FormPrincipal_593CM()
        {
            InitializeComponent();
            var usuarioDB  = new UsuarioDB_593CM();
            var eventoDB   = new EventoDAL_593CM();
            _eventoBLL_593CM   = new EventoBLL_593CM(eventoDB, usuarioDB);
            _usuarioCtrl_593CM = new UsuarioController_593CM(usuarioDB, _eventoBLL_593CM);
        }

        protected override void OnLoad(EventArgs e)
        {
            base.OnLoad(e);
            ActualizarFooter_593CM();
            AplicarPermisosPorRol_593CM();
            tmrReloj_593CM.Start();
        }

        private void tmrReloj_Tick_593CM(object sender, EventArgs e)
        {
            slFechaHora_593CM.Text = DateTime.Now.ToString("dd/MM/yyyy  HH:mm:ss");
        }

        private void ActualizarFooter_593CM()
        {
            var u = SessionManager_593CM.GetInstancia_593CM().UsuarioActual_593CM;
            if (u != null)
            {
                slUsuario_593CM.Text = $"Usuario: {u.Login_593CM}";
                slRol_593CM.Text     = $"Rol: {u.Rol_593CM}";
            }
        }

        private void AplicarPermisosPorRol_593CM()
        {
            var u = SessionManager_593CM.GetInstancia_593CM().UsuarioActual_593CM;
            if (u == null) return;

            bool esAdmin = u.Rol_593CM == "Administrador";
            bool puedeAuditoria = Array.IndexOf(Catalogos_593CM.RolesConAuditoria_593CM, u.Rol_593CM) >= 0;

            mnuAdminUsuarios_593CM.Enabled = esAdmin;
            mnuAdminBitacora_593CM.Enabled = puedeAuditoria;
            mnuAdmin_593CM.Visible         = esAdmin || puedeAuditoria;
        }

        // ── ADMIN → Usuarios ────────────────────────────────────────────────────────────

        private void AbrirFormUsuariosEnModo_593CM(string modo)
        {
            var f = new FormUsuarios_593CM(modo);
            f.MdiParent = this;
            f.Show();
        }

        private void mnuCrearUsuario_Click_593CM(object sender, EventArgs e)    => AbrirFormUsuariosEnModo_593CM("Crear");
        private void mnuModificarUsuario_Click_593CM(object sender, EventArgs e) => AbrirFormUsuariosEnModo_593CM("Modificar");
        private void mnuActDesact_Click_593CM(object sender, EventArgs e)        => AbrirFormUsuariosEnModo_593CM("ActDesact");
        private void mnuDesbloquear_Click_593CM(object sender, EventArgs e)      => AbrirFormUsuariosEnModo_593CM("Desbloquear");

        // ── ADMIN → Bitácora ────────────────────────────────────────────────────────────

        private void mnuBitacora_Click_593CM(object sender, EventArgs e)
        {
            var f = new FormBitacora_593CM();
            f.MdiParent = this;
            f.Show();
        }

        // ── USUARIO → Re-Login ──────────────────────────────────────────────────────────

        private void mnuReLogin_Click_593CM(object sender, EventArgs e)
        {
            var f = new FormLogin_593CM(esModoReLogin: true);
            f.ShowDialog(this);
            if (f.DialogResult == DialogResult.OK)
            {
                ActualizarFooter_593CM();
                AplicarPermisosPorRol_593CM();
            }
        }

        // ── USUARIO → Cambiar Clave ─────────────────────────────────────────────────────

        private void mnuCambiarClave_Click_593CM(object sender, EventArgs e)
        {
            var f = new FormCambiarClave_593CM();
            f.ShowDialog(this);
        }

        // ── USUARIO → Logout ────────────────────────────────────────────────────────────

        private void mnuLogout_Click_593CM(object sender, EventArgs e)
        {
            var res = MessageBox.Show("¿Desea cerrar la sesión actual?", "Logout",
                MessageBoxButtons.YesNo, MessageBoxIcon.Question);
            if (res != DialogResult.Yes) return;

            _usuarioCtrl_593CM.Logout_593CM();
            tmrReloj_593CM.Stop();

            var login = new FormLogin_593CM();
            Hide();
            login.FormClosed += (s, args) => Close();
            login.Show();
        }

        protected override void OnFormClosing(FormClosingEventArgs e)
        {
            tmrReloj_593CM.Stop();
            base.OnFormClosing(e);
        }
    }
}
