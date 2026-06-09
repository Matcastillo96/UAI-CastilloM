using System;
using System.Collections.Generic;
using System.Windows.Forms;
using DIEFER.BLL;
using DIEFER.Servicios;

namespace DIEFER.UI
{
    // Formulario MDI principal — contenedor de todos los módulos de DIEFER.
    public partial class FormPrincipal_593CM : Form, IIdiomaObserver_593CM
    {
        private readonly UsuarioBLL_593CM  _usuarioCtrl_593CM;
        private readonly PerfilesBLL_593CM _perfilesBLL_593CM;

        public FormPrincipal_593CM()
        {
            InitializeComponent();
            _usuarioCtrl_593CM = new UsuarioBLL_593CM();
            _perfilesBLL_593CM = new PerfilesBLL_593CM();
        }

        protected override void OnLoad(EventArgs e)
        {
            base.OnLoad(e);
            ActualizarFooter_593CM();
            AplicarPermisosPorRol_593CM();
            tmrReloj_593CM.Start();
            IdiomaService_593CM.GetInstancia_593CM().Suscribir_593CM(this);
        }

        protected override void OnFormClosed(FormClosedEventArgs e)
        {
            IdiomaService_593CM.GetInstancia_593CM().Desuscribir_593CM(this);
            base.OnFormClosed(e);
        }

        // ── IIdiomaObserver ─────────────────────────────────────────────────────────

        public void OnIdiomaChanged_593CM(string codigo, Dictionary<string, string> textos)
        {
            if (InvokeRequired) { Invoke(new Action(() => OnIdiomaChanged_593CM(codigo, textos))); return; }

            mnuAdmin_593CM.Text           = Get_593CM(textos, "menu_admin",           "ADMIN");
            mnuAdminUsuarios_593CM.Text   = Get_593CM(textos, "menu_admin_usuarios",  "Usuarios");
            mnuAdminBitacora_593CM.Text   = Get_593CM(textos, "menu_admin_bitacora",  "Bitácora de Eventos");
            mnuAdminPerfiles_593CM.Text   = Get_593CM(textos, "menu_admin_perfiles",  "Perfiles");
            mnuMaestros_593CM.Text        = Get_593CM(textos, "menu_maestros",        "MAESTROS");
            mnuUsuario_593CM.Text         = Get_593CM(textos, "menu_usuario",         "USUARIO");
            mnuReLogin_593CM.Text         = Get_593CM(textos, "menu_relogin",         "Re-Login");
            mnuCambiarClave_593CM.Text    = Get_593CM(textos, "menu_cambiar_clave",   "Cambiar Clave");
            mnuCambiarIdioma_593CM.Text   = Get_593CM(textos, "menu_cambiar_idioma",  "Cambiar Idioma");
            mnuLogout_593CM.Text          = Get_593CM(textos, "menu_logout",          "Logout");
            mnuVentas_593CM.Text          = Get_593CM(textos, "menu_ventas",          "VENTAS");
            mnuCompras_593CM.Text         = Get_593CM(textos, "menu_compras",         "COMPRAS");
            mnuReportes_593CM.Text        = Get_593CM(textos, "menu_reportes",        "REPORTES");
            mnuAyuda_593CM.Text           = Get_593CM(textos, "menu_ayuda",           "AYUDA");

            ActualizarFooter_593CM();
        }

        private static string Get_593CM(Dictionary<string, string> t, string k, string def)
            => t.TryGetValue(k, out var v) ? v : def;

        private void tmrReloj_Tick_593CM(object sender, EventArgs e)
        {
            slFechaHora_593CM.Text = DateTime.Now.ToString("dd/MM/yyyy  HH:mm:ss");
        }

        private void ActualizarFooter_593CM()
        {
            var u   = SessionManager_593CM.GetInstancia_593CM().UsuarioActual_593CM;
            var svc = IdiomaService_593CM.GetInstancia_593CM();
            if (u != null)
            {
                slUsuario_593CM.Text = $"{svc.ObtenerTexto_593CM("sl_usuario", "Usuario:")} {u.Login_593CM}";
                slRol_593CM.Text     = $"{svc.ObtenerTexto_593CM("sl_rol", "Rol:")} {u.Rol_593CM}";
            }
        }

        private void AplicarPermisosPorRol_593CM()
        {
            var u = SessionManager_593CM.GetInstancia_593CM().UsuarioActual_593CM;
            if (u == null) return;

            // Consume los permisos definidos en la DB para el rol del usuario.
            var permisos = _perfilesBLL_593CM.GetPermisosEfectivosDeRol_593CM(u.ID_rol_593CM);

            mnuAdminUsuarios_593CM.Enabled = permisos.Contains("admin.usuarios");
            mnuAdminBitacora_593CM.Enabled = permisos.Contains("admin.bitacora");
            mnuAdminPerfiles_593CM.Enabled = permisos.Contains("admin.perfiles");
            mnuAdmin_593CM.Visible = mnuAdminUsuarios_593CM.Enabled
                                  || mnuAdminBitacora_593CM.Enabled
                                  || mnuAdminPerfiles_593CM.Enabled;
        }

        // ── ADMIN → Usuarios ────────────────────────────────────────────────────────────

        private void mnuAdminUsuarios_Click_593CM(object sender, EventArgs e)
        {
            var f = new FormUsuarios_593CM();
            f.MdiParent = this;
            f.Show();
        }

        // ── ADMIN → Perfiles ────────────────────────────────────────────────────────────

        private void mnuPerfiles_Click_593CM(object sender, EventArgs e)
        {
            var f = new FormPerfiles_593CM();
            f.MdiParent = this;
            f.Show();
        }

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
            var sesion   = SessionManager_593CM.GetInstancia_593CM();
            string login = sesion.UsuarioActual_593CM?.Login_593CM ?? "(desconocido)";

            var respuesta = MessageBox.Show(
                $"Sesión activa: {login}\n\n¿Desea re-loguearse para aplicar permisos actualizados?",
                "Re-Login — Sesión activa",
                MessageBoxButtons.YesNo,
                MessageBoxIcon.Information);

            if (respuesta != DialogResult.Yes) return;

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

        // ── USUARIO → Cambiar Idioma ────────────────────────────────────────────────────

        private void mnuCambiarIdioma_Click_593CM(object sender, EventArgs e)
        {
            var f = new FormCambiarIdioma_593CM();
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
