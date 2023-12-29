namespace NeptunoNet2023.Entidades.Entidades
{
    public class Proveedor
    {
        public int ProveedorId { get; set; }
        public string NombreProveedor { get; set; }
        public string Direccion { get; set; }
        public string CodPostal { get; set; }
        public int PaisId { get; set; }
        public int CiudadId { get; set; }
        public string Telefono { get; set; }
        public byte[] RowVersion { get; set; }
        public Ciudad Ciudad { get; set; }
        public Pais Pais { get; set; }

    }
}
