using NeptunoNet2023.Comun.Interfaces;
using NeptunoNet2023.Entidades.Dtos.Ciudad;
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
        public List<CiudadListDto>? GetAll(Pais paisFiltro=null)
        {
            List<CiudadListDto> lista = new List<CiudadListDto>();
            using (var conn = new SqlConnection(_connectionString))
            {
                conn.Open();
                string selectQuery = @"SELECT c.CiudadId, c.NombreCiudad, p.NombrePais 
						FROM Ciudades c INNER JOIN Paises p 
						ON c.PaisId=p.PaisId";
                string conditional = " WHERE c.PaisId=@PaisId ";                       
                string order=" ORDER BY c.NombreCiudad";

                if (paisFiltro == null)
                {
                    selectQuery += order;
                }
                else
                {
                    selectQuery = string.Concat(selectQuery, conditional, order);
                }
                using (var cmd = new SqlCommand(selectQuery, conn))
                {
                    if (paisFiltro != null)
                    {
                        cmd.Parameters.AddWithValue("@PaisId", paisFiltro.PaisId);
                    }
                    using (var reader = cmd.ExecuteReader())
                    {
                        while (reader.Read())
                        {
                            CiudadListDto ciudad = ConstruirCiudadDto(reader);
                            lista.Add(ciudad);
                        }
                    }
                }
            }
            return lista;
        }

        private CiudadListDto ConstruirCiudadDto(SqlDataReader reader)
        {
            return new CiudadListDto
            {
                CiudadId = reader.GetInt32(0),
                NombreCiudad = reader.GetString(1),
                NombrePais = reader.GetString(2)
            };
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

        public int Agregar(Ciudad ciudad)
        {
            int registrosAfectados = 0;
            using (var conn = new SqlConnection(_connectionString))
            {
                conn.Open();
                string insertQuery = @"INSERT INTO Ciudades(NombreCiudad, PaisId) 
					VALUES(@Nombre, @PaisId)";
                using (var cmd = new SqlCommand(insertQuery, conn))
                {
                    cmd.Parameters.AddWithValue("@Nombre", ciudad.NombreCiudad);
                    cmd.Parameters.AddWithValue("@PaisId", ciudad.PaisId);

                    registrosAfectados = cmd.ExecuteNonQuery();
                }
                if (registrosAfectados > 0)
                {
                    string selectQuery = "SELECT @@IDENTITY";
                    using (var cmd = new SqlCommand(selectQuery, conn))
                    {
                        int id = Convert.ToInt32(cmd.ExecuteScalar());
                        ciudad.CiudadId = id;
                    }
                    selectQuery = @"SELECT RowVersion FROM Ciudades 
						WHERE CiudadId=@CiudadId";
                    using (var cmd = new SqlCommand(selectQuery, conn))
                    {
                        cmd.Parameters.AddWithValue("@CiudadId", ciudad.CiudadId);
                        byte[] rowVersion = (byte[])cmd.ExecuteScalar();
                        ciudad.RowVersion = rowVersion;
                    }

                }

            }
            return registrosAfectados;
        }

        public CiudadListDto GetCiudadDtoPorId(int ciudadId)
        {
            CiudadListDto ciudadDto = null;
            using (var conn = new SqlConnection(_connectionString))
            {
                conn.Open();
                string selectQuery = @"SELECT c.CiudadId, c.NombreCiudad, p.NombrePais 
					FROM Ciudades c INNER JOIN Paises p 
					ON c.PaisId=p.PaisId WHERE CiudadId=@CiudadId";
                using (var cmd = new SqlCommand(selectQuery, conn))
                {
                    cmd.Parameters.AddWithValue("@CiudadId", ciudadId);
                    using (var reader = cmd.ExecuteReader())
                    {
                        if (reader.HasRows)
                        {
                            reader.Read();
                            ciudadDto = ConstruirCiudadDto(reader);
                        }
                    }
                }
            }
            return ciudadDto;
        }

        public bool Existe(Ciudad ciudad)
        {
            int registros = 0;
            using (var conn = new SqlConnection(_connectionString))
            {
                conn.Open();
                if (ciudad.CiudadId == 0)
                {
                    string selectQuery = @"SELECT COUNT(*) AS Cantidad FROM Ciudades
                        WHERE NombreCiudad=@Nombre AND PaisId=@PaisId";
                    using (var cmd = new SqlCommand(selectQuery, conn))
                    {
                        cmd.Parameters.AddWithValue("@Nombre", ciudad.NombreCiudad);
                        cmd.Parameters.AddWithValue("@PaisId", ciudad.PaisId);

                        registros = Convert.ToInt32(cmd.ExecuteScalar());

                    }

                }
                else
                {
                    string selectQuery = @"SELECT COUNT(*) AS Cantidad FROM Ciudades
                        WHERE NombreCiudad=@Nombre AND PaisId=@PaisId 
                        AND CiudadId<>@CiudadId";
                    using (var cmd = new SqlCommand(selectQuery, conn))
                    {
                        cmd.Parameters.AddWithValue("@Nombre", ciudad.NombreCiudad);
                        cmd.Parameters.AddWithValue("@PaisId", ciudad.PaisId);
                        cmd.Parameters.AddWithValue("@CiudadId", ciudad.CiudadId);

                        registros = Convert.ToInt32(cmd.ExecuteScalar());

                    }


                }

            }
            return registros > 0;
        }

        public Ciudad GetCiudadPorId(int ciudadId)
        {
            Ciudad ciudad = null;
            using (var conn = new SqlConnection(_connectionString))
            {
                conn.Open();
                string selectQuery = @"SELECT c.CiudadId, c.NombreCiudad, c.PaisId, c.RowVersion 
					FROM Ciudades c 
					WHERE CiudadId=@CiudadId";
                using (var cmd = new SqlCommand(selectQuery, conn))
                {
                    cmd.Parameters.AddWithValue("@CiudadId", ciudadId);
                    using (var reader = cmd.ExecuteReader())
                    {
                        if (reader.HasRows)
                        {
                            reader.Read();
                            ciudad = ConstruirCiudad(reader);
                        }
                    }
                }
            }
            return ciudad;
        }

        public bool EstaRelacionado(Ciudad ciudad)
        {
            int cantidad = 0;
            using (var conn = new SqlConnection(_connectionString))
            {
                conn.Open();
                string selectQuery = @"SELECT
                    (SELECT COUNT(*) FROM Clientes WHERE CiudadId = @CiudadId) +
                    (SELECT COUNT(*) FROM Proveedores WHERE CiudadId =@CiudadId)
                    AS TotalCantidad";
                using (var cmd = new SqlCommand(selectQuery, conn))
                {
                    cmd.Parameters.AddWithValue("@CiudadId", ciudad.CiudadId);

                    cantidad = (int)cmd.ExecuteScalar();
                }
            }
            return cantidad > 0;
        }

        public int Borrar(Ciudad ciudad)
        {
            int registrosAfectados = 0;
            using (var conn = new SqlConnection(_connectionString))
            {
                conn.Open();
                string deleteQuery = @"DELETE FROM Ciudades WHERE CiudadId=@CiudadId 
                        AND RowVersion=@RowVersion";
                using (var cmd = new SqlCommand(deleteQuery, conn))
                {
                    cmd.Parameters.AddWithValue("@CiudadId", ciudad.CiudadId);
                    cmd.Parameters.AddWithValue("@RowVersion", ciudad.RowVersion);

                    registrosAfectados = cmd.ExecuteNonQuery();
                }
            }
            return registrosAfectados;
        }

        public int Editar(Ciudad ciudad)
        {
            int registrosAfectados = 0;
            using (var conn = new SqlConnection(_connectionString))
            {
                conn.Open();
                string updateQuery = @"UPDATE Ciudades SET NombreCiudad=@NombreCiudad,
                            PaisId=@PaisId
							WHERE CiudadId=@CiudadId AND RowVersion=@RowVersion";
                using (var cmd = new SqlCommand(updateQuery, conn))
                {

                    cmd.Parameters.AddWithValue("@NombreCiudad", ciudad.NombreCiudad);
                    cmd.Parameters.AddWithValue("@PaisId", ciudad.PaisId);
                    cmd.Parameters.AddWithValue("@CiudadId", ciudad.CiudadId);
                    cmd.Parameters.AddWithValue("@RowVersion", ciudad.RowVersion);
                    registrosAfectados = cmd.ExecuteNonQuery();
                    if (registrosAfectados > 0)
                    {
                        string selectQuery = @"SELECT RowVersion FROM Ciudades 
							WHERE CiudadId=@CiudadId";
                        using (var comando = new SqlCommand(selectQuery, conn))
                        {
                            comando.Parameters.AddWithValue("@CiudadId", ciudad.CiudadId);

                            var row = (byte[])comando.ExecuteScalar();
                            ciudad.RowVersion = row;

                        }

                    }
                }
            }
            return registrosAfectados;
        }

    }
}
