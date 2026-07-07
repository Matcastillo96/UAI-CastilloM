using System;
using System.Collections.Generic;
using System.Linq;
using System.Windows.Forms;
using DIEFER.BLL;
using DIEFER.Servicios;

namespace DIEFER.UI
{
    public partial class FormNuevaFamilia_593CM : Form, IIdiomaObserver_593CM
    {
        private readonly PerfilesBLL_593CM _bll;

        public int IdFamiliaCreada_593CM { get; private set; } = -1;

        private class PatenteItem
        {
            public Patente_593CM Patente { get; }
            public PatenteItem(Patente_593CM patente) { Patente = patente; }
            public override string ToString() => Patente.Nombre_593CM;
        }

        public FormNuevaFamilia_593CM()
        {
            InitializeComponent();
            _bll = new PerfilesBLL_593CM();
        }

        protected override void OnLoad(EventArgs e)
        {
            base.OnLoad(e);
            IdiomaService_593CM.GetInstancia_593CM().Suscribir_593CM(this);
            CargarPatentes_593CM();
            ValidarEstadoBoton_593CM();
        }

        protected override void OnFormClosed(FormClosedEventArgs e)
        {
            IdiomaService_593CM.GetInstancia_593CM().Desuscribir_593CM(this);
            base.OnFormClosed(e);
        }

        public void OnIdiomaChanged_593CM(string codigo, Dictionary<string, string> textos)
        {
            if (InvokeRequired) { Invoke(new Action(() => OnIdiomaChanged_593CM(codigo, textos))); return; }

            Text = Get_593CM(textos, "form_nueva_familia_titulo", "Nueva Familia");
            lblNombre_593CM.Text = Get_593CM(textos, "form_nueva_familia_nombre", "Nombre:");
            lblPatentes_593CM.Text = Get_593CM(textos, "form_nueva_familia_patentes", "Patentes (al menos una):");
            btnCrear_593CM.Text = Get_593CM(textos, "btn_crear", "Crear");
            btnCancelar_593CM.Text = Get_593CM(textos, "btn_cancelar", "Cancelar");
        }

        private static string Get_593CM(Dictionary<string, string> t, string k, string def)
            => t.TryGetValue(k, out var v) ? v : def;

        private void CargarPatentes_593CM()
        {
            var patentes = _bll.GetDisponiblesParaFamilia_593CM(-1)
                .OfType<Patente_593CM>()
                .ToList();

            chkPatentes_593CM.Items.Clear();
            foreach (var p in patentes)
                chkPatentes_593CM.Items.Add(new PatenteItem(p), false);
        }

        private void ValidarEstadoBoton_593CM()
        {
            bool tieneNombre = !string.IsNullOrWhiteSpace(txtNombre_593CM.Text);
            bool tienePatente = chkPatentes_593CM.CheckedItems.Count > 0;
            btnCrear_593CM.Enabled = tieneNombre && tienePatente;
        }

        private void txtNombre_TextChanged_593CM(object sender, EventArgs e)
        {
            ValidarEstadoBoton_593CM();
        }

        private void chkPatentes_ItemCheck_593CM(object sender, ItemCheckEventArgs e)
        {
            // El conteo de CheckedItems no se actualiza hasta después del evento.
            BeginInvoke(new Action(ValidarEstadoBoton_593CM));
        }

        private void btnCrear_Click_593CM(object sender, EventArgs e)
        {
            var idsPatente = chkPatentes_593CM.CheckedItems
                .Cast<PatenteItem>()
                .Select(p => p.Patente.ID_patente_593CM)
                .ToList();

            var resultado = _bll.CrearFamiliaConPatentes_593CM(
                txtNombre_593CM.Text.Trim(), idsPatente, out int idCreado);

            switch (resultado)
            {
                case PerfilesBLL_593CM.ResultadoCrearFamilia_593CM.Exitoso:
                    IdFamiliaCreada_593CM = idCreado;
                    MessageBox.Show("Familia creada correctamente.", "Nueva Familia",
                                    MessageBoxButtons.OK, MessageBoxIcon.Information);
                    DialogResult = DialogResult.OK;
                    Close();
                    break;

                case PerfilesBLL_593CM.ResultadoCrearFamilia_593CM.NombreRequerido:
                    MessageBox.Show("El nombre es obligatorio.", "Validación",
                                    MessageBoxButtons.OK, MessageBoxIcon.Warning);
                    break;

                case PerfilesBLL_593CM.ResultadoCrearFamilia_593CM.PatenteRequerida:
                    MessageBox.Show("Debe seleccionar al menos una patente.", "Validación",
                                    MessageBoxButtons.OK, MessageBoxIcon.Warning);
                    break;

                case PerfilesBLL_593CM.ResultadoCrearFamilia_593CM.NombreDuplicado:
                    MessageBox.Show("Ya existe una familia con ese nombre.", "Validación",
                                    MessageBoxButtons.OK, MessageBoxIcon.Warning);
                    break;
            }
        }

        private void btnCancelar_Click_593CM(object sender, EventArgs e)
        {
            DialogResult = DialogResult.Cancel;
            Close();
        }
    }
}
