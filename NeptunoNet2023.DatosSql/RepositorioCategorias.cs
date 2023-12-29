using NeptunoNet2023.Comun.Interfaces;
using NeptunoNet2023.Entidades.Entidades;
using System.Configuration;
using System.Data;
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

        public bool EstaRelacionado(Categoria categoria)
        {
            using (var conn = new SqlConnection(_connectionString))
            {
                conn.Open();
                string selectQuery;
                selectQuery = @"SELECT COUNT(*) AS Cantidad FROM Productos 
                            WHERE CategoriaId = @CategoriaId";
                using (var cmd = new SqlCommand(selectQuery, conn))
                {
                    cmd.Parameters.Add("@CategoriaId", SqlDbType.Int);
                    cmd.Parameters["@CategoriaId"].Value = categoria.CategoriaId;

                    return (int)cmd.ExecuteScalar() > 0;
                }
            }
        }

        public int Agregar(Categoria categoria)
        {
            int registrosAfectados = 0;
            using (var conn = new SqlConnection(_connectionString))
            {
                conn.Open();
                string insertQuery = @"INSERT INTO Categorias 
                    (NombreCategoria, Descripcion) 
                    VALUES(@NombreCategoria, @Descripcion)";

                using (var cmd = new SqlCommand(insertQuery, conn))
                {
                    cmd.Parameters.AddWithValue("@NombreCategoria", categoria.NombreCategoria);
                    cmd.Parameters.AddWithValue("@Descripcion", categoria.Descripcion);

                    registrosAfectados = cmd.ExecuteNonQuery();
                }

                if (registrosAfectados > 0)
                {
                    string selectQuery = @"SELECT @@IDENTITY";
                    using (var comando = new SqlCommand(selectQuery, conn))
                    {
                        var id = Convert.ToInt32(comando.ExecuteScalar());
                        categoria.CategoriaId = id;
                    }

                    selectQuery = @"SELECT RowVersion FROM Categorias 
							WHERE CategoriaId=@CategoriaId";
                    using (var comando = new SqlCommand(selectQuery, conn))
                    {
                        comando.Parameters.AddWithValue("@CategoriaId", categoria.CategoriaId);
                        var row = (byte[])comando.ExecuteScalar();
                        categoria.RowVersion = row;

                    }

                }
            }
            return registrosAfectados;
        }

        public int Borrar(Categoria categoria)
        {
            int registrosAfectados = 0;
            using (var conn = new SqlConnection(_connectionString))
            {
                conn.Open();

                string deleteQuery = @"DELETE FROM Categorias 
                    WHERE CategoriaId=@CategoriaId AND 
					RowVersion=@RowVersion";
                using (var cmd = new SqlCommand(deleteQuery, conn))
                {
                    cmd.Parameters.AddWithValue("@CategoriaId",categoria.CategoriaId);

                    cmd.Parameters.AddWithValue("@RowVersion", categoria.RowVersion);

                    registrosAfectados = cmd.ExecuteNonQuery();
                }
            }
            return registrosAfectados;
        }

        public int Editar(Categoria categoria)
        {
            int registrosAfectados = 0;
            using (var conn = new SqlConnection(_connectionString))
            {
                conn.Open();
                string updateQuery = @"UPDATE Categorias SET NombreCategoria=@NombreCategoria ,
                            Descripcion=@Descripcion 
							WHERE CategoriaId=@CategoriaId AND RowVersion=@RowVersion";
                using (var cmd = new SqlCommand(updateQuery, conn))
                {

                    cmd.Parameters.AddWithValue("@NombreCategoria",categoria.NombreCategoria);
                    cmd.Parameters.AddWithValue("@Descripcion",categoria.Descripcion);

                    cmd.Parameters.AddWithValue("@CategoriaId", categoria.CategoriaId);

                    cmd.Parameters.AddWithValue("@RowVersion",categoria.RowVersion);

                    registrosAfectados = cmd.ExecuteNonQuery();
                    if (registrosAfectados > 0)
                    {
                        string selectQuery = @"SELECT RowVersion FROM Categorias 
							WHERE CategoriaId=@CategoriaId";
                        using (var comando = new SqlCommand(selectQuery, conn))
                        {
                            comando.Parameters.AddWithValue("@CategoriaId", categoria.CategoriaId);

                            var row = (byte[])comando.ExecuteScalar();
                            categoria.RowVersion = row;

                        }

                    }
                }
            }
            return registrosAfectados;
        }

        public bool Existe(Categoria categoria)
        {
            using (var conn = new SqlConnection(_connectionString))
            {
                conn.Open();
                string selectQuery;
                if (categoria.CategoriaId == 0)
                {
                    selectQuery = @"SELECT COUNT(*) AS Cantidad FROM Categorias 
                                WHERE NombreCategoria = @NombreCategoria";
                    using (var cmd = new SqlCommand(selectQuery, conn))
                    {
                        cmd.Parameters.Add("@NombreCategoria", SqlDbType.NVarChar);
                        cmd.Parameters["@NombreCategoria"].Value = categoria.NombreCategoria;
                        return (int)cmd.ExecuteScalar() > 0;
                    }
                }

                else
                {
                    selectQuery = @"SELECT COUNT(*) AS Cantidad FROM Categorias 
                                WHERE NombreCategoria = @NombreCategoria AND 
                                CategoriaId<>@CategoriaId";
                    using (var cmd = new SqlCommand(selectQuery, conn))
                    {
                        cmd.Parameters.Add("@NombreCategoria", SqlDbType.NVarChar);
                        cmd.Parameters["@NombreCategoria"].Value = categoria.NombreCategoria;

                        cmd.Parameters.Add("@CategoriaId", SqlDbType.Int);
                        cmd.Parameters["@CategoriaId"].Value = categoria.CategoriaId;

                        return (int)cmd.ExecuteScalar() > 0;
                    }
                }
            }
        }

        public List<Categoria> GetAll()
		{
			List<Categoria> categorias = new List<Categoria>();
			using (var conn = new SqlConnection(_connectionString))
			{
				conn.Open();
				string selectQuery = @"SELECT CategoriaId, NombreCategoria, 
                        Descripcion, RowVersion FROM Categorias";
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

        public Categoria GetCategoria(int categoriaId)
        {
            Categoria categoria = null;
            using (var conn = new SqlConnection(_connectionString))
            {
                conn.Open();
                string selectQuery = @"SELECT CategoriaId, NombreCategoria, Descripcion,
                     RowVersion FROM Categorias
						WHERE CategoriaId=@CategoriaId";
                using (var cmd = new SqlCommand(selectQuery, conn))
                {
                    cmd.Parameters.AddWithValue("@CategoriaId",categoriaId);
                    using (var reader = cmd.ExecuteReader())
                    {
                        if (reader.HasRows)
                        {
                            reader.Read();
                            categoria = ConstruirCategoria(reader);
                            
                        }
                    }
                }
            }
            return categoria;

        }

        private Categoria ConstruirCategoria(SqlDataReader reader)
		{
			return new Categoria
			{
				CategoriaId = reader.GetInt32(0),
				NombreCategoria = reader.GetString(1),
				Descripcion = reader.GetString(2),
                RowVersion = (byte[])reader[3]
			};
		}
	}
}
