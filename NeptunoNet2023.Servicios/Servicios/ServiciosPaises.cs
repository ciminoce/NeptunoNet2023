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

        public void Borrar(int paisId)
        {
			try
			{
				_repositorioPaises.Borrar(paisId);
			}
			catch (Exception ex)
			{

				throw ex;
			}
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

		public void Guardar(Pais pais)
		{
			try
			{

				if (pais.PaisId==0)
				{
					_repositorioPaises.Agregar(pais);
				}
				else
				{
					_repositorioPaises.Editar(pais);
				}
			}
			catch (Exception ex)
			{

				throw ex;
			}
		}
    }
}
