using NeptunoNet2023.Entidades.Entidades;

namespace NeptunoNet2023.Windows
{
    public partial class frmCategoriasAE : Form
    {
        public frmCategoriasAE()
        {
            InitializeComponent();
        }
        private Categoria categoria;
        protected override void OnLoad(EventArgs e)
        {
            base.OnLoad(e);
            if (categoria != null)
            {
                txtCategoria.Text = categoria.NombreCategoria;
                txtDescripcion.Text = categoria.Descripcion;
            }
        }
        public Categoria GetCategoria()
        {
            return categoria;
        }

        private void btnCancelar_Click(object sender, EventArgs e)
        {
            DialogResult = DialogResult.Cancel;
        }

        private void frmCategoriasAE_Load(object sender, EventArgs e)
        {

        }

        private void btnOK_Click(object sender, EventArgs e)
        {
            if (ValidarDatos())
            {
                if (categoria == null)
                {
                    categoria = new Categoria();
                }
                categoria.NombreCategoria = txtCategoria.Text;
                categoria.Descripcion = txtDescripcion.Text;
                DialogResult = DialogResult.OK;

            }
        }

        private bool ValidarDatos()
        {
            bool valido = true;
            errorProvider1.Clear();
            if (string.IsNullOrEmpty(txtCategoria.Text))
            {
                valido = false;
                errorProvider1.SetError(txtCategoria, "Categoría requerida");
            }
            return valido;
        }

        internal void SetCategoria(Categoria? categoria)
        {
            this.categoria = categoria;
        }

    }
}
