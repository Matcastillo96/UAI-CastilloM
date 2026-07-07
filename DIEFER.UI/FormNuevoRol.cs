using System;
using System.Collections.Generic;
using System.Linq;
using System.Windows.Forms;
using DIEFER.BLL;
using DIEFER.Servicios;

namespace DIEFER.UI
{
    public partial class FormNuevoRol_593CM : Form, IIdiomaObserver_593CM
    {
        private readonly PerfilesBLL_593CM _perfilesBLL;
        private readonly RolBLL_593CM _rolBLL;

        public int IdRolCreado_593CM { get; private set; } = -1;

        private class PatenteItem
        {
            public Patente_593CM Patente { get; }
            public PatenteItem(Patente_593CM patente) { Patente = patente; }
            public override string ToString() => Patente.Nombre_593CM;
        }

        private class FamiliaItem
        {
            public Familia_593CM Familia { get; }
            public FamiliaItem(Familia_593CM familia) { Familia = familia; }
            public override string ToString() => Familia.Nombre_593CM;
        }

        public FormNuevoRol_593CM()
        {
            InitializeComponent();
            _perfilesBLL = new PerfilesBLL_593CM();
            _rolBLL = new RolBLL_593CM();
        }

        protected override void OnLoad(EventArgs e)
        {
            base.OnLoad(e);
            IdiomaService_593CM.GetInstancia_593CM().Suscribir_593CM(this);
            CargarListas_593CM();
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

            Text = Get_593CM(textos, "form_nuevo_rol_titulo", "Nuevo Rol");
            lblNombre_593CM.Text = Get_593CM(textos, "form_nuevo_rol_nombre", "Nombre:");
            gbPatentes_593CM.Text = Get_593CM(textos, "form_nuevo_rol_patentes", "Patentes");
            gbFamilias_593CM.Text = Get_593CM(textos, "form_nuevo_rol_familias", "Familias");
            lblAyuda_593CM.Text = Get_593CM(textos, "form_nuevo_rol_ayuda", "Seleccione al menos una patente o familia.");
            btnCrear_593CM.Text = Get_593CM(textos, "btn_crear", "Crear");
            btnCancelar_593CM.Text = Get_593CM(textos, "btn_cancelar", "Cancelar");
        }

        private static string Get_593CM(Dictionary<string, string> t, string k, string def)
            => t.TryGetValue(k, out var v) ? v : def;

        private void CargarListas_593CM()
        {
            chkPatentes_593CM.Items.Clear();
            foreach (var p in _perfilesBLL.GetDisponiblesParaRol_593CM(-1).OfType<Patente_593CM>())
                chkPatentes_593CM.Items.Add(new PatenteItem(p), false);

            chkFamilias_593CM.Items.Clear();
            foreach (var f in _perfilesBLL.GetDisponiblesParaRol_593CM(-1).OfType<Familia_593CM>())
                chkFamilias_593CM.Items.Add(new FamiliaItem(f), false);
        }

        private void ValidarEstadoBoton_593CM()
        {
            bool tieneNombre = !string.IsNullOrWhiteSpace(txtNombre_593CM.Text);
            bool tienePermiso = chkPatentes_593CM.CheckedItems.Count > 0 ||
                                chkFamilias_593CM.CheckedItems.Count > 0;
            btnCrear_593CM.Enabled = tieneNombre && tienePermiso;
        }

        private void txtNombre_TextChanged_593CM(object sender, EventArgs e)
        {
            ValidarEstadoBoton_593CM();
        }

        private void chkPatentes_ItemCheck_593CM(object sender, ItemCheckEventArgs e)
        {
            BeginInvoke(new Action(ValidarEstadoBoton_593CM));
        }

        private void chkFamilias_ItemCheck_593CM(object sender, ItemCheckEventArgs e)
        {
            BeginInvoke(new Action(ValidarEstadoBoton_593CM));
        }

        private void btnCrear_Click_593CM(object sender, EventArgs e)
        {
            var idsPatente = chkPatentes_593CM.CheckedItems
                .Cast<PatenteItem>()
                .Select(p => p.Patente.ID_patente_593CM)
                .ToList();

            var idsFamilia = chkFamilias_593CM.CheckedItems
                .Cast<FamiliaItem>()
                .Select(f => f.Familia.ID_familia_593CM)
                .ToList();

            var resultado = _rolBLL.CrearRolConPermisos_593CM(
                txtNombre_593CM.Text.Trim(), idsPatente, idsFamilia, out int idCreado);

            switch (resultado)
            {
                case RolBLL_593CM.ResultadoCrearRol_593CM.Exitoso:
                    IdRolCreado_593CM = idCreado;
                    MessageBox.Show("Rol creado correctamente.", "Nuevo Rol",
                                    MessageBoxButtons.OK, MessageBoxIcon.Information);
                    DialogResult = DialogResult.OK;
                    Close();
                    break;

                case RolBLL_593CM.ResultadoCrearRol_593CM.NombreRequerido:
                    MessageBox.Show("El nombre es obligatorio.", "Validación",
                                    MessageBoxButtons.OK, MessageBoxIcon.Warning);
                    break;

                case RolBLL_593CM.ResultadoCrearRol_593CM.PermisoRequerido:
                    MessageBox.Show("Debe seleccionar al menos una patente o familia.", "Validación",
                                    MessageBoxButtons.OK, MessageBoxIcon.Warning);
                    break;

                case RolBLL_593CM.ResultadoCrearRol_593CM.NombreDuplicado:
                    MessageBox.Show("Ya existe un rol con ese nombre.", "Validación",
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
