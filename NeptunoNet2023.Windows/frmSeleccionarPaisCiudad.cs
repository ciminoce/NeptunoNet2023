using NeptunoNet2023.Entidades.Dtos.Ciudad;
using NeptunoNet2023.Entidades.Entidades;
using NeptunoNet2023.Windows.Helpers;

namespace NeptunoNet2023.Windows
{
    public partial class frmSeleccionarPaisCiudad : Form
    {
        private Pais pais;
        private CiudadComboDto ciudad;
        private Tuple<Pais, CiudadComboDto> datosSeleccionados;
        public frmSeleccionarPaisCiudad()
        {
            InitializeComponent();
        }

        private void frmSeleccionarPaisCiudad_Load(object sender, EventArgs e)
        {
            CombosHelper.CargarDatosComboPaises(ref cboPaises);
        }

        private void cboPaises_SelectedIndexChanged(object sender, EventArgs e)
        {
            if (cboPaises.SelectedIndex > 0)
            {
                pais = (Pais)cboPaises.SelectedItem;
                CombosHelper.CargarDatosComboCiudades(ref cboCiudades, pais);
            }
            else
            {
                pais = null;
                cboCiudades.DataSource = null;
            }
        }

        private void btnCancelar_Click(object sender, EventArgs e)
        {
            DialogResult = DialogResult.Cancel;
        }

        private void btnOK_Click(object sender, EventArgs e)
        {
            if (ValidarDatos())
            {
                datosSeleccionados = new Tuple<Pais, CiudadComboDto>(pais, ciudad);
                DialogResult = DialogResult.OK;
            }
        }
        public Tuple<Pais,CiudadComboDto> GetDatosSeleccionados()
        {
            return datosSeleccionados;
        }
        private bool ValidarDatos()
        {
            bool valido = true;
            errorProvider1.Clear();
            if (cboPaises.SelectedIndex == 0)
            {
                valido = false;
                errorProvider1.SetError(cboPaises, "Debe seleccionar un país");
            }
            if (cboCiudades.SelectedIndex == 0)
            {
                valido = false;
                errorProvider1.SetError(cboCiudades, "Debe seleccionar una ciudad");
            }
            return valido;
        }

        private void cboCiudades_SelectedIndexChanged(object sender, EventArgs e)
        {
            if (cboCiudades.SelectedIndex>0)
            {
                ciudad = (CiudadComboDto)cboCiudades.SelectedItem;
            }
            else
            {
                ciudad = null;
            }
        }
    }
}
