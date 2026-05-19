namespace DIEFER.UI
{
    partial class FormUsuarios_593CM
    {
        private System.ComponentModel.IContainer components = null;

        protected override void Dispose(bool disposing)
        {
            if (disposing && components != null) components.Dispose();
            base.Dispose(disposing);
        }

        private void InitializeComponent()
        {
            this.lblTitulo_593CM      = new System.Windows.Forms.Label();
            this.rbActivos_593CM      = new System.Windows.Forms.RadioButton();
            this.rbTodos_593CM        = new System.Windows.Forms.RadioButton();
            this.lblNumUsuarios_593CM = new System.Windows.Forms.Label();
            this.dgvUsuarios_593CM    = new System.Windows.Forms.DataGridView();
            this.colDNI_593CM         = new System.Windows.Forms.DataGridViewTextBoxColumn();
            this.colApellidos_593CM   = new System.Windows.Forms.DataGridViewTextBoxColumn();
            this.colNombre_593CM      = new System.Windows.Forms.DataGridViewTextBoxColumn();
            this.colLogin_593CM       = new System.Windows.Forms.DataGridViewTextBoxColumn();
            this.colRol_593CM         = new System.Windows.Forms.DataGridViewTextBoxColumn();
            this.pnlDetalle_593CM     = new System.Windows.Forms.Panel();
            this.lblDNI_593CM         = new System.Windows.Forms.Label();
            this.txtDNI_593CM         = new System.Windows.Forms.TextBox();
            this.lblApellidos_593CM   = new System.Windows.Forms.Label();
            this.txtApellidos_593CM   = new System.Windows.Forms.TextBox();
            this.lblNombre_593CM      = new System.Windows.Forms.Label();
            this.txtNombre_593CM      = new System.Windows.Forms.TextBox();
            this.lblEmail_593CM       = new System.Windows.Forms.Label();
            this.txtEmail_593CM       = new System.Windows.Forms.TextBox();
            this.lblRol_593CM         = new System.Windows.Forms.Label();
            this.cboRol_593CM         = new System.Windows.Forms.ComboBox();
            this.lblLogin_593CM       = new System.Windows.Forms.Label();
            this.txtLogin_593CM       = new System.Windows.Forms.TextBox();
            this.lblBloqueado_593CM   = new System.Windows.Forms.Label();
            this.txtBloqueado_593CM   = new System.Windows.Forms.TextBox();
            this.lblActivo_593CM      = new System.Windows.Forms.Label();
            this.txtActivo_593CM      = new System.Windows.Forms.TextBox();
            this.pnlBotones_593CM     = new System.Windows.Forms.Panel();
            this.btnCrear_593CM       = new System.Windows.Forms.Button();
            this.btnDesbloquear_593CM = new System.Windows.Forms.Button();
            this.btnModificar_593CM   = new System.Windows.Forms.Button();
            this.btnActDesact_593CM   = new System.Windows.Forms.Button();
            this.btnAplicar_593CM     = new System.Windows.Forms.Button();
            this.btnCancelar_593CM    = new System.Windows.Forms.Button();
            this.btnSalir_593CM       = new System.Windows.Forms.Button();
            this.pnlMensaje_593CM     = new System.Windows.Forms.Panel();
            this.lblMensaje_593CM     = new System.Windows.Forms.Label();

            ((System.ComponentModel.ISupportInitialize)this.dgvUsuarios_593CM).BeginInit();
            this.pnlDetalle_593CM.SuspendLayout();
            this.pnlBotones_593CM.SuspendLayout();
            this.pnlMensaje_593CM.SuspendLayout();
            this.SuspendLayout();

            // lblTitulo
            this.lblTitulo_593CM.Font      = new System.Drawing.Font("Arial", 12, System.Drawing.FontStyle.Bold);
            this.lblTitulo_593CM.ForeColor = System.Drawing.Color.FromArgb(0, 70, 127);
            this.lblTitulo_593CM.Location  = new System.Drawing.Point(12, 12);
            this.lblTitulo_593CM.Size      = new System.Drawing.Size(200, 25);
            this.lblTitulo_593CM.Text      = "USUARIOS";

            // rbActivos
            this.rbActivos_593CM.Checked  = true;
            this.rbActivos_593CM.Location = new System.Drawing.Point(220, 14);
            this.rbActivos_593CM.Size     = new System.Drawing.Size(70, 20);
            this.rbActivos_593CM.Text     = "Activos";
            this.rbActivos_593CM.CheckedChanged += new System.EventHandler(this.rbActivos_CheckedChanged_593CM);

            // rbTodos
            this.rbTodos_593CM.Location = new System.Drawing.Point(295, 14);
            this.rbTodos_593CM.Size     = new System.Drawing.Size(60, 20);
            this.rbTodos_593CM.Text     = "Todos";
            this.rbTodos_593CM.CheckedChanged += new System.EventHandler(this.rbTodos_CheckedChanged_593CM);

            // lblNumUsuarios
            this.lblNumUsuarios_593CM.Location  = new System.Drawing.Point(580, 14);
            this.lblNumUsuarios_593CM.Size      = new System.Drawing.Size(200, 20);
            this.lblNumUsuarios_593CM.Text      = "Número de Usuarios: 0";
            this.lblNumUsuarios_593CM.TextAlign = System.Drawing.ContentAlignment.MiddleRight;

            // dgvUsuarios
            this.dgvUsuarios_593CM.AllowUserToAddRows    = false;
            this.dgvUsuarios_593CM.AllowUserToDeleteRows = false;
            this.dgvUsuarios_593CM.AutoSizeColumnsMode   = System.Windows.Forms.DataGridViewAutoSizeColumnsMode.Fill;
            this.dgvUsuarios_593CM.ColumnHeadersHeightSizeMode = System.Windows.Forms.DataGridViewColumnHeadersHeightSizeMode.AutoSize;
            this.dgvUsuarios_593CM.Columns.AddRange(new System.Windows.Forms.DataGridViewColumn[] {
                this.colDNI_593CM, this.colApellidos_593CM, this.colNombre_593CM, this.colLogin_593CM, this.colRol_593CM
            });
            this.dgvUsuarios_593CM.Location              = new System.Drawing.Point(12, 42);
            this.dgvUsuarios_593CM.MultiSelect            = false;
            this.dgvUsuarios_593CM.ReadOnly               = true;
            this.dgvUsuarios_593CM.SelectionMode          = System.Windows.Forms.DataGridViewSelectionMode.FullRowSelect;
            this.dgvUsuarios_593CM.Size                   = new System.Drawing.Size(770, 200);
            this.dgvUsuarios_593CM.SelectionChanged      += new System.EventHandler(this.dgvUsuarios_SelectionChanged_593CM);

            this.colDNI_593CM.HeaderText       = "DNI";       this.colDNI_593CM.FillWeight       = 80;
            this.colApellidos_593CM.HeaderText = "Apellidos";  this.colApellidos_593CM.FillWeight = 120;
            this.colNombre_593CM.HeaderText    = "Nombres";    this.colNombre_593CM.FillWeight    = 120;
            this.colLogin_593CM.HeaderText     = "Login";      this.colLogin_593CM.FillWeight     = 120;
            this.colRol_593CM.HeaderText       = "Rol";        this.colRol_593CM.FillWeight       = 80;

            // pnlDetalle
            this.pnlDetalle_593CM.Location = new System.Drawing.Point(12, 252);
            this.pnlDetalle_593CM.Size     = new System.Drawing.Size(770, 220);
            this.pnlDetalle_593CM.Controls.AddRange(new System.Windows.Forms.Control[] {
                this.lblDNI_593CM, this.txtDNI_593CM, this.lblApellidos_593CM, this.txtApellidos_593CM,
                this.lblNombre_593CM, this.txtNombre_593CM, this.lblEmail_593CM, this.txtEmail_593CM,
                this.lblRol_593CM, this.cboRol_593CM, this.lblLogin_593CM, this.txtLogin_593CM,
                this.lblBloqueado_593CM, this.txtBloqueado_593CM, this.lblActivo_593CM, this.txtActivo_593CM
            });

            int lw = 80, tw = 250, lh = 22, gap = 30;
            int col1x = 10, col1tx = 95, col2x = 390, col2tx = 475;

            // Row 1: DNI | Email
            AgregarCampo_593CM(this.lblDNI_593CM, "DNI:", col1x, 10, lw, lh);
            AgregarTextBox_593CM(this.txtDNI_593CM, col1tx, 8, tw, lh + 2);
            AgregarCampo_593CM(this.lblEmail_593CM, "Email:", col2x, 10, lw, lh);
            AgregarTextBox_593CM(this.txtEmail_593CM, col2tx, 8, tw, lh + 2);
            // Row 2: Apellidos | Rol
            AgregarCampo_593CM(this.lblApellidos_593CM, "Apellidos:", col1x, 10 + gap, lw, lh);
            AgregarTextBox_593CM(this.txtApellidos_593CM, col1tx, 8 + gap, tw, lh + 2);
            this.txtApellidos_593CM.TextChanged += new System.EventHandler(this.txtNombreApellido_TextChanged_593CM);
            AgregarCampo_593CM(this.lblRol_593CM, "Rol:", col2x, 10 + gap, lw, lh);
            this.cboRol_593CM.Location = new System.Drawing.Point(col2tx, 8 + gap);
            this.cboRol_593CM.Size     = new System.Drawing.Size(tw, lh + 2);
            this.cboRol_593CM.DropDownStyle = System.Windows.Forms.ComboBoxStyle.DropDownList;
            this.pnlDetalle_593CM.Controls.Add(this.cboRol_593CM);
            // Row 3: Nombre | Login
            AgregarCampo_593CM(this.lblNombre_593CM, "Nombres:", col1x, 10 + gap * 2, lw, lh);
            AgregarTextBox_593CM(this.txtNombre_593CM, col1tx, 8 + gap * 2, tw, lh + 2);
            this.txtNombre_593CM.TextChanged += new System.EventHandler(this.txtNombreApellido_TextChanged_593CM);
            AgregarCampo_593CM(this.lblLogin_593CM, "Login:", col2x, 10 + gap * 2, lw, lh);
            AgregarTextBox_593CM(this.txtLogin_593CM, col2tx, 8 + gap * 2, tw, lh + 2);
            this.txtLogin_593CM.ReadOnly = true;
            // Row 4: Bloqueado | Activo
            AgregarCampo_593CM(this.lblBloqueado_593CM, "Bloqueado:", col1x, 10 + gap * 3, lw, lh);
            AgregarTextBox_593CM(this.txtBloqueado_593CM, col1tx, 8 + gap * 3, 80, lh + 2);
            this.txtBloqueado_593CM.ReadOnly = true;
            AgregarCampo_593CM(this.lblActivo_593CM, "Activo:", col2x, 10 + gap * 3, lw, lh);
            AgregarTextBox_593CM(this.txtActivo_593CM, col2tx, 8 + gap * 3, 80, lh + 2);
            this.txtActivo_593CM.ReadOnly = true;

            // pnlMensaje
            this.pnlMensaje_593CM.BorderStyle = System.Windows.Forms.BorderStyle.FixedSingle;
            this.pnlMensaje_593CM.Location    = new System.Drawing.Point(12, 482);
            this.pnlMensaje_593CM.Size        = new System.Drawing.Size(770, 40);
            this.pnlMensaje_593CM.Controls.Add(this.lblMensaje_593CM);

            this.lblMensaje_593CM.Dock      = System.Windows.Forms.DockStyle.Fill;
            this.lblMensaje_593CM.Font      = new System.Drawing.Font("Arial", 9, System.Drawing.FontStyle.Bold);
            this.lblMensaje_593CM.TextAlign = System.Drawing.ContentAlignment.MiddleLeft;
            this.lblMensaje_593CM.Padding   = new System.Windows.Forms.Padding(5, 0, 0, 0);

            // pnlBotones
            this.pnlBotones_593CM.Location = new System.Drawing.Point(790, 42);
            this.pnlBotones_593CM.Size     = new System.Drawing.Size(130, 480);
            this.pnlBotones_593CM.Controls.AddRange(new System.Windows.Forms.Control[] {
                this.btnCrear_593CM, this.btnDesbloquear_593CM, this.btnModificar_593CM,
                this.btnActDesact_593CM, this.btnAplicar_593CM, this.btnCancelar_593CM, this.btnSalir_593CM
            });

            ConfigBtn_593CM(this.btnCrear_593CM,       "Crear",            0);
            ConfigBtn_593CM(this.btnDesbloquear_593CM, "Desbloquear",     55);
            ConfigBtn_593CM(this.btnModificar_593CM,   "Modificar",       110);
            ConfigBtn_593CM(this.btnActDesact_593CM,   "Act. / Desact.",  165);
            ConfigBtn_593CM(this.btnAplicar_593CM,     "Aplicar",         240);
            ConfigBtn_593CM(this.btnCancelar_593CM,    "Cancelar",        295);
            ConfigBtn_593CM(this.btnSalir_593CM,       "Salir",           370);

            this.btnCrear_593CM.Click       += new System.EventHandler(this.btnCrear_Click_593CM);
            this.btnDesbloquear_593CM.Click += new System.EventHandler(this.btnDesbloquear_Click_593CM);
            this.btnModificar_593CM.Click   += new System.EventHandler(this.btnModificar_Click_593CM);
            this.btnActDesact_593CM.Click   += new System.EventHandler(this.btnActDesact_Click_593CM);
            this.btnAplicar_593CM.Click     += new System.EventHandler(this.btnAplicar_Click_593CM);
            this.btnCancelar_593CM.Click    += new System.EventHandler(this.btnCancelar_Click_593CM);
            this.btnSalir_593CM.Click       += new System.EventHandler(this.btnSalir_Click_593CM);

            // Form
            this.AutoScaleDimensions = new System.Drawing.SizeF(6F, 13F);
            this.AutoScaleMode       = System.Windows.Forms.AutoScaleMode.Font;
            this.ClientSize          = new System.Drawing.Size(940, 540);
            this.Controls.AddRange(new System.Windows.Forms.Control[] {
                this.lblTitulo_593CM, this.rbActivos_593CM, this.rbTodos_593CM, this.lblNumUsuarios_593CM,
                this.dgvUsuarios_593CM, this.pnlDetalle_593CM, this.pnlMensaje_593CM, this.pnlBotones_593CM
            });
            this.MinimumSize     = new System.Drawing.Size(960, 580);
            this.Name            = "FormUsuarios_593CM";
            this.StartPosition   = System.Windows.Forms.FormStartPosition.CenterParent;
            this.Text            = "GESTIÓN DE USUARIOS";

            ((System.ComponentModel.ISupportInitialize)this.dgvUsuarios_593CM).EndInit();
            this.pnlDetalle_593CM.ResumeLayout(false);
            this.pnlBotones_593CM.ResumeLayout(false);
            this.pnlMensaje_593CM.ResumeLayout(false);
            this.ResumeLayout(false);
        }

        private void AgregarCampo_593CM(System.Windows.Forms.Label lbl, string texto, int x, int y, int w, int h)
        {
            lbl.Text      = texto;
            lbl.Location  = new System.Drawing.Point(x, y + 2);
            lbl.Size      = new System.Drawing.Size(w, h);
            lbl.Font      = new System.Drawing.Font("Arial", 9);
            this.pnlDetalle_593CM.Controls.Add(lbl);
        }

        private void AgregarTextBox_593CM(System.Windows.Forms.TextBox txt, int x, int y, int w, int h)
        {
            txt.Location = new System.Drawing.Point(x, y);
            txt.Size     = new System.Drawing.Size(w, h);
            txt.Font     = new System.Drawing.Font("Arial", 9);
            this.pnlDetalle_593CM.Controls.Add(txt);
        }

        private void ConfigBtn_593CM(System.Windows.Forms.Button btn, string texto, int top)
        {
            btn.Text      = texto;
            btn.Location  = new System.Drawing.Point(5, top);
            btn.Size      = new System.Drawing.Size(120, 40);
            btn.Font      = new System.Drawing.Font("Arial", 9);
        }

        private System.Windows.Forms.Label                    lblTitulo_593CM;
        private System.Windows.Forms.RadioButton              rbActivos_593CM;
        private System.Windows.Forms.RadioButton              rbTodos_593CM;
        private System.Windows.Forms.Label                    lblNumUsuarios_593CM;
        private System.Windows.Forms.DataGridView             dgvUsuarios_593CM;
        private System.Windows.Forms.DataGridViewTextBoxColumn colDNI_593CM;
        private System.Windows.Forms.DataGridViewTextBoxColumn colApellidos_593CM;
        private System.Windows.Forms.DataGridViewTextBoxColumn colNombre_593CM;
        private System.Windows.Forms.DataGridViewTextBoxColumn colLogin_593CM;
        private System.Windows.Forms.DataGridViewTextBoxColumn colRol_593CM;
        private System.Windows.Forms.Panel                    pnlDetalle_593CM;
        private System.Windows.Forms.Label                    lblDNI_593CM;
        private System.Windows.Forms.TextBox                  txtDNI_593CM;
        private System.Windows.Forms.Label                    lblApellidos_593CM;
        private System.Windows.Forms.TextBox                  txtApellidos_593CM;
        private System.Windows.Forms.Label                    lblNombre_593CM;
        private System.Windows.Forms.TextBox                  txtNombre_593CM;
        private System.Windows.Forms.Label                    lblEmail_593CM;
        private System.Windows.Forms.TextBox                  txtEmail_593CM;
        private System.Windows.Forms.Label                    lblRol_593CM;
        private System.Windows.Forms.ComboBox                 cboRol_593CM;
        private System.Windows.Forms.Label                    lblLogin_593CM;
        private System.Windows.Forms.TextBox                  txtLogin_593CM;
        private System.Windows.Forms.Label                    lblBloqueado_593CM;
        private System.Windows.Forms.TextBox                  txtBloqueado_593CM;
        private System.Windows.Forms.Label                    lblActivo_593CM;
        private System.Windows.Forms.TextBox                  txtActivo_593CM;
        private System.Windows.Forms.Panel                    pnlBotones_593CM;
        private System.Windows.Forms.Button                   btnCrear_593CM;
        private System.Windows.Forms.Button                   btnDesbloquear_593CM;
        private System.Windows.Forms.Button                   btnModificar_593CM;
        private System.Windows.Forms.Button                   btnActDesact_593CM;
        private System.Windows.Forms.Button                   btnAplicar_593CM;
        private System.Windows.Forms.Button                   btnCancelar_593CM;
        private System.Windows.Forms.Button                   btnSalir_593CM;
        private System.Windows.Forms.Panel                    pnlMensaje_593CM;
        private System.Windows.Forms.Label                    lblMensaje_593CM;
    }
}
