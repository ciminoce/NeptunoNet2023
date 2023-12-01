using NeptunoNet2023.Entidades.Dtos.Cliente;

namespace NeptunoNet2023.Servicios.Interfaces
{
    public interface IServiciosClientes
    {
        List<ClienteListDto> GetClientes();
    }
}
