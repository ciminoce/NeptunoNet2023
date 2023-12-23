using NeptunoNet2023.Entidades.Entidades;
using NeptunoNet2023.Windows.Helpers;

namespace NeptunoNet2023.Windows
{
    public partial class frmClienteAE : Form
    {
        public frmClienteAE()
        {
            InitializeComponent();
        }
        private Pais paisSeleccionado;
        private Cliente cliente;
        protected override void OnLoad(EventArgs e)
        {
            base.OnLoad(e);
            CombosHelper.CargarDatosComboPaises(ref cboPaises);
            if (cliente!=null)
            {
                txtCliente.Text = cliente.NombreCliente;
                txtDireccion.Text=cliente.Direccion;
                txtCodPostal.Text=cliente.CodPostal;
                txtTelFijo.Text=cliente.TelFijo;
                txtTelMovil.Text=cliente.TelMovil;
                cboPaises.SelectedValue = cliente.PaisId;
                paisSeleccionado = (Pais)cboPaises.SelectedItem;
                CombosHelper.CargarDatosComboCiudades(ref cboCiudades, paisSeleccionado);
                cboCiudades.SelectedValue = cliente.CiudadId;
            }
        }
        private void btnCancelar_Click(object sender, EventArgs e)
        {
            DialogResult = DialogResult.Cancel;
        }

        private void cboPaises_SelectedIndexChanged(object sender, EventArgs e)
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

        private void btnOK_Click(object sender, EventArgs e)
        {
            if (ValidarDatos())
            {
                if (cliente==null)
                {
                    cliente = new Cliente();
                }
                cliente.NombreCliente = txtCliente.Text;
                cliente.Direccion = txtDireccion.Text;
                cliente.CodPostal = txtCodPostal.Text;
                cliente.PaisId =(int) cboPaises.SelectedValue;
                cliente.CiudadId=(int)cboCiudades.SelectedValue;
                cliente.TelFijo= txtTelFijo.Text;
                cliente.TelMovil=txtTelMovil.Text;
                DialogResult = DialogResult.OK;
            }
        }

        private bool ValidarDatos()
        {
            bool valido = true;
            errorProvider1.Clear();
            if (string.IsNullOrEmpty(txtCliente.Text))
            {
                valido = false;
                errorProvider1.SetError(txtCliente, "El cliente es requerido");

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
            else if (cboCiudades.SelectedIndex==0)
            {
                valido = false;
                errorProvider1.SetError(cboCiudades, "Debe seleccionar una ciudad");
            }
            return valido;
        }

        public Cliente GetCliente()
        {
            return cliente;
        }

        public void SetCliente(Cliente cliente)
        {
            this.cliente = cliente;
        }
    }
}
