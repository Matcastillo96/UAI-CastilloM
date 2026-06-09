using System;
using System.Collections.Generic;
using System.Linq;
using System.Windows.Forms;
using DIEFER.BE;
using DIEFER.BLL;

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
            cmbFamilias.DataSource    = null;
            cmbFamilias.DataSource    = _bll.ListarFamilias_593CM();
            cmbFamilias.DisplayMember = "Nombre_593CM";
            cmbFamilias.ValueMember   = "ID_familia_593CM";
            if (cmbFamilias.Items.Count > 0)
                RefrescarListasFamilias();
        }

        private void CargarComboRoles()
        {
            cmbRoles.DataSource    = null;
            cmbRoles.DataSource    = _rolBLL.ListarTodos_593CM();
            cmbRoles.DisplayMember = "Nombre_593CM";
            cmbRoles.ValueMember   = "ID_593CM";
            if (cmbRoles.Items.Count > 0)
                RefrescarListasRoles();
        }

        // ── Familia tab ───────────────────────────────────────────────────────────────

        private void cmbFamilias_SelectedIndexChanged(object sender, EventArgs e)
        {
            RefrescarListasFamilias();
        }

        private void RefrescarListasFamilias()
        {
            if (cmbFamilias.SelectedValue == null) return;
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
            int idFamilia = (int)cmbFamilias.SelectedValue;
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
            int idFamilia = (int)cmbFamilias.SelectedValue;
            var item = ((PermisoItem)lstAsignadosF.SelectedItem).Permiso;

            if (item is Patente_593CM p)
                _bll.QuitarPatenteDeFamilia_593CM(idFamilia, p.ID_patente_593CM);
            else if (item is Familia_593CM f)
                _bll.QuitarSubFamiliaDeFamilia_593CM(idFamilia, f.ID_familia_593CM);

            RefrescarListasFamilias();
        }

        private void btnNuevaFamilia_Click(object sender, EventArgs e)
        {
            string nombre = Microsoft.VisualBasic.Interaction.InputBox(
                "Nombre de la nueva familia:", "Nueva Familia", string.Empty);
            if (string.IsNullOrWhiteSpace(nombre)) return;

            if (!_bll.CrearFamilia_593CM(nombre.Trim()))
            {
                MessageBox.Show("No se pudo crear la familia.", "Error",
                                MessageBoxButtons.OK, MessageBoxIcon.Error);
                return;
            }
            CargarComboFamilias();
            // Seleccionar la recién creada
            var nueva = ((List<Familia_593CM>)cmbFamilias.DataSource)
                        .FirstOrDefault(f => f.Nombre_593CM == nombre.Trim());
            if (nueva != null) cmbFamilias.SelectedValue = nueva.ID_familia_593CM;
        }

        // ── Rol tab ───────────────────────────────────────────────────────────────────

        private void cmbRoles_SelectedIndexChanged(object sender, EventArgs e)
        {
            RefrescarListasRoles();
        }

        private void RefrescarListasRoles()
        {
            if (cmbRoles.SelectedValue == null) return;
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
            int idRol = (int)cmbRoles.SelectedValue;
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
            int idRol = (int)cmbRoles.SelectedValue;
            var item  = ((PermisoItem)lstAsignadosR.SelectedItem).Permiso;

            if (item is Patente_593CM p)
                _bll.QuitarPatenteDeRol_593CM(idRol, p.ID_patente_593CM);
            else if (item is Familia_593CM f)
                _bll.QuitarFamiliaDeRol_593CM(idRol, f.ID_familia_593CM);

            RefrescarListasRoles();
        }
    }
}
