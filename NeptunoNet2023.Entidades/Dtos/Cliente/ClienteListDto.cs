namespace NeptunoNet2023.Entidades.Dtos.Cliente
{
    public class ClienteListDto
    {
        public int ClienteId { get; set; }
        public string? NombreCliente { get; set; }
        public string? NombrePais { get; set; }
        public string? NombreCiudad { get; set; }
        public string? TelFijo { get; set; }
        public string? TelMovil { get; set; }

        public override string ToString()
        {
            return $"{NombreCliente}";
        }

    }
}
