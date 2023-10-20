using NeptunoNet2023.Entidades.Entidades;
using System.Configuration;
using System.Data;
using System.Data.SqlClient;

namespace NeptunoNet2023.DatosSql
{
	public class RepositorioPaises
	{
		private string connectionString;
        public RepositorioPaises()
        {
			connectionString = ConfigurationManager.ConnectionStrings["MiConexion"].ToString();
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

		public void Agregar(Pais pais)
		{
			using (var conn=new SqlConnection(connectionString))
			{
				conn.Open();
				string insertQuery = @"INSERT INTO Paises (NombrePais) VALUES(@NombrePais);
					SELECT SCOPE_IDENTITY()";
				using (var cmd = new SqlCommand(insertQuery, conn))
				{
					cmd.Parameters.AddWithValue("@NombrePais", pais.NombrePais);

					//               cmd.Parameters.Add("@NombrePais", SqlDbType.NVarChar);
					//cmd.Parameters["@NombrePais"].Value = pais.NombrePais;

					//cmd.ExecuteNonQuery();
					int id=Convert.ToInt32(cmd.ExecuteScalar());
					pais.PaisId= id;
                }
            }
        }

        public void Borrar(int paisId)
        {
			using (var conn=new SqlConnection(connectionString))
			{
				conn.Open();
				string deleteQuery = "DELETE FROM Paises WHERE PaisId=@PaisId";
				using (var cmd=new SqlCommand(deleteQuery,conn))
				{
					cmd.Parameters.Add("@PaisId", SqlDbType.Int);
					cmd.Parameters["@PaisId"].Value=paisId;
					cmd.ExecuteNonQuery();
				}
			}
        }

        public void Editar(Pais pais)
        {
            using (var conn = new SqlConnection(connectionString))
            {
                conn.Open();
				string updateQuery = @"UPDATE Paises SET NombrePais=@NombrePais 
							WHERE PaisId=@PaisId";
                using (var cmd = new SqlCommand(updateQuery, conn))
                {

					cmd.Parameters.Add("@NombrePais", SqlDbType.NVarChar);
					cmd.Parameters["@NombrePais"].Value = pais.NombrePais;

                    cmd.Parameters.Add("@PaisId", SqlDbType.Int);
                    cmd.Parameters["@PaisId"].Value = pais.PaisId;

                    cmd.ExecuteNonQuery();
                }
            }
        }
    }
}
