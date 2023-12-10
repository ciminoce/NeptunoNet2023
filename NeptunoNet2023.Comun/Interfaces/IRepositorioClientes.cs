using NeptunoNet2023.Entidades.Dtos.Cliente;
using NeptunoNet2023.Entidades.Entidades;

namespace NeptunoNet2023.Comun.Interfaces
{
    public interface IRepositorioClientes
    {
        List<ClienteListDto> GetClientes();
        int Agregar(Cliente cliente);
        Cliente GetClientePorId(int clienteId);
        ClienteListDto GetClienteDtoPorId(int clienteId);

        bool Existe(Cliente cliente);
        bool EstaRelacionado(Cliente cliente);
        int Borrar(Cliente cliente);
    }
}
