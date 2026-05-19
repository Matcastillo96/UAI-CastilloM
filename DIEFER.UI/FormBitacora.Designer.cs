namespace DIEFER.UI
{
    partial class FormBitacora_593CM
    {
        private System.ComponentModel.IContainer components_593CM = null;

        protected override void Dispose(bool disposing)
        {
            if (disposing && components_593CM != null) components_593CM.Dispose();
            base.Dispose(disposing);
        }

        private void InitializeComponent()
        {
            this.lblTitulo_593CM       = new System.Windows.Forms.Label();
            this.dgvEventos_593CM      = new System.Windows.Forms.DataGridView();
            this.colLogin_593CM        = new System.Windows.Forms.DataGridViewTextBoxColumn();
            this.colFecha_593CM        = new System.Windows.Forms.DataGridViewTextBoxColumn();
            this.colHora_593CM         = new System.Windows.Forms.DataGridViewTextBoxColumn();
            this.colModulo_593CM       = new System.Windows.Forms.DataGridViewTextBoxColumn();
            this.colEvento_593CM       = new System.Windows.Forms.DataGridViewTextBoxColumn();
            this.colCriticidad_593CM   = new System.Windows.Forms.DataGridViewTextBoxColumn();
            this.lblNombreLabel_593CM  = new System.Windows.Forms.Label();
            this.txtNombre_593CM       = new System.Windows.Forms.TextBox();
            this.lblApellidoLabel_593CM= new System.Windows.Forms.Label();
            this.txtApellido_593CM     = new System.Windows.Forms.TextBox();
            this.lblLoginFiltro_593CM  = new System.Windows.Forms.Label();
            this.txtFiltroLogin_593CM  = new System.Windows.Forms.TextBox();
            this.lblFechaIni_593CM     = new System.Windows.Forms.Label();
            this.dtpFechaIni_593CM     = new System.Windows.Forms.DateTimePicker();
            this.lblFechaFin_593CM     = new System.Windows.Forms.Label();
            this.dtpFechaFin_593CM     = new System.Windows.Forms.DateTimePicker();
            this.lblModulo_593CM       = new System.Windows.Forms.Label();
            this.cboModulo_593CM       = new System.Windows.Forms.ComboBox();
            this.lblEvento_593CM       = new System.Windows.Forms.Label();
            this.cboEvento_593CM       = new System.Windows.Forms.ComboBox();
            this.lblCriticidad_593CM   = new System.Windows.Forms.Label();
            this.cboCriticidad_593CM   = new System.Windows.Forms.ComboBox();
            this.btnLimpiar_593CM      = new System.Windows.Forms.Button();
            this.btnAplicar_593CM      = new System.Windows.Forms.Button();
            this.btnImprimir_593CM     = new System.Windows.Forms.Button();
            this.btnSalir_593CM        = new System.Windows.Forms.Button();
            this.lblEstado_593CM       = new System.Windows.Forms.Label();

            ((System.ComponentModel.ISupportInitialize)this.dgvEventos_593CM).BeginInit();
            this.SuspendLayout();

            // lblTitulo_593CM
            this.lblTitulo_593CM.Font      = new System.Drawing.Font("Arial", 12, System.Drawing.FontStyle.Bold);
            this.lblTitulo_593CM.ForeColor = System.Drawing.Color.FromArgb(0, 70, 127);
            this.lblTitulo_593CM.Location  = new System.Drawing.Point(12, 12);
            this.lblTitulo_593CM.Size      = new System.Drawing.Size(400, 25);
            this.lblTitulo_593CM.Text      = "BITÁCORA DE EVENTOS";

            // btnSalir_593CM (arriba derecha)
            this.btnSalir_593CM.Location = new System.Drawing.Point(870, 10);
            this.btnSalir_593CM.Size     = new System.Drawing.Size(80, 28);
            this.btnSalir_593CM.Text     = "SALIR";
            this.btnSalir_593CM.Click   += new System.EventHandler(this.btnSalir_Click_593CM);

            // dgvEventos_593CM
            this.dgvEventos_593CM.AllowUserToAddRows    = false;
            this.dgvEventos_593CM.AllowUserToDeleteRows = false;
            this.dgvEventos_593CM.AutoSizeColumnsMode   = System.Windows.Forms.DataGridViewAutoSizeColumnsMode.Fill;
            this.dgvEventos_593CM.ColumnHeadersHeightSizeMode = System.Windows.Forms.DataGridViewColumnHeadersHeightSizeMode.AutoSize;
            this.dgvEventos_593CM.Columns.AddRange(new System.Windows.Forms.DataGridViewColumn[] {
                this.colLogin_593CM, this.colFecha_593CM, this.colHora_593CM,
                this.colModulo_593CM, this.colEvento_593CM, this.colCriticidad_593CM
            });
            this.dgvEventos_593CM.Location         = new System.Drawing.Point(12, 45);
            this.dgvEventos_593CM.MultiSelect       = false;
            this.dgvEventos_593CM.ReadOnly          = true;
            this.dgvEventos_593CM.SelectionMode     = System.Windows.Forms.DataGridViewSelectionMode.FullRowSelect;
            this.dgvEventos_593CM.Size              = new System.Drawing.Size(938, 260);
            this.dgvEventos_593CM.SelectionChanged += new System.EventHandler(this.dgvEventos_SelectionChanged_593CM);

            this.colLogin_593CM.HeaderText      = "Login";   this.colLogin_593CM.FillWeight      = 90;
            this.colFecha_593CM.HeaderText      = "Fecha";   this.colFecha_593CM.FillWeight      = 80;
            this.colHora_593CM.HeaderText       = "Hora";    this.colHora_593CM.FillWeight       = 60;
            this.colModulo_593CM.HeaderText     = "Módulo";  this.colModulo_593CM.FillWeight     = 80;
            this.colEvento_593CM.HeaderText     = "Evento";  this.colEvento_593CM.FillWeight     = 180;
            this.colCriticidad_593CM.HeaderText = "Crit.";   this.colCriticidad_593CM.FillWeight = 40;

            // Nombre / Apellido al seleccionar
            this.lblNombreLabel_593CM.Text     = "Nombre:";
            this.lblNombreLabel_593CM.Location = new System.Drawing.Point(12, 315);
            this.lblNombreLabel_593CM.Size     = new System.Drawing.Size(60, 22);

            this.txtNombre_593CM.Location  = new System.Drawing.Point(75, 313);
            this.txtNombre_593CM.Size      = new System.Drawing.Size(180, 22);
            this.txtNombre_593CM.ReadOnly  = true;

            this.lblApellidoLabel_593CM.Text     = "Apellido:";
            this.lblApellidoLabel_593CM.Location = new System.Drawing.Point(270, 315);
            this.lblApellidoLabel_593CM.Size     = new System.Drawing.Size(60, 22);

            this.txtApellido_593CM.Location = new System.Drawing.Point(333, 313);
            this.txtApellido_593CM.Size     = new System.Drawing.Size(180, 22);
            this.txtApellido_593CM.ReadOnly = true;

            // Filtros — fila 1
            int fy = 350;
            this.lblLoginFiltro_593CM.Text     = "LOGIN:";
            this.lblLoginFiltro_593CM.Location = new System.Drawing.Point(12, fy + 2);
            this.lblLoginFiltro_593CM.Size     = new System.Drawing.Size(50, 22);
            this.txtFiltroLogin_593CM.Location = new System.Drawing.Point(65, fy);
            this.txtFiltroLogin_593CM.Size     = new System.Drawing.Size(130, 22);

            this.lblFechaIni_593CM.Text     = "FECHA INI:";
            this.lblFechaIni_593CM.Location = new System.Drawing.Point(210, fy + 2);
            this.lblFechaIni_593CM.Size     = new System.Drawing.Size(70, 22);
            this.dtpFechaIni_593CM.Location = new System.Drawing.Point(283, fy);
            this.dtpFechaIni_593CM.Size     = new System.Drawing.Size(120, 22);
            this.dtpFechaIni_593CM.Format   = System.Windows.Forms.DateTimePickerFormat.Short;

            this.lblFechaFin_593CM.Text     = "FECHA FIN:";
            this.lblFechaFin_593CM.Location = new System.Drawing.Point(415, fy + 2);
            this.lblFechaFin_593CM.Size     = new System.Drawing.Size(70, 22);
            this.dtpFechaFin_593CM.Location = new System.Drawing.Point(488, fy);
            this.dtpFechaFin_593CM.Size     = new System.Drawing.Size(120, 22);
            this.dtpFechaFin_593CM.Format   = System.Windows.Forms.DateTimePickerFormat.Short;

            // Filtros — fila 2
            int fy2 = 385;
            this.lblModulo_593CM.Text     = "MÓDULO:";
            this.lblModulo_593CM.Location = new System.Drawing.Point(12, fy2 + 2);
            this.lblModulo_593CM.Size     = new System.Drawing.Size(60, 22);
            this.cboModulo_593CM.Location = new System.Drawing.Point(75, fy2);
            this.cboModulo_593CM.Size     = new System.Drawing.Size(130, 22);
            this.cboModulo_593CM.DropDownStyle = System.Windows.Forms.ComboBoxStyle.DropDownList;

            this.lblEvento_593CM.Text     = "EVENTO:";
            this.lblEvento_593CM.Location = new System.Drawing.Point(220, fy2 + 2);
            this.lblEvento_593CM.Size     = new System.Drawing.Size(60, 22);
            this.cboEvento_593CM.Location = new System.Drawing.Point(283, fy2);
            this.cboEvento_593CM.Size     = new System.Drawing.Size(250, 22);
            this.cboEvento_593CM.DropDownStyle = System.Windows.Forms.ComboBoxStyle.DropDownList;

            this.lblCriticidad_593CM.Text     = "CRITICIDAD:";
            this.lblCriticidad_593CM.Location = new System.Drawing.Point(545, fy2 + 2);
            this.lblCriticidad_593CM.Size     = new System.Drawing.Size(70, 22);
            this.cboCriticidad_593CM.Location = new System.Drawing.Point(618, fy2);
            this.cboCriticidad_593CM.Size     = new System.Drawing.Size(60, 22);
            this.cboCriticidad_593CM.DropDownStyle = System.Windows.Forms.ComboBoxStyle.DropDownList;

            // lblEstado_593CM
            this.lblEstado_593CM.Location  = new System.Drawing.Point(12, 420);
            this.lblEstado_593CM.Size      = new System.Drawing.Size(700, 20);
            this.lblEstado_593CM.ForeColor = System.Drawing.Color.DimGray;

            // Botones
            this.btnLimpiar_593CM.Location  = new System.Drawing.Point(200, 450);
            this.btnLimpiar_593CM.Size      = new System.Drawing.Size(100, 34);
            this.btnLimpiar_593CM.Text      = "LIMPIAR";
            this.btnLimpiar_593CM.Click    += new System.EventHandler(this.btnLimpiar_Click_593CM);

            this.btnAplicar_593CM.Location  = new System.Drawing.Point(340, 450);
            this.btnAplicar_593CM.Size      = new System.Drawing.Size(100, 34);
            this.btnAplicar_593CM.Text      = "APLICAR";
            this.btnAplicar_593CM.Font      = new System.Drawing.Font("Arial", 9, System.Drawing.FontStyle.Bold);
            this.btnAplicar_593CM.Click    += new System.EventHandler(this.btnAplicar_Click_593CM);

            this.btnImprimir_593CM.Location = new System.Drawing.Point(480, 450);
            this.btnImprimir_593CM.Size     = new System.Drawing.Size(100, 34);
            this.btnImprimir_593CM.Text     = "IMPRIMIR";
            this.btnImprimir_593CM.Click   += new System.EventHandler(this.btnImprimir_Click_593CM);

            // Form
            this.AutoScaleDimensions = new System.Drawing.SizeF(6F, 13F);
            this.AutoScaleMode       = System.Windows.Forms.AutoScaleMode.Font;
            this.ClientSize          = new System.Drawing.Size(962, 500);
            this.Controls.AddRange(new System.Windows.Forms.Control[] {
                this.lblTitulo_593CM, this.btnSalir_593CM, this.dgvEventos_593CM,
                this.lblNombreLabel_593CM, this.txtNombre_593CM,
                this.lblApellidoLabel_593CM, this.txtApellido_593CM,
                this.lblLoginFiltro_593CM, this.txtFiltroLogin_593CM,
                this.lblFechaIni_593CM, this.dtpFechaIni_593CM,
                this.lblFechaFin_593CM, this.dtpFechaFin_593CM,
                this.lblModulo_593CM, this.cboModulo_593CM,
                this.lblEvento_593CM, this.cboEvento_593CM,
                this.lblCriticidad_593CM, this.cboCriticidad_593CM,
                this.lblEstado_593CM,
                this.btnLimpiar_593CM, this.btnAplicar_593CM, this.btnImprimir_593CM
            });
            this.MinimumSize     = new System.Drawing.Size(980, 540);
            this.Name            = "FormBitacora_593CM";
            this.StartPosition   = System.Windows.Forms.FormStartPosition.CenterParent;
            this.Text            = "BITÁCORA DE EVENTOS";

            ((System.ComponentModel.ISupportInitialize)this.dgvEventos_593CM).EndInit();
            this.ResumeLayout(false);
        }

        private System.Windows.Forms.Label                    lblTitulo_593CM;
        private System.Windows.Forms.DataGridView             dgvEventos_593CM;
        private System.Windows.Forms.DataGridViewTextBoxColumn colLogin_593CM;
        private System.Windows.Forms.DataGridViewTextBoxColumn colFecha_593CM;
        private System.Windows.Forms.DataGridViewTextBoxColumn colHora_593CM;
        private System.Windows.Forms.DataGridViewTextBoxColumn colModulo_593CM;
        private System.Windows.Forms.DataGridViewTextBoxColumn colEvento_593CM;
        private System.Windows.Forms.DataGridViewTextBoxColumn colCriticidad_593CM;
        private System.Windows.Forms.Label                    lblNombreLabel_593CM;
        private System.Windows.Forms.TextBox                  txtNombre_593CM;
        private System.Windows.Forms.Label                    lblApellidoLabel_593CM;
        private System.Windows.Forms.TextBox                  txtApellido_593CM;
        private System.Windows.Forms.Label                    lblLoginFiltro_593CM;
        private System.Windows.Forms.TextBox                  txtFiltroLogin_593CM;
        private System.Windows.Forms.Label                    lblFechaIni_593CM;
        private System.Windows.Forms.DateTimePicker           dtpFechaIni_593CM;
        private System.Windows.Forms.Label                    lblFechaFin_593CM;
        private System.Windows.Forms.DateTimePicker           dtpFechaFin_593CM;
        private System.Windows.Forms.Label                    lblModulo_593CM;
        private System.Windows.Forms.ComboBox                 cboModulo_593CM;
        private System.Windows.Forms.Label                    lblEvento_593CM;
        private System.Windows.Forms.ComboBox                 cboEvento_593CM;
        private System.Windows.Forms.Label                    lblCriticidad_593CM;
        private System.Windows.Forms.ComboBox                 cboCriticidad_593CM;
        private System.Windows.Forms.Label                    lblEstado_593CM;
        private System.Windows.Forms.Button                   btnLimpiar_593CM;
        private System.Windows.Forms.Button                   btnAplicar_593CM;
        private System.Windows.Forms.Button                   btnImprimir_593CM;
        private System.Windows.Forms.Button                   btnSalir_593CM;
    }
}
