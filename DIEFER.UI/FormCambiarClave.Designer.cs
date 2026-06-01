namespace DIEFER.UI
{
    partial class FormCambiarClave_593CM
    {
        private System.ComponentModel.IContainer components_593CM = null;

        protected override void Dispose(bool disposing)
        {
            if (disposing && components_593CM != null)
            {
                components_593CM.Dispose();
            }

            base.Dispose(disposing);
        }

        private void InitializeComponent()
        {
            this.lblTitulo_593CM = new System.Windows.Forms.Label();
            this.lblActual_593CM = new System.Windows.Forms.Label();
            this.txtActual_593CM = new System.Windows.Forms.TextBox();
            this.lblNueva_593CM = new System.Windows.Forms.Label();
            this.txtNueva_593CM = new System.Windows.Forms.TextBox();
            this.lblConfirmar_593CM = new System.Windows.Forms.Label();
            this.txtConfirmar_593CM = new System.Windows.Forms.TextBox();
            this.btnActualizar_593CM = new System.Windows.Forms.Button();
            this.btnCancelar_593CM = new System.Windows.Forms.Button();
            this.lblError_593CM = new System.Windows.Forms.Label();
            this.SuspendLayout();

            // 
            // lblTitulo_593CM
            // 
            this.lblTitulo_593CM.Font = new System.Drawing.Font("Arial", 11F, System.Drawing.FontStyle.Bold);
            this.lblTitulo_593CM.Location = new System.Drawing.Point(20, 15);
            this.lblTitulo_593CM.Name = "lblTitulo_593CM";
            this.lblTitulo_593CM.Size = new System.Drawing.Size(350, 25);
            this.lblTitulo_593CM.TabIndex = 0;
            this.lblTitulo_593CM.Text = "Cambiar mi clave";

            // 
            // lblActual_593CM
            // 
            this.lblActual_593CM.Font = new System.Drawing.Font("Arial", 9F);
            this.lblActual_593CM.Location = new System.Drawing.Point(20, 62);
            this.lblActual_593CM.Name = "lblActual_593CM";
            this.lblActual_593CM.Size = new System.Drawing.Size(145, 22);
            this.lblActual_593CM.TabIndex = 1;
            this.lblActual_593CM.Text = "Clave actual:";

            // 
            // txtActual_593CM
            // 
            this.txtActual_593CM.Location = new System.Drawing.Point(170, 60);
            this.txtActual_593CM.MaxLength = 50;
            this.txtActual_593CM.Name = "txtActual_593CM";
            this.txtActual_593CM.PasswordChar = '*';
            this.txtActual_593CM.Size = new System.Drawing.Size(200, 20);
            this.txtActual_593CM.TabIndex = 2;

            // 
            // lblNueva_593CM
            // 
            this.lblNueva_593CM.Font = new System.Drawing.Font("Arial", 9F);
            this.lblNueva_593CM.Location = new System.Drawing.Point(20, 97);
            this.lblNueva_593CM.Name = "lblNueva_593CM";
            this.lblNueva_593CM.Size = new System.Drawing.Size(145, 22);
            this.lblNueva_593CM.TabIndex = 3;
            this.lblNueva_593CM.Text = "Nueva clave:";

            // 
            // txtNueva_593CM
            // 
            this.txtNueva_593CM.Location = new System.Drawing.Point(170, 95);
            this.txtNueva_593CM.MaxLength = 50;
            this.txtNueva_593CM.Name = "txtNueva_593CM";
            this.txtNueva_593CM.PasswordChar = '*';
            this.txtNueva_593CM.Size = new System.Drawing.Size(200, 20);
            this.txtNueva_593CM.TabIndex = 4;

            // 
            // lblConfirmar_593CM
            // 
            this.lblConfirmar_593CM.Font = new System.Drawing.Font("Arial", 9F);
            this.lblConfirmar_593CM.Location = new System.Drawing.Point(20, 132);
            this.lblConfirmar_593CM.Name = "lblConfirmar_593CM";
            this.lblConfirmar_593CM.Size = new System.Drawing.Size(145, 22);
            this.lblConfirmar_593CM.TabIndex = 5;
            this.lblConfirmar_593CM.Text = "Confirmar nueva:";

            // 
            // txtConfirmar_593CM
            // 
            this.txtConfirmar_593CM.Location = new System.Drawing.Point(170, 130);
            this.txtConfirmar_593CM.MaxLength = 50;
            this.txtConfirmar_593CM.Name = "txtConfirmar_593CM";
            this.txtConfirmar_593CM.PasswordChar = '*';
            this.txtConfirmar_593CM.Size = new System.Drawing.Size(200, 20);
            this.txtConfirmar_593CM.TabIndex = 6;

            // 
            // btnActualizar_593CM
            // 
            this.btnActualizar_593CM.Font = new System.Drawing.Font("Arial", 9F);
            this.btnActualizar_593CM.Location = new System.Drawing.Point(60, 175);
            this.btnActualizar_593CM.Name = "btnActualizar_593CM";
            this.btnActualizar_593CM.Size = new System.Drawing.Size(110, 32);
            this.btnActualizar_593CM.TabIndex = 7;
            this.btnActualizar_593CM.Text = "Actualizar";
            this.btnActualizar_593CM.UseVisualStyleBackColor = true;
            this.btnActualizar_593CM.Click += new System.EventHandler(this.btnActualizar_Click_593CM);

            // 
            // btnCancelar_593CM
            // 
            this.btnCancelar_593CM.Font = new System.Drawing.Font("Arial", 9F);
            this.btnCancelar_593CM.Location = new System.Drawing.Point(185, 175);
            this.btnCancelar_593CM.Name = "btnCancelar_593CM";
            this.btnCancelar_593CM.Size = new System.Drawing.Size(90, 32);
            this.btnCancelar_593CM.TabIndex = 8;
            this.btnCancelar_593CM.Text = "Cancelar";
            this.btnCancelar_593CM.UseVisualStyleBackColor = true;
            this.btnCancelar_593CM.Click += new System.EventHandler(this.btnCancelar_Click_593CM);

            // 
            // lblError_593CM
            // 
            this.lblError_593CM.Font = new System.Drawing.Font("Arial", 8F);
            this.lblError_593CM.ForeColor = System.Drawing.Color.Red;
            this.lblError_593CM.Location = new System.Drawing.Point(20, 218);
            this.lblError_593CM.Name = "lblError_593CM";
            this.lblError_593CM.Size = new System.Drawing.Size(360, 40);
            this.lblError_593CM.TabIndex = 9;
            this.lblError_593CM.Visible = false;

            // 
            // FormCambiarClave_593CM
            // 
            this.AutoScaleDimensions = new System.Drawing.SizeF(6F, 13F);
            this.AutoScaleMode = System.Windows.Forms.AutoScaleMode.Font;
            this.ClientSize = new System.Drawing.Size(400, 275);
            this.Controls.Add(this.lblTitulo_593CM);
            this.Controls.Add(this.lblActual_593CM);
            this.Controls.Add(this.txtActual_593CM);
            this.Controls.Add(this.lblNueva_593CM);
            this.Controls.Add(this.txtNueva_593CM);
            this.Controls.Add(this.lblConfirmar_593CM);
            this.Controls.Add(this.txtConfirmar_593CM);
            this.Controls.Add(this.btnActualizar_593CM);
            this.Controls.Add(this.btnCancelar_593CM);
            this.Controls.Add(this.lblError_593CM);
            this.FormBorderStyle = System.Windows.Forms.FormBorderStyle.FixedDialog;
            this.MaximizeBox = false;
            this.MinimizeBox = false;
            this.Name = "FormCambiarClave_593CM";
            this.StartPosition = System.Windows.Forms.FormStartPosition.CenterParent;
            this.Text = "Cambiar Clave";
            this.ResumeLayout(false);
            this.PerformLayout();
        }

        private System.Windows.Forms.Label lblTitulo_593CM;
        private System.Windows.Forms.Label lblActual_593CM;
        private System.Windows.Forms.TextBox txtActual_593CM;
        private System.Windows.Forms.Label lblNueva_593CM;
        private System.Windows.Forms.TextBox txtNueva_593CM;
        private System.Windows.Forms.Label lblConfirmar_593CM;
        private System.Windows.Forms.TextBox txtConfirmar_593CM;
        private System.Windows.Forms.Button btnActualizar_593CM;
        private System.Windows.Forms.Button btnCancelar_593CM;
        private System.Windows.Forms.Label lblError_593CM;
    }
}