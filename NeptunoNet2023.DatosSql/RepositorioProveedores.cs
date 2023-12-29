using NeptunoNet2023.Comun.Interfaces;
using NeptunoNet2023.Entidades.Dtos.Ciudad;
using NeptunoNet2023.Entidades.Dtos.Proveedor;
using NeptunoNet2023.Entidades.Entidades;
using System.Configuration;
using System.Data.SqlClient;

namespace NeptunoNet2023.DatosSql
{
    public class RepositorioProveedores : IRepositorioProveedores
    {
        private readonly string _connectionString;
        public RepositorioProveedores()
        {
            _connectionString = ConfigurationManager.ConnectionStrings["MiConexion"].ToString();
        }

        public int Agregar(Proveedor proveedor)
        {
            int registrosAfectados = 0;
            using (var conn = new SqlConnection(_connectionString))
            {
                conn.Open();
                string insertQuery = @"INSERT INTO Proveedores (NombreProveedor, Direccion, CodPostal,
                    PaisId, CiudadId, Telefono) 
					VALUES(@Nombre,@Direccion, @CodPostal, @PaisId, @CiudadId,  
                        @Telefono)";
                using (var cmd = new SqlCommand(insertQuery, conn))
                {
                    cmd.Parameters.AddWithValue("@Nombre", proveedor.NombreProveedor);
                    cmd.Parameters.AddWithValue("@Direccion", proveedor.Direccion);
                    cmd.Parameters.AddWithValue("@CodPostal", proveedor.CodPostal);
                    cmd.Parameters.AddWithValue("@PaisId", proveedor.PaisId);
                    cmd.Parameters.AddWithValue("@CiudadId", proveedor.CiudadId);

                    if (proveedor.Telefono!=null)
                    {
                        cmd.Parameters.AddWithValue("@Telefono", proveedor.Telefono);
                    }
                    else
                    {
                        cmd.Parameters.AddWithValue("@Telefono", DBNull.Value);
                    }


                    registrosAfectados = cmd.ExecuteNonQuery();
                }
                if (registrosAfectados > 0)
                {
                    string selectQuery = "SELECT @@IDENTITY";
                    using (var cmd = new SqlCommand(selectQuery, conn))
                    {
                        int id = Convert.ToInt32(cmd.ExecuteScalar());
                        proveedor.ProveedorId = id;
                    }
                    selectQuery = @"SELECT RowVersion FROM Proveedores 
						WHERE ProveedorId=@ProveedorId";
                    using (var cmd = new SqlCommand(selectQuery, conn))
                    {
                        cmd.Parameters.AddWithValue("@ProveedorId", proveedor.ProveedorId);
                        byte[] rowVersion = (byte[])cmd.ExecuteScalar();
                        proveedor.RowVersion = rowVersion;
                    }

                }

            }
            return registrosAfectados;
        }

        public bool Existe(Proveedor proveedor)
        {
            int registros = 0;
            using (var conn = new SqlConnection(_connectionString))
            {
                conn.Open();
                //Alta
                if (proveedor.ProveedorId == 0)
                {
                    string selectQuery = @"SELECT COUNT(*) AS Cantidad FROM Proveedores
                        WHERE NombreProveedor=@Nombre AND PaisId=@PaisId AND CiudadId=@CiudadId";
                    using (var cmd = new SqlCommand(selectQuery, conn))
                    {
                        cmd.Parameters.AddWithValue("@Nombre", proveedor.NombreProveedor);
                        cmd.Parameters.AddWithValue("@PaisId", proveedor.PaisId);
                        cmd.Parameters.AddWithValue("@CiudadId", proveedor.CiudadId);

                        registros = Convert.ToInt32(cmd.ExecuteScalar());

                    }

                }
                else
                {
                    string selectQuery = @"SELECT COUNT(*) AS Cantidad FROM Proveedores
                        WHERE NombreProveedor=@Nombre AND PaisId=@PaisId 
                        AND CiudadId=@CiudadId AND ProveedorId<>@ProveedorId";
                    using (var cmd = new SqlCommand(selectQuery, conn))
                    {
                        cmd.Parameters.AddWithValue("@Nombre", proveedor.NombreProveedor);
                        cmd.Parameters.AddWithValue("@PaisId", proveedor.PaisId);
                        cmd.Parameters.AddWithValue("@CiudadId", proveedor.CiudadId);

                        cmd.Parameters.AddWithValue("@ProveedorId", proveedor.ProveedorId);

                        registros = Convert.ToInt32(cmd.ExecuteScalar());

                    }


                }

            }
            return registros > 0;
        }

        public Proveedor GetProveedorPorId(int proveedorId)
        {
            Proveedor proveedor= null;
            using (var conn = new SqlConnection(_connectionString))
            {
                conn.Open();
                string selectQuery = @"SELECT ProveedorId, NombreProveedor, Direccion, 
                        CodPostal, PaisId, CiudadId, Telefono, RowVersion
                    FROM Proveedores 
                    WHERE ProveedorId=@ProveedorId";
                using (var cmd = new SqlCommand(selectQuery, conn))
                {
                    cmd.Parameters.AddWithValue("@ProveedorId", proveedorId);
                    using (var reader = cmd.ExecuteReader())
                    {
                        if (reader.HasRows)
                        {
                            reader.Read();
                            proveedor = ConstruirProveedor(reader);
                        }
                    }
                }

            }
            return proveedor;

        }

        private Proveedor ConstruirProveedor(SqlDataReader reader)
        {
            return new Proveedor()
            {
                ProveedorId = reader.GetInt32(0),
                NombreProveedor = reader.GetString(1),
                Direccion = reader.GetString(2),
                CodPostal = reader.GetString(3),
                PaisId = reader.GetInt32(4),
                CiudadId = reader.GetInt32(5),
                Telefono = reader[6] != DBNull.Value ? reader.GetString(6) : string.Empty,
                RowVersion = (byte[])reader[7]
            };
        }

        public List<ProveedorListDto> GetProveedores(Pais paisFiltro=null, CiudadComboDto ciudadFiltro=null)
        {
            List<ProveedorListDto> proveedores=new List<ProveedorListDto>();
            using (var conn=new SqlConnection(_connectionString))
            {
                conn.Open();
                string selectQuery = @"SELECT pro.ProveedorId, pro.NombreProveedor, p.NombrePais, 
                        c.NombreCiudad, pro.Telefono FROM Proveedores pro
	                    INNER JOIN Paises p ON pro.PaisId=p.PaisId 
                        INNER JOIN Ciudades c ON pro.CiudadId=c.CiudadId ";
                string orderBy="ORDER BY pro.NombreProveedor ";
                string filter = "WHERE pro.PaisId=@PaisId AND pro.CiudadId=@CiudadId ";

                if (paisFiltro == null)
                {
                    selectQuery += orderBy;

                }
                else
                {
                    selectQuery += filter + orderBy;
                }
                using (var cmd=new SqlCommand(selectQuery,conn))
                {
                    if (paisFiltro != null) {
                        cmd.Parameters.AddWithValue("@PaisId", paisFiltro.PaisId);
                        cmd.Parameters.AddWithValue("@CiudadId", ciudadFiltro.CiudadId);
                    }
                    using (var reader=cmd.ExecuteReader())
                    {
                        while (reader.Read())
                        {
                            ProveedorListDto proveedor = ConstruirProveedorDto(reader);
                            proveedores.Add(proveedor);
                        }
                    }
                }

            }
            return proveedores;
        }

        private ProveedorListDto ConstruirProveedorDto(SqlDataReader reader)
        {
            return new ProveedorListDto
            {
                ProveedorId = reader.GetInt32(0),
                NombreProveedor = reader.GetString(1),
                NombrePais = reader.GetString(2),
                NombreCiudad = reader.GetString(3),
                Telefono = reader[4]!=DBNull.Value? reader.GetString(4):string.Empty,

            };
        }

        public ProveedorListDto GetProveedorDtoPorId(int proveedorId)
        {
            ProveedorListDto proveedorDto = null;
            using (var conn = new SqlConnection(_connectionString))
            {
                conn.Open();
                string selectQuery = @"SELECT pro.ProveedorId, pro.NombreProveedor, p.NombrePais, 
                    c.NombreCiudad, pro.Telefono FROM Proveedores pro
	                INNER JOIN Paises p ON pro.PaisId=p.PaisId 
                    INNER JOIN Ciudades c ON pro.CiudadId=c.CiudadId 
                    WHERE pro.ProveedorId=@ProveedorId";
                using (var cmd = new SqlCommand(selectQuery, conn))
                {
                    cmd.Parameters.AddWithValue("@ProveedorId", proveedorId);
                    using (var reader = cmd.ExecuteReader())
                    {

                        if (reader.HasRows)
                        {
                            reader.Read();
                            proveedorDto = ConstruirProveedorDto(reader);
                           
                        }
                    }
                }

            }
            return proveedorDto;

        }

        public bool EstaRelacionado(Proveedor proveedor)
        {
            int cantidad = 0;
            using (var conn = new SqlConnection(_connectionString))
            {
                conn.Open();
                string selectQuery = @"SELECT COUNT(*) FROM Productos
                        WHERE ProveedorId = @ProveedorId";
                using (var cmd = new SqlCommand(selectQuery, conn))
                {
                    cmd.Parameters.AddWithValue("@ProveedorId", proveedor.ProveedorId);

                    cantidad = (int)cmd.ExecuteScalar();
                }
            }
            return cantidad>0;
        }

        public int Borrar(Proveedor proveedor)
        {
            int registrosAfectados = 0;
            using (var conn = new SqlConnection(_connectionString))
            {
                conn.Open();
                string deleteQuery = @"DELETE FROM Proveedores WHERE ProveedorId=@ProveedorId 
                        AND RowVersion=@RowVersion";
                using (var cmd = new SqlCommand(deleteQuery, conn))
                {
                    cmd.Parameters.AddWithValue("@ProveedorId", proveedor.ProveedorId);
                    cmd.Parameters.AddWithValue("@RowVersion", proveedor.RowVersion);

                    registrosAfectados = cmd.ExecuteNonQuery();
                }
            }
            return registrosAfectados;

        }

        public int Editar(Proveedor proveedor)
        {
            int registrosAfectados = 0;
            using (var conn = new SqlConnection(_connectionString))
            {
                conn.Open();
                string updateQuery = @"UPDATE Proveedores SET NombreProveedor=@Nombre, Direccion=@Direccion,
                    CodPostal=@CodPostal, PaisId=@PaisId, CiudadId=@CiudadId, Telefono=@Telefono
                    WHERE ProveedorId=@ProveedorId"; 
                using (var cmd = new SqlCommand(updateQuery, conn)) { 
                    cmd.Parameters.AddWithValue("@Nombre", proveedor.NombreProveedor);
                    cmd.Parameters.AddWithValue("@Direccion", proveedor.Direccion);
                    cmd.Parameters.AddWithValue("@CodPostal", proveedor.CodPostal);
                    cmd.Parameters.AddWithValue("@PaisId", proveedor.PaisId);
                    cmd.Parameters.AddWithValue("@CiudadId", proveedor.CiudadId);

                    if (proveedor.Telefono != null)
                    {
                        cmd.Parameters.AddWithValue("@Telefono", proveedor.Telefono);
                    }
                    else
                    {
                        cmd.Parameters.AddWithValue("@Telefono", DBNull.Value);
                    }

                    cmd.Parameters.AddWithValue("@ProveedorId", proveedor.ProveedorId);

                    registrosAfectados = cmd.ExecuteNonQuery();
                }
                if (registrosAfectados > 0)
                {
                    var selectQuery = @"SELECT RowVersion FROM Proveedores 
						WHERE ProveedorId=@ProveedorId";
                    using (var cmd = new SqlCommand(selectQuery, conn))
                    {
                        cmd.Parameters.AddWithValue("@ProveedorId", proveedor.ProveedorId);
                        byte[] rowVersion = (byte[])cmd.ExecuteScalar();
                        proveedor.RowVersion = rowVersion;
                    }

                }

            }
            return registrosAfectados;
        }
    }
}
