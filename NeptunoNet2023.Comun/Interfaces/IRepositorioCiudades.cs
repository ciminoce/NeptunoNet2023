using NeptunoNet2023.Entidades.Dtos.Ciudad;
using NeptunoNet2023.Entidades.Entidades;

namespace NeptunoNet2023.Comun.Interfaces
{
    public interface IRepositorioCiudades
    {
        int Agregar(Ciudad ciudad);
        List<CiudadListDto> GetAll();
        CiudadListDto GetCiudadDtoPorId(int ciudadId);
        Ciudad GetCiudadPorId(int ciudadId);
        bool Existe(Ciudad ciudad);
        bool EstaRelacionado(Ciudad ciudad);
        int Borrar(Ciudad ciudad);
        int Editar(Ciudad ciudad);
    }
}
