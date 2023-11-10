using NeptunoNet2023.Comun.Interfaces;
using NeptunoNet2023.Entidades.Entidades;
using System.Configuration;
using System.Data.SqlClient;

namespace NeptunoNet2023.DatosSql
{
	public class RepositorioCategorias : IRepositorioCategorias
	{
		private readonly string _connectionString;
		public RepositorioCategorias()
		{
			_connectionString = ConfigurationManager.ConnectionStrings["MiConexion"].ToString();
		}

		public List<Categoria> GetAll()
		{
			List<Categoria> categorias = new List<Categoria>();
			using (var conn = new SqlConnection(_connectionString))
			{
				conn.Open();
				string selectQuery = @"SELECT CategoriaId, NombreCategoria, 
                        Descripcion FROM Categorias";
				using (var cmd = new SqlCommand(selectQuery, conn))
				{
					using (var reader = cmd.ExecuteReader())
					{
						while (reader.Read())
						{
							Categoria categoria = ConstruirCategoria(reader);
							categorias.Add(categoria);
						}
					}
				}
			}
			return categorias;

		}

		private Categoria ConstruirCategoria(SqlDataReader reader)
		{
			return new Categoria
			{
				CategoriaId = reader.GetInt32(0),
				NombreCategoria = reader.GetString(1),
				Descripcion = reader.GetString(2)
			};
		}
	}
}
