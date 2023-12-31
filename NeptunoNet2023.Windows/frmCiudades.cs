﻿using NeptunoNet2023.Entidades.Dtos.Ciudad;
using NeptunoNet2023.Entidades.Entidades;
using NeptunoNet2023.Servicios.Interfaces;
using NeptunoNet2023.Servicios.Servicios;
using NeptunoNet2023.Windows.Helpers;

namespace NeptunoNet2023.Windows
{
    public partial class frmCiudades : Form
    {
        private readonly IServiciosCiudades _serviciosCiudades;
        private List<CiudadListDto>? listaCiudades;
        private bool filterOn = false;
        public frmCiudades()
        {
            InitializeComponent();
            _serviciosCiudades = new ServiciosCiudades();
        }

        private void frmCiudades_Load(object sender, EventArgs e)
        {
            txtCiudadBuscar.Enabled = false;

            RecargarGrilla();
        }

        private void MostrarDatosEnGrilla(List<CiudadListDto> lista)
        {
            GridHelper.LimpiarGrilla(dgvDatos);
            foreach (var item in lista)
            {
                DataGridViewRow r = GridHelper.ConstruirFila(dgvDatos);
                GridHelper.SetearFila(r, item);
                GridHelper.AgregarFila(r, dgvDatos);
            }
        }

        private void tsbCerrar_Click(object sender, EventArgs e)
        {
            Close();
        }

        private void tsbNuevo_Click(object sender, EventArgs e)
        {
            frmCiudadAE frm = new frmCiudadAE() { Text = "Nueva Ciudad" };
            DialogResult dr = frm.ShowDialog(this);
            if (dr == DialogResult.Cancel) { return; }
            try
            {
                Ciudad ciudad = frm.GetCiudad();

                if (!_serviciosCiudades.Existe(ciudad))
                {
                    int registrosAfectados = _serviciosCiudades.Guardar(ciudad);
                    if (registrosAfectados > 0)
                    {
                        CiudadListDto ciudadListDto = _serviciosCiudades
                        .GetCiudadDtoPorId(ciudad.CiudadId);
                        DataGridViewRow r = GridHelper.ConstruirFila(dgvDatos);
                        GridHelper.SetearFila(r, ciudadListDto);
                        GridHelper.AgregarFila(r, dgvDatos);
                        MessageBox.Show("Registro agregado!!", "Mensaje", MessageBoxButtons.OK,
                            MessageBoxIcon.Information);
                    }
                    else
                    {
                        MessageBox.Show("No se pudo agregar registro", "Error", MessageBoxButtons.OK,
                            MessageBoxIcon.Error);

                    }

                }
                else
                {
                    MessageBox.Show("Ciudad Existente!!!", "Error", MessageBoxButtons.OK,
                        MessageBoxIcon.Error);

                }
            }
            catch (Exception ex)
            {

                MessageBox.Show(ex.Message, "Error", MessageBoxButtons.OK,
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
            CiudadListDto ciudadDto = r.Tag as CiudadListDto;
            try
            {
                DialogResult dr = MessageBox.Show($"¿Desea dar de baja la ciudad de {ciudadDto.NombreCiudad}?",
                    "Confirmar Borrado",
                    MessageBoxButtons.YesNo, MessageBoxIcon.Question,
                    MessageBoxDefaultButton.Button2);
                if (dr == DialogResult.No) { return; }
                Ciudad ciudad = _serviciosCiudades.GetCiudadPorId(ciudadDto.CiudadId);
                if (ciudad != null)
                {
                    if (!_serviciosCiudades.EstaRelacionado(ciudad))
                    {
                        int registrosAfectados = _serviciosCiudades.Borrar(ciudad);
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
            catch (Exception)
            {

                throw;
            }

        }

        private void RecargarGrilla()
        {
            try
            {
                listaCiudades = _serviciosCiudades.GetAll(null);
                MostrarDatosEnGrilla(listaCiudades);
            }
            catch (Exception)
            {

                throw;
            }
        }

        private void tsbEditar_Click(object sender, EventArgs e)
        {
            if (dgvDatos.SelectedRows.Count == 0)
            {
                return;
            }
            DataGridViewRow r = dgvDatos.SelectedRows[0];
            CiudadListDto ciudadDto = (CiudadListDto)r.Tag;
            CiudadListDto ciudadCopia = (CiudadListDto)ciudadDto.Clone();
            Ciudad ciudad = _serviciosCiudades.GetCiudadPorId(ciudadDto.CiudadId);
            frmCiudadAE frm = new frmCiudadAE() { Text = "Editar Ciudad" };
            frm.SetCiudad(ciudad);
            DialogResult dr = frm.ShowDialog(this);
            if (dr == DialogResult.Cancel) { return; }
            try
            {
                ciudad = frm.GetCiudad();
                if (!_serviciosCiudades.Existe(ciudad))
                {
                    int registrosAfectados = _serviciosCiudades.Guardar(ciudad);
                    if (registrosAfectados > 0)
                    {
                        ciudadDto = _serviciosCiudades.GetCiudadDtoPorId(ciudad.CiudadId);
                        GridHelper.SetearFila(r, ciudadDto);
                        MessageBox.Show("Registro Editado", "Mensaje",
                           MessageBoxButtons.OK, MessageBoxIcon.Information);
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
                    MessageBox.Show("Registro Duplicado!!!", "Error",
                        MessageBoxButtons.OK, MessageBoxIcon.Error);
                    GridHelper.SetearFila(r, ciudadCopia);

                }

            }
            catch (Exception ex)
            {

                MessageBox.Show(ex.Message, "Error",
                    MessageBoxButtons.OK, MessageBoxIcon.Error);
                GridHelper.SetearFila(r, ciudadCopia);
            }
        }

        private void tsbFiltrar_Click(object sender, EventArgs e)
        {
            if (filterOn)
            {
                MessageBox.Show("Filtro aplicado...\nActualizar antes",
                    "Advertencia",
                    MessageBoxButtons.OK, MessageBoxIcon.Warning);
                return;
            }
            frmSeleccionarPais frm = new frmSeleccionarPais() { Text = "País para Filtrar" };
            DialogResult dr = frm.ShowDialog(this);
            if (dr == DialogResult.Cancel) return;
            Pais paisFiltro = frm.GetPais();
            try
            {
                listaCiudades = _serviciosCiudades.GetAll(paisFiltro);
                MostrarDatosEnGrilla(listaCiudades);
                tsbFiltrar.BackColor = Color.Orange;
                filterOn = true;
            }
            catch (Exception ex)
            {

                MessageBox.Show(ex.Message, "Error", MessageBoxButtons.OK, MessageBoxIcon.Error);
            }

        }

        private void tsbActualizar_Click(object sender, EventArgs e)
        {
            filterOn = false;
            tsbFiltrar.BackColor = SystemColors.Control;
            RecargarGrilla();
        }



        private void txtCiudadBuscar_TextChanged(object sender, EventArgs e)
        {
            if (txtCiudadBuscar.Text != string.Empty)
            {
                var lista = listaCiudades
            .Where(c => c.NombreCiudad.StartsWith(txtCiudadBuscar.Text, StringComparison.CurrentCultureIgnoreCase))
            .ToList();
                MostrarDatosEnGrilla(lista);

            }
            else
            {
                txtCiudadBuscar.PlaceholderText = "Ingrese ciudad a buscar";
                txtCiudadBuscar.Enabled = false;
                RecargarGrilla();
            }
        }

        private void tsbBuscar_Click(object sender, EventArgs e)
        {
            txtCiudadBuscar.Enabled = true;
            txtCiudadBuscar.Focus();
        }
    }
}
