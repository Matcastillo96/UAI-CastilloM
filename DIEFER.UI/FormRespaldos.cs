using System;
using System.Collections.Generic;
using System.Windows.Forms;
using DIEFER.BLL;
using DIEFER.Servicios;

namespace DIEFER.UI
{
    /// <summary>
    /// Formulario de respaldos: crear copia de seguridad y restaurar la BD.
    /// </summary>
    public partial class FormRespaldos_593CM : Form, IIdiomaObserver_593CM
    {
        private readonly BackupBLL_593CM _backupBLL_593CM;

        public FormRespaldos_593CM()
        {
            InitializeComponent();
            _backupBLL_593CM = new BackupBLL_593CM();
        }

        protected override void OnLoad(EventArgs e)
        {
            base.OnLoad(e);
            IdiomaService_593CM.GetInstancia_593CM().Suscribir_593CM(this);
        }

        protected override void OnFormClosed(FormClosedEventArgs e)
        {
            IdiomaService_593CM.GetInstancia_593CM().Desuscribir_593CM(this);
            base.OnFormClosed(e);
        }

        public void OnIdiomaChanged_593CM(string codigo, Dictionary<string, string> textos)
        {
            if (InvokeRequired) { Invoke(new Action(() => OnIdiomaChanged_593CM(codigo, textos))); return; }

            Text = Get_593CM(textos, "form_respaldos_titulo", "Respaldos");
            lblBackup_593CM.Text = Get_593CM(textos, "form_respaldos_backup", "Crear copia de seguridad:");
            lblRestore_593CM.Text = Get_593CM(textos, "form_respaldos_restore", "Restaurar desde copia:");
            btnSeleccionarBackup_593CM.Text = Get_593CM(textos, "btn_examinar", "Examinar...");
            btnSeleccionarRestore_593CM.Text = Get_593CM(textos, "btn_examinar", "Examinar...");
            btnCrearBackup_593CM.Text = Get_593CM(textos, "form_respaldos_btn_crear", "Crear .bkp");
            btnRestaurar_593CM.Text = Get_593CM(textos, "form_respaldos_btn_restaurar", "Restaurar");
        }

        private static string Get_593CM(Dictionary<string, string> t, string k, string def)
            => t.TryGetValue(k, out var v) ? v : def;

        private void btnSeleccionarBackup_Click_593CM(object sender, EventArgs e)
        {
            using (var dlg = new SaveFileDialog())
            {
                dlg.Filter = "Backup SQL Server|*.bkp";
                dlg.Title = "Guardar copia de seguridad";
                if (dlg.ShowDialog(this) == DialogResult.OK)
                    txtBackup_593CM.Text = dlg.FileName;
            }
        }

        private void btnSeleccionarRestore_Click_593CM(object sender, EventArgs e)
        {
            using (var dlg = new OpenFileDialog())
            {
                dlg.Filter = "Backup SQL Server|*.bkp|Todos los archivos|*.*";
                dlg.Title = "Seleccionar copia de seguridad";
                if (dlg.ShowDialog(this) == DialogResult.OK)
                    txtRestore_593CM.Text = dlg.FileName;
            }
        }

        private void btnCrearBackup_Click_593CM(object sender, EventArgs e)
        {
            if (string.IsNullOrWhiteSpace(txtBackup_593CM.Text))
            {
                MessageBox.Show("Seleccione una ruta para guardar el backup.", "Validación",
                                MessageBoxButtons.OK, MessageBoxIcon.Warning);
                return;
            }

            try
            {
                _backupBLL_593CM.Backup_593CM(txtBackup_593CM.Text.Trim());
                MessageBox.Show("Copia de seguridad creada correctamente.", "Backup",
                                MessageBoxButtons.OK, MessageBoxIcon.Information);
            }
            catch (Exception ex)
            {
                MessageBox.Show($"Error al crear backup:\n{ex.Message}", "Error",
                                MessageBoxButtons.OK, MessageBoxIcon.Error);
            }
        }

        private void btnRestaurar_Click_593CM(object sender, EventArgs e)
        {
            if (string.IsNullOrWhiteSpace(txtRestore_593CM.Text))
            {
                MessageBox.Show("Seleccione una copia de seguridad para restaurar.", "Validación",
                                MessageBoxButtons.OK, MessageBoxIcon.Warning);
                return;
            }

            var res = MessageBox.Show(
                "La restauración reemplazará la base de datos actual. " +
                "¿Desea continuar?",
                "Confirmar restore",
                MessageBoxButtons.YesNo,
                MessageBoxIcon.Warning);

            if (res != DialogResult.Yes) return;

            try
            {
                _backupBLL_593CM.Restaurar_593CM(txtRestore_593CM.Text.Trim());
                MessageBox.Show("Base de datos restaurada correctamente.", "Restore",
                                MessageBoxButtons.OK, MessageBoxIcon.Information);
            }
            catch (Exception ex)
            {
                MessageBox.Show($"Error al restaurar:\n{ex.Message}", "Error",
                                MessageBoxButtons.OK, MessageBoxIcon.Error);
            }
        }
    }
}
