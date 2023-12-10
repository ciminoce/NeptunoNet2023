using NeptunoNet2023.Entidades.Dtos.Cliente;
using NeptunoNet2023.Entidades.Entidades;
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

        private void tsbNuevo_Click(object sender, EventArgs e)
        {
            frmClienteAE frm = new frmClienteAE() { Text = "Nuevo Cliente" };
            DialogResult dr = frm.ShowDialog(this);
            if (dr == DialogResult.Cancel) { return; }
            try
            {
                Cliente cliente = frm.GetCliente();
                //TODO: Controlar que no estea repetido
                if (!_serviciosClientes.Existe(cliente))
                {
                    int registrosAfectados = _serviciosClientes.Guardar(cliente);
                    if (registrosAfectados > 0)
                    {
                        ClienteListDto clienteDto = _serviciosClientes
                            .GetClienteDtoPorId(cliente.ClienteId);

                        var r = GridHelper.ConstruirFila(dgvDatos);
                        GridHelper.SetearFila(r, clienteDto);
                        GridHelper.AgregarFila(r, dgvDatos);
                        MessageBox.Show("Registro agregado!!!",
                            "Mensaje", MessageBoxButtons.OK, MessageBoxIcon.Information);
                    }
                    else
                    {
                        MessageBox.Show("Error al intentar agregar un registro",
                        "Error", MessageBoxButtons.OK, MessageBoxIcon.Error);

                    }

                }
                else
                {
                    MessageBox.Show("Cliente Duplicado!!!",
                            "Error", MessageBoxButtons.OK, MessageBoxIcon.Error);


                }
            }
            catch (Exception)
            {

                throw;
            }
        }

        private void tsbCerrar_Click(object sender, EventArgs e)
        {
            Close();
        }

        private void tsbBorrar_Click(object sender, EventArgs e)
        {
            if (dgvDatos.SelectedRows.Count==0)
            {
                return;
            }
            var r = dgvDatos.SelectedRows[0];
            var clienteDto = (ClienteListDto)r.Tag;
            DialogResult dr = MessageBox.Show($"¿Desea dar de baja al cliente {clienteDto.ToString()}?",
                "Confirmar Borrado",
                MessageBoxButtons.YesNo, MessageBoxIcon.Question,
                    MessageBoxDefaultButton.Button2);
            if (dr == DialogResult.No) { return; }
            Cliente cliente=_serviciosClientes.GetClientePorId(clienteDto.ClienteId);
            if (cliente != null)
            {
                if (!_serviciosClientes.EstaRelacionado(cliente))
                {
                    int registrosAfectados = _serviciosClientes.Borrar(cliente);
                    if (registrosAfectados > 0)
                    {
                        GridHelper.QuitarFila(r, dgvDatos);
                        MessageBox.Show("Registro Borrado", "Mensaje",
                            MessageBoxButtons.OK,
                            MessageBoxIcon.Information);
                    }
                    else
                    {
                        MessageBox.Show("Registro modificado por otro usuario!!",
                            "Advertencia",
                            MessageBoxButtons.OK,
                            MessageBoxIcon.Warning);
                        RecargarGrilla();
                    }
                }
                else
                {
                    MessageBox.Show("Registro relacionado!!!", "Error",
                        MessageBoxButtons.OK, MessageBoxIcon.Error);
                }

            }
            else
            {
                MessageBox.Show("Registro borrado por otro usuario!!",
                    "Advertencia",
                    MessageBoxButtons.OK,
                    MessageBoxIcon.Warning);
                RecargarGrilla();

            }

        }
    }
}
