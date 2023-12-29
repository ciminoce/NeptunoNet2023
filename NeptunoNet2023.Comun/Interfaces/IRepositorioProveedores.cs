using NeptunoNet2023.Entidades.Dtos.Ciudad;
using NeptunoNet2023.Entidades.Dtos.Proveedor;
using NeptunoNet2023.Entidades.Entidades;

namespace NeptunoNet2023.Comun.Interfaces
{
    public interface IRepositorioProveedores
    {
        List<ProveedorListDto> GetProveedores(Pais paisFiltro = null, CiudadComboDto ciudadFiltro = null);
        int Agregar(Proveedor proveedor);
        Proveedor GetProveedorPorId(int proveedorId);
        ProveedorListDto GetProveedorDtoPorId(int proveedorId);

        bool Existe(Proveedor proveedor);
        bool EstaRelacionado(Proveedor proveedor);
        int Borrar(Proveedor proveedor);
        int Editar(Proveedor proveedor);
    }
}
