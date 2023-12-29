using NeptunoNet2023.Entidades.Entidades;
using NeptunoNet2023.Servicios.Servicios;
using NeptunoNet2023.Windows.Helpers;

namespace NeptunoNet2023.Windows
{
    public partial class frmCategorias : Form
    {
        private readonly ServiciosCategorias _serviciosCategorias;
        private List<Categoria>? listaCategorias;
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
                DataGridViewRow r = GridHelper.ConstruirFila(dgvDatos);
                GridHelper.SetearFila(r, item);
                GridHelper.AgregarFila(r, dgvDatos);
            }
        }

        private void tsbNuevo_Click(object sender, EventArgs e)
        {
            frmCategoriasAE frm = new frmCategoriasAE() { Text = "Nueva Categoría" };
            DialogResult dr = frm.ShowDialog(this);
            if (dr == DialogResult.Cancel)
            {
                return;
            }
            try
            {
                Categoria categoria = frm.GetCategoria();
                if (!_serviciosCategorias.Existe(categoria))
                {
                    _serviciosCategorias.Guardar(categoria);
                    DataGridViewRow r = GridHelper.ConstruirFila(dgvDatos);
                    GridHelper.SetearFila(r, categoria);
                    GridHelper.AgregarFila(r,dgvDatos);
                    MessageBox.Show("Registro Agregado!!!",
                        "Mensaje",
                        MessageBoxButtons.OK,
                        MessageBoxIcon.Information);
                }
                else
                {
                    MessageBox.Show("Registro duplicado!!!",
                    "Error",
                    MessageBoxButtons.OK,
                    MessageBoxIcon.Error);
                }
            }
            catch (Exception ex)
            {
                MessageBox.Show(ex.Message,
                    "Error",
                    MessageBoxButtons.OK,
                    MessageBoxIcon.Error);
            }
        }

        private void tsbBorrar_Click(object sender, EventArgs e)
        {
            if (dgvDatos.SelectedRows.Count == 0)
            {
                return;
            }
            DataGridViewRow r = dgvDatos.SelectedRows[0];
            Categoria categoria = (Categoria)r.Tag;
            DialogResult dr = MessageBox.Show($"Desea borrar la categoría {categoria.ToString()}",
                "Confirmar Eliminación",
                MessageBoxButtons.YesNo,
                MessageBoxIcon.Question,
                MessageBoxDefaultButton.Button2);

            if (dr == DialogResult.No)
            {
                return;
            }

            try
            {

                if (!_serviciosCategorias.EstaRelacionado(categoria))
                {

                    _serviciosCategorias.Borrar(categoria);
                    GridHelper.QuitarFila(r, dgvDatos);
                    MessageBox.Show("Registro borrado!!!",
                                        "Mensaje",
                                        MessageBoxButtons.OK,
                                        MessageBoxIcon.Error);
                }
                else
                {
                    MessageBox.Show("Registro relacionado!!!",
                    "Error",
                    MessageBoxButtons.OK,
                    MessageBoxIcon.Error);
                }
            }
            catch (Exception ex)
            {
                MessageBox.Show(ex.Message,
                                    "Error",
                                    MessageBoxButtons.OK,
                                    MessageBoxIcon.Error);
            }
        }


        private void tsbEditar_Click(object sender, EventArgs e)
        {
            if (dgvDatos.SelectedRows.Count == 0)
            {
                return;
            }
            var r = dgvDatos.SelectedRows[0];
            var categoria = (Categoria)r.Tag;
            var categoriaCopia = (Categoria)categoria.Clone();
            frmCategoriasAE frm = new frmCategoriasAE() { Text = "Editar Categoría" };
            frm.SetCategoria(categoria);
            DialogResult dr = frm.ShowDialog(this);
            if (dr == DialogResult.Cancel)
            {
                return;
            }
            categoria = frm.GetCategoria();
            try
            {
                if (!_serviciosCategorias.Existe(categoria))
                {
                    _serviciosCategorias.Guardar(categoria);
                    GridHelper.SetearFila(r, categoria);
                    MessageBox.Show("Registro editado!!!",
                                    "Mensaje",
                                    MessageBoxButtons.OK,
                                    MessageBoxIcon.Information);
                }
                else
                {
                    GridHelper.SetearFila(r, categoriaCopia);
                    MessageBox.Show("Registro duplicado!!!",
                    "Error",
                    MessageBoxButtons.OK,
                    MessageBoxIcon.Error);
                }
            }
            catch (Exception ex)
            {
                MessageBox.Show(ex.Message,
                                "Error",
                                MessageBoxButtons.OK,
                                MessageBoxIcon.Error);
            }

        }

    }
}
