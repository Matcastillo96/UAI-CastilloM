using System;
using System.Collections.Generic;
using System.Windows.Forms;
using DIEFER.BLL;
using DIEFER.Servicios;

namespace DIEFER.UI
{
    public partial class FormPerfiles_593CM : Form
    {
        private readonly PerfilesBLL_593CM _bll;
        private readonly RolBLL_593CM      _rolBLL;

        // Wrapper para mostrar nombre en ListBox y guardar el objeto completo.
        private class PermisoItem
        {
            public IPermiso_593CM Permiso { get; }
            public PermisoItem(IPermiso_593CM permiso) { Permiso = permiso; }
            public override string ToString()
            {
                if (Permiso is Patente_593CM p)
                    return $"[Patente] {p.Nombre_593CM}";
                if (Permiso is Familia_593CM f)
                    return $"[Familia] {f.Nombre_593CM}";
                return Permiso.Nombre_593CM;
            }
        }

        public FormPerfiles_593CM()
        {
            InitializeComponent();
            _bll    = new PerfilesBLL_593CM();
            _rolBLL = new RolBLL_593CM();
        }

        // ── Load ─────────────────────────────────────────────────────────────────────

        private void FormPerfiles_Load(object sender, EventArgs e)
        {
            CargarComboFamilias();
            CargarComboRoles();
        }

        private void CargarComboFamilias()
        {
            cmbFamilias.SelectedIndexChanged -= cmbFamilias_SelectedIndexChanged;

            cmbFamilias.DataSource = null;
            cmbFamilias.DisplayMember = "Nombre_593CM";
            cmbFamilias.ValueMember = "ID_familia_593CM";
            cmbFamilias.DataSource = _bll.ListarFamilias_593CM();

            cmbFamilias.SelectedIndexChanged += cmbFamilias_SelectedIndexChanged;

            if (cmbFamilias.Items.Count > 0)
                cmbFamilias.SelectedIndex = 0;

            RefrescarListasFamilias();
        }

        private void CargarComboRoles()
        {
            cmbRoles.SelectedIndexChanged -= cmbRoles_SelectedIndexChanged;

            cmbRoles.DataSource = null;
            cmbRoles.DisplayMember = "Nombre_593CM";
            cmbRoles.ValueMember = "ID_593CM";
            cmbRoles.DataSource = _rolBLL.ListarTodos_593CM();

            cmbRoles.SelectedIndexChanged += cmbRoles_SelectedIndexChanged;

            if (cmbRoles.Items.Count > 0)
                cmbRoles.SelectedIndex = 0;

            RefrescarListasRoles();
        }

        // ── Familia tab ───────────────────────────────────────────────────────────────

        private void cmbFamilias_SelectedIndexChanged(object sender, EventArgs e)
        {
            RefrescarListasFamilias();
        }

        private void RefrescarListasFamilias()
        {
            if (!(cmbFamilias.SelectedValue is int)) return;

            int idFamilia = (int)cmbFamilias.SelectedValue;

            var familia = _bll.CargarFamiliaConComponentes_593CM(idFamilia);

            lstAsignadosF.Items.Clear();
            if (familia != null)
                foreach (var comp in familia.Componentes_593CM)
                    lstAsignadosF.Items.Add(new PermisoItem(comp));

            lstDisponiblesF.Items.Clear();
            foreach (var item in _bll.GetDisponiblesParaFamilia_593CM(idFamilia))
                lstDisponiblesF.Items.Add(new PermisoItem(item));
        }

        private void btnAgregarF_Click(object sender, EventArgs e)
        {
            if (cmbFamilias.SelectedValue == null || lstDisponiblesF.SelectedItem == null) return;
            int idFamilia = Convert.ToInt32(cmbFamilias.SelectedValue);
            var item = ((PermisoItem)lstDisponiblesF.SelectedItem).Permiso;

            bool ok;
            if (item is Patente_593CM p)
                ok = _bll.AgregarPatenteAFamilia_593CM(idFamilia, p.ID_patente_593CM);
            else if (item is Familia_593CM f)
                ok = _bll.AgregarSubFamiliaAFamilia_593CM(idFamilia, f.ID_familia_593CM);
            else return;

            if (!ok)
                MessageBox.Show("No se puede agregar: ya existe efectivamente o generaría un ciclo.",
                                "Operación rechazada", MessageBoxButtons.OK, MessageBoxIcon.Warning);

            RefrescarListasFamilias();
        }

        private void btnQuitarF_Click(object sender, EventArgs e)
        {
            if (cmbFamilias.SelectedValue == null || lstAsignadosF.SelectedItem == null) return;
            int idFamilia = Convert.ToInt32(cmbFamilias.SelectedValue);
            var item = ((PermisoItem)lstAsignadosF.SelectedItem).Permiso;

            if (item is Patente_593CM p)
                _bll.QuitarPatenteDeFamilia_593CM(idFamilia, p.ID_patente_593CM);
            else if (item is Familia_593CM f)
                _bll.QuitarSubFamiliaDeFamilia_593CM(idFamilia, f.ID_familia_593CM);

            RefrescarListasFamilias();
        }

        private void btnNuevaFamilia_Click(object sender, EventArgs e)
        {
            using (var form = new FormNuevaFamilia_593CM())
            {
                if (form.ShowDialog(this) == DialogResult.OK)
                {
                    CargarComboFamilias();
                    if (form.IdFamiliaCreada_593CM > 0)
                        cmbFamilias.SelectedValue = form.IdFamiliaCreada_593CM;
                }
            }
        }

        private void btnRenombrarF_Click(object sender, EventArgs e)
        {
            if (cmbFamilias.SelectedValue == null) return;
            int id = (int)cmbFamilias.SelectedValue;
            string actual = cmbFamilias.Text;

            string nombre = Microsoft.VisualBasic.Interaction.InputBox(
                "Nuevo nombre de la familia:", "Renombrar Familia", actual);
            if (string.IsNullOrWhiteSpace(nombre) || nombre.Trim() == actual) return;

            var resultado = _bll.RenombrarFamilia_593CM(id, nombre.Trim());
            if (resultado == PerfilesBLL_593CM.ResultadoRenombrarFamilia_593CM.NombreDuplicado)
            {
                MessageBox.Show("Ya existe una familia con ese nombre.", "Error",
                                MessageBoxButtons.OK, MessageBoxIcon.Error);
                return;
            }

            CargarComboFamilias();
        }

        private void btnEliminarF_Click(object sender, EventArgs e)
        {
            if (cmbFamilias.SelectedValue == null) return;
            int id = (int)cmbFamilias.SelectedValue;
            string nombre = cmbFamilias.Text;

            var confirm = MessageBox.Show(
                $"¿Eliminar la familia '{nombre}'?",
                "Confirmar eliminación",
                MessageBoxButtons.YesNo,
                MessageBoxIcon.Question);
            if (confirm != DialogResult.Yes) return;

            var resultado = _bll.EliminarFamilia_593CM(id);
            if (resultado == PerfilesBLL_593CM.ResultadoEliminarFamilia_593CM.Referenciada)
            {
                MessageBox.Show(
                    "No se puede eliminar porque está referenciada por otra familia o rol.",
                    "Eliminación bloqueada",
                    MessageBoxButtons.OK,
                    MessageBoxIcon.Warning);
                return;
            }

            CargarComboFamilias();
        }

        // ── Rol tab ───────────────────────────────────────────────────────────────────

        private void cmbRoles_SelectedIndexChanged(object sender, EventArgs e)
        {
            RefrescarListasRoles();
        }

        private void RefrescarListasRoles()
        {
            if (!(cmbRoles.SelectedValue is int)) return;

            int idRol = (int)cmbRoles.SelectedValue;

            lstAsignadosR.Items.Clear();
            foreach (var comp in _bll.ObtenerComponentesDeRol_593CM(idRol))
                lstAsignadosR.Items.Add(new PermisoItem(comp));

            lstDisponiblesR.Items.Clear();
            foreach (var item in _bll.GetDisponiblesParaRol_593CM(idRol))
                lstDisponiblesR.Items.Add(new PermisoItem(item));
        }

        private void btnAgregarR_Click(object sender, EventArgs e)
        {
            if (cmbRoles.SelectedValue == null || lstDisponiblesR.SelectedItem == null) return;
            int idRol = Convert.ToInt32(cmbRoles.SelectedValue);
            var item  = ((PermisoItem)lstDisponiblesR.SelectedItem).Permiso;

            bool ok;
            if (item is Patente_593CM p)
                ok = _bll.AgregarPatenteARol_593CM(idRol, p.ID_patente_593CM);
            else if (item is Familia_593CM f)
                ok = _bll.AgregarFamiliaARol_593CM(idRol, f.ID_familia_593CM);
            else return;

            if (!ok)
                MessageBox.Show("No se puede agregar: ya existe efectivamente en este rol.",
                                "Operación rechazada", MessageBoxButtons.OK, MessageBoxIcon.Warning);

            RefrescarListasRoles();
        }

        private void btnQuitarR_Click(object sender, EventArgs e)
        {
            if (cmbRoles.SelectedValue == null || lstAsignadosR.SelectedItem == null) return;
            int idRol = Convert.ToInt32(cmbRoles.SelectedValue);
            var item  = ((PermisoItem)lstAsignadosR.SelectedItem).Permiso;

            if (item is Patente_593CM p)
                _bll.QuitarPatenteDeRol_593CM(idRol, p.ID_patente_593CM);
            else if (item is Familia_593CM f)
                _bll.QuitarFamiliaDeRol_593CM(idRol, f.ID_familia_593CM);

            RefrescarListasRoles();
        }

        private void btnNuevoRol_Click(object sender, EventArgs e)
        {
            using (var form = new FormNuevoRol_593CM())
            {
                if (form.ShowDialog(this) == DialogResult.OK)
                {
                    CargarComboRoles();
                    if (form.IdRolCreado_593CM > 0)
                        cmbRoles.SelectedValue = form.IdRolCreado_593CM;
                }
            }
        }

        private void btnRenombrarR_Click(object sender, EventArgs e)
        {
            if (cmbRoles.SelectedValue == null) return;
            int id = (int)cmbRoles.SelectedValue;
            string actual = cmbRoles.Text;

            string nombre = Microsoft.VisualBasic.Interaction.InputBox(
                "Nuevo nombre del rol:", "Renombrar Rol", actual);
            if (string.IsNullOrWhiteSpace(nombre) || nombre.Trim() == actual) return;

            var resultado = _rolBLL.RenombrarRol_593CM(id, nombre.Trim());
            if (resultado == RolBLL_593CM.ResultadoRenombrarRol_593CM.NombreDuplicado)
            {
                MessageBox.Show("Ya existe un rol con ese nombre.", "Error",
                                MessageBoxButtons.OK, MessageBoxIcon.Error);
                return;
            }

            CargarComboRoles();
        }

        private void btnEliminarR_Click(object sender, EventArgs e)
        {
            if (cmbRoles.SelectedValue == null) return;
            int id = (int)cmbRoles.SelectedValue;
            string nombre = cmbRoles.Text;

            var confirm = MessageBox.Show(
                $"¿Eliminar el rol '{nombre}'?",
                "Confirmar eliminación",
                MessageBoxButtons.YesNo,
                MessageBoxIcon.Question);
            if (confirm != DialogResult.Yes) return;

            var resultado = _rolBLL.EliminarRol_593CM(id);
            if (resultado == RolBLL_593CM.ResultadoEliminarRol_593CM.Referenciado)
            {
                MessageBox.Show(
                    "No se puede eliminar porque hay usuarios asignados a este rol.",
                    "Eliminación bloqueada",
                    MessageBoxButtons.OK,
                    MessageBoxIcon.Warning);
                return;
            }

            CargarComboRoles();
        }
    }
}
