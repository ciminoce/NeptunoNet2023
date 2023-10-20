using NeptunoNet2023.Entidades.Entidades;
using NeptunoNet2023.Servicios.Servicios;

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
            dgvDatos.Rows.Clear();
            foreach (var item in listaCategorias)
            {
                DataGridViewRow r = ConstruirFila();
                SetearFila(r, item);
                AgregarFila(r);
            }
        }

        private void SetearFila(DataGridViewRow r, Categoria item)
        {
            r.Cells[colCategoria.Index].Value = item.NombreCategoria;
            r.Cells[colDescripcion.Index].Value = item.Descripcion;
            r.Tag = item;
        }

        private void AgregarFila(DataGridViewRow r)
        {
            dgvDatos.Rows.Add(r);
        }

        private DataGridViewRow ConstruirFila()
        {
            DataGridViewRow r = new DataGridViewRow();
            r.CreateCells(dgvDatos);
            return r;
        }

    }
}
