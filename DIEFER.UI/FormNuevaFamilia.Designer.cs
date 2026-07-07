namespace DIEFER.UI
{
    partial class FormNuevaFamilia_593CM
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
            this.lblPatentes_593CM = new System.Windows.Forms.Label();
            this.chkPatentes_593CM = new System.Windows.Forms.CheckedListBox();
            this.btnCrear_593CM = new System.Windows.Forms.Button();
            this.btnCancelar_593CM = new System.Windows.Forms.Button();
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
            // lblPatentes_593CM
            //
            this.lblPatentes_593CM.AutoSize = true;
            this.lblPatentes_593CM.Location = new System.Drawing.Point(12, 70);
            this.lblPatentes_593CM.Name = "lblPatentes_593CM";
            this.lblPatentes_593CM.Size = new System.Drawing.Size(142, 13);
            this.lblPatentes_593CM.TabIndex = 2;
            this.lblPatentes_593CM.Text = "Patentes (al menos una):";
            //
            // chkPatentes_593CM
            //
            this.chkPatentes_593CM.FormattingEnabled = true;
            this.chkPatentes_593CM.Location = new System.Drawing.Point(12, 90);
            this.chkPatentes_593CM.Name = "chkPatentes_593CM";
            this.chkPatentes_593CM.Size = new System.Drawing.Size(360, 184);
            this.chkPatentes_593CM.TabIndex = 3;
            this.chkPatentes_593CM.ItemCheck += new System.Windows.Forms.ItemCheckEventHandler(this.chkPatentes_ItemCheck_593CM);
            //
            // btnCrear_593CM
            //
            this.btnCrear_593CM.Enabled = false;
            this.btnCrear_593CM.Location = new System.Drawing.Point(200, 290);
            this.btnCrear_593CM.Name = "btnCrear_593CM";
            this.btnCrear_593CM.Size = new System.Drawing.Size(80, 28);
            this.btnCrear_593CM.TabIndex = 4;
            this.btnCrear_593CM.Text = "Crear";
            this.btnCrear_593CM.UseVisualStyleBackColor = true;
            this.btnCrear_593CM.Click += new System.EventHandler(this.btnCrear_Click_593CM);
            //
            // btnCancelar_593CM
            //
            this.btnCancelar_593CM.Location = new System.Drawing.Point(292, 290);
            this.btnCancelar_593CM.Name = "btnCancelar_593CM";
            this.btnCancelar_593CM.Size = new System.Drawing.Size(80, 28);
            this.btnCancelar_593CM.TabIndex = 5;
            this.btnCancelar_593CM.Text = "Cancelar";
            this.btnCancelar_593CM.UseVisualStyleBackColor = true;
            this.btnCancelar_593CM.Click += new System.EventHandler(this.btnCancelar_Click_593CM);
            //
            // FormNuevaFamilia_593CM
            //
            this.AutoScaleDimensions = new System.Drawing.SizeF(6F, 13F);
            this.AutoScaleMode = System.Windows.Forms.AutoScaleMode.Font;
            this.ClientSize = new System.Drawing.Size(384, 330);
            this.Controls.Add(this.btnCancelar_593CM);
            this.Controls.Add(this.btnCrear_593CM);
            this.Controls.Add(this.chkPatentes_593CM);
            this.Controls.Add(this.lblPatentes_593CM);
            this.Controls.Add(this.txtNombre_593CM);
            this.Controls.Add(this.lblNombre_593CM);
            this.FormBorderStyle = System.Windows.Forms.FormBorderStyle.FixedDialog;
            this.MaximizeBox = false;
            this.MinimizeBox = false;
            this.Name = "FormNuevaFamilia_593CM";
            this.StartPosition = System.Windows.Forms.FormStartPosition.CenterParent;
            this.Text = "Nueva Familia";
            this.ResumeLayout(false);
            this.PerformLayout();
        }

        private System.Windows.Forms.Label lblNombre_593CM;
        private System.Windows.Forms.TextBox txtNombre_593CM;
        private System.Windows.Forms.Label lblPatentes_593CM;
        private System.Windows.Forms.CheckedListBox chkPatentes_593CM;
        private System.Windows.Forms.Button btnCrear_593CM;
        private System.Windows.Forms.Button btnCancelar_593CM;
    }
}
