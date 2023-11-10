using NeptunoNet2023.Entidades.Entidades;
using NeptunoNet2023.Servicios.Servicios;
using NeptunoNet2023.Windows.Helpers;

namespace NeptunoNet2023.Windows
{
    public partial class frmCategorias : Form
    {
        private readonly ServiciosCategorias _serviciosCategorias;
        private List<Categoria> listaCategorias;
        public frmCategorias()
        {
            InitializeComponent();
            _serviciosCategorias = new ServiciosCategorias();
        }

        private void tsbCerrar_Click(object sender, EventArgs e)
        {
            Close();
        }

        private void frmCategorias_Load(object sender, EventArgs e)
        {
            try
            {
                listaCategorias = _serviciosCategorias.GetAll();
                MostrarDatosEnGrilla();
            }
            catch (Exception)
            {

                throw;
            }
        }
        private void MostrarDatosEnGrilla()
        {
            GridHelper.LimpiarGrilla(dgvDatos);
            foreach (var item in listaCategorias)
            {
                DataGridViewRow r =GridHelper.ConstruirFila(dgvDatos);
                GridHelper.SetearFila(r, item);
                GridHelper.AgregarFila(r,dgvDatos);
            }
        }




    }
}
