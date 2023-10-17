using NeptunoNet2023.Entidades.Entidades;
using NeptunoNet2023.Servicios.Servicios;

namespace NeptunoNet2023.Windows
{
	public partial class frmPaises : Form
	{
		private readonly ServiciosPaises _serviciosPaises;
		List<Pais> listaPaises;
		public frmPaises()
		{
			InitializeComponent();
			_serviciosPaises = new ServiciosPaises();
		}

		private void tsbCerrar_Click(object sender, EventArgs e)
		{
			Close();
		}

		private void frmPaises_Load(object sender, EventArgs e)
		{
			try
			{
				listaPaises = _serviciosPaises.GetAll();
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
			foreach (var item in listaPaises)
			{
				DataGridViewRow r = ConstruirFila();
				SetearFila(r,item);
				AgregarFila(r);
			}
		}

		private void SetearFila(DataGridViewRow r, Pais item)
		{
			r.Cells[colPais.Index].Value = item.NombrePais;
			r.Tag= item;
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
