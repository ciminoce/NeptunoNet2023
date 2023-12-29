using NeptunoNet2023.Entidades.Dtos.Ciudad;
using NeptunoNet2023.Entidades.Dtos.Proveedor;
using NeptunoNet2023.Entidades.Entidades;

namespace NeptunoNet2023.Servicios.Interfaces
{
    public interface IServiciosProveedores
    {
        int Borrar(Proveedor proveedor);
        bool EstaRelacionado(Proveedor proveedor);
        bool Existe(Proveedor proveedor);
        ProveedorListDto GetProveedorDtoPorId(int proveedorId);
        Proveedor GetProveedorPorId(int proveedorId);
        List<ProveedorListDto> GetProveedores(Pais paisFiltro = null, CiudadComboDto ciudadFiltro = null);
        int Guardar(Proveedor proveedor);

    }
}
