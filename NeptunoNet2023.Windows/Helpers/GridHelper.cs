using NeptunoNet2023.Entidades.Entidades;

namespace NeptunoNet2023.Windows.Helpers
{
	public static class GridHelper
	{
		public static void LimpiarGrilla(DataGridView dgv)
		{
			dgv.Rows.Clear();
		}

		public static DataGridViewRow ConstruirFila(DataGridView dgv)
		{
			DataGridViewRow r = new DataGridViewRow();
			r.CreateCells(dgv);
			return r;

		}

		public static void QuitarFila(DataGridViewRow r, DataGridView dgv)
		{
			dgv.Rows.Remove(r);
		}
		public static void SetearFila(DataGridViewRow r, object item)
		{
			switch (item)
			{
				case Pais pais:
					r.Cells[0].Value = pais.NombrePais;
					break;
				case Categoria categoria:
					r.Cells[0].Value = categoria.NombreCategoria;
					r.Cells[1].Value = categoria.Descripcion;
					break;
				case Ciudad ciudad:
					r.Cells[0].Value = ciudad.NombreCiudad;
					//r.Cells[1].Value = ciudad.Pais;
					r.Cells[1].Value = ciudad.Pais.NombrePais;
					break;
				default:
					break;

			}
			r.Tag = item;
		}

		public static void AgregarFila(DataGridViewRow r, DataGridView dgv)
		{
			dgv.Rows.Add(r);
		}

	}
}
