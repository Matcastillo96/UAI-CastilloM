namespace DIEFER.UI
{
    partial class FormRespaldos_593CM
    {
        private System.ComponentModel.IContainer components = null;

        protected override void Dispose(bool disposing)
        {
            if (disposing && (components != null)) components.Dispose();
            base.Dispose(disposing);
        }

        private void InitializeComponent()
        {
            this.lblBackup_593CM = new System.Windows.Forms.Label();
            this.txtBackup_593CM = new System.Windows.Forms.TextBox();
            this.btnSeleccionarBackup_593CM = new System.Windows.Forms.Button();
            this.btnCrearBackup_593CM = new System.Windows.Forms.Button();
            this.lblRestore_593CM = new System.Windows.Forms.Label();
            this.txtRestore_593CM = new System.Windows.Forms.TextBox();
            this.btnSeleccionarRestore_593CM = new System.Windows.Forms.Button();
            this.btnRestaurar_593CM = new System.Windows.Forms.Button();
            this.SuspendLayout();
            //
            // lblBackup_593CM
            //
            this.lblBackup_593CM.AutoSize = true;
            this.lblBackup_593CM.Location = new System.Drawing.Point(12, 20);
            this.lblBackup_593CM.Name = "lblBackup_593CM";
            this.lblBackup_593CM.Size = new System.Drawing.Size(145, 13);
            this.lblBackup_593CM.TabIndex = 0;
            this.lblBackup_593CM.Text = "Crear copia de seguridad:";
            //
            // txtBackup_593CM
            //
            this.txtBackup_593CM.Location = new System.Drawing.Point(12, 40);
            this.txtBackup_593CM.Name = "txtBackup_593CM";
            this.txtBackup_593CM.Size = new System.Drawing.Size(330, 20);
            this.txtBackup_593CM.TabIndex = 1;
            //
            // btnSeleccionarBackup_593CM
            //
            this.btnSeleccionarBackup_593CM.Location = new System.Drawing.Point(348, 38);
            this.btnSeleccionarBackup_593CM.Name = "btnSeleccionarBackup_593CM";
            this.btnSeleccionarBackup_593CM.Size = new System.Drawing.Size(80, 24);
            this.btnSeleccionarBackup_593CM.TabIndex = 2;
            this.btnSeleccionarBackup_593CM.Text = "Examinar...";
            this.btnSeleccionarBackup_593CM.UseVisualStyleBackColor = true;
            this.btnSeleccionarBackup_593CM.Click += new System.EventHandler(this.btnSeleccionarBackup_Click_593CM);
            //
            // btnCrearBackup_593CM
            //
            this.btnCrearBackup_593CM.Location = new System.Drawing.Point(12, 70);
            this.btnCrearBackup_593CM.Name = "btnCrearBackup_593CM";
            this.btnCrearBackup_593CM.Size = new System.Drawing.Size(110, 30);
            this.btnCrearBackup_593CM.TabIndex = 3;
            this.btnCrearBackup_593CM.Text = "Crear .bkp";
            this.btnCrearBackup_593CM.UseVisualStyleBackColor = true;
            this.btnCrearBackup_593CM.Click += new System.EventHandler(this.btnCrearBackup_Click_593CM);
            //
            // lblRestore_593CM
            //
            this.lblRestore_593CM.AutoSize = true;
            this.lblRestore_593CM.Location = new System.Drawing.Point(12, 120);
            this.lblRestore_593CM.Name = "lblRestore_593CM";
            this.lblRestore_593CM.Size = new System.Drawing.Size(126, 13);
            this.lblRestore_593CM.TabIndex = 4;
            this.lblRestore_593CM.Text = "Restaurar desde copia:";
            //
            // txtRestore_593CM
            //
            this.txtRestore_593CM.Location = new System.Drawing.Point(12, 140);
            this.txtRestore_593CM.Name = "txtRestore_593CM";
            this.txtRestore_593CM.Size = new System.Drawing.Size(330, 20);
            this.txtRestore_593CM.TabIndex = 5;
            //
            // btnSeleccionarRestore_593CM
            //
            this.btnSeleccionarRestore_593CM.Location = new System.Drawing.Point(348, 138);
            this.btnSeleccionarRestore_593CM.Name = "btnSeleccionarRestore_593CM";
            this.btnSeleccionarRestore_593CM.Size = new System.Drawing.Size(80, 24);
            this.btnSeleccionarRestore_593CM.TabIndex = 6;
            this.btnSeleccionarRestore_593CM.Text = "Examinar...";
            this.btnSeleccionarRestore_593CM.UseVisualStyleBackColor = true;
            this.btnSeleccionarRestore_593CM.Click += new System.EventHandler(this.btnSeleccionarRestore_Click_593CM);
            //
            // btnRestaurar_593CM
            //
            this.btnRestaurar_593CM.Location = new System.Drawing.Point(12, 170);
            this.btnRestaurar_593CM.Name = "btnRestaurar_593CM";
            this.btnRestaurar_593CM.Size = new System.Drawing.Size(110, 30);
            this.btnRestaurar_593CM.TabIndex = 7;
            this.btnRestaurar_593CM.Text = "Restaurar";
            this.btnRestaurar_593CM.UseVisualStyleBackColor = true;
            this.btnRestaurar_593CM.Click += new System.EventHandler(this.btnRestaurar_Click_593CM);
            //
            // FormRespaldos_593CM
            //
            this.AutoScaleDimensions = new System.Drawing.SizeF(6F, 13F);
            this.AutoScaleMode = System.Windows.Forms.AutoScaleMode.Font;
            this.ClientSize = new System.Drawing.Size(444, 221);
            this.Controls.Add(this.btnRestaurar_593CM);
            this.Controls.Add(this.btnSeleccionarRestore_593CM);
            this.Controls.Add(this.txtRestore_593CM);
            this.Controls.Add(this.lblRestore_593CM);
            this.Controls.Add(this.btnCrearBackup_593CM);
            this.Controls.Add(this.btnSeleccionarBackup_593CM);
            this.Controls.Add(this.txtBackup_593CM);
            this.Controls.Add(this.lblBackup_593CM);
            this.FormBorderStyle = System.Windows.Forms.FormBorderStyle.FixedDialog;
            this.MaximizeBox = false;
            this.MinimizeBox = false;
            this.Name = "FormRespaldos_593CM";
            this.StartPosition = System.Windows.Forms.FormStartPosition.CenterParent;
            this.Text = "Respaldos";
            this.ResumeLayout(false);
            this.PerformLayout();
        }

        private System.Windows.Forms.Label lblBackup_593CM;
        private System.Windows.Forms.TextBox txtBackup_593CM;
        private System.Windows.Forms.Button btnSeleccionarBackup_593CM;
        private System.Windows.Forms.Button btnCrearBackup_593CM;
        private System.Windows.Forms.Label lblRestore_593CM;
        private System.Windows.Forms.TextBox txtRestore_593CM;
        private System.Windows.Forms.Button btnSeleccionarRestore_593CM;
        private System.Windows.Forms.Button btnRestaurar_593CM;
    }
}
