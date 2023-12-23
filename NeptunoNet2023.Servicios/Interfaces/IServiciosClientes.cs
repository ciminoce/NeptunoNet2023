using NeptunoNet2023.Entidades.Dtos.Ciudad;
using NeptunoNet2023.Entidades.Dtos.Cliente;
using NeptunoNet2023.Entidades.Entidades;

namespace NeptunoNet2023.Servicios.Interfaces
{
    public interface IServiciosClientes
    {
        int Borrar(Cliente cliente);
        bool EstaRelacionado(Cliente cliente);
        bool Existe(Cliente cliente);
        ClienteListDto GetClienteDtoPorId(int clienteId);
        Cliente GetClientePorId(int clienteId);
        List<ClienteListDto> GetClientes(Pais paisFiltro = null, CiudadComboDto ciudadFiltro = null);
        int Guardar(Cliente cliente);

    }
}
