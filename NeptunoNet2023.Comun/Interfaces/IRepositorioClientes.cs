using NeptunoNet2023.Entidades.Dtos.Cliente;

namespace NeptunoNet2023.Comun.Interfaces
{
    public interface IRepositorioClientes
    {
        List<ClienteListDto> GetClientes();
    }
}
