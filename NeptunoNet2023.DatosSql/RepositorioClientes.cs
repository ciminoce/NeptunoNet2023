using NeptunoNet2023.Comun.Interfaces;
using NeptunoNet2023.Entidades.Dtos.Cliente;
using NeptunoNet2023.Entidades.Entidades;
using System.Configuration;
using System.Data.SqlClient;

namespace NeptunoNet2023.DatosSql
{
    public class RepositorioClientes : IRepositorioClientes
    {
        private readonly string _connectionString;
        public RepositorioClientes()
        {
            _connectionString = ConfigurationManager.ConnectionStrings["MiConexion"].ToString();
        }

        public int Agregar(Cliente cliente)
        {
            int registrosAfectados = 0;
            using (var conn = new SqlConnection(_connectionString))
            {
                conn.Open();
                string insertQuery = @"INSERT INTO Clientes(NombreCliente, Direccion, CodPostal,
                    PaisId, CiudadId, TelFijo, TelMovil) 
					VALUES(@Nombre,@Direccion, @CodPostal, @PaisId, @CiudadId,  
                        @TelFijo, @TelMovil)";
                using (var cmd = new SqlCommand(insertQuery, conn))
                {
                    cmd.Parameters.AddWithValue("@Nombre", cliente.NombreCliente);
                    cmd.Parameters.AddWithValue("@Direccion", cliente.Direccion);
                    cmd.Parameters.AddWithValue("@CodPostal", cliente.CodPostal);
                    cmd.Parameters.AddWithValue("@PaisId", cliente.PaisId);
                    cmd.Parameters.AddWithValue("@CiudadId", cliente.CiudadId);

                    if (cliente.TelFijo!=null)
                    {
                        cmd.Parameters.AddWithValue("@TelFijo", cliente.TelFijo);
                    }
                    else
                    {
                        cmd.Parameters.AddWithValue("@TelFijo", DBNull.Value);
                    }

                    if (cliente.TelMovil != null)
                    {
                        cmd.Parameters.AddWithValue("@TelMovil", cliente.TelMovil);
                    }
                    else
                    {
                        cmd.Parameters.AddWithValue("@TelMovil", DBNull.Value);
                    }

                    registrosAfectados = cmd.ExecuteNonQuery();
                }
                if (registrosAfectados > 0)
                {
                    string selectQuery = "SELECT @@IDENTITY";
                    using (var cmd = new SqlCommand(selectQuery, conn))
                    {
                        int id = Convert.ToInt32(cmd.ExecuteScalar());
                        cliente.ClienteId = id;
                    }
                    selectQuery = @"SELECT RowVersion FROM Clientes 
						WHERE ClienteId=@ClienteId";
                    using (var cmd = new SqlCommand(selectQuery, conn))
                    {
                        cmd.Parameters.AddWithValue("@ClienteId", cliente.ClienteId);
                        byte[] rowVersion = (byte[])cmd.ExecuteScalar();
                        cliente.RowVersion = rowVersion;
                    }

                }

            }
            return registrosAfectados;
        }

        public bool Existe(Cliente cliente)
        {
            int registros = 0;
            using (var conn = new SqlConnection(_connectionString))
            {
                conn.Open();
                //Alta
                if (cliente.ClienteId == 0)
                {
                    string selectQuery = @"SELECT COUNT(*) AS Cantidad FROM Clientes
                        WHERE NombreCliente=@Nombre AND PaisId=@PaisId AND CiudadId=@CiudadId";
                    using (var cmd = new SqlCommand(selectQuery, conn))
                    {
                        cmd.Parameters.AddWithValue("@Nombre", cliente.NombreCliente);
                        cmd.Parameters.AddWithValue("@PaisId", cliente.PaisId);
                        cmd.Parameters.AddWithValue("@CiudadId", cliente.CiudadId);

                        registros = Convert.ToInt32(cmd.ExecuteScalar());

                    }

                }
                else
                {
                    string selectQuery = @"SELECT COUNT(*) AS Cantidad FROM Clientes
                        WHERE NombreCliente=@Nombre AND PaisId=@PaisId 
                        AND CiudadId=@CiudadId AND ClienteId<>@ClienteId";
                    using (var cmd = new SqlCommand(selectQuery, conn))
                    {
                        cmd.Parameters.AddWithValue("@Nombre", cliente.NombreCliente);
                        cmd.Parameters.AddWithValue("@PaisId", cliente.PaisId);
                        cmd.Parameters.AddWithValue("@CiudadId", cliente.CiudadId);

                        cmd.Parameters.AddWithValue("@ClienteId", cliente.ClienteId);

                        registros = Convert.ToInt32(cmd.ExecuteScalar());

                    }


                }

            }
            return registros > 0;
        }

        public Cliente GetClientePorId(int clienteId)
        {
            Cliente cliente= null;
            using (var conn = new SqlConnection(_connectionString))
            {
                conn.Open();
                string selectQuery = @"SELECT ClienteId, NombreCliente, Direccion, 
                        CodPostal, PaisId, CiudadId, TelFijo, TelMovil, RowVersion
                    FROM Clientes 
                    WHERE ClienteId=@ClienteId";
                using (var cmd = new SqlCommand(selectQuery, conn))
                {
                    cmd.Parameters.AddWithValue("@ClienteId", clienteId);
                    using (var reader = cmd.ExecuteReader())
                    {
                        if (reader.HasRows)
                        {
                            reader.Read();
                            cliente = ConstruirCliente(reader);
                        }
                    }
                }

            }
            return cliente;

        }

        private Cliente ConstruirCliente(SqlDataReader reader)
        {
            return new Cliente()
            {
                ClienteId = reader.GetInt32(0),
                NombreCliente = reader.GetString(1),
                Direccion = reader.GetString(2),
                CodPostal = reader.GetString(3),
                PaisId = reader.GetInt32(4),
                CiudadId = reader.GetInt32(5),
                TelFijo = reader[6] != DBNull.Value ? reader.GetString(6) : string.Empty,
                TelMovil = reader[7] != DBNull.Value ? reader.GetString(7) : string.Empty,
                RowVersion = (byte[])reader[8]
            };
        }

        public List<ClienteListDto> GetClientes()
        {
            List<ClienteListDto> clientes=new List<ClienteListDto>();
            using (var conn=new SqlConnection(_connectionString))
            {
                conn.Open();
                string selectQuery = @"SELECT cli.ClienteId, cli.NombreCliente, p.NombrePais, 
                    c.NombreCiudad, cli.TelFijo, cli.TelMovil FROM Clientes cli
	                INNER JOIN Paises p ON cli.PaisId=p.PaisId 
                    INNER JOIN Ciudades c ON cli.CiudadId=c.CiudadId 
                    ORDER BY cli.NombreCliente";
                using (var cmd=new SqlCommand(selectQuery,conn))
                {
                    using (var reader=cmd.ExecuteReader())
                    {
                        while (reader.Read())
                        {
                            ClienteListDto cliente = ConstruirClienteDto(reader);
                            clientes.Add(cliente);
                        }
                    }
                }

            }
            return clientes;
        }

        private ClienteListDto ConstruirClienteDto(SqlDataReader reader)
        {
            return new ClienteListDto
            {
                ClienteId = reader.GetInt32(0),
                NombreCliente = reader.GetString(1),
                NombrePais = reader.GetString(2),
                NombreCiudad = reader.GetString(3),
                TelFijo = reader[4]!=DBNull.Value? reader.GetString(4):string.Empty,
                TelMovil =reader[5]!=DBNull.Value? reader.GetString(5):string.Empty,

            };
        }

        public ClienteListDto GetClienteDtoPorId(int clienteId)
        {
            ClienteListDto clienteDto = null;
            using (var conn = new SqlConnection(_connectionString))
            {
                conn.Open();
                string selectQuery = @"SELECT cli.ClienteId, cli.NombreCliente, p.NombrePais, 
                    c.NombreCiudad, cli.TelFijo, cli.TelMovil FROM Clientes cli
	                INNER JOIN Paises p ON cli.PaisId=p.PaisId 
                    INNER JOIN Ciudades c ON cli.CiudadId=c.CiudadId 
                    WHERE cli.ClienteId=@ClienteId";
                using (var cmd = new SqlCommand(selectQuery, conn))
                {
                    cmd.Parameters.AddWithValue("@ClienteId", clienteId);
                    using (var reader = cmd.ExecuteReader())
                    {

                        if (reader.HasRows)
                        {
                            reader.Read();
                            clienteDto = ConstruirClienteDto(reader);
                           
                        }
                    }
                }

            }
            return clienteDto;

        }

        public bool EstaRelacionado(Cliente cliente)
        {
            int cantidad = 0;
            using (var conn = new SqlConnection(_connectionString))
            {
                conn.Open();
                string selectQuery = @"SELECT COUNT(*) FROM Ventas
                        WHERE ClienteId = @ClienteId";
                using (var cmd = new SqlCommand(selectQuery, conn))
                {
                    cmd.Parameters.AddWithValue("@ClienteId", cliente.ClienteId);

                    cantidad = (int)cmd.ExecuteScalar();
                }
            }
            return cantidad>0;
        }

        public int Borrar(Cliente cliente)
        {
            int registrosAfectados = 0;
            using (var conn = new SqlConnection(_connectionString))
            {
                conn.Open();
                string deleteQuery = @"DELETE FROM Clientes WHERE ClienteId=@ClienteId 
                        AND RowVersion=@RowVersion";
                using (var cmd = new SqlCommand(deleteQuery, conn))
                {
                    cmd.Parameters.AddWithValue("@ClienteId", cliente.ClienteId);
                    cmd.Parameters.AddWithValue("@RowVersion", cliente.RowVersion);

                    registrosAfectados = cmd.ExecuteNonQuery();
                }
            }
            return registrosAfectados;

        }
    }
}
