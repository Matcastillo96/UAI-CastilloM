namespace DIEFER.UI
{
    partial class FormReparacionDV_593CM
    {
        private System.ComponentModel.IContainer components = null;

        protected override void Dispose(bool disposing)
        {
            if (disposing && (components != null)) components.Dispose();
            base.Dispose(disposing);
        }

        private void InitializeComponent()
        {
            this.lblTitulo_593CM = new System.Windows.Forms.Label();
            this.lblAfectadas_593CM = new System.Windows.Forms.Label();
            this.lstTablas_593CM = new System.Windows.Forms.ListBox();
            this.btnRecalcular_593CM = new System.Windows.Forms.Button();
            this.btnRestore_593CM = new System.Windows.Forms.Button();
            this.btnSalir_593CM = new System.Windows.Forms.Button();
            this.SuspendLayout();
            //
            // lblTitulo_593CM
            //
            this.lblTitulo_593CM.AutoSize = true;
            this.lblTitulo_593CM.Font = new System.Drawing.Font("Microsoft Sans Serif", 10F, System.Drawing.FontStyle.Bold);
            this.lblTitulo_593CM.Location = new System.Drawing.Point(12, 9);
            this.lblTitulo_593CM.Name = "lblTitulo_593CM";
            this.lblTitulo_593CM.Size = new System.Drawing.Size(160, 17);
            this.lblTitulo_593CM.TabIndex = 0;
            this.lblTitulo_593CM.Text = "Reparar Integridad";
            //
            // lblAfectadas_593CM
            //
            this.lblAfectadas_593CM.AutoSize = true;
            this.lblAfectadas_593CM.Location = new System.Drawing.Point(12, 40);
            this.lblAfectadas_593CM.Name = "lblAfectadas_593CM";
            this.lblAfectadas_593CM.Size = new System.Drawing.Size(99, 13);
            this.lblAfectadas_593CM.TabIndex = 1;
            this.lblAfectadas_593CM.Text = "Tablas afectadas:";
            //
            // lstTablas_593CM
            //
            this.lstTablas_593CM.FormattingEnabled = true;
            this.lstTablas_593CM.Location = new System.Drawing.Point(12, 60);
            this.lstTablas_593CM.Name = "lstTablas_593CM";
            this.lstTablas_593CM.Size = new System.Drawing.Size(360, 160);
            this.lstTablas_593CM.TabIndex = 2;
            //
            // btnRecalcular_593CM
            //
            this.btnRecalcular_593CM.Location = new System.Drawing.Point(12, 235);
            this.btnRecalcular_593CM.Name = "btnRecalcular_593CM";
            this.btnRecalcular_593CM.Size = new System.Drawing.Size(110, 30);
            this.btnRecalcular_593CM.TabIndex = 3;
            this.btnRecalcular_593CM.Text = "Recalcular DV";
            this.btnRecalcular_593CM.UseVisualStyleBackColor = true;
            this.btnRecalcular_593CM.Click += new System.EventHandler(this.btnRecalcular_Click_593CM);
            //
            // btnRestore_593CM
            //
            this.btnRestore_593CM.Location = new System.Drawing.Point(137, 235);
            this.btnRestore_593CM.Name = "btnRestore_593CM";
            this.btnRestore_593CM.Size = new System.Drawing.Size(110, 30);
            this.btnRestore_593CM.TabIndex = 4;
            this.btnRestore_593CM.Text = "Restore DB";
            this.btnRestore_593CM.UseVisualStyleBackColor = true;
            this.btnRestore_593CM.Click += new System.EventHandler(this.btnRestore_Click_593CM);
            //
            // btnSalir_593CM
            //
            this.btnSalir_593CM.Location = new System.Drawing.Point(262, 235);
            this.btnSalir_593CM.Name = "btnSalir_593CM";
            this.btnSalir_593CM.Size = new System.Drawing.Size(110, 30);
            this.btnSalir_593CM.TabIndex = 5;
            this.btnSalir_593CM.Text = "Salir";
            this.btnSalir_593CM.UseVisualStyleBackColor = true;
            this.btnSalir_593CM.Click += new System.EventHandler(this.btnSalir_Click_593CM);
            //
            // FormReparacionDV_593CM
            //
            this.AutoScaleDimensions = new System.Drawing.SizeF(6F, 13F);
            this.AutoScaleMode = System.Windows.Forms.AutoScaleMode.Font;
            this.ClientSize = new System.Drawing.Size(384, 281);
            this.Controls.Add(this.btnSalir_593CM);
            this.Controls.Add(this.btnRestore_593CM);
            this.Controls.Add(this.btnRecalcular_593CM);
            this.Controls.Add(this.lstTablas_593CM);
            this.Controls.Add(this.lblAfectadas_593CM);
            this.Controls.Add(this.lblTitulo_593CM);
            this.FormBorderStyle = System.Windows.Forms.FormBorderStyle.FixedDialog;
            this.MaximizeBox = false;
            this.MinimizeBox = false;
            this.Name = "FormReparacionDV_593CM";
            this.StartPosition = System.Windows.Forms.FormStartPosition.CenterParent;
            this.Text = "Reparar Integridad";
            this.ResumeLayout(false);
            this.PerformLayout();
        }

        private System.Windows.Forms.Label lblTitulo_593CM;
        private System.Windows.Forms.Label lblAfectadas_593CM;
        private System.Windows.Forms.ListBox lstTablas_593CM;
        private System.Windows.Forms.Button btnRecalcular_593CM;
        private System.Windows.Forms.Button btnRestore_593CM;
        private System.Windows.Forms.Button btnSalir_593CM;
    }
}
