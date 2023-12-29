using NeptunoNet2023.Entidades.Dtos.Proveedor;
using NeptunoNet2023.Entidades.Entidades;
using NeptunoNet2023.Servicios.Interfaces;
using NeptunoNet2023.Servicios.Servicios;
using NeptunoNet2023.Windows.Helpers;

namespace NeptunoNet2023.Windows
{
    public partial class frmProveedores : Form
    {
        public frmProveedores()
        {
            InitializeComponent();
            _serviciosProveedores = new ServiciosProveedores();
        }
        private readonly IServiciosProveedores _serviciosProveedores;
        private List<ProveedorListDto> proveedores;

        private void frmProveedores_Load(object sender, EventArgs e)
        {
            RecargarGrilla();
        }

        private void RecargarGrilla()
        {
            try
            {
                proveedores = _serviciosProveedores.GetProveedores();
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
            foreach (var item in proveedores)
            {
                DataGridViewRow r = GridHelper.ConstruirFila(dgvDatos);
                GridHelper.SetearFila(r, item);
                GridHelper.AgregarFila(r, dgvDatos);
            }
        }

        private void tsbNuevo_Click(object sender, EventArgs e)
        {
            frmProveedorAE frm = new frmProveedorAE() { Text = "Nuevo Proveedor" };
            DialogResult dr = frm.ShowDialog(this);
            if (dr == DialogResult.Cancel) { return; }
            try
            {
                Proveedor proveedor = frm.GetProveedor();
                //TODO: Controlar que no estea repetido
                if (!_serviciosProveedores.Existe(proveedor))
                {
                    int registrosAfectados = _serviciosProveedores.Guardar(proveedor);
                    if (registrosAfectados > 0)
                    {
                        ProveedorListDto proveedorDto = _serviciosProveedores
                            .GetProveedorDtoPorId(proveedor.ProveedorId);

                        var r = GridHelper.ConstruirFila(dgvDatos);
                        GridHelper.SetearFila(r, proveedorDto);
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
                    MessageBox.Show("Proveedor Duplicado!!!",
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
            if (dgvDatos.SelectedRows.Count == 0)
            {
                return;
            }
            var r = dgvDatos.SelectedRows[0];
            var proveedorDto = (ProveedorListDto)r.Tag;
            DialogResult dr = MessageBox.Show($"¿Desea dar de baja al proveedor {proveedorDto.ToString()}?",
                "Confirmar Borrado",
                MessageBoxButtons.YesNo, MessageBoxIcon.Question,
                    MessageBoxDefaultButton.Button2);
            if (dr == DialogResult.No) { return; }
            Proveedor proveedor = _serviciosProveedores.GetProveedorPorId(proveedorDto.ProveedorId);
            if (proveedor != null)
            {
                if (!_serviciosProveedores.EstaRelacionado(proveedor))
                {
                    int registrosAfectados = _serviciosProveedores.Borrar(proveedor);
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

        private void tsbEditar_Click(object sender, EventArgs e)
        {
            if (dgvDatos.SelectedRows.Count == 0) { return; }

            var r = dgvDatos.SelectedRows[0];
            var proveedorDto = (ProveedorListDto)r.Tag;
            var proveedorDtoAux = (ProveedorListDto)proveedorDto.Clone();
            var proveedor = _serviciosProveedores.GetProveedorPorId(proveedorDto.ProveedorId);
            frmProveedorAE frm = new frmProveedorAE() { Text = "Edición de Proveedor" };
            frm.SetProveedor(proveedor);
            DialogResult dr = frm.ShowDialog(this);
            if (dr == DialogResult.Cancel) { return; }
            try
            {
                proveedor = frm.GetProveedor();
                if (!_serviciosProveedores.Existe(proveedor))
                {
                    int registrosAfectados = _serviciosProveedores.Guardar(proveedor);
                    if (registrosAfectados > 0)
                    {
                        proveedorDto = _serviciosProveedores.GetProveedorDtoPorId(proveedorDto.ProveedorId);
                        GridHelper.SetearFila(r, proveedorDto);
                        MessageBox.Show("Registro Modificado!!", "Mensaje", MessageBoxButtons.OK,
                            MessageBoxIcon.Information);
                    }
                    else
                    {
                        MessageBox.Show("Registro borrado o modificado por otro usuario!!",
                            "Advertencia",
                            MessageBoxButtons.OK,
                            MessageBoxIcon.Warning);
                        RecargarGrilla();

                    }

                }
                else
                {
                    MessageBox.Show("Registro Duplicado!!!", "Error", MessageBoxButtons.OK,
                        MessageBoxIcon.Error);
                    GridHelper.SetearFila(r, proveedorDtoAux);
                }
            }
            catch (Exception ex)
            {
                GridHelper.SetearFila(r, proveedorDtoAux);

                MessageBox.Show(ex.Message,
                    "Error",
                    MessageBoxButtons.OK,
                    MessageBoxIcon.Error);

            }

        }

        private void tsbFiltrar_Click(object sender, EventArgs e)
        {
            frmSeleccionarPaisCiudad frm = new frmSeleccionarPaisCiudad() { Text = "Seleccionar País y Ciudad" };
            DialogResult dr = frm.ShowDialog(this);
            if (dr == DialogResult.Cancel) { return; }
            try
            {
                var datosSeleccionados = frm.GetDatosSeleccionados();
                var paisSeleccionado = datosSeleccionados.Item1;
                var ciudadSeleccionada = datosSeleccionados.Item2;

                proveedores = _serviciosProveedores.GetProveedores(paisSeleccionado, ciudadSeleccionada);
                MostrarDatosEnGrilla();
            }
            catch (Exception)
            {

                throw;
            }
        }

        private void tsbActualizar_Click(object sender, EventArgs e)
        {
            RecargarGrilla();
        }

    }
}
