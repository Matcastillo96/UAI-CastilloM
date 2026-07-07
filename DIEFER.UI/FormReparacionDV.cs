using System;
using System.Collections.Generic;
using System.Windows.Forms;
using DIEFER.BLL;
using DIEFER.Servicios;

namespace DIEFER.UI
{
    /// <summary>
    /// CU-103: reparación de integridad tras detectar inconsistencias en el login.
    /// </summary>
    public partial class FormReparacionDV_593CM : Form, IIdiomaObserver_593CM
    {
        private readonly DVBLL_593CM _dvBLL_593CM;
        private readonly BackupBLL_593CM _backupBLL_593CM;
        private List<string> _tablasAfectadas_593CM;

        public FormReparacionDV_593CM(List<string> tablasAfectadas)
        {
            InitializeComponent();
            _dvBLL_593CM = new DVBLL_593CM();
            _backupBLL_593CM = new BackupBLL_593CM();
            _tablasAfectadas_593CM = tablasAfectadas ?? new List<string>();
        }

        protected override void OnLoad(EventArgs e)
        {
            base.OnLoad(e);
            IdiomaService_593CM.GetInstancia_593CM().Suscribir_593CM(this);
            RefrescarLista_593CM();
        }

        protected override void OnFormClosed(FormClosedEventArgs e)
        {
            IdiomaService_593CM.GetInstancia_593CM().Desuscribir_593CM(this);
            base.OnFormClosed(e);
        }

        public void OnIdiomaChanged_593CM(string codigo, Dictionary<string, string> textos)
        {
            if (InvokeRequired) { Invoke(new Action(() => OnIdiomaChanged_593CM(codigo, textos))); return; }

            Text = Get_593CM(textos, "form_reparacion_dv_titulo", "Reparar Integridad");
            lblTitulo_593CM.Text = Get_593CM(textos, "form_reparacion_dv_titulo", "Reparar Integridad");
            lblAfectadas_593CM.Text = Get_593CM(textos, "form_reparacion_dv_afectadas", "Tablas afectadas:");
            btnRecalcular_593CM.Text = Get_593CM(textos, "form_reparacion_dv_recalcular", "Recalcular DV");
            btnRestore_593CM.Text = Get_593CM(textos, "form_reparacion_dv_restore", "Restore DB");
            btnSalir_593CM.Text = Get_593CM(textos, "btn_salir", "Salir");
        }

        private static string Get_593CM(Dictionary<string, string> t, string k, string def)
            => t.TryGetValue(k, out var v) ? v : def;

        private void RefrescarLista_593CM()
        {
            lstTablas_593CM.Items.Clear();
            foreach (var tabla in _tablasAfectadas_593CM)
                lstTablas_593CM.Items.Add(tabla);

            btnRecalcular_593CM.Enabled = _tablasAfectadas_593CM.Count > 0;
        }

        private void btnRecalcular_Click_593CM(object sender, EventArgs e)
        {
            try
            {
                var login = SessionManager_593CM.GetInstancia_593CM().UsuarioActual_593CM?.Login_593CM
                            ?? "Sistema";

                _tablasAfectadas_593CM = _dvBLL_593CM.RecalcularTodo_593CM(login);
                RefrescarLista_593CM();

                if (_tablasAfectadas_593CM.Count == 0)
                {
                    MessageBox.Show(
                        "La integridad fue restablecida. Puede continuar.",
                        "DV restaurado",
                        MessageBoxButtons.OK,
                        MessageBoxIcon.Information);
                }
                else
                {
                    MessageBox.Show(
                        "Persisten inconsistencias tras recalcular. Considere restaurar un backup válido.",
                        "DV inconsistente",
                        MessageBoxButtons.OK,
                        MessageBoxIcon.Warning);
                }
            }
            catch (Exception ex)
            {
                MessageBox.Show($"Error al recalcular DV:\n{ex.Message}", "Error",
                                MessageBoxButtons.OK, MessageBoxIcon.Error);
            }
        }

        private void btnRestore_Click_593CM(object sender, EventArgs e)
        {
            using (var dlg = new OpenFileDialog())
            {
                dlg.Filter = "Backup SQL Server|*.bkp|Todos los archivos|*.*";
                dlg.Title = "Seleccionar copia de seguridad";

                if (dlg.ShowDialog(this) != DialogResult.OK) return;

                try
                {
                    _backupBLL_593CM.Restaurar_593CM(dlg.FileName);

                    _tablasAfectadas_593CM = _dvBLL_593CM.VerificarIntegridad_593CM();
                    RefrescarLista_593CM();

                    if (_tablasAfectadas_593CM.Count == 0)
                    {
                        MessageBox.Show(
                            "Restauración completada. La integridad fue verificada correctamente.",
                            "Restore exitoso",
                            MessageBoxButtons.OK,
                            MessageBoxIcon.Information);
                    }
                    else
                    {
                        MessageBox.Show(
                            "Restauración completada, pero persisten inconsistencias. " +
                            "Utilice Recalcular DV o elija otro backup.",
                            "Restore con advertencias",
                            MessageBoxButtons.OK,
                            MessageBoxIcon.Warning);
                    }
                }
                catch (Exception ex)
                {
                    MessageBox.Show($"Error al restaurar:\n{ex.Message}", "Error",
                                    MessageBoxButtons.OK, MessageBoxIcon.Error);
                }
            }
        }

        private void btnSalir_Click_593CM(object sender, EventArgs e)
        {
            Close();
        }
    }
}
