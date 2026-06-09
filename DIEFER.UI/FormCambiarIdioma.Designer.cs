namespace DIEFER.UI
{
    partial class FormCambiarIdioma_593CM
    {
        private System.ComponentModel.IContainer components = null;

        protected override void Dispose(bool disposing)
        {
            if (disposing && components != null) components.Dispose();
            base.Dispose(disposing);
        }

        private void InitializeComponent()
        {
            this.lblSeleccione_593CM = new System.Windows.Forms.Label();
            this.cboIdiomas_593CM    = new System.Windows.Forms.ComboBox();
            this.btnAceptar_593CM    = new System.Windows.Forms.Button();
            this.btnCancelar_593CM   = new System.Windows.Forms.Button();
            this.SuspendLayout();

            this.lblSeleccione_593CM.Location  = new System.Drawing.Point(12, 16);
            this.lblSeleccione_593CM.Name      = "lblSeleccione_593CM";
            this.lblSeleccione_593CM.Size      = new System.Drawing.Size(280, 20);
            this.lblSeleccione_593CM.Text      = "Seleccione un idioma:";

            this.cboIdiomas_593CM.DropDownStyle = System.Windows.Forms.ComboBoxStyle.DropDownList;
            this.cboIdiomas_593CM.Location      = new System.Drawing.Point(12, 40);
            this.cboIdiomas_593CM.Name          = "cboIdiomas_593CM";
            this.cboIdiomas_593CM.Size          = new System.Drawing.Size(280, 24);

            this.btnAceptar_593CM.Location    = new System.Drawing.Point(136, 80);
            this.btnAceptar_593CM.Name        = "btnAceptar_593CM";
            this.btnAceptar_593CM.Size        = new System.Drawing.Size(75, 28);
            this.btnAceptar_593CM.Text        = "Aceptar";
            this.btnAceptar_593CM.DialogResult = System.Windows.Forms.DialogResult.OK;
            this.btnAceptar_593CM.Click       += new System.EventHandler(this.btnAceptar_Click_593CM);

            this.btnCancelar_593CM.Location    = new System.Drawing.Point(218, 80);
            this.btnCancelar_593CM.Name        = "btnCancelar_593CM";
            this.btnCancelar_593CM.Size        = new System.Drawing.Size(75, 28);
            this.btnCancelar_593CM.Text        = "Cancelar";
            this.btnCancelar_593CM.DialogResult = System.Windows.Forms.DialogResult.Cancel;
            this.btnCancelar_593CM.Click       += new System.EventHandler(this.btnCancelar_Click_593CM);

            this.AutoScaleDimensions = new System.Drawing.SizeF(6F, 13F);
            this.AutoScaleMode       = System.Windows.Forms.AutoScaleMode.Font;
            this.ClientSize          = new System.Drawing.Size(306, 122);
            this.Controls.Add(this.lblSeleccione_593CM);
            this.Controls.Add(this.cboIdiomas_593CM);
            this.Controls.Add(this.btnAceptar_593CM);
            this.Controls.Add(this.btnCancelar_593CM);
            this.FormBorderStyle = System.Windows.Forms.FormBorderStyle.FixedDialog;
            this.MaximizeBox     = false;
            this.MinimizeBox     = false;
            this.Name            = "FormCambiarIdioma_593CM";
            this.StartPosition   = System.Windows.Forms.FormStartPosition.CenterParent;
            this.Text            = "Cambiar Idioma";
            this.AcceptButton    = this.btnAceptar_593CM;
            this.CancelButton    = this.btnCancelar_593CM;
            this.ResumeLayout(false);
        }

        private System.Windows.Forms.Label    lblSeleccione_593CM;
        private System.Windows.Forms.ComboBox cboIdiomas_593CM;
        private System.Windows.Forms.Button   btnAceptar_593CM;
        private System.Windows.Forms.Button   btnCancelar_593CM;
    }
}
