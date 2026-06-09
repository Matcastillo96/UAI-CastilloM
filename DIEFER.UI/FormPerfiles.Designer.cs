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
            this.tabRoles = new System.Windows.Forms.TabPage();

            // ── Tab Familias ─────────────────────────────────────────────────────────────
            this.lblFamilia       = new System.Windows.Forms.Label();
            this.cmbFamilias      = new System.Windows.Forms.ComboBox();
            this.btnNuevaFamilia  = new System.Windows.Forms.Button();
            this.lstAsignadosF    = new System.Windows.Forms.ListBox();
            this.lstDisponiblesF  = new System.Windows.Forms.ListBox();
            this.lblAsignadosF    = new System.Windows.Forms.Label();
            this.lblDisponiblesF  = new System.Windows.Forms.Label();
            this.btnAgregarF      = new System.Windows.Forms.Button();
            this.btnQuitarF       = new System.Windows.Forms.Button();

            // ── Tab Roles ────────────────────────────────────────────────────────────────
            this.lblRol           = new System.Windows.Forms.Label();
            this.cmbRoles         = new System.Windows.Forms.ComboBox();
            this.lstAsignadosR    = new System.Windows.Forms.ListBox();
            this.lstDisponiblesR  = new System.Windows.Forms.ListBox();
            this.lblAsignadosR    = new System.Windows.Forms.Label();
            this.lblDisponiblesR  = new System.Windows.Forms.Label();
            this.btnAgregarR      = new System.Windows.Forms.Button();
            this.btnQuitarR       = new System.Windows.Forms.Button();

            this.tabControl.SuspendLayout();
            this.tabFamilias.SuspendLayout();
            this.tabRoles.SuspendLayout();
            this.SuspendLayout();

            // ── TabControl ───────────────────────────────────────────────────────────────
            this.tabControl.Controls.Add(this.tabFamilias);
            this.tabControl.Controls.Add(this.tabRoles);
            this.tabControl.Dock      = System.Windows.Forms.DockStyle.Fill;
            this.tabControl.Location  = new System.Drawing.Point(0, 0);
            this.tabControl.Name      = "tabControl";
            this.tabControl.Size      = new System.Drawing.Size(784, 461);
            this.tabControl.TabIndex  = 0;

            // ── tabFamilias ──────────────────────────────────────────────────────────────
            this.tabFamilias.Controls.Add(this.lblFamilia);
            this.tabFamilias.Controls.Add(this.cmbFamilias);
            this.tabFamilias.Controls.Add(this.btnNuevaFamilia);
            this.tabFamilias.Controls.Add(this.lblAsignadosF);
            this.tabFamilias.Controls.Add(this.lstAsignadosF);
            this.tabFamilias.Controls.Add(this.btnQuitarF);
            this.tabFamilias.Controls.Add(this.btnAgregarF);
            this.tabFamilias.Controls.Add(this.lstDisponiblesF);
            this.tabFamilias.Controls.Add(this.lblDisponiblesF);
            this.tabFamilias.Location  = new System.Drawing.Point(4, 22);
            this.tabFamilias.Name      = "tabFamilias";
            this.tabFamilias.Padding   = new System.Windows.Forms.Padding(3);
            this.tabFamilias.Size      = new System.Drawing.Size(776, 435);
            this.tabFamilias.TabIndex  = 0;
            this.tabFamilias.Text      = "Administrador de Familias";
            this.tabFamilias.UseVisualStyleBackColor = true;

            this.lblFamilia.AutoSize = true;
            this.lblFamilia.Location = new System.Drawing.Point(8, 12);
            this.lblFamilia.Text     = "Familia:";

            this.cmbFamilias.DropDownStyle = System.Windows.Forms.ComboBoxStyle.DropDownList;
            this.cmbFamilias.Location      = new System.Drawing.Point(70, 9);
            this.cmbFamilias.Name          = "cmbFamilias";
            this.cmbFamilias.Size          = new System.Drawing.Size(280, 21);
            this.cmbFamilias.TabIndex      = 0;
            this.cmbFamilias.SelectedIndexChanged += new System.EventHandler(this.cmbFamilias_SelectedIndexChanged);

            this.btnNuevaFamilia.Location  = new System.Drawing.Point(360, 7);
            this.btnNuevaFamilia.Name      = "btnNuevaFamilia";
            this.btnNuevaFamilia.Size      = new System.Drawing.Size(110, 25);
            this.btnNuevaFamilia.TabIndex  = 1;
            this.btnNuevaFamilia.Text      = "Nueva Familia";
            this.btnNuevaFamilia.Click    += new System.EventHandler(this.btnNuevaFamilia_Click);

            this.lblAsignadosF.AutoSize = true;
            this.lblAsignadosF.Location = new System.Drawing.Point(8, 42);
            this.lblAsignadosF.Text     = "Asignados:";

            this.lstAsignadosF.FormattingEnabled = true;
            this.lstAsignadosF.Location           = new System.Drawing.Point(8, 60);
            this.lstAsignadosF.Name               = "lstAsignadosF";
            this.lstAsignadosF.Size               = new System.Drawing.Size(330, 355);
            this.lstAsignadosF.TabIndex           = 2;

            this.btnQuitarF.Location  = new System.Drawing.Point(348, 180);
            this.btnQuitarF.Name      = "btnQuitarF";
            this.btnQuitarF.Size      = new System.Drawing.Size(80, 28);
            this.btnQuitarF.TabIndex  = 3;
            this.btnQuitarF.Text      = "<< Quitar";
            this.btnQuitarF.Click    += new System.EventHandler(this.btnQuitarF_Click);

            this.btnAgregarF.Location  = new System.Drawing.Point(348, 218);
            this.btnAgregarF.Name      = "btnAgregarF";
            this.btnAgregarF.Size      = new System.Drawing.Size(80, 28);
            this.btnAgregarF.TabIndex  = 4;
            this.btnAgregarF.Text      = "Agregar >>";
            this.btnAgregarF.Click    += new System.EventHandler(this.btnAgregarF_Click);

            this.lblDisponiblesF.AutoSize = true;
            this.lblDisponiblesF.Location = new System.Drawing.Point(438, 42);
            this.lblDisponiblesF.Text     = "Disponibles:";

            this.lstDisponiblesF.FormattingEnabled = true;
            this.lstDisponiblesF.Location           = new System.Drawing.Point(438, 60);
            this.lstDisponiblesF.Name               = "lstDisponiblesF";
            this.lstDisponiblesF.Size               = new System.Drawing.Size(330, 355);
            this.lstDisponiblesF.TabIndex           = 5;

            // ── tabRoles ─────────────────────────────────────────────────────────────────
            this.tabRoles.Controls.Add(this.lblRol);
            this.tabRoles.Controls.Add(this.cmbRoles);
            this.tabRoles.Controls.Add(this.lblAsignadosR);
            this.tabRoles.Controls.Add(this.lstAsignadosR);
            this.tabRoles.Controls.Add(this.btnQuitarR);
            this.tabRoles.Controls.Add(this.btnAgregarR);
            this.tabRoles.Controls.Add(this.lstDisponiblesR);
            this.tabRoles.Controls.Add(this.lblDisponiblesR);
            this.tabRoles.Location  = new System.Drawing.Point(4, 22);
            this.tabRoles.Name      = "tabRoles";
            this.tabRoles.Padding   = new System.Windows.Forms.Padding(3);
            this.tabRoles.Size      = new System.Drawing.Size(776, 435);
            this.tabRoles.TabIndex  = 1;
            this.tabRoles.Text      = "Administrador de Roles";
            this.tabRoles.UseVisualStyleBackColor = true;

            this.lblRol.AutoSize = true;
            this.lblRol.Location = new System.Drawing.Point(8, 12);
            this.lblRol.Text     = "Rol:";

            this.cmbRoles.DropDownStyle = System.Windows.Forms.ComboBoxStyle.DropDownList;
            this.cmbRoles.Location      = new System.Drawing.Point(70, 9);
            this.cmbRoles.Name          = "cmbRoles";
            this.cmbRoles.Size          = new System.Drawing.Size(280, 21);
            this.cmbRoles.TabIndex      = 0;
            this.cmbRoles.SelectedIndexChanged += new System.EventHandler(this.cmbRoles_SelectedIndexChanged);

            this.lblAsignadosR.AutoSize = true;
            this.lblAsignadosR.Location = new System.Drawing.Point(8, 42);
            this.lblAsignadosR.Text     = "Asignados:";

            this.lstAsignadosR.FormattingEnabled = true;
            this.lstAsignadosR.Location           = new System.Drawing.Point(8, 60);
            this.lstAsignadosR.Name               = "lstAsignadosR";
            this.lstAsignadosR.Size               = new System.Drawing.Size(330, 355);
            this.lstAsignadosR.TabIndex           = 1;

            this.btnQuitarR.Location  = new System.Drawing.Point(348, 180);
            this.btnQuitarR.Name      = "btnQuitarR";
            this.btnQuitarR.Size      = new System.Drawing.Size(80, 28);
            this.btnQuitarR.TabIndex  = 2;
            this.btnQuitarR.Text      = "<< Quitar";
            this.btnQuitarR.Click    += new System.EventHandler(this.btnQuitarR_Click);

            this.btnAgregarR.Location  = new System.Drawing.Point(348, 218);
            this.btnAgregarR.Name      = "btnAgregarR";
            this.btnAgregarR.Size      = new System.Drawing.Size(80, 28);
            this.btnAgregarR.TabIndex  = 3;
            this.btnAgregarR.Text      = "Agregar >>";
            this.btnAgregarR.Click    += new System.EventHandler(this.btnAgregarR_Click);

            this.lblDisponiblesR.AutoSize = true;
            this.lblDisponiblesR.Location = new System.Drawing.Point(438, 42);
            this.lblDisponiblesR.Text     = "Disponibles:";

            this.lstDisponiblesR.FormattingEnabled = true;
            this.lstDisponiblesR.Location           = new System.Drawing.Point(438, 60);
            this.lstDisponiblesR.Name               = "lstDisponiblesR";
            this.lstDisponiblesR.Size               = new System.Drawing.Size(330, 355);
            this.lstDisponiblesR.TabIndex           = 4;

            // ── Form ─────────────────────────────────────────────────────────────────────
            this.tabControl.ResumeLayout(false);
            this.tabFamilias.ResumeLayout(false);
            this.tabFamilias.PerformLayout();
            this.tabRoles.ResumeLayout(false);
            this.tabRoles.PerformLayout();

            this.AutoScaleDimensions = new System.Drawing.SizeF(6F, 13F);
            this.AutoScaleMode       = System.Windows.Forms.AutoScaleMode.Font;
            this.ClientSize          = new System.Drawing.Size(784, 461);
            this.Controls.Add(this.tabControl);
            this.FormBorderStyle = System.Windows.Forms.FormBorderStyle.FixedSingle;
            this.MaximizeBox     = false;
            this.MinimizeBox     = false;
            this.Name            = "FormPerfiles_593CM";
            this.StartPosition   = System.Windows.Forms.FormStartPosition.CenterParent;
            this.Text            = "Administrador de Perfiles";
            this.Load           += new System.EventHandler(this.FormPerfiles_Load);
            this.ResumeLayout(false);
        }

        private System.Windows.Forms.TabControl  tabControl;
        private System.Windows.Forms.TabPage     tabFamilias;
        private System.Windows.Forms.TabPage     tabRoles;
        private System.Windows.Forms.Label       lblFamilia;
        private System.Windows.Forms.ComboBox    cmbFamilias;
        private System.Windows.Forms.Button      btnNuevaFamilia;
        private System.Windows.Forms.ListBox     lstAsignadosF;
        private System.Windows.Forms.ListBox     lstDisponiblesF;
        private System.Windows.Forms.Label       lblAsignadosF;
        private System.Windows.Forms.Label       lblDisponiblesF;
        private System.Windows.Forms.Button      btnAgregarF;
        private System.Windows.Forms.Button      btnQuitarF;
        private System.Windows.Forms.Label       lblRol;
        private System.Windows.Forms.ComboBox    cmbRoles;
        private System.Windows.Forms.ListBox     lstAsignadosR;
        private System.Windows.Forms.ListBox     lstDisponiblesR;
        private System.Windows.Forms.Label       lblAsignadosR;
        private System.Windows.Forms.Label       lblDisponiblesR;
        private System.Windows.Forms.Button      btnAgregarR;
        private System.Windows.Forms.Button      btnQuitarR;
    }
}
