using NeptunoNet2023.Entidades.Dtos.Ciudad;
using NeptunoNet2023.Entidades.Entidades;

namespace NeptunoNet2023.Servicios.Interfaces
{
	public interface IServiciosCiudades
	{
        CiudadListDto GetCiudadDtoPorId(int ciudadId);
        Ciudad GetCiudadPorId(int ciudadId);
        int Guardar(Ciudad ciudad);

        bool Existe(Ciudad ciudad);
        bool EstaRelacionado(Ciudad ciudad);
        int Borrar(Ciudad ciudad);
        List<CiudadListDto>? GetAll(Pais paisFiltro=null);
        List<CiudadComboDto> GetCiudadesComboDto(Pais paisFiltro);
    }
}
