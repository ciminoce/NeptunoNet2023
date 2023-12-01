using NeptunoNet2023.Comun.Interfaces;
using NeptunoNet2023.Entidades.Dtos.Cliente;
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
                NombreCiudad = reader.GetString(3)
                //TODO: Ver los teléfonos

            };
        }
    }
}
