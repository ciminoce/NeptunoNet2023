using NeptunoNet2023.Comun.Interfaces;
using NeptunoNet2023.Entidades.Entidades;
using System.Configuration;
using System.Data.SqlClient;

namespace NeptunoNet2023.DatosSql
{
	public class RepositorioCiudades : IRepositorioCiudades
	{
		private readonly string _connectionString;
		public RepositorioCiudades()
		{
			_connectionString = ConfigurationManager.ConnectionStrings["MiConexion"].ToString();
		}

		public List<Ciudad> GetAll()
		{
			List<Ciudad> lista = new List<Ciudad>();
			using (var conn=new SqlConnection(_connectionString))
			{
				conn.Open();
				string selectQuery = @"SELECT CiudadId, NombreCiudad, PaisId, RowVersion 
					FROM Ciudades";
				using (var cmd=new SqlCommand(selectQuery,conn))
				{
					using (var reader=cmd.ExecuteReader())
					{
						while (reader.Read())
						{
							Ciudad ciudad = ConstruirCiudad(reader);
							lista.Add(ciudad);
						}
					}
				}
			}
			return lista;
		}

		private Ciudad ConstruirCiudad(SqlDataReader reader)
		{
			return new Ciudad()
			{
				CiudadId = reader.GetInt32(0),
				NombreCiudad = reader.GetString(1),
				PaisId = reader.GetInt32(2),
				RowVersion = (byte[])reader[3]
			};
		}
	}
}
