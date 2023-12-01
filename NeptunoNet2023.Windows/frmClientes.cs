using NeptunoNet2023.Entidades.Dtos.Cliente;
using NeptunoNet2023.Servicios.Interfaces;
using NeptunoNet2023.Servicios.Servicios;
using NeptunoNet2023.Windows.Helpers;

namespace NeptunoNet2023.Windows
{
    public partial class frmClientes : Form
    {
        private readonly IServiciosClientes _serviciosClientes;
        private List<ClienteListDto> clientes;
        public frmClientes()
        {
            InitializeComponent();
            _serviciosClientes = new ServiciosClientes();
        }

        private void frmClientes_Load(object sender, EventArgs e)
        {
            RecargarGrilla();
        }

        private void RecargarGrilla()
        {
            try
            {
                clientes = _serviciosClientes.GetClientes();
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
            foreach (var item in clientes)
            {
                DataGridViewRow r = GridHelper.ConstruirFila(dgvDatos);
                GridHelper.SetearFila(r, item);
                GridHelper.AgregarFila(r, dgvDatos);
            }
        }

    }
}
