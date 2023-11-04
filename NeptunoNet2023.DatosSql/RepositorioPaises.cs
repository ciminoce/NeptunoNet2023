using NeptunoNet2023.Comun.Interfaces;
using NeptunoNet2023.Entidades.Entidades;
using System.Configuration;
using System.Data;
using System.Data.SqlClient;

namespace NeptunoNet2023.DatosSql
{
	public class RepositorioPaises:IRepositorioPaises
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
				string selectQuery = "SELECT PaisId, NombrePais, RowVersion FROM Paises";
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
				RowVersion = (byte[])reader[2]
			};
		}

		public int Agregar(Pais pais)
		{
			int registrosAfectados = 0;
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
				string selectQuery = @"SELECT RowVersion FROM Paises 
							WHERE PaisId=@PaisId";
				using (var comando = new SqlCommand(selectQuery, conn))
				{
					comando.Parameters.Add("@PaisId", SqlDbType.Int);
					comando.Parameters["@PaisId"].Value = pais.PaisId;

					var row = (byte[])comando.ExecuteScalar();
					pais.RowVersion = row;

				}
				registrosAfectados = 1;
				return registrosAfectados;

			}
		}

        public int Borrar(Pais pais)
        {
			int registrosAfectados = 0;
			using (var conn=new SqlConnection(connectionString))
			{
				conn.Open();
				string deleteQuery = @"DELETE FROM Paises WHERE PaisId=@PaisId AND 
					RowVersion=@RowVersion";
				using (var cmd=new SqlCommand(deleteQuery,conn))
				{
					cmd.Parameters.Add("@PaisId", SqlDbType.Int);
					cmd.Parameters["@PaisId"].Value=pais.PaisId;

					cmd.Parameters.Add("@RowVersion", SqlDbType.Timestamp);
					cmd.Parameters["@RowVersion"].Value = pais.RowVersion;

					registrosAfectados=cmd.ExecuteNonQuery();
				}
			}
			return registrosAfectados;
        }

        public int Editar(Pais pais)
        {
			int registrosAfectados = 0;
            using (var conn = new SqlConnection(connectionString))
            {
                conn.Open();
				string updateQuery = @"UPDATE Paises SET NombrePais=@NombrePais 
							WHERE PaisId=@PaisId AND RowVersion=@RowVersion";
                using (var cmd = new SqlCommand(updateQuery, conn))
                {

					cmd.Parameters.Add("@NombrePais", SqlDbType.NVarChar);
					cmd.Parameters["@NombrePais"].Value = pais.NombrePais;

					cmd.Parameters.Add("@PaisId", SqlDbType.Int);
					cmd.Parameters["@PaisId"].Value = pais.PaisId;

					cmd.Parameters.Add("@RowVersion", SqlDbType.Timestamp);
					cmd.Parameters["@RowVersion"].Value = (byte[])pais.RowVersion;
					//cmd.Parameters.AddWithValue("@NombrePais", pais.NombrePais);
					//cmd.Parameters.AddWithValue("@PaisId",pais.PaisId);
					//cmd.Parameters.AddWithValue("@RowVersion", pais.RowVersion);

					registrosAfectados =cmd.ExecuteNonQuery();
					if (registrosAfectados>0)
					{
						string selectQuery = @"SELECT RowVersion FROM Paises 
							WHERE PaisId=@PaisId";
						using (var comando = new SqlCommand(selectQuery, conn))
						{
							comando.Parameters.Add("@PaisId", SqlDbType.Int);
							comando.Parameters["@PaisId"].Value = pais.PaisId;

							var row = (byte[])comando.ExecuteScalar();
							pais.RowVersion = row;

						}

					}
				}
            }
			return registrosAfectados;
        }

		public bool Existe(Pais pais)
		{
			
			using (var conn = new SqlConnection(connectionString))
			{
				conn.Open();
				string selectQuery;
				if (pais.PaisId == 0)
				{
					selectQuery = @"SELECT COUNT(*) AS Cantidad FROM Paises
						WHERE NombrePais=@NombrePais";
					using (var cmd = new SqlCommand(selectQuery, conn))
					{
						cmd.Parameters.Add("@NombrePais", SqlDbType.NVarChar);
						cmd.Parameters["@NombrePais"].Value = pais.NombrePais;

						return Convert.ToInt32(cmd.ExecuteScalar())>0;
					}

				}
				else
				{
					selectQuery = @"SELECT COUNT(*) AS Cantidad FROM Paises
						WHERE NombrePais=@NombrePais AND PaisId<>@PaisId";
					using (var cmd = new SqlCommand(selectQuery, conn))
					{
						cmd.Parameters.Add("@NombrePais", SqlDbType.NVarChar);
						cmd.Parameters["@NombrePais"].Value = pais.NombrePais;

						cmd.Parameters.Add("@PaisId", SqlDbType.Int);
						cmd.Parameters["@PaisId"].Value = pais.PaisId;


						return Convert.ToInt32(cmd.ExecuteScalar()) > 0;
					}

				}

			}
			

		}

		public bool EstaRelacionado(Pais pais)
		{
			throw new NotImplementedException();
		}
	}
}
