using NeptunoNet2023.Entidades.Entidades;
using NeptunoNet2023.Windows.Helpers;

namespace NeptunoNet2023.Windows
{
    public partial class frmSeleccionarPais : Form
    {
        //private readonly IServiciosPaises _serviciosPaises;
        private Pais pais;
        public frmSeleccionarPais()
        {
            InitializeComponent();
            //_serviciosPaises = new ServiciosPaises();
        }

        private void frmSeleccionarPais_Load(object sender, EventArgs e)
        {
            CombosHelper.CargarDatosComboPaises(ref cboPaises);
        }

        private void btnCancelar_Click(object sender, EventArgs e)
        {
            DialogResult = DialogResult.Cancel;
        }

        private void btnOK_Click(object sender, EventArgs e)
        {
            if (ValidarDatos())
            {
                DialogResult= DialogResult.OK;
            }
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
            return valido;
        }

        private void cboPaises_SelectedIndexChanged(object sender, EventArgs e)
        {
            if (cboPaises.SelectedIndex>0)
            {
                pais=cboPaises.SelectedItem as Pais;
            }
            else
            {
                pais = null;
            }
        }
        public Pais GetPais()
        {
            return pais;
        }
    }
}
