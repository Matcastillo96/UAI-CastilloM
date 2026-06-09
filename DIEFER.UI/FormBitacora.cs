using System;
using System.Collections.Generic;
using System.Drawing.Printing;
using System.Windows.Forms;
using DIEFER.BE;
using DIEFER.BLL;

namespace DIEFER.UI
{
    public partial class FormBitacora_593CM : Form
    {
        private readonly EventoBLL_593CM  _eventoBLL_593CM;
        private List<Eventos_593CM> _listaVisible_593CM = new List<Eventos_593CM>();

        public FormBitacora_593CM()
        {
            InitializeComponent();
            _eventoBLL_593CM = new EventoBLL_593CM();

            PoblarCombos_593CM();
            CargarDefault_593CM();
        }

        private void PoblarCombos_593CM()
        {
            cboModulo_593CM.Items.Add(string.Empty);
            cboModulo_593CM.Items.AddRange(Catalogos_593CM.Modulos_593CM);

            cboEvento_593CM.Items.Add(string.Empty);
            cboEvento_593CM.Items.AddRange(Catalogos_593CM.GetNombresEvento_593CM());

            cboCriticidad_593CM.Items.Add(string.Empty);
            for (int i = 1; i <= 5; i++) cboCriticidad_593CM.Items.Add(i.ToString());

            cboModulo_593CM.SelectedIndex     = 0;
            cboEvento_593CM.SelectedIndex     = 0;
            cboCriticidad_593CM.SelectedIndex = 0;
        }

        private void CargarDefault_593CM()
        {
            dtpFechaIni_593CM.Value = DateTime.Today.AddDays(-3);
            dtpFechaFin_593CM.Value = DateTime.Today;
            Actualizar_593CM(dtpFechaIni_593CM.Value, dtpFechaFin_593CM.Value, null, null, null, null);
        }

        private void Actualizar_593CM(DateTime? fIni, DateTime? fFin, string login,
                                      string modulo, string evento, int? criticidad)
        {
            _listaVisible_593CM = _eventoBLL_593CM.GetEventos_593CM(fIni, fFin, login, modulo, evento, criticidad);
            dgvEventos_593CM.Rows.Clear();
            foreach (var ev in _listaVisible_593CM)
                dgvEventos_593CM.Rows.Add(ev.Login_593CM, ev.Fecha_593CM.ToString("dd/MM/yyyy"),
                    ev.Hora_593CM.ToString("HH:mm:ss"), ev.Modulo_593CM, ev.Evento_593CM, ev.Criticidad_593CM);

            txtNombre_593CM.Clear();
            txtApellido_593CM.Clear();

            if (_listaVisible_593CM.Count == 0)
                lblEstado_593CM.Text = "No se encontraron eventos para los filtros seleccionados.";
            else
                lblEstado_593CM.Text = $"{_listaVisible_593CM.Count} evento(s) encontrado(s).";
        }

        private void dgvEventos_SelectionChanged_593CM(object sender, EventArgs e)
        {
            if (dgvEventos_593CM.CurrentRow == null) return;
            string login = dgvEventos_593CM.CurrentRow.Cells[0].Value?.ToString();
            if (string.IsNullOrEmpty(login)) return;

            var (nombre, apellido) = _eventoBLL_593CM.GetNombreApellido_593CM(login);
            txtNombre_593CM.Text   = nombre;
            txtApellido_593CM.Text = apellido;
        }

        private void btnAplicar_Click_593CM(object sender, EventArgs e)
        {
            int? crit = null;
            if (!string.IsNullOrEmpty(cboCriticidad_593CM.Text) &&
                int.TryParse(cboCriticidad_593CM.Text, out int c))
                crit = c;

            Actualizar_593CM(
                dtpFechaIni_593CM.Value,
                dtpFechaFin_593CM.Value,
                NullIfEmpty_593CM(txtFiltroLogin_593CM.Text),
                NullIfEmpty_593CM(cboModulo_593CM.Text),
                NullIfEmpty_593CM(cboEvento_593CM.Text),
                crit);
        }

        private void btnLimpiar_Click_593CM(object sender, EventArgs e)
        {
            txtFiltroLogin_593CM.Clear();
            cboModulo_593CM.SelectedIndex     = 0;
            cboEvento_593CM.SelectedIndex     = 0;
            cboCriticidad_593CM.SelectedIndex = 0;
            CargarDefault_593CM();
        }

        private void btnImprimir_Click_593CM(object sender, EventArgs e)
        {
            if (_listaVisible_593CM.Count == 0)
            {
                MessageBox.Show("No hay eventos para imprimir.", "Imprimir",
                    MessageBoxButtons.OK, MessageBoxIcon.Information);
                return;
            }

            var doc = _eventoBLL_593CM.CrearDocumentoDePrint_593CM(_listaVisible_593CM);
            var pd  = new PrintDialog { Document = doc, UseEXDialog = true };
            if (pd.ShowDialog() == DialogResult.OK)
                doc.Print();
        }

        private void btnSalir_Click_593CM(object sender, EventArgs e) => Close();

        private static string NullIfEmpty_593CM(string s) =>
            string.IsNullOrWhiteSpace(s) ? null : s.Trim();
    }
}
