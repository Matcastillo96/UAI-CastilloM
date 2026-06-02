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
            this.lblTitulo_593CM = new System.Windows.Forms.Label();
            this.rbActivos_593CM = new System.Windows.Forms.RadioButton();
            this.rbTodos_593CM = new System.Windows.Forms.RadioButton();
            this.lblNumUsuarios_593CM = new System.Windows.Forms.Label();
            this.dgvUsuarios_593CM = new System.Windows.Forms.DataGridView();
            this.colDNI_593CM = new System.Windows.Forms.DataGridViewTextBoxColumn();
            this.colApellidos_593CM = new System.Windows.Forms.DataGridViewTextBoxColumn();
            this.colNombre_593CM = new System.Windows.Forms.DataGridViewTextBoxColumn();
            this.colLogin_593CM = new System.Windows.Forms.DataGridViewTextBoxColumn();
            this.colRol_593CM = new System.Windows.Forms.DataGridViewTextBoxColumn();
            this.pnlDetalle_593CM = new System.Windows.Forms.Panel();
            this.lblDNI_593CM = new System.Windows.Forms.Label();
            this.txtDNI_593CM = new System.Windows.Forms.TextBox();
            this.lblApellidos_593CM = new System.Windows.Forms.Label();
            this.txtApellidos_593CM = new System.Windows.Forms.TextBox();
            this.lblNombre_593CM = new System.Windows.Forms.Label();
            this.txtNombre_593CM = new System.Windows.Forms.TextBox();
            this.lblEmail_593CM = new System.Windows.Forms.Label();
            this.txtEmail_593CM = new System.Windows.Forms.TextBox();
            this.lblRol_593CM = new System.Windows.Forms.Label();
            this.cboRol_593CM = new System.Windows.Forms.ComboBox();
            this.lblLogin_593CM = new System.Windows.Forms.Label();
            this.txtLogin_593CM = new System.Windows.Forms.TextBox();
            this.lblBloqueado_593CM = new System.Windows.Forms.Label();
            this.txtBloqueado_593CM = new System.Windows.Forms.TextBox();
            this.lblActivo_593CM = new System.Windows.Forms.Label();
            this.txtActivo_593CM = new System.Windows.Forms.TextBox();
            this.pnlBotones_593CM = new System.Windows.Forms.Panel();
            this.btnCrear_593CM = new System.Windows.Forms.Button();
            this.btnDesbloquear_593CM = new System.Windows.Forms.Button();
            this.btnModificar_593CM = new System.Windows.Forms.Button();
            this.btnActDesact_593CM = new System.Windows.Forms.Button();
            this.btnAplicar_593CM = new System.Windows.Forms.Button();
            this.btnCancelar_593CM = new System.Windows.Forms.Button();
            this.btnSalir_593CM = new System.Windows.Forms.Button();
            this.pnlMensaje_593CM = new System.Windows.Forms.Panel();
            this.lblMensaje_593CM = new System.Windows.Forms.Label();

            ((System.ComponentModel.ISupportInitialize)(this.dgvUsuarios_593CM)).BeginInit();
            this.pnlDetalle_593CM.SuspendLayout();
            this.pnlBotones_593CM.SuspendLayout();
            this.pnlMensaje_593CM.SuspendLayout();
            this.SuspendLayout();

            // 
            // lblTitulo_593CM
            // 
            this.lblTitulo_593CM.Font = new System.Drawing.Font("Arial", 12F, System.Drawing.FontStyle.Bold);
            this.lblTitulo_593CM.ForeColor = System.Drawing.Color.FromArgb(0, 70, 127);
            this.lblTitulo_593CM.Location = new System.Drawing.Point(12, 12);
            this.lblTitulo_593CM.Name = "lblTitulo_593CM";
            this.lblTitulo_593CM.Size = new System.Drawing.Size(200, 25);
            this.lblTitulo_593CM.TabIndex = 0;
            this.lblTitulo_593CM.Text = "USUARIOS";

            // 
            // rbActivos_593CM
            // 
            this.rbActivos_593CM.Checked = true;
            this.rbActivos_593CM.Location = new System.Drawing.Point(220, 14);
            this.rbActivos_593CM.Name = "rbActivos_593CM";
            this.rbActivos_593CM.Size = new System.Drawing.Size(70, 20);
            this.rbActivos_593CM.TabIndex = 1;
            this.rbActivos_593CM.TabStop = true;
            this.rbActivos_593CM.Text = "Activos";
            this.rbActivos_593CM.UseVisualStyleBackColor = true;
            this.rbActivos_593CM.CheckedChanged += new System.EventHandler(this.rbActivos_CheckedChanged_593CM);

            // 
            // rbTodos_593CM
            // 
            this.rbTodos_593CM.Location = new System.Drawing.Point(295, 14);
            this.rbTodos_593CM.Name = "rbTodos_593CM";
            this.rbTodos_593CM.Size = new System.Drawing.Size(60, 20);
            this.rbTodos_593CM.TabIndex = 2;
            this.rbTodos_593CM.Text = "Todos";
            this.rbTodos_593CM.UseVisualStyleBackColor = true;
            this.rbTodos_593CM.CheckedChanged += new System.EventHandler(this.rbTodos_CheckedChanged_593CM);

            // 
            // lblNumUsuarios_593CM
            // 
            this.lblNumUsuarios_593CM.Location = new System.Drawing.Point(580, 14);
            this.lblNumUsuarios_593CM.Name = "lblNumUsuarios_593CM";
            this.lblNumUsuarios_593CM.Size = new System.Drawing.Size(200, 20);
            this.lblNumUsuarios_593CM.TabIndex = 3;
            this.lblNumUsuarios_593CM.Text = "Número de Usuarios: 0";
            this.lblNumUsuarios_593CM.TextAlign = System.Drawing.ContentAlignment.MiddleRight;

            // 
            // dgvUsuarios_593CM
            // 
            this.dgvUsuarios_593CM.AllowUserToAddRows = false;
            this.dgvUsuarios_593CM.AllowUserToDeleteRows = false;
            this.dgvUsuarios_593CM.AutoSizeColumnsMode = System.Windows.Forms.DataGridViewAutoSizeColumnsMode.Fill;
            this.dgvUsuarios_593CM.ColumnHeadersHeightSizeMode = System.Windows.Forms.DataGridViewColumnHeadersHeightSizeMode.AutoSize;
            this.dgvUsuarios_593CM.Columns.AddRange(new System.Windows.Forms.DataGridViewColumn[] {
                this.colDNI_593CM,
                this.colApellidos_593CM,
                this.colNombre_593CM,
                this.colLogin_593CM,
                this.colRol_593CM
            });
            this.dgvUsuarios_593CM.Location = new System.Drawing.Point(12, 42);
            this.dgvUsuarios_593CM.MultiSelect = false;
            this.dgvUsuarios_593CM.Name = "dgvUsuarios_593CM";
            this.dgvUsuarios_593CM.ReadOnly = true;
            this.dgvUsuarios_593CM.SelectionMode = System.Windows.Forms.DataGridViewSelectionMode.FullRowSelect;
            this.dgvUsuarios_593CM.Size = new System.Drawing.Size(770, 200);
            this.dgvUsuarios_593CM.TabIndex = 4;
            this.dgvUsuarios_593CM.SelectionChanged += new System.EventHandler(this.dgvUsuarios_SelectionChanged_593CM);

            // 
            // colDNI_593CM
            // 
            this.colDNI_593CM.FillWeight = 80F;
            this.colDNI_593CM.HeaderText = "DNI";
            this.colDNI_593CM.Name = "colDNI_593CM";
            this.colDNI_593CM.ReadOnly = true;

            // 
            // colApellidos_593CM
            // 
            this.colApellidos_593CM.FillWeight = 120F;
            this.colApellidos_593CM.HeaderText = "Apellidos";
            this.colApellidos_593CM.Name = "colApellidos_593CM";
            this.colApellidos_593CM.ReadOnly = true;

            // 
            // colNombre_593CM
            // 
            this.colNombre_593CM.FillWeight = 120F;
            this.colNombre_593CM.HeaderText = "Nombres";
            this.colNombre_593CM.Name = "colNombre_593CM";
            this.colNombre_593CM.ReadOnly = true;

            // 
            // colLogin_593CM
            // 
            this.colLogin_593CM.FillWeight = 120F;
            this.colLogin_593CM.HeaderText = "Login";
            this.colLogin_593CM.Name = "colLogin_593CM";
            this.colLogin_593CM.ReadOnly = true;

            // 
            // colRol_593CM
            // 
            this.colRol_593CM.FillWeight = 80F;
            this.colRol_593CM.HeaderText = "Rol";
            this.colRol_593CM.Name = "colRol_593CM";
            this.colRol_593CM.ReadOnly = true;

            // 
            // pnlDetalle_593CM
            // 
            this.pnlDetalle_593CM.Controls.Add(this.lblDNI_593CM);
            this.pnlDetalle_593CM.Controls.Add(this.txtDNI_593CM);
            this.pnlDetalle_593CM.Controls.Add(this.lblApellidos_593CM);
            this.pnlDetalle_593CM.Controls.Add(this.txtApellidos_593CM);
            this.pnlDetalle_593CM.Controls.Add(this.lblNombre_593CM);
            this.pnlDetalle_593CM.Controls.Add(this.txtNombre_593CM);
            this.pnlDetalle_593CM.Controls.Add(this.lblEmail_593CM);
            this.pnlDetalle_593CM.Controls.Add(this.txtEmail_593CM);
            this.pnlDetalle_593CM.Controls.Add(this.lblRol_593CM);
            this.pnlDetalle_593CM.Controls.Add(this.cboRol_593CM);
            this.pnlDetalle_593CM.Controls.Add(this.lblLogin_593CM);
            this.pnlDetalle_593CM.Controls.Add(this.txtLogin_593CM);
            this.pnlDetalle_593CM.Controls.Add(this.lblBloqueado_593CM);
            this.pnlDetalle_593CM.Controls.Add(this.txtBloqueado_593CM);
            this.pnlDetalle_593CM.Controls.Add(this.lblActivo_593CM);
            this.pnlDetalle_593CM.Controls.Add(this.txtActivo_593CM);
            this.pnlDetalle_593CM.Location = new System.Drawing.Point(12, 252);
            this.pnlDetalle_593CM.Name = "pnlDetalle_593CM";
            this.pnlDetalle_593CM.Size = new System.Drawing.Size(770, 220);
            this.pnlDetalle_593CM.TabIndex = 5;

            // 
            // lblDNI_593CM
            // 
            this.lblDNI_593CM.Font = new System.Drawing.Font("Arial", 9F);
            this.lblDNI_593CM.Location = new System.Drawing.Point(10, 12);
            this.lblDNI_593CM.Name = "lblDNI_593CM";
            this.lblDNI_593CM.Size = new System.Drawing.Size(80, 22);
            this.lblDNI_593CM.TabIndex = 0;
            this.lblDNI_593CM.Text = "DNI:";

            // 
            // txtDNI_593CM
            // 
            this.txtDNI_593CM.Font = new System.Drawing.Font("Arial", 9F);
            this.txtDNI_593CM.Location = new System.Drawing.Point(95, 8);
            this.txtDNI_593CM.Name = "txtDNI_593CM";
            this.txtDNI_593CM.Size = new System.Drawing.Size(250, 21);
            this.txtDNI_593CM.TabIndex = 1;

            // 
            // lblEmail_593CM
            // 
            this.lblEmail_593CM.Font = new System.Drawing.Font("Arial", 9F);
            this.lblEmail_593CM.Location = new System.Drawing.Point(390, 12);
            this.lblEmail_593CM.Name = "lblEmail_593CM";
            this.lblEmail_593CM.Size = new System.Drawing.Size(80, 22);
            this.lblEmail_593CM.TabIndex = 2;
            this.lblEmail_593CM.Text = "Email:";

            // 
            // txtEmail_593CM
            // 
            this.txtEmail_593CM.Font = new System.Drawing.Font("Arial", 9F);
            this.txtEmail_593CM.Location = new System.Drawing.Point(475, 8);
            this.txtEmail_593CM.Name = "txtEmail_593CM";
            this.txtEmail_593CM.Size = new System.Drawing.Size(250, 21);
            this.txtEmail_593CM.TabIndex = 3;

            // 
            // lblApellidos_593CM
            // 
            this.lblApellidos_593CM.Font = new System.Drawing.Font("Arial", 9F);
            this.lblApellidos_593CM.Location = new System.Drawing.Point(10, 42);
            this.lblApellidos_593CM.Name = "lblApellidos_593CM";
            this.lblApellidos_593CM.Size = new System.Drawing.Size(80, 22);
            this.lblApellidos_593CM.TabIndex = 4;
            this.lblApellidos_593CM.Text = "Apellidos:";

            // 
            // txtApellidos_593CM
            // 
            this.txtApellidos_593CM.Font = new System.Drawing.Font("Arial", 9F);
            this.txtApellidos_593CM.Location = new System.Drawing.Point(95, 38);
            this.txtApellidos_593CM.Name = "txtApellidos_593CM";
            this.txtApellidos_593CM.Size = new System.Drawing.Size(250, 21);
            this.txtApellidos_593CM.TabIndex = 5;
            this.txtApellidos_593CM.TextChanged += new System.EventHandler(this.txtNombreApellido_TextChanged_593CM);

            // 
            // lblRol_593CM
            // 
            this.lblRol_593CM.Font = new System.Drawing.Font("Arial", 9F);
            this.lblRol_593CM.Location = new System.Drawing.Point(390, 42);
            this.lblRol_593CM.Name = "lblRol_593CM";
            this.lblRol_593CM.Size = new System.Drawing.Size(80, 22);
            this.lblRol_593CM.TabIndex = 6;
            this.lblRol_593CM.Text = "Rol:";

            // 
            // cboRol_593CM
            // 
            this.cboRol_593CM.DropDownStyle = System.Windows.Forms.ComboBoxStyle.DropDownList;
            this.cboRol_593CM.Font = new System.Drawing.Font("Arial", 9F);
            this.cboRol_593CM.FormattingEnabled = true;
            this.cboRol_593CM.Location = new System.Drawing.Point(475, 38);
            this.cboRol_593CM.Name = "cboRol_593CM";
            this.cboRol_593CM.Size = new System.Drawing.Size(250, 23);
            this.cboRol_593CM.TabIndex = 7;

            // 
            // lblNombre_593CM
            // 
            this.lblNombre_593CM.Font = new System.Drawing.Font("Arial", 9F);
            this.lblNombre_593CM.Location = new System.Drawing.Point(10, 72);
            this.lblNombre_593CM.Name = "lblNombre_593CM";
            this.lblNombre_593CM.Size = new System.Drawing.Size(80, 22);
            this.lblNombre_593CM.TabIndex = 8;
            this.lblNombre_593CM.Text = "Nombres:";

            // 
            // txtNombre_593CM
            // 
            this.txtNombre_593CM.Font = new System.Drawing.Font("Arial", 9F);
            this.txtNombre_593CM.Location = new System.Drawing.Point(95, 68);
            this.txtNombre_593CM.Name = "txtNombre_593CM";
            this.txtNombre_593CM.Size = new System.Drawing.Size(250, 21);
            this.txtNombre_593CM.TabIndex = 9;
            this.txtNombre_593CM.TextChanged += new System.EventHandler(this.txtNombreApellido_TextChanged_593CM);

            // 
            // lblLogin_593CM
            // 
            this.lblLogin_593CM.Font = new System.Drawing.Font("Arial", 9F);
            this.lblLogin_593CM.Location = new System.Drawing.Point(390, 72);
            this.lblLogin_593CM.Name = "lblLogin_593CM";
            this.lblLogin_593CM.Size = new System.Drawing.Size(80, 22);
            this.lblLogin_593CM.TabIndex = 10;
            this.lblLogin_593CM.Text = "Login:";

            // 
            // txtLogin_593CM
            // 
            this.txtLogin_593CM.Font = new System.Drawing.Font("Arial", 9F);
            this.txtLogin_593CM.Location = new System.Drawing.Point(475, 68);
            this.txtLogin_593CM.Name = "txtLogin_593CM";
            this.txtLogin_593CM.ReadOnly = true;
            this.txtLogin_593CM.Size = new System.Drawing.Size(250, 21);
            this.txtLogin_593CM.TabIndex = 11;

            // 
            // lblBloqueado_593CM
            // 
            this.lblBloqueado_593CM.Font = new System.Drawing.Font("Arial", 9F);
            this.lblBloqueado_593CM.Location = new System.Drawing.Point(10, 102);
            this.lblBloqueado_593CM.Name = "lblBloqueado_593CM";
            this.lblBloqueado_593CM.Size = new System.Drawing.Size(80, 22);
            this.lblBloqueado_593CM.TabIndex = 12;
            this.lblBloqueado_593CM.Text = "Bloqueado:";

            // 
            // txtBloqueado_593CM
            // 
            this.txtBloqueado_593CM.Font = new System.Drawing.Font("Arial", 9F);
            this.txtBloqueado_593CM.Location = new System.Drawing.Point(95, 98);
            this.txtBloqueado_593CM.Name = "txtBloqueado_593CM";
            this.txtBloqueado_593CM.ReadOnly = true;
            this.txtBloqueado_593CM.Size = new System.Drawing.Size(80, 21);
            this.txtBloqueado_593CM.TabIndex = 13;

            // 
            // lblActivo_593CM
            // 
            this.lblActivo_593CM.Font = new System.Drawing.Font("Arial", 9F);
            this.lblActivo_593CM.Location = new System.Drawing.Point(390, 102);
            this.lblActivo_593CM.Name = "lblActivo_593CM";
            this.lblActivo_593CM.Size = new System.Drawing.Size(80, 22);
            this.lblActivo_593CM.TabIndex = 14;
            this.lblActivo_593CM.Text = "Activo:";

            // 
            // txtActivo_593CM
            // 
            this.txtActivo_593CM.Font = new System.Drawing.Font("Arial", 9F);
            this.txtActivo_593CM.Location = new System.Drawing.Point(475, 98);
            this.txtActivo_593CM.Name = "txtActivo_593CM";
            this.txtActivo_593CM.ReadOnly = true;
            this.txtActivo_593CM.Size = new System.Drawing.Size(80, 21);
            this.txtActivo_593CM.TabIndex = 15;

            // 
            // pnlMensaje_593CM
            // 
            this.pnlMensaje_593CM.BorderStyle = System.Windows.Forms.BorderStyle.FixedSingle;
            this.pnlMensaje_593CM.Controls.Add(this.lblMensaje_593CM);
            this.pnlMensaje_593CM.Location = new System.Drawing.Point(12, 482);
            this.pnlMensaje_593CM.Name = "pnlMensaje_593CM";
            this.pnlMensaje_593CM.Size = new System.Drawing.Size(770, 40);
            this.pnlMensaje_593CM.TabIndex = 6;

            // 
            // lblMensaje_593CM
            // 
            this.lblMensaje_593CM.Dock = System.Windows.Forms.DockStyle.Fill;
            this.lblMensaje_593CM.Font = new System.Drawing.Font("Arial", 9F, System.Drawing.FontStyle.Bold);
            this.lblMensaje_593CM.Location = new System.Drawing.Point(0, 0);
            this.lblMensaje_593CM.Name = "lblMensaje_593CM";
            this.lblMensaje_593CM.Padding = new System.Windows.Forms.Padding(5, 0, 0, 0);
            this.lblMensaje_593CM.Size = new System.Drawing.Size(768, 38);
            this.lblMensaje_593CM.TabIndex = 0;
            this.lblMensaje_593CM.TextAlign = System.Drawing.ContentAlignment.MiddleLeft;

            // 
            // pnlBotones_593CM
            // 
            this.pnlBotones_593CM.Controls.Add(this.btnCrear_593CM);
            this.pnlBotones_593CM.Controls.Add(this.btnDesbloquear_593CM);
            this.pnlBotones_593CM.Controls.Add(this.btnModificar_593CM);
            this.pnlBotones_593CM.Controls.Add(this.btnActDesact_593CM);
            this.pnlBotones_593CM.Controls.Add(this.btnAplicar_593CM);
            this.pnlBotones_593CM.Controls.Add(this.btnCancelar_593CM);
            this.pnlBotones_593CM.Controls.Add(this.btnSalir_593CM);
            this.pnlBotones_593CM.Location = new System.Drawing.Point(790, 42);
            this.pnlBotones_593CM.Name = "pnlBotones_593CM";
            this.pnlBotones_593CM.Size = new System.Drawing.Size(130, 480);
            this.pnlBotones_593CM.TabIndex = 7;

            // 
            // btnCrear_593CM
            // 
            this.btnCrear_593CM.Font = new System.Drawing.Font("Arial", 9F);
            this.btnCrear_593CM.Location = new System.Drawing.Point(5, 0);
            this.btnCrear_593CM.Name = "btnCrear_593CM";
            this.btnCrear_593CM.Size = new System.Drawing.Size(120, 40);
            this.btnCrear_593CM.TabIndex = 0;
            this.btnCrear_593CM.Text = "Crear";
            this.btnCrear_593CM.UseVisualStyleBackColor = true;
            this.btnCrear_593CM.Click += new System.EventHandler(this.btnCrear_Click_593CM);

            // 
            // btnDesbloquear_593CM
            // 
            this.btnDesbloquear_593CM.Font = new System.Drawing.Font("Arial", 9F);
            this.btnDesbloquear_593CM.Location = new System.Drawing.Point(5, 55);
            this.btnDesbloquear_593CM.Name = "btnDesbloquear_593CM";
            this.btnDesbloquear_593CM.Size = new System.Drawing.Size(120, 40);
            this.btnDesbloquear_593CM.TabIndex = 1;
            this.btnDesbloquear_593CM.Text = "Desbloquear";
            this.btnDesbloquear_593CM.UseVisualStyleBackColor = true;
            this.btnDesbloquear_593CM.Click += new System.EventHandler(this.btnDesbloquear_Click_593CM);

            // 
            // btnModificar_593CM
            // 
            this.btnModificar_593CM.Font = new System.Drawing.Font("Arial", 9F);
            this.btnModificar_593CM.Location = new System.Drawing.Point(5, 110);
            this.btnModificar_593CM.Name = "btnModificar_593CM";
            this.btnModificar_593CM.Size = new System.Drawing.Size(120, 40);
            this.btnModificar_593CM.TabIndex = 2;
            this.btnModificar_593CM.Text = "Modificar";
            this.btnModificar_593CM.UseVisualStyleBackColor = true;
            this.btnModificar_593CM.Click += new System.EventHandler(this.btnModificar_Click_593CM);

            // 
            // btnActDesact_593CM
            // 
            this.btnActDesact_593CM.Font = new System.Drawing.Font("Arial", 9F);
            this.btnActDesact_593CM.Location = new System.Drawing.Point(5, 165);
            this.btnActDesact_593CM.Name = "btnActDesact_593CM";
            this.btnActDesact_593CM.Size = new System.Drawing.Size(120, 40);
            this.btnActDesact_593CM.TabIndex = 3;
            this.btnActDesact_593CM.Text = "Act. / Desact.";
            this.btnActDesact_593CM.UseVisualStyleBackColor = true;
            this.btnActDesact_593CM.Click += new System.EventHandler(this.btnActDesact_Click_593CM);

            // 
            // btnAplicar_593CM
            // 
            this.btnAplicar_593CM.Font = new System.Drawing.Font("Arial", 9F);
            this.btnAplicar_593CM.Location = new System.Drawing.Point(5, 240);
            this.btnAplicar_593CM.Name = "btnAplicar_593CM";
            this.btnAplicar_593CM.Size = new System.Drawing.Size(120, 40);
            this.btnAplicar_593CM.TabIndex = 4;
            this.btnAplicar_593CM.Text = "Aplicar";
            this.btnAplicar_593CM.UseVisualStyleBackColor = true;
            this.btnAplicar_593CM.Click += new System.EventHandler(this.btnAplicar_Click_593CM);

            // 
            // btnCancelar_593CM
            // 
            this.btnCancelar_593CM.Font = new System.Drawing.Font("Arial", 9F);
            this.btnCancelar_593CM.Location = new System.Drawing.Point(5, 295);
            this.btnCancelar_593CM.Name = "btnCancelar_593CM";
            this.btnCancelar_593CM.Size = new System.Drawing.Size(120, 40);
            this.btnCancelar_593CM.TabIndex = 5;
            this.btnCancelar_593CM.Text = "Cancelar";
            this.btnCancelar_593CM.UseVisualStyleBackColor = true;
            this.btnCancelar_593CM.Click += new System.EventHandler(this.btnCancelar_Click_593CM);

            // 
            // btnSalir_593CM
            // 
            this.btnSalir_593CM.Font = new System.Drawing.Font("Arial", 9F);
            this.btnSalir_593CM.Location = new System.Drawing.Point(5, 370);
            this.btnSalir_593CM.Name = "btnSalir_593CM";
            this.btnSalir_593CM.Size = new System.Drawing.Size(120, 40);
            this.btnSalir_593CM.TabIndex = 6;
            this.btnSalir_593CM.Text = "Salir";
            this.btnSalir_593CM.UseVisualStyleBackColor = true;
            this.btnSalir_593CM.Click += new System.EventHandler(this.btnSalir_Click_593CM);

            // 
            // FormUsuarios_593CM
            // 
            this.AutoScaleDimensions = new System.Drawing.SizeF(6F, 13F);
            this.AutoScaleMode = System.Windows.Forms.AutoScaleMode.Font;
            this.ClientSize = new System.Drawing.Size(940, 540);
            this.Controls.Add(this.lblTitulo_593CM);
            this.Controls.Add(this.rbActivos_593CM);
            this.Controls.Add(this.rbTodos_593CM);
            this.Controls.Add(this.lblNumUsuarios_593CM);
            this.Controls.Add(this.dgvUsuarios_593CM);
            this.Controls.Add(this.pnlDetalle_593CM);
            this.Controls.Add(this.pnlMensaje_593CM);
            this.Controls.Add(this.pnlBotones_593CM);
            this.MinimumSize = new System.Drawing.Size(960, 580);
            this.Name = "FormUsuarios_593CM";
            this.StartPosition = System.Windows.Forms.FormStartPosition.CenterParent;
            this.Text = "GESTIÓN DE USUARIOS";

            ((System.ComponentModel.ISupportInitialize)(this.dgvUsuarios_593CM)).EndInit();
            this.pnlDetalle_593CM.ResumeLayout(false);
            this.pnlDetalle_593CM.PerformLayout();
            this.pnlBotones_593CM.ResumeLayout(false);
            this.pnlMensaje_593CM.ResumeLayout(false);
            this.ResumeLayout(false);
        }

        private System.Windows.Forms.Label lblTitulo_593CM;
        private System.Windows.Forms.RadioButton rbActivos_593CM;
        private System.Windows.Forms.RadioButton rbTodos_593CM;
        private System.Windows.Forms.Label lblNumUsuarios_593CM;
        private System.Windows.Forms.DataGridView dgvUsuarios_593CM;
        private System.Windows.Forms.DataGridViewTextBoxColumn colDNI_593CM;
        private System.Windows.Forms.DataGridViewTextBoxColumn colApellidos_593CM;
        private System.Windows.Forms.DataGridViewTextBoxColumn colNombre_593CM;
        private System.Windows.Forms.DataGridViewTextBoxColumn colLogin_593CM;
        private System.Windows.Forms.DataGridViewTextBoxColumn colRol_593CM;
        private System.Windows.Forms.Panel pnlDetalle_593CM;
        private System.Windows.Forms.Label lblDNI_593CM;
        private System.Windows.Forms.TextBox txtDNI_593CM;
        private System.Windows.Forms.Label lblApellidos_593CM;
        private System.Windows.Forms.TextBox txtApellidos_593CM;
        private System.Windows.Forms.Label lblNombre_593CM;
        private System.Windows.Forms.TextBox txtNombre_593CM;
        private System.Windows.Forms.Label lblEmail_593CM;
        private System.Windows.Forms.TextBox txtEmail_593CM;
        private System.Windows.Forms.Label lblRol_593CM;
        private System.Windows.Forms.ComboBox cboRol_593CM;
        private System.Windows.Forms.Label lblLogin_593CM;
        private System.Windows.Forms.TextBox txtLogin_593CM;
        private System.Windows.Forms.Label lblBloqueado_593CM;
        private System.Windows.Forms.TextBox txtBloqueado_593CM;
        private System.Windows.Forms.Label lblActivo_593CM;
        private System.Windows.Forms.TextBox txtActivo_593CM;
        private System.Windows.Forms.Panel pnlBotones_593CM;
        private System.Windows.Forms.Button btnCrear_593CM;
        private System.Windows.Forms.Button btnDesbloquear_593CM;
        private System.Windows.Forms.Button btnModificar_593CM;
        private System.Windows.Forms.Button btnActDesact_593CM;
        private System.Windows.Forms.Button btnAplicar_593CM;
        private System.Windows.Forms.Button btnCancelar_593CM;
        private System.Windows.Forms.Button btnSalir_593CM;
        private System.Windows.Forms.Panel pnlMensaje_593CM;
        private System.Windows.Forms.Label lblMensaje_593CM;
    }
}