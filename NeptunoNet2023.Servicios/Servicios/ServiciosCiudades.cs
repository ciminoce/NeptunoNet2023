using NeptunoNet2023.Comun.Interfaces;
using NeptunoNet2023.DatosSql;
using NeptunoNet2023.Entidades.Dtos.Ciudad;
using NeptunoNet2023.Entidades.Entidades;
using NeptunoNet2023.Servicios.Interfaces;

namespace NeptunoNet2023.Servicios.Servicios
{
	public class ServiciosCiudades : IServiciosCiudades
	{
		private readonly IRepositorioCiudades _repositorioCiudades;
		public ServiciosCiudades()
		{
			_repositorioCiudades = new RepositorioCiudades();
		}

        public int Borrar(Ciudad ciudad)
        {
			try
			{
				return _repositorioCiudades.Borrar(ciudad);
			}
			catch (Exception)
			{

				throw;
			}
        }

        public bool EstaRelacionado(Ciudad ciudad)
        {
			try
			{
				return _repositorioCiudades.EstaRelacionado(ciudad);
			}
			catch (Exception)
			{

				throw;
			}
        }

        public bool Existe(Ciudad ciudad)
		{
			try
			{
				return _repositorioCiudades.Existe(ciudad);
			}
			catch (Exception)
			{

				throw;
			}
		}

        public List<CiudadListDto>? GetAll(Pais paisFiltro=null)
        {
            try
            {

                return _repositorioCiudades.GetAll(paisFiltro);
            }
            catch (Exception)
            {

                throw;
            }
        }

        public CiudadListDto GetCiudadDtoPorId(int ciudadId)
        {
			try
			{
				return _repositorioCiudades.GetCiudadDtoPorId(ciudadId);
			}
			catch (Exception)
			{

				throw;
			}
        }

        public Ciudad GetCiudadPorId(int ciudadId)
        {
			try
			{
				return _repositorioCiudades.GetCiudadPorId(ciudadId);
			}
			catch (Exception)
			{

				throw;
			}
        }

        public int Guardar(Ciudad ciudad)
        {
			try
			{
				if (ciudad.CiudadId==0)
				{
					return _repositorioCiudades.Agregar(ciudad);
				}
				else
				{
					return _repositorioCiudades.Editar(ciudad);
				}
			}
			catch (Exception)
			{

				throw;
			}
        }
    }
}
