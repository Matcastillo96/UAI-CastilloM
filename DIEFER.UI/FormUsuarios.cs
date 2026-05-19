using System;
using System.Collections.Generic;
using System.Drawing;
using System.Windows.Forms;
using DIEFER.BE;
using DIEFER.BLL;
using DIEFER.DAL;

namespace DIEFER.UI
{
    public partial class FormUsuarios_593CM : Form
    {
        private enum Modo_593CM { Consulta, Anadir, Modificar, Eliminar, Desbloquear }

        private readonly UsuarioController_593CM _ctrl_593CM;
        private Modo_593CM   _modoActual_593CM   = Modo_593CM.Consulta;
        private string       _dniSeleccionado_593CM;
        private List<Usuario_593CM> _listaActual_593CM = new List<Usuario_593CM>();

        public FormUsuarios_593CM(string modoInicial = null)
        {
            InitializeComponent();
            var usuarioDB  = new UsuarioDB_593CM();
            var eventoDB   = new EventoDAL_593CM();
            var eventoBLL  = new EventoBLL_593CM(eventoDB, usuarioDB);
            _ctrl_593CM    = new UsuarioController_593CM(usuarioDB, eventoBLL);

            cboRol_593CM.Items.AddRange(Catalogos_593CM.Roles_593CM);

            CargarGrilla_593CM();
            EstablecerModo_593CM(Modo_593CM.Consulta);

            if (modoInicial == "Crear")           EstablecerModo_593CM(Modo_593CM.Anadir);
            else if (modoInicial == "Desbloquear") EstablecerModo_593CM(Modo_593CM.Desbloquear);
        }

        // ── Carga de datos ──────────────────────────────────────────────────────────────

        private void CargarGrilla_593CM(string fDNI = null, string fApe = null, string fNom = null,
                                        string fEmail = null, string fRol = null, string fLogin = null)
        {
            bool soloActivos   = rbActivos_593CM.Checked;
            _listaActual_593CM = _ctrl_593CM.Listar_593CM(soloActivos, fDNI, fApe, fNom, fEmail, fRol, fLogin);

            dgvUsuarios_593CM.Rows.Clear();
            foreach (var u in _listaActual_593CM)
            {
                int idx = dgvUsuarios_593CM.Rows.Add(
                    u.DNI_593CM, u.Apellidos_593CM, u.Nombre_593CM, u.Login_593CM, u.Rol_593CM);
                if (!u.Activo_593CM)
                    dgvUsuarios_593CM.Rows[idx].DefaultCellStyle.BackColor = Color.LightCoral;
            }

            lblNumUsuarios_593CM.Text = $"Número de Usuarios: {_listaActual_593CM.Count}";
            _dniSeleccionado_593CM    = null;
            LimpiarDetalle_593CM();
        }

        private void dgvUsuarios_SelectionChanged_593CM(object sender, EventArgs e)
        {
            if (dgvUsuarios_593CM.CurrentRow == null) return;
            _dniSeleccionado_593CM = dgvUsuarios_593CM.CurrentRow.Cells[0].Value?.ToString();

            if (_modoActual_593CM == Modo_593CM.Consulta  ||
                _modoActual_593CM == Modo_593CM.Modificar ||
                _modoActual_593CM == Modo_593CM.Eliminar  ||
                _modoActual_593CM == Modo_593CM.Desbloquear)
            {
                var u = _ctrl_593CM.GetByDNI_593CM(_dniSeleccionado_593CM);
                if (u != null) CargarDetalle_593CM(u);
            }
        }

        private void CargarDetalle_593CM(Usuario_593CM u)
        {
            txtDNI_593CM.Text       = u.DNI_593CM;
            txtApellidos_593CM.Text = u.Apellidos_593CM;
            txtNombre_593CM.Text    = u.Nombre_593CM;
            txtEmail_593CM.Text     = u.Email_593CM;
            cboRol_593CM.Text       = u.Rol_593CM;
            txtLogin_593CM.Text     = u.Login_593CM;
            txtBloqueado_593CM.Text = u.Bloqueado_593CM ? "Sí" : "No";
            txtActivo_593CM.Text    = u.Activo_593CM    ? "Sí" : "No";
        }

        private void LimpiarDetalle_593CM()
        {
            txtDNI_593CM.Clear(); txtApellidos_593CM.Clear(); txtNombre_593CM.Clear();
            txtEmail_593CM.Clear(); cboRol_593CM.Text = string.Empty;
            txtLogin_593CM.Clear(); txtBloqueado_593CM.Clear(); txtActivo_593CM.Clear();
        }

        // ── Cambio de modo ──────────────────────────────────────────────────────────────

        private void EstablecerModo_593CM(Modo_593CM modo)
        {
            _modoActual_593CM = modo;
            bool esConsulta    = modo == Modo_593CM.Consulta;
            bool esEdicion     = modo == Modo_593CM.Anadir || modo == Modo_593CM.Modificar;
            bool esDesbloquear = modo == Modo_593CM.Desbloquear;

            switch (modo)
            {
                case Modo_593CM.Consulta:    lblMensaje_593CM.Text = "Modo Consulta";    break;
                case Modo_593CM.Anadir:      lblMensaje_593CM.Text = "Modo Añadir";      break;
                case Modo_593CM.Modificar:   lblMensaje_593CM.Text = "Modo Modificar";   break;
                case Modo_593CM.Eliminar:    lblMensaje_593CM.Text = "Modo Eliminar";    break;
                case Modo_593CM.Desbloquear: lblMensaje_593CM.Text = "Modo Desbloquear"; break;
            }

            btnCrear_593CM.Enabled       = esConsulta;
            btnDesbloquear_593CM.Enabled = esConsulta;
            btnModificar_593CM.Enabled   = esConsulta;
            btnActDesact_593CM.Enabled   = esConsulta;

            btnAplicar_593CM.Enabled  = true;
            btnCancelar_593CM.Enabled = !esConsulta;
            btnSalir_593CM.Enabled    = esConsulta;

            bool detalleEditable      = esEdicion;
            txtDNI_593CM.ReadOnly     = !modo.Equals(Modo_593CM.Anadir);
            txtApellidos_593CM.ReadOnly = !detalleEditable;
            txtNombre_593CM.ReadOnly    = !detalleEditable;
            txtEmail_593CM.ReadOnly     = !detalleEditable;
            cboRol_593CM.Enabled        = detalleEditable;
            pnlDetalle_593CM.Enabled    = !esDesbloquear;

            rbActivos_593CM.Enabled = esConsulta;
            rbTodos_593CM.Enabled   = esConsulta;

            if (modo == Modo_593CM.Anadir)
            {
                LimpiarDetalle_593CM();
                txtDNI_593CM.Focus();
            }
            else if (modo == Modo_593CM.Desbloquear)
            {
                CargarGrilla_593CM();
            }
        }

        // ── Botones principales ─────────────────────────────────────────────────────────

        private void btnCrear_Click_593CM(object sender, EventArgs e)      => EstablecerModo_593CM(Modo_593CM.Anadir);
        private void btnDesbloquear_Click_593CM(object sender, EventArgs e) => EstablecerModo_593CM(Modo_593CM.Desbloquear);

        private void btnModificar_Click_593CM(object sender, EventArgs e)
        {
            if (_dniSeleccionado_593CM == null) { MostrarInfo_593CM("Seleccione un usuario de la grilla."); return; }
            EstablecerModo_593CM(Modo_593CM.Modificar);
        }

        private void btnActDesact_Click_593CM(object sender, EventArgs e)
        {
            if (_dniSeleccionado_593CM == null) { MostrarInfo_593CM("Seleccione un usuario de la grilla."); return; }
            EstablecerModo_593CM(Modo_593CM.Eliminar);
        }

        private void btnCancelar_Click_593CM(object sender, EventArgs e)
        {
            EstablecerModo_593CM(Modo_593CM.Consulta);
            CargarGrilla_593CM();
        }

        private void btnSalir_Click_593CM(object sender, EventArgs e) => Close();

        // ── Aplicar (según modo) ────────────────────────────────────────────────────────

        private void btnAplicar_Click_593CM(object sender, EventArgs e)
        {
            switch (_modoActual_593CM)
            {
                case Modo_593CM.Consulta:    EjecutarConsulta_593CM();    break;
                case Modo_593CM.Anadir:      EjecutarCrear_593CM();       break;
                case Modo_593CM.Modificar:   EjecutarModificar_593CM();   break;
                case Modo_593CM.Eliminar:    EjecutarActDesact_593CM();   break;
                case Modo_593CM.Desbloquear: EjecutarDesbloquear_593CM(); break;
            }
        }

        private void EjecutarConsulta_593CM()
        {
            CargarGrilla_593CM(
                NullIfEmpty_593CM(txtDNI_593CM.Text),
                NullIfEmpty_593CM(txtApellidos_593CM.Text),
                NullIfEmpty_593CM(txtNombre_593CM.Text),
                NullIfEmpty_593CM(txtEmail_593CM.Text),
                NullIfEmpty_593CM(cboRol_593CM.Text),
                NullIfEmpty_593CM(txtLogin_593CM.Text));
        }

        private void EjecutarCrear_593CM()
        {
            if (!string.IsNullOrWhiteSpace(txtNombre_593CM.Text) &&
                !string.IsNullOrWhiteSpace(txtApellidos_593CM.Text))
                txtLogin_593CM.Text = $"{txtNombre_593CM.Text.Trim()}.{txtApellidos_593CM.Text.Trim()}";

            var res = _ctrl_593CM.Crear_593CM(
                txtDNI_593CM.Text, txtApellidos_593CM.Text, txtNombre_593CM.Text,
                txtEmail_593CM.Text, cboRol_593CM.Text);

            switch (res)
            {
                case UsuarioController_593CM.ResultadoCrear_593CM.Exitoso:
                    MostrarInfo_593CM("Usuario creado exitosamente.");
                    EstablecerModo_593CM(Modo_593CM.Consulta);
                    CargarGrilla_593CM();
                    break;
                case UsuarioController_593CM.ResultadoCrear_593CM.DNIExistente:
                    MostrarError_593CM("El DNI ya está registrado.");               break;
                case UsuarioController_593CM.ResultadoCrear_593CM.LoginExistente:
                    MostrarError_593CM("El Login generado ya existe en el sistema."); break;
                case UsuarioController_593CM.ResultadoCrear_593CM.CamposRequeridos:
                    MostrarError_593CM("Complete todos los campos requeridos.");      break;
                case UsuarioController_593CM.ResultadoCrear_593CM.EmailInvalido:
                    MostrarError_593CM("El formato del Email no es válido.");         break;
            }
        }

        private void EjecutarModificar_593CM()
        {
            var res = _ctrl_593CM.Modificar_593CM(
                _dniSeleccionado_593CM, txtApellidos_593CM.Text,
                txtNombre_593CM.Text, txtEmail_593CM.Text, cboRol_593CM.Text);

            switch (res)
            {
                case UsuarioController_593CM.ResultadoModificar_593CM.Exitoso:
                    MostrarInfo_593CM("Modificado correctamente.");
                    EstablecerModo_593CM(Modo_593CM.Consulta);
                    CargarGrilla_593CM();
                    break;
                case UsuarioController_593CM.ResultadoModificar_593CM.CamposRequeridos:
                    MostrarError_593CM("Complete todos los campos requeridos."); break;
                case UsuarioController_593CM.ResultadoModificar_593CM.EmailInvalido:
                    MostrarError_593CM("El formato del Email no es válido.");    break;
                case UsuarioController_593CM.ResultadoModificar_593CM.LoginExistente:
                    MostrarError_593CM("El Login ya existe en otro usuario.");   break;
            }
        }

        private void EjecutarActDesact_593CM()
        {
            if (_dniSeleccionado_593CM == null) { MostrarError_593CM("Seleccione un usuario."); return; }
            var u = _ctrl_593CM.GetByDNI_593CM(_dniSeleccionado_593CM);
            if (u == null) return;

            bool activar  = !u.Activo_593CM;
            string accion = activar ? "activar" : "desactivar";
            var confirm   = MessageBox.Show($"¿Desea {accion} al usuario {u.Login_593CM}?",
                "Confirmación", MessageBoxButtons.YesNo, MessageBoxIcon.Question);
            if (confirm != DialogResult.Yes) return;

            var res = _ctrl_593CM.CambiarEstado_593CM(_dniSeleccionado_593CM, activar);
            if (res == UsuarioController_593CM.ResultadoCambiarEstado_593CM.NoPermitido)
                MostrarError_593CM("No puede desactivar su propia cuenta.");
            else
            {
                MostrarInfo_593CM($"Usuario {(activar ? "activado" : "desactivado")} correctamente.");
                EstablecerModo_593CM(Modo_593CM.Consulta);
                CargarGrilla_593CM();
            }
        }

        private void EjecutarDesbloquear_593CM()
        {
            if (_dniSeleccionado_593CM == null) { MostrarError_593CM("Seleccione un usuario bloqueado."); return; }
            bool ok = _ctrl_593CM.Desbloquear_593CM(_dniSeleccionado_593CM);
            if (ok)
            {
                MostrarInfo_593CM("Usuario desbloqueado exitosamente.");
                EstablecerModo_593CM(Modo_593CM.Consulta);
                CargarGrilla_593CM();
            }
            else
                MostrarError_593CM("No se pudo desbloquear el usuario.");
        }

        // ── Cambio de filtro Activos/Todos ──────────────────────────────────────────────

        private void rbActivos_CheckedChanged_593CM(object sender, EventArgs e) => CargarGrilla_593CM();
        private void rbTodos_CheckedChanged_593CM(object sender, EventArgs e)   => CargarGrilla_593CM();

        // ── Auto-generar Login al editar Nombre/Apellido ────────────────────────────────

        private void txtNombreApellido_TextChanged_593CM(object sender, EventArgs e)
        {
            if (_modoActual_593CM == Modo_593CM.Anadir || _modoActual_593CM == Modo_593CM.Modificar)
                if (!string.IsNullOrWhiteSpace(txtNombre_593CM.Text) &&
                    !string.IsNullOrWhiteSpace(txtApellidos_593CM.Text))
                    txtLogin_593CM.Text = $"{txtNombre_593CM.Text.Trim()}.{txtApellidos_593CM.Text.Trim()}";
        }

        // ── Helpers ─────────────────────────────────────────────────────────────────────

        private void MostrarInfo_593CM(string msg)
        {
            lblMensaje_593CM.ForeColor = Color.DarkGreen;
            lblMensaje_593CM.Text      = msg;
        }

        private void MostrarError_593CM(string msg)
        {
            lblMensaje_593CM.ForeColor = Color.DarkRed;
            lblMensaje_593CM.Text      = msg;
        }

        private static string NullIfEmpty_593CM(string s) =>
            string.IsNullOrWhiteSpace(s) ? null : s.Trim();
    }
}
