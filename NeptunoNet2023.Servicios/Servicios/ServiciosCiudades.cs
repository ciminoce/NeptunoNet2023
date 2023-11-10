using NeptunoNet2023.Comun.Interfaces;
using NeptunoNet2023.DatosSql;
using NeptunoNet2023.Entidades.Entidades;
using NeptunoNet2023.Servicios.Interfaces;

namespace NeptunoNet2023.Servicios.Servicios
{
	public class ServiciosCiudades : IServiciosCiudades
	{
		private readonly IRepositorioCiudades _repositorioCiudades;
		private readonly IRepositorioPaises _repositorioPaises;
		public ServiciosCiudades()
		{
			_repositorioCiudades = new RepositorioCiudades();
			_repositorioPaises=new RepositorioPaises();
		}

		public List<Ciudad> GetAll()
		{
			try
			{
				var listaCiudades=_repositorioCiudades.GetAll();//100+1
				foreach (var itemCiudad in listaCiudades)
				{
					var paisDeCiudad = _repositorioPaises.GetPais(itemCiudad.PaisId);
					itemCiudad.Pais = paisDeCiudad;
				}
				return listaCiudades;
			}
			catch (Exception)
			{

				throw;
			}
		}
	}
}
