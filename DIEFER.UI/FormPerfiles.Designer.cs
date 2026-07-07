namespace DIEFER.UI
{
    partial class FormPerfiles_593CM
    {
        private System.ComponentModel.IContainer components = null;

        protected override void Dispose(bool disposing)
        {
            if (disposing && (components != null)) components.Dispose();
            base.Dispose(disposing);
        }

        private void InitializeComponent()
        {
            this.tabControl = new System.Windows.Forms.TabControl();
            this.tabFamilias = new System.Windows.Forms.TabPage();
            this.lblFamilia = new System.Windows.Forms.Label();
            this.cmbFamilias = new System.Windows.Forms.ComboBox();
            this.btnNuevaFamilia = new System.Windows.Forms.Button();
            this.btnRenombrarF = new System.Windows.Forms.Button();
            this.btnEliminarF = new System.Windows.Forms.Button();
            this.lblAsignadosF = new System.Windows.Forms.Label();
            this.lstAsignadosF = new System.Windows.Forms.ListBox();
            this.btnQuitarF = new System.Windows.Forms.Button();
            this.btnAgregarF = new System.Windows.Forms.Button();
            this.lstDisponiblesF = new System.Windows.Forms.ListBox();
            this.lblDisponiblesF = new System.Windows.Forms.Label();
            this.tabRoles = new System.Windows.Forms.TabPage();
            this.lblRol = new System.Windows.Forms.Label();
            this.cmbRoles = new System.Windows.Forms.ComboBox();
            this.btnNuevoRol = new System.Windows.Forms.Button();
            this.btnRenombrarR = new System.Windows.Forms.Button();
            this.btnEliminarR = new System.Windows.Forms.Button();
            this.lblAsignadosR = new System.Windows.Forms.Label();
            this.lstAsignadosR = new System.Windows.Forms.ListBox();
            this.btnQuitarR = new System.Windows.Forms.Button();
            this.btnAgregarR = new System.Windows.Forms.Button();
            this.lstDisponiblesR = new System.Windows.Forms.ListBox();
            this.lblDisponiblesR = new System.Windows.Forms.Label();
            this.tabControl.SuspendLayout();
            this.tabFamilias.SuspendLayout();
            this.tabRoles.SuspendLayout();
            this.SuspendLayout();
            // 
            // tabControl
            // 
            this.tabControl.Controls.Add(this.tabFamilias);
            this.tabControl.Controls.Add(this.tabRoles);
            this.tabControl.Dock = System.Windows.Forms.DockStyle.Fill;
            this.tabControl.Location = new System.Drawing.Point(0, 0);
            this.tabControl.Name = "tabControl";
            this.tabControl.SelectedIndex = 0;
            this.tabControl.Size = new System.Drawing.Size(784, 461);
            this.tabControl.TabIndex = 0;
            // 
            // tabFamilias
            // 
            this.tabFamilias.Controls.Add(this.lblFamilia);
            this.tabFamilias.Controls.Add(this.cmbFamilias);
            this.tabFamilias.Controls.Add(this.btnNuevaFamilia);
            this.tabFamilias.Controls.Add(this.btnRenombrarF);
            this.tabFamilias.Controls.Add(this.btnEliminarF);
            this.tabFamilias.Controls.Add(this.lblAsignadosF);
            this.tabFamilias.Controls.Add(this.lstAsignadosF);
            this.tabFamilias.Controls.Add(this.btnQuitarF);
            this.tabFamilias.Controls.Add(this.btnAgregarF);
            this.tabFamilias.Controls.Add(this.lstDisponiblesF);
            this.tabFamilias.Controls.Add(this.lblDisponiblesF);
            this.tabFamilias.Location = new System.Drawing.Point(4, 22);
            this.tabFamilias.Name = "tabFamilias";
            this.tabFamilias.Padding = new System.Windows.Forms.Padding(3);
            this.tabFamilias.Size = new System.Drawing.Size(776, 435);
            this.tabFamilias.TabIndex = 0;
            this.tabFamilias.Text = "Administrador de Familias";
            this.tabFamilias.UseVisualStyleBackColor = true;
            // 
            // lblFamilia
            // 
            this.lblFamilia.AutoSize = true;
            this.lblFamilia.Location = new System.Drawing.Point(8, 12);
            this.lblFamilia.Name = "lblFamilia";
            this.lblFamilia.Size = new System.Drawing.Size(42, 13);
            this.lblFamilia.TabIndex = 0;
            this.lblFamilia.Text = "Familia:";
            // 
            // cmbFamilias
            // 
            this.cmbFamilias.DropDownStyle = System.Windows.Forms.ComboBoxStyle.DropDownList;
            this.cmbFamilias.Location = new System.Drawing.Point(70, 9);
            this.cmbFamilias.Name = "cmbFamilias";
            this.cmbFamilias.Size = new System.Drawing.Size(220, 21);
            this.cmbFamilias.TabIndex = 0;
            this.cmbFamilias.SelectedIndexChanged += new System.EventHandler(this.cmbFamilias_SelectedIndexChanged);
            // 
            // btnNuevaFamilia
            // 
            this.btnNuevaFamilia.Location = new System.Drawing.Point(300, 7);
            this.btnNuevaFamilia.Name = "btnNuevaFamilia";
            this.btnNuevaFamilia.Size = new System.Drawing.Size(95, 25);
            this.btnNuevaFamilia.TabIndex = 1;
            this.btnNuevaFamilia.Text = "Nueva";
            this.btnNuevaFamilia.Click += new System.EventHandler(this.btnNuevaFamilia_Click);
            // 
            // btnRenombrarF
            // 
            this.btnRenombrarF.Location = new System.Drawing.Point(400, 7);
            this.btnRenombrarF.Name = "btnRenombrarF";
            this.btnRenombrarF.Size = new System.Drawing.Size(95, 25);
            this.btnRenombrarF.TabIndex = 2;
            this.btnRenombrarF.Text = "Renombrar";
            this.btnRenombrarF.Click += new System.EventHandler(this.btnRenombrarF_Click);
            // 
            // btnEliminarF
            // 
            this.btnEliminarF.Location = new System.Drawing.Point(500, 7);
            this.btnEliminarF.Name = "btnEliminarF";
            this.btnEliminarF.Size = new System.Drawing.Size(95, 25);
            this.btnEliminarF.TabIndex = 3;
            this.btnEliminarF.Text = "Eliminar";
            this.btnEliminarF.Click += new System.EventHandler(this.btnEliminarF_Click);
            // 
            // lblAsignadosF
            // 
            this.lblAsignadosF.AutoSize = true;
            this.lblAsignadosF.Location = new System.Drawing.Point(8, 42);
            this.lblAsignadosF.Name = "lblAsignadosF";
            this.lblAsignadosF.Size = new System.Drawing.Size(59, 13);
            this.lblAsignadosF.TabIndex = 4;
            this.lblAsignadosF.Text = "Asignados:";
            // 
            // lstAsignadosF
            // 
            this.lstAsignadosF.FormattingEnabled = true;
            this.lstAsignadosF.Location = new System.Drawing.Point(8, 60);
            this.lstAsignadosF.Name = "lstAsignadosF";
            this.lstAsignadosF.Size = new System.Drawing.Size(330, 355);
            this.lstAsignadosF.TabIndex = 5;
            // 
            // btnQuitarF
            // 
            this.btnQuitarF.Location = new System.Drawing.Point(348, 180);
            this.btnQuitarF.Name = "btnQuitarF";
            this.btnQuitarF.Size = new System.Drawing.Size(80, 28);
            this.btnQuitarF.TabIndex = 6;
            this.btnQuitarF.Text = "Quitar >>";
            this.btnQuitarF.Click += new System.EventHandler(this.btnQuitarF_Click);
            // 
            // btnAgregarF
            // 
            this.btnAgregarF.Location = new System.Drawing.Point(348, 146);
            this.btnAgregarF.Name = "btnAgregarF";
            this.btnAgregarF.Size = new System.Drawing.Size(80, 28);
            this.btnAgregarF.TabIndex = 7;
            this.btnAgregarF.Text = "<< Agregar";
            this.btnAgregarF.Click += new System.EventHandler(this.btnAgregarF_Click);
            // 
            // lstDisponiblesF
            // 
            this.lstDisponiblesF.FormattingEnabled = true;
            this.lstDisponiblesF.Location = new System.Drawing.Point(438, 60);
            this.lstDisponiblesF.Name = "lstDisponiblesF";
            this.lstDisponiblesF.Size = new System.Drawing.Size(330, 355);
            this.lstDisponiblesF.TabIndex = 8;
            // 
            // lblDisponiblesF
            // 
            this.lblDisponiblesF.AutoSize = true;
            this.lblDisponiblesF.Location = new System.Drawing.Point(438, 42);
            this.lblDisponiblesF.Name = "lblDisponiblesF";
            this.lblDisponiblesF.Size = new System.Drawing.Size(64, 13);
            this.lblDisponiblesF.TabIndex = 9;
            this.lblDisponiblesF.Text = "Disponibles:";
            // 
            // tabRoles
            // 
            this.tabRoles.Controls.Add(this.lblRol);
            this.tabRoles.Controls.Add(this.cmbRoles);
            this.tabRoles.Controls.Add(this.btnNuevoRol);
            this.tabRoles.Controls.Add(this.btnRenombrarR);
            this.tabRoles.Controls.Add(this.btnEliminarR);
            this.tabRoles.Controls.Add(this.lblAsignadosR);
            this.tabRoles.Controls.Add(this.lstAsignadosR);
            this.tabRoles.Controls.Add(this.btnQuitarR);
            this.tabRoles.Controls.Add(this.btnAgregarR);
            this.tabRoles.Controls.Add(this.lstDisponiblesR);
            this.tabRoles.Controls.Add(this.lblDisponiblesR);
            this.tabRoles.Location = new System.Drawing.Point(4, 22);
            this.tabRoles.Name = "tabRoles";
            this.tabRoles.Padding = new System.Windows.Forms.Padding(3);
            this.tabRoles.Size = new System.Drawing.Size(776, 435);
            this.tabRoles.TabIndex = 1;
            this.tabRoles.Text = "Administrador de Roles";
            this.tabRoles.UseVisualStyleBackColor = true;
            // 
            // lblRol
            // 
            this.lblRol.AutoSize = true;
            this.lblRol.Location = new System.Drawing.Point(8, 12);
            this.lblRol.Name = "lblRol";
            this.lblRol.Size = new System.Drawing.Size(26, 13);
            this.lblRol.TabIndex = 0;
            this.lblRol.Text = "Rol:";
            // 
            // cmbRoles
            // 
            this.cmbRoles.DropDownStyle = System.Windows.Forms.ComboBoxStyle.DropDownList;
            this.cmbRoles.Location = new System.Drawing.Point(70, 9);
            this.cmbRoles.Name = "cmbRoles";
            this.cmbRoles.Size = new System.Drawing.Size(220, 21);
            this.cmbRoles.TabIndex = 0;
            this.cmbRoles.SelectedIndexChanged += new System.EventHandler(this.cmbRoles_SelectedIndexChanged);
            //
            // btnNuevoRol
            //
            this.btnNuevoRol.Location = new System.Drawing.Point(300, 7);
            this.btnNuevoRol.Name = "btnNuevoRol";
            this.btnNuevoRol.Size = new System.Drawing.Size(95, 25);
            this.btnNuevoRol.TabIndex = 1;
            this.btnNuevoRol.Text = "Nuevo";
            this.btnNuevoRol.Click += new System.EventHandler(this.btnNuevoRol_Click);
            //
            // btnRenombrarR
            //
            this.btnRenombrarR.Location = new System.Drawing.Point(400, 7);
            this.btnRenombrarR.Name = "btnRenombrarR";
            this.btnRenombrarR.Size = new System.Drawing.Size(95, 25);
            this.btnRenombrarR.TabIndex = 2;
            this.btnRenombrarR.Text = "Renombrar";
            this.btnRenombrarR.Click += new System.EventHandler(this.btnRenombrarR_Click);
            //
            // btnEliminarR
            //
            this.btnEliminarR.Location = new System.Drawing.Point(500, 7);
            this.btnEliminarR.Name = "btnEliminarR";
            this.btnEliminarR.Size = new System.Drawing.Size(95, 25);
            this.btnEliminarR.TabIndex = 3;
            this.btnEliminarR.Text = "Eliminar";
            this.btnEliminarR.Click += new System.EventHandler(this.btnEliminarR_Click);
            //
            // lblAsignadosR
            //
            this.lblAsignadosR.AutoSize = true;
            this.lblAsignadosR.Location = new System.Drawing.Point(8, 42);
            this.lblAsignadosR.Name = "lblAsignadosR";
            this.lblAsignadosR.Size = new System.Drawing.Size(59, 13);
            this.lblAsignadosR.TabIndex = 4;
            this.lblAsignadosR.Text = "Asignados:";
            // 
            // lstAsignadosR
            // 
            this.lstAsignadosR.FormattingEnabled = true;
            this.lstAsignadosR.Location = new System.Drawing.Point(8, 60);
            this.lstAsignadosR.Name = "lstAsignadosR";
            this.lstAsignadosR.Size = new System.Drawing.Size(330, 355);
            this.lstAsignadosR.TabIndex = 5;
            // 
            // btnQuitarR
            // 
            this.btnQuitarR.Location = new System.Drawing.Point(348, 180);
            this.btnQuitarR.Name = "btnQuitarR";
            this.btnQuitarR.Size = new System.Drawing.Size(80, 28);
            this.btnQuitarR.TabIndex = 6;
            this.btnQuitarR.Text = "Quitar >>";
            this.btnQuitarR.Click += new System.EventHandler(this.btnQuitarR_Click);
            // 
            // btnAgregarR
            // 
            this.btnAgregarR.Location = new System.Drawing.Point(348, 146);
            this.btnAgregarR.Name = "btnAgregarR";
            this.btnAgregarR.Size = new System.Drawing.Size(80, 28);
            this.btnAgregarR.TabIndex = 7;
            this.btnAgregarR.Text = "<< Agregar";
            this.btnAgregarR.Click += new System.EventHandler(this.btnAgregarR_Click);
            // 
            // lstDisponiblesR
            // 
            this.lstDisponiblesR.FormattingEnabled = true;
            this.lstDisponiblesR.Location = new System.Drawing.Point(438, 60);
            this.lstDisponiblesR.Name = "lstDisponiblesR";
            this.lstDisponiblesR.Size = new System.Drawing.Size(330, 355);
            this.lstDisponiblesR.TabIndex = 8;
            // 
            // lblDisponiblesR
            // 
            this.lblDisponiblesR.AutoSize = true;
            this.lblDisponiblesR.Location = new System.Drawing.Point(438, 42);
            this.lblDisponiblesR.Name = "lblDisponiblesR";
            this.lblDisponiblesR.Size = new System.Drawing.Size(64, 13);
            this.lblDisponiblesR.TabIndex = 9;
            this.lblDisponiblesR.Text = "Disponibles:";
            // 
            // FormPerfiles_593CM
            // 
            this.AutoScaleDimensions = new System.Drawing.SizeF(6F, 13F);
            this.AutoScaleMode = System.Windows.Forms.AutoScaleMode.Font;
            this.ClientSize = new System.Drawing.Size(784, 461);
            this.Controls.Add(this.tabControl);
            this.FormBorderStyle = System.Windows.Forms.FormBorderStyle.FixedSingle;
            this.MaximizeBox = false;
            this.MinimizeBox = false;
            this.Name = "FormPerfiles_593CM";
            this.StartPosition = System.Windows.Forms.FormStartPosition.CenterParent;
            this.Text = "Administrador de Perfiles";
            this.Load += new System.EventHandler(this.FormPerfiles_Load);
            this.tabControl.ResumeLayout(false);
            this.tabFamilias.ResumeLayout(false);
            this.tabFamilias.PerformLayout();
            this.tabRoles.ResumeLayout(false);
            this.tabRoles.PerformLayout();
            this.ResumeLayout(false);

        }

        private System.Windows.Forms.TabControl  tabControl;
        private System.Windows.Forms.TabPage     tabFamilias;
        private System.Windows.Forms.TabPage     tabRoles;
        private System.Windows.Forms.Label       lblFamilia;
        private System.Windows.Forms.ComboBox    cmbFamilias;
        private System.Windows.Forms.Button      btnNuevaFamilia;
        private System.Windows.Forms.Button      btnRenombrarF;
        private System.Windows.Forms.Button      btnEliminarF;
        private System.Windows.Forms.ListBox     lstAsignadosF;
        private System.Windows.Forms.ListBox     lstDisponiblesF;
        private System.Windows.Forms.Label       lblAsignadosF;
        private System.Windows.Forms.Label       lblDisponiblesF;
        private System.Windows.Forms.Button      btnAgregarF;
        private System.Windows.Forms.Button      btnQuitarF;
        private System.Windows.Forms.Label       lblRol;
        private System.Windows.Forms.ComboBox    cmbRoles;
        private System.Windows.Forms.Button      btnNuevoRol;
        private System.Windows.Forms.Button      btnRenombrarR;
        private System.Windows.Forms.Button      btnEliminarR;
        private System.Windows.Forms.ListBox     lstAsignadosR;
        private System.Windows.Forms.ListBox     lstDisponiblesR;
        private System.Windows.Forms.Label       lblAsignadosR;
        private System.Windows.Forms.Label       lblDisponiblesR;
        private System.Windows.Forms.Button      btnAgregarR;
        private System.Windows.Forms.Button      btnQuitarR;
    }
}
