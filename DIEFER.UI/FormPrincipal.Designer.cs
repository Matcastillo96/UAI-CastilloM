namespace DIEFER.UI
{
    partial class FormPrincipal_593CM
    {
        private System.ComponentModel.IContainer components_593CM = null;

        protected override void Dispose(bool disposing)
        {
            if (disposing && components_593CM != null) components_593CM.Dispose();
            base.Dispose(disposing);
        }

        private void InitializeComponent()
        {
            this.components_593CM = new System.ComponentModel.Container();

            this.msMenu_593CM             = new System.Windows.Forms.MenuStrip();
            this.mnuAdmin_593CM           = new System.Windows.Forms.ToolStripMenuItem();
            this.mnuAdminUsuarios_593CM   = new System.Windows.Forms.ToolStripMenuItem();
            this.mnuAdminBitacora_593CM   = new System.Windows.Forms.ToolStripMenuItem();
            this.mnuMaestros_593CM        = new System.Windows.Forms.ToolStripMenuItem();
            this.mnuUsuario_593CM         = new System.Windows.Forms.ToolStripMenuItem();
            this.mnuReLogin_593CM         = new System.Windows.Forms.ToolStripMenuItem();
            this.mnuCambiarClave_593CM    = new System.Windows.Forms.ToolStripMenuItem();
            this.mnuLogout_593CM          = new System.Windows.Forms.ToolStripMenuItem();
            this.mnuVentas_593CM          = new System.Windows.Forms.ToolStripMenuItem();
            this.mnuCompras_593CM         = new System.Windows.Forms.ToolStripMenuItem();
            this.mnuReportes_593CM        = new System.Windows.Forms.ToolStripMenuItem();
            this.mnuAyuda_593CM           = new System.Windows.Forms.ToolStripMenuItem();
            this.ssEstado_593CM           = new System.Windows.Forms.StatusStrip();
            this.slUsuario_593CM          = new System.Windows.Forms.ToolStripStatusLabel();
            this.slSep1_593CM             = new System.Windows.Forms.ToolStripStatusLabel();
            this.slRol_593CM              = new System.Windows.Forms.ToolStripStatusLabel();
            this.slSep2_593CM             = new System.Windows.Forms.ToolStripStatusLabel();
            this.slFechaHora_593CM        = new System.Windows.Forms.ToolStripStatusLabel();
            this.tmrReloj_593CM           = new System.Windows.Forms.Timer(this.components_593CM);

            this.msMenu_593CM.SuspendLayout();
            this.ssEstado_593CM.SuspendLayout();
            this.SuspendLayout();

            // ── MenuStrip ──────────────────────────────────────────────────────────────

            this.msMenu_593CM.Items.AddRange(new System.Windows.Forms.ToolStripItem[] {
                this.mnuAdmin_593CM, this.mnuMaestros_593CM, this.mnuUsuario_593CM,
                this.mnuVentas_593CM, this.mnuCompras_593CM, this.mnuReportes_593CM, this.mnuAyuda_593CM
            });
            this.msMenu_593CM.Location = new System.Drawing.Point(0, 0);
            this.msMenu_593CM.Name     = "msMenu_593CM";
            this.msMenu_593CM.Size     = new System.Drawing.Size(1024, 24);
            this.msMenu_593CM.Text     = "msMenu_593CM";

            // mnuAdmin_593CM
            this.mnuAdmin_593CM.DropDownItems.AddRange(new System.Windows.Forms.ToolStripItem[] {
                this.mnuAdminUsuarios_593CM, this.mnuAdminBitacora_593CM
            });
            this.mnuAdmin_593CM.Name = "mnuAdmin_593CM";
            this.mnuAdmin_593CM.Text = "ADMIN";

            // mnuAdminUsuarios_593CM — acceso directo al formulario de gestión
            this.mnuAdminUsuarios_593CM.Name   = "mnuAdminUsuarios_593CM";
            this.mnuAdminUsuarios_593CM.Text   = "Usuarios";
            this.mnuAdminUsuarios_593CM.Click += new System.EventHandler(this.mnuAdminUsuarios_Click_593CM);

            // mnuAdminBitacora_593CM
            this.mnuAdminBitacora_593CM.Name   = "mnuAdminBitacora_593CM";
            this.mnuAdminBitacora_593CM.Text   = "Bitácora de Eventos";
            this.mnuAdminBitacora_593CM.Click += new System.EventHandler(this.mnuBitacora_Click_593CM);

            // mnuMaestros_593CM (grisado)
            this.mnuMaestros_593CM.Name    = "mnuMaestros_593CM";
            this.mnuMaestros_593CM.Text    = "MAESTROS";
            this.mnuMaestros_593CM.Enabled = false;

            // mnuUsuario_593CM
            this.mnuUsuario_593CM.DropDownItems.AddRange(new System.Windows.Forms.ToolStripItem[] {
                this.mnuReLogin_593CM, this.mnuCambiarClave_593CM, this.mnuLogout_593CM
            });
            this.mnuUsuario_593CM.Name = "mnuUsuario_593CM";
            this.mnuUsuario_593CM.Text = "USUARIO";

            this.mnuReLogin_593CM.Name    = "mnuReLogin_593CM";
            this.mnuReLogin_593CM.Text    = "Re-Login";
            this.mnuReLogin_593CM.Visible = true;
            this.mnuReLogin_593CM.Click  += new System.EventHandler(this.mnuReLogin_Click_593CM);

            this.mnuCambiarClave_593CM.Name   = "mnuCambiarClave_593CM";
            this.mnuCambiarClave_593CM.Text   = "Cambiar Clave";
            this.mnuCambiarClave_593CM.Click += new System.EventHandler(this.mnuCambiarClave_Click_593CM);

            this.mnuLogout_593CM.Name   = "mnuLogout_593CM";
            this.mnuLogout_593CM.Text   = "Logout";
            this.mnuLogout_593CM.Click += new System.EventHandler(this.mnuLogout_Click_593CM);

            // Módulos grisados (entregas futuras)
            this.mnuVentas_593CM.Name    = "mnuVentas_593CM";
            this.mnuVentas_593CM.Text    = "VENTAS";
            this.mnuVentas_593CM.Enabled = false;

            this.mnuCompras_593CM.Name    = "mnuCompras_593CM";
            this.mnuCompras_593CM.Text    = "COMPRAS";
            this.mnuCompras_593CM.Enabled = false;

            this.mnuReportes_593CM.Name    = "mnuReportes_593CM";
            this.mnuReportes_593CM.Text    = "REPORTES";
            this.mnuReportes_593CM.Enabled = false;

            this.mnuAyuda_593CM.Name    = "mnuAyuda_593CM";
            this.mnuAyuda_593CM.Text    = "AYUDA";
            this.mnuAyuda_593CM.Enabled = false;

            // ── StatusStrip ────────────────────────────────────────────────────────────

            this.ssEstado_593CM.Items.AddRange(new System.Windows.Forms.ToolStripItem[] {
                this.slUsuario_593CM, this.slSep1_593CM, this.slRol_593CM,
                this.slSep2_593CM, this.slFechaHora_593CM
            });
            this.ssEstado_593CM.Location = new System.Drawing.Point(0, 739);
            this.ssEstado_593CM.Name     = "ssEstado_593CM";
            this.ssEstado_593CM.Size     = new System.Drawing.Size(1024, 22);

            this.slUsuario_593CM.Name         = "slUsuario_593CM";
            this.slUsuario_593CM.Text         = "Usuario:";
            this.slUsuario_593CM.BorderSides  = System.Windows.Forms.ToolStripStatusLabelBorderSides.Right;

            this.slSep1_593CM.Name  = "slSep1_593CM";
            this.slSep1_593CM.Text  = "  ";

            this.slRol_593CM.Name        = "slRol_593CM";
            this.slRol_593CM.Text        = "Rol:";
            this.slRol_593CM.BorderSides = System.Windows.Forms.ToolStripStatusLabelBorderSides.Right;

            this.slSep2_593CM.Name  = "slSep2_593CM";
            this.slSep2_593CM.Text  = "  ";

            this.slFechaHora_593CM.Name      = "slFechaHora_593CM";
            this.slFechaHora_593CM.Text      = System.DateTime.Now.ToString("dd/MM/yyyy  HH:mm:ss");
            this.slFechaHora_593CM.Spring    = true;
            this.slFechaHora_593CM.TextAlign = System.Drawing.ContentAlignment.MiddleRight;

            // ── Timer ──────────────────────────────────────────────────────────────────

            this.tmrReloj_593CM.Interval = 1000;
            this.tmrReloj_593CM.Tick    += new System.EventHandler(this.tmrReloj_Tick_593CM);

            // ── FormPrincipal_593CM ────────────────────────────────────────────────────

            this.AutoScaleDimensions = new System.Drawing.SizeF(6F, 13F);
            this.AutoScaleMode       = System.Windows.Forms.AutoScaleMode.Font;
            this.ClientSize          = new System.Drawing.Size(1024, 761);
            this.Controls.Add(this.ssEstado_593CM);
            this.Controls.Add(this.msMenu_593CM);
            this.IsMdiContainer      = true;
            this.MainMenuStrip       = this.msMenu_593CM;
            this.MinimumSize         = new System.Drawing.Size(900, 600);
            this.Name                = "FormPrincipal_593CM";
            this.StartPosition       = System.Windows.Forms.FormStartPosition.CenterScreen;
            this.Text                = "DIEFER — Sistema de Gestión de Taller Mecánico  v1.0";
            this.WindowState         = System.Windows.Forms.FormWindowState.Maximized;

            this.msMenu_593CM.ResumeLayout(false);
            this.msMenu_593CM.PerformLayout();
            this.ssEstado_593CM.ResumeLayout(false);
            this.ssEstado_593CM.PerformLayout();
            this.ResumeLayout(false);
            this.PerformLayout();
        }

        private System.Windows.Forms.MenuStrip             msMenu_593CM;
        private System.Windows.Forms.ToolStripMenuItem     mnuAdmin_593CM;
        private System.Windows.Forms.ToolStripMenuItem     mnuAdminUsuarios_593CM;
        private System.Windows.Forms.ToolStripMenuItem     mnuAdminBitacora_593CM;
        private System.Windows.Forms.ToolStripMenuItem     mnuMaestros_593CM;
        private System.Windows.Forms.ToolStripMenuItem     mnuUsuario_593CM;
        private System.Windows.Forms.ToolStripMenuItem     mnuReLogin_593CM;
        private System.Windows.Forms.ToolStripMenuItem     mnuCambiarClave_593CM;
        private System.Windows.Forms.ToolStripMenuItem     mnuLogout_593CM;
        private System.Windows.Forms.ToolStripMenuItem     mnuVentas_593CM;
        private System.Windows.Forms.ToolStripMenuItem     mnuCompras_593CM;
        private System.Windows.Forms.ToolStripMenuItem     mnuReportes_593CM;
        private System.Windows.Forms.ToolStripMenuItem     mnuAyuda_593CM;
        private System.Windows.Forms.StatusStrip           ssEstado_593CM;
        private System.Windows.Forms.ToolStripStatusLabel  slUsuario_593CM;
        private System.Windows.Forms.ToolStripStatusLabel  slSep1_593CM;
        private System.Windows.Forms.ToolStripStatusLabel  slRol_593CM;
        private System.Windows.Forms.ToolStripStatusLabel  slSep2_593CM;
        private System.Windows.Forms.ToolStripStatusLabel  slFechaHora_593CM;
        private System.Windows.Forms.Timer                 tmrReloj_593CM;
    }
}
