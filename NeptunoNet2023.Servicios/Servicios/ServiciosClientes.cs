using NeptunoNet2023.Comun.Interfaces;
using NeptunoNet2023.DatosSql;
using NeptunoNet2023.Entidades.Dtos.Cliente;
using NeptunoNet2023.Servicios.Interfaces;

namespace NeptunoNet2023.Servicios.Servicios
{
    public class ServiciosClientes : IServiciosClientes
    {
        private readonly IRepositorioClientes _repositorioClientes;
        public ServiciosClientes()
        {
            _repositorioClientes = new RepositorioClientes();
        }
        public List<ClienteListDto> GetClientes()
        {
            try
            {
                return _repositorioClientes.GetClientes();
            }
            catch (Exception)
            {

                throw;
            }
        }
    }
}
