namespace DIEFER.UI
{
    partial class FormLogin_593CM
    {
        private System.ComponentModel.IContainer components_593CM = null;

        protected override void Dispose(bool disposing)
        {
            if (disposing && components_593CM != null) components_593CM.Dispose();
            base.Dispose(disposing);
        }

        private void InitializeComponent()
        {
            this.pnlCentro_593CM    = new System.Windows.Forms.Panel();
            this.lblTitulo_593CM    = new System.Windows.Forms.Label();
            this.lblSubtitulo_593CM = new System.Windows.Forms.Label();
            this.lblLogin_593CM     = new System.Windows.Forms.Label();
            this.txtLogin_593CM     = new System.Windows.Forms.TextBox();
            this.lblPassword_593CM  = new System.Windows.Forms.Label();
            this.txtPassword_593CM  = new System.Windows.Forms.TextBox();
            this.btnEntrar_593CM    = new System.Windows.Forms.Button();
            this.lblError_593CM     = new System.Windows.Forms.Label();
            this.pnlCentro_593CM.SuspendLayout();
            this.SuspendLayout();

            // pnlCentro_593CM
            this.pnlCentro_593CM.BackColor = System.Drawing.Color.White;
            this.pnlCentro_593CM.BorderStyle = System.Windows.Forms.BorderStyle.FixedSingle;
            this.pnlCentro_593CM.Controls.Add(this.lblTitulo_593CM);
            this.pnlCentro_593CM.Controls.Add(this.lblSubtitulo_593CM);
            this.pnlCentro_593CM.Controls.Add(this.lblLogin_593CM);
            this.pnlCentro_593CM.Controls.Add(this.txtLogin_593CM);
            this.pnlCentro_593CM.Controls.Add(this.lblPassword_593CM);
            this.pnlCentro_593CM.Controls.Add(this.txtPassword_593CM);
            this.pnlCentro_593CM.Controls.Add(this.btnEntrar_593CM);
            this.pnlCentro_593CM.Controls.Add(this.lblError_593CM);
            this.pnlCentro_593CM.Location = new System.Drawing.Point(50, 40);
            this.pnlCentro_593CM.Size     = new System.Drawing.Size(360, 300);

            // lblTitulo_593CM
            this.lblTitulo_593CM.Font      = new System.Drawing.Font("Arial", 16, System.Drawing.FontStyle.Bold);
            this.lblTitulo_593CM.ForeColor = System.Drawing.Color.FromArgb(0, 70, 127);
            this.lblTitulo_593CM.Location  = new System.Drawing.Point(20, 20);
            this.lblTitulo_593CM.Size      = new System.Drawing.Size(320, 35);
            this.lblTitulo_593CM.Text      = "DIEFER";
            this.lblTitulo_593CM.TextAlign = System.Drawing.ContentAlignment.MiddleCenter;

            // lblSubtitulo_593CM
            this.lblSubtitulo_593CM.Font      = new System.Drawing.Font("Arial", 9);
            this.lblSubtitulo_593CM.ForeColor = System.Drawing.Color.Gray;
            this.lblSubtitulo_593CM.Location  = new System.Drawing.Point(20, 55);
            this.lblSubtitulo_593CM.Size      = new System.Drawing.Size(320, 20);
            this.lblSubtitulo_593CM.Text      = "Sistema de Gestión — Taller Mecánico";
            this.lblSubtitulo_593CM.TextAlign = System.Drawing.ContentAlignment.MiddleCenter;

            // lblLogin_593CM
            this.lblLogin_593CM.Location = new System.Drawing.Point(30, 100);
            this.lblLogin_593CM.Size     = new System.Drawing.Size(70, 20);
            this.lblLogin_593CM.Text     = "Login:";
            this.lblLogin_593CM.Font     = new System.Drawing.Font("Arial", 9);

            // txtLogin_593CM
            this.txtLogin_593CM.Location  = new System.Drawing.Point(110, 97);
            this.txtLogin_593CM.Size      = new System.Drawing.Size(220, 22);
            this.txtLogin_593CM.Font      = new System.Drawing.Font("Arial", 9);
            this.txtLogin_593CM.MaxLength = 100;

            // lblPassword_593CM
            this.lblPassword_593CM.Location = new System.Drawing.Point(30, 140);
            this.lblPassword_593CM.Size     = new System.Drawing.Size(70, 20);
            this.lblPassword_593CM.Text     = "Password:";
            this.lblPassword_593CM.Font     = new System.Drawing.Font("Arial", 9);

            // txtPassword_593CM
            this.txtPassword_593CM.Location     = new System.Drawing.Point(110, 137);
            this.txtPassword_593CM.Size         = new System.Drawing.Size(220, 22);
            this.txtPassword_593CM.Font         = new System.Drawing.Font("Arial", 9);
            this.txtPassword_593CM.PasswordChar = '*';
            this.txtPassword_593CM.MaxLength    = 100;
            this.txtPassword_593CM.KeyDown     += new System.Windows.Forms.KeyEventHandler(this.txtPassword_KeyDown_593CM);

            // btnEntrar_593CM
            this.btnEntrar_593CM.Location  = new System.Drawing.Point(110, 185);
            this.btnEntrar_593CM.Size      = new System.Drawing.Size(130, 32);
            this.btnEntrar_593CM.Text      = "Entrar";
            this.btnEntrar_593CM.Font      = new System.Drawing.Font("Arial", 10, System.Drawing.FontStyle.Bold);
            this.btnEntrar_593CM.BackColor = System.Drawing.Color.FromArgb(0, 70, 127);
            this.btnEntrar_593CM.ForeColor = System.Drawing.Color.White;
            this.btnEntrar_593CM.FlatStyle = System.Windows.Forms.FlatStyle.Flat;
            this.btnEntrar_593CM.Click    += new System.EventHandler(this.btnEntrar_Click_593CM);

            // lblError_593CM
            this.lblError_593CM.ForeColor  = System.Drawing.Color.Red;
            this.lblError_593CM.Font       = new System.Drawing.Font("Arial", 8);
            this.lblError_593CM.Location   = new System.Drawing.Point(20, 240);
            this.lblError_593CM.Size       = new System.Drawing.Size(320, 40);
            this.lblError_593CM.TextAlign  = System.Drawing.ContentAlignment.TopCenter;
            this.lblError_593CM.Visible    = false;

            // FormLogin_593CM
            this.AutoScaleDimensions = new System.Drawing.SizeF(6F, 13F);
            this.AutoScaleMode       = System.Windows.Forms.AutoScaleMode.Font;
            this.BackColor           = System.Drawing.Color.FromArgb(230, 237, 245);
            this.ClientSize          = new System.Drawing.Size(460, 380);
            this.Controls.Add(this.pnlCentro_593CM);
            this.FormBorderStyle     = System.Windows.Forms.FormBorderStyle.FixedDialog;
            this.MaximizeBox         = false;
            this.MinimizeBox         = false;
            this.Name                = "FormLogin_593CM";
            this.StartPosition       = System.Windows.Forms.FormStartPosition.CenterScreen;
            this.Text                = "DIEFER — Ingreso";

            this.pnlCentro_593CM.ResumeLayout(false);
            this.ResumeLayout(false);
        }

        private System.Windows.Forms.Panel     pnlCentro_593CM;
        private System.Windows.Forms.Label     lblTitulo_593CM;
        private System.Windows.Forms.Label     lblSubtitulo_593CM;
        private System.Windows.Forms.Label     lblLogin_593CM;
        private System.Windows.Forms.TextBox   txtLogin_593CM;
        private System.Windows.Forms.Label     lblPassword_593CM;
        private System.Windows.Forms.TextBox   txtPassword_593CM;
        private System.Windows.Forms.Button    btnEntrar_593CM;
        private System.Windows.Forms.Label     lblError_593CM;
    }
}
