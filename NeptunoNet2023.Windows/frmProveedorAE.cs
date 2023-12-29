using NeptunoNet2023.Entidades.Entidades;
using NeptunoNet2023.Windows.Helpers;

namespace NeptunoNet2023.Windows
{
    public partial class frmProveedorAE : Form
    {
        public frmProveedorAE()
        {
            InitializeComponent();
        }

        public Proveedor GetProveedor()
        {
            return proveedor;
        }

        public void SetProveedor(Proveedor proveedor)
        {
            this.proveedor = proveedor;
        }
        private Pais paisSeleccionado;
        private Proveedor proveedor;
        protected override void OnLoad(EventArgs e)
        {
            base.OnLoad(e);
            CombosHelper.CargarDatosComboPaises(ref cboPaises);
            if (proveedor != null)
            {
                txtProveedor.Text = proveedor.NombreProveedor;
                txtDireccion.Text = proveedor.Direccion;
                txtCodPostal.Text = proveedor.CodPostal;
                txtTelefono.Text = proveedor.Telefono;
                cboPaises.SelectedValue = proveedor.PaisId;
                paisSeleccionado = (Pais)cboPaises.SelectedItem;
                CombosHelper.CargarDatosComboCiudades(ref cboCiudades, paisSeleccionado);
                cboCiudades.SelectedValue = proveedor.CiudadId;
            }
        }
        private void btnCancelar_Click(object sender, EventArgs e)
        {
            DialogResult = DialogResult.Cancel;
        }

        private void cboPaises_SelectedIndexChanged(object sender, EventArgs e)
        {
            //if (cboPaises.SelectedIndex > 0)
            //{
            //    paisSeleccionado = (Pais)cboPaises.SelectedItem;
            //    CombosHelper.CargarDatosComboCiudades(ref cboCiudades, paisSeleccionado);
            //}
            //else
            //{
            //    paisSeleccionado = null;
            //    cboCiudades.DataSource = null;
            //}
        }

        private void btnOK_Click(object sender, EventArgs e)
        {
            if (ValidarDatos())
            {
                if (proveedor == null)
                {
                    proveedor = new Proveedor();
                }
                proveedor.NombreProveedor = txtProveedor.Text;
                proveedor.Direccion = txtDireccion.Text;
                proveedor.CodPostal = txtCodPostal.Text;
                proveedor.PaisId = (int)cboPaises.SelectedValue;
                proveedor.CiudadId = (int)cboCiudades.SelectedValue;
                proveedor.Telefono = txtTelefono.Text;
                DialogResult = DialogResult.OK;
            }
        }

        private bool ValidarDatos()
        {
            bool valido = true;
            errorProvider1.Clear();
            if (string.IsNullOrEmpty(txtProveedor.Text))
            {
                valido = false;
                errorProvider1.SetError(txtProveedor, "El proveedor es requerido");

            }
            if (string.IsNullOrEmpty(txtDireccion.Text))
            {
                valido = false;
                errorProvider1.SetError(txtDireccion, "La dirección es requerida");

            }
            if (string.IsNullOrEmpty(txtCodPostal.Text))
            {
                valido = false;
                errorProvider1.SetError(txtCodPostal, "El CP es requerido");

            }
            if (cboPaises.SelectedIndex == 0)
            {
                valido = false;
                errorProvider1.SetError(cboPaises, "Debe seleccionar un país");
            }
            else if (cboCiudades.SelectedIndex == 0)
            {
                valido = false;
                errorProvider1.SetError(cboCiudades, "Debe seleccionar una ciudad");
            }
            return valido;
        }

        private void cboPaises_SelectionChangeCommitted(object sender, EventArgs e)
        {
            if (cboPaises.SelectedIndex > 0)
            {
                paisSeleccionado = (Pais)cboPaises.SelectedItem;
                CombosHelper.CargarDatosComboCiudades(ref cboCiudades, paisSeleccionado);
            }
            else
            {
                paisSeleccionado = null;
                cboCiudades.DataSource = null;
            }

        }
    }
}
