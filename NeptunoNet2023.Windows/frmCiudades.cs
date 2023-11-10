using NeptunoNet2023.Entidades.Entidades;
using NeptunoNet2023.Servicios.Interfaces;
using NeptunoNet2023.Servicios.Servicios;
using NeptunoNet2023.Windows.Helpers;

namespace NeptunoNet2023.Windows
{
	public partial class frmCiudades : Form
	{
		private readonly IServiciosCiudades _serviciosCiudades;
		private List<Ciudad> listaCiudades;
		public frmCiudades()
		{
			InitializeComponent();
			_serviciosCiudades = new ServiciosCiudades();
		}

		private void frmCiudades_Load(object sender, EventArgs e)
		{
			try
			{
				listaCiudades = _serviciosCiudades.GetAll();
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
			foreach (var item in listaCiudades)
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
	}
}
