using System.Windows.Forms;
using DIEFER.BLL;
using DIEFER.Servicios;

namespace DIEFER.UI
{
    // Ventana sencilla que permite al usuario elegir su idioma preferido.
    // Persiste la elección en la base de datos y notifica al IdiomaService (Observer).
    public partial class FormCambiarIdioma_593CM : Form
    {
        private readonly UsuarioBLL_593CM _usuarioBLL_593CM;

        public FormCambiarIdioma_593CM()
        {
            InitializeComponent();
            _usuarioBLL_593CM = new UsuarioBLL_593CM();

            var svc     = IdiomaService_593CM.GetInstancia_593CM();
            var idiomas = svc.IdiomasDisponibles_593CM();
            string actual = svc.CodigoActual_593CM;

            foreach (var kv in idiomas)
            {
                int idx = cboIdiomas_593CM.Items.Add(new IdiomaItem_593CM(kv.Key, kv.Value));
                if (kv.Key == actual)
                    cboIdiomas_593CM.SelectedIndex = idx;
            }

            // Actualizar texto del label según idioma activo
            lblSeleccione_593CM.Text = svc.ObtenerTexto_593CM("form_cambiar_idioma_label", "Seleccione un idioma:");
            Text                     = svc.ObtenerTexto_593CM("form_cambiar_idioma_titulo", "Cambiar Idioma");
            btnAceptar_593CM.Text    = svc.ObtenerTexto_593CM("btn_aceptar", "Aceptar");
            btnCancelar_593CM.Text   = svc.ObtenerTexto_593CM("btn_cancelar", "Cancelar");
        }

        private void btnAceptar_Click_593CM(object sender, System.EventArgs e)
        {
            if (cboIdiomas_593CM.SelectedItem is IdiomaItem_593CM item)
                _usuarioBLL_593CM.CambiarIdioma_593CM(item.Codigo);
        }

        private void btnCancelar_Click_593CM(object sender, System.EventArgs e) => Close();
    }

    // DTO interno para el ComboBox — muestra el nombre pero guarda el código.
    internal sealed class IdiomaItem_593CM
    {
        public string Codigo { get; }
        public string Nombre { get; }

        public IdiomaItem_593CM(string codigo, string nombre)
        {
            Codigo = codigo;
            Nombre = nombre;
        }

        public override string ToString() => Nombre;
    }
}
