using NeptunoNet2023.DatosSql;
using NeptunoNet2023.Entidades.Entidades;

namespace NeptunoNet2023.Servicios.Servicios
{
	public class ServiciosPaises
	{
		private readonly RepositorioPaises _repositorioPaises;
        public ServiciosPaises()
        {
            _repositorioPaises = new RepositorioPaises();
        }

        public List<Pais> GetAll()
        {
			try
			{
				return _repositorioPaises.GetAll();
			}
			catch (Exception ex)
			{

				throw ex;
			}
        }
    }
}
