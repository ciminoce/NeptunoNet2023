using NeptunoNet2023.Entidades.Entidades;
using System.Configuration;
using System.Data.SqlClient;

namespace NeptunoNet2023.DatosSql
{
	public class RepositorioPaises
	{
		private string connectionString;
        public RepositorioPaises()
        {
			//connectionString = ConfigurationManager.ConnectionStrings["MiConexion"].ToString();
			connectionString = "Server =.; Database = NeptunoFer2023; Trusted_Connection = true";

		}
        public List<Pais> GetAll()
		{
			var listaPaises=new List<Pais>();
			using (var conn=new SqlConnection(connectionString))
			{
				conn.Open();
				string selectQuery = "SELECT PaisId, NombrePais FROM Paises";
				using (var command = new SqlCommand(selectQuery, conn))
				{
					using (var reader=command.ExecuteReader())
					{
						while (reader.Read())
						{
							var pais = ConstruirPais(reader);
							listaPaises.Add(pais);
						}
					}
				}

			}
			return listaPaises;
		}

		private Pais ConstruirPais(SqlDataReader reader)
		{
			return new Pais
			{
				PaisId = reader.GetInt32(0),
				NombrePais = reader.GetString(1),
			};
		}
	}
}
