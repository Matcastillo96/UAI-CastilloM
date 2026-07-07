namespace DIEFER.UI
{
    partial class FormNuevoRol_593CM
    {
        private System.ComponentModel.IContainer components = null;

        protected override void Dispose(bool disposing)
        {
            if (disposing && (components != null)) components.Dispose();
            base.Dispose(disposing);
        }

        private void InitializeComponent()
        {
            this.lblNombre_593CM = new System.Windows.Forms.Label();
            this.txtNombre_593CM = new System.Windows.Forms.TextBox();
            this.gbPatentes_593CM = new System.Windows.Forms.GroupBox();
            this.chkPatentes_593CM = new System.Windows.Forms.CheckedListBox();
            this.gbFamilias_593CM = new System.Windows.Forms.GroupBox();
            this.chkFamilias_593CM = new System.Windows.Forms.CheckedListBox();
            this.lblAyuda_593CM = new System.Windows.Forms.Label();
            this.btnCrear_593CM = new System.Windows.Forms.Button();
            this.btnCancelar_593CM = new System.Windows.Forms.Button();
            this.gbPatentes_593CM.SuspendLayout();
            this.gbFamilias_593CM.SuspendLayout();
            this.SuspendLayout();
            //
            // lblNombre_593CM
            //
            this.lblNombre_593CM.AutoSize = true;
            this.lblNombre_593CM.Location = new System.Drawing.Point(12, 15);
            this.lblNombre_593CM.Name = "lblNombre_593CM";
            this.lblNombre_593CM.Size = new System.Drawing.Size(47, 13);
            this.lblNombre_593CM.TabIndex = 0;
            this.lblNombre_593CM.Text = "Nombre:";
            //
            // txtNombre_593CM
            //
            this.txtNombre_593CM.Location = new System.Drawing.Point(12, 35);
            this.txtNombre_593CM.Name = "txtNombre_593CM";
            this.txtNombre_593CM.Size = new System.Drawing.Size(360, 20);
            this.txtNombre_593CM.TabIndex = 1;
            this.txtNombre_593CM.TextChanged += new System.EventHandler(this.txtNombre_TextChanged_593CM);
            //
            // gbPatentes_593CM
            //
            this.gbPatentes_593CM.Controls.Add(this.chkPatentes_593CM);
            this.gbPatentes_593CM.Location = new System.Drawing.Point(12, 70);
            this.gbPatentes_593CM.Name = "gbPatentes_593CM";
            this.gbPatentes_593CM.Size = new System.Drawing.Size(175, 200);
            this.gbPatentes_593CM.TabIndex = 2;
            this.gbPatentes_593CM.TabStop = false;
            this.gbPatentes_593CM.Text = "Patentes";
            //
            // chkPatentes_593CM
            //
            this.chkPatentes_593CM.Dock = System.Windows.Forms.DockStyle.Fill;
            this.chkPatentes_593CM.FormattingEnabled = true;
            this.chkPatentes_593CM.Location = new System.Drawing.Point(3, 16);
            this.chkPatentes_593CM.Name = "chkPatentes_593CM";
            this.chkPatentes_593CM.Size = new System.Drawing.Size(169, 181);
            this.chkPatentes_593CM.TabIndex = 0;
            this.chkPatentes_593CM.ItemCheck += new System.Windows.Forms.ItemCheckEventHandler(this.chkPatentes_ItemCheck_593CM);
            //
            // gbFamilias_593CM
            //
            this.gbFamilias_593CM.Controls.Add(this.chkFamilias_593CM);
            this.gbFamilias_593CM.Location = new System.Drawing.Point(197, 70);
            this.gbFamilias_593CM.Name = "gbFamilias_593CM";
            this.gbFamilias_593CM.Size = new System.Drawing.Size(175, 200);
            this.gbFamilias_593CM.TabIndex = 3;
            this.gbFamilias_593CM.TabStop = false;
            this.gbFamilias_593CM.Text = "Familias";
            //
            // chkFamilias_593CM
            //
            this.chkFamilias_593CM.Dock = System.Windows.Forms.DockStyle.Fill;
            this.chkFamilias_593CM.FormattingEnabled = true;
            this.chkFamilias_593CM.Location = new System.Drawing.Point(3, 16);
            this.chkFamilias_593CM.Name = "chkFamilias_593CM";
            this.chkFamilias_593CM.Size = new System.Drawing.Size(169, 181);
            this.chkFamilias_593CM.TabIndex = 0;
            this.chkFamilias_593CM.ItemCheck += new System.Windows.Forms.ItemCheckEventHandler(this.chkFamilias_ItemCheck_593CM);
            //
            // lblAyuda_593CM
            //
            this.lblAyuda_593CM.AutoSize = true;
            this.lblAyuda_593CM.Location = new System.Drawing.Point(12, 280);
            this.lblAyuda_593CM.Name = "lblAyuda_593CM";
            this.lblAyuda_593CM.Size = new System.Drawing.Size(220, 13);
            this.lblAyuda_593CM.TabIndex = 4;
            this.lblAyuda_593CM.Text = "Seleccione al menos una patente o familia.";
            //
            // btnCrear_593CM
            //
            this.btnCrear_593CM.Enabled = false;
            this.btnCrear_593CM.Location = new System.Drawing.Point(200, 310);
            this.btnCrear_593CM.Name = "btnCrear_593CM";
            this.btnCrear_593CM.Size = new System.Drawing.Size(80, 28);
            this.btnCrear_593CM.TabIndex = 5;
            this.btnCrear_593CM.Text = "Crear";
            this.btnCrear_593CM.UseVisualStyleBackColor = true;
            this.btnCrear_593CM.Click += new System.EventHandler(this.btnCrear_Click_593CM);
            //
            // btnCancelar_593CM
            //
            this.btnCancelar_593CM.Location = new System.Drawing.Point(292, 310);
            this.btnCancelar_593CM.Name = "btnCancelar_593CM";
            this.btnCancelar_593CM.Size = new System.Drawing.Size(80, 28);
            this.btnCancelar_593CM.TabIndex = 6;
            this.btnCancelar_593CM.Text = "Cancelar";
            this.btnCancelar_593CM.UseVisualStyleBackColor = true;
            this.btnCancelar_593CM.Click += new System.EventHandler(this.btnCancelar_Click_593CM);
            //
            // FormNuevoRol_593CM
            //
            this.AutoScaleDimensions = new System.Drawing.SizeF(6F, 13F);
            this.AutoScaleMode = System.Windows.Forms.AutoScaleMode.Font;
            this.ClientSize = new System.Drawing.Size(384, 350);
            this.Controls.Add(this.btnCancelar_593CM);
            this.Controls.Add(this.btnCrear_593CM);
            this.Controls.Add(this.lblAyuda_593CM);
            this.Controls.Add(this.gbFamilias_593CM);
            this.Controls.Add(this.gbPatentes_593CM);
            this.Controls.Add(this.txtNombre_593CM);
            this.Controls.Add(this.lblNombre_593CM);
            this.FormBorderStyle = System.Windows.Forms.FormBorderStyle.FixedDialog;
            this.MaximizeBox = false;
            this.MinimizeBox = false;
            this.Name = "FormNuevoRol_593CM";
            this.StartPosition = System.Windows.Forms.FormStartPosition.CenterParent;
            this.Text = "Nuevo Rol";
            this.gbPatentes_593CM.ResumeLayout(false);
            this.gbFamilias_593CM.ResumeLayout(false);
            this.ResumeLayout(false);
            this.PerformLayout();
        }

        private System.Windows.Forms.Label lblNombre_593CM;
        private System.Windows.Forms.TextBox txtNombre_593CM;
        private System.Windows.Forms.GroupBox gbPatentes_593CM;
        private System.Windows.Forms.CheckedListBox chkPatentes_593CM;
        private System.Windows.Forms.GroupBox gbFamilias_593CM;
        private System.Windows.Forms.CheckedListBox chkFamilias_593CM;
        private System.Windows.Forms.Label lblAyuda_593CM;
        private System.Windows.Forms.Button btnCrear_593CM;
        private System.Windows.Forms.Button btnCancelar_593CM;
    }
}
