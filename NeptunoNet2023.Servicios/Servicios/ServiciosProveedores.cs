using NeptunoNet2023.Comun.Interfaces;
using NeptunoNet2023.DatosSql;
using NeptunoNet2023.Entidades.Dtos.Ciudad;
using NeptunoNet2023.Entidades.Dtos.Proveedor;
using NeptunoNet2023.Entidades.Entidades;
using NeptunoNet2023.Servicios.Interfaces;

namespace NeptunoNet2023.Servicios.Servicios
{
    public class ServiciosProveedores : IServiciosProveedores
    {
        private readonly IRepositorioProveedores _repositorioProveedores;
        public ServiciosProveedores()
        {
            _repositorioProveedores = new RepositorioProveedores();
        }

        public int Borrar(Proveedor proveedor)
        {
            try
            {
                return _repositorioProveedores.Borrar(proveedor);
            }
            catch (Exception)
            {

                throw;
            }
        }

        public bool EstaRelacionado(Proveedor proveedor)
        {
            try
            {
                return _repositorioProveedores.EstaRelacionado(proveedor);
            }
            catch (Exception)
            {

                throw;
            }
        }

        public bool Existe(Proveedor proveedor)
        {
            try
            {
                return _repositorioProveedores.Existe(proveedor);
            }
            catch (Exception)
            {

                throw;
            }
        }

        public ProveedorListDto GetProveedorDtoPorId(int proveedorId)
        {
            try
            {
                return _repositorioProveedores.GetProveedorDtoPorId(proveedorId);
            }
            catch (Exception)
            {

                throw;
            }
        }


        public Proveedor GetProveedorPorId(int proveedorId)
        {
            try
            {
                return _repositorioProveedores.GetProveedorPorId(proveedorId);
            }
            catch (Exception)
            {

                throw;
            }
        }

        public List<ProveedorListDto> GetProveedores(Pais paisFiltro=null, CiudadComboDto ciudadFiltro=null)
        {
            try
            {
                return _repositorioProveedores.GetProveedores(paisFiltro,ciudadFiltro);
            }
            catch (Exception)
            {

                throw;
            }
        }

        public int Guardar(Proveedor proveedor)
        {
            try
            {
                if (proveedor.ProveedorId == 0)
                {
                    return _repositorioProveedores.Agregar(proveedor);

                }
                else
                {
                    return _repositorioProveedores.Editar(proveedor);
                }
            }
            catch (Exception)
            {

                throw;
            }
        }
    }
}
