using NeptunoNet2023.Comun.Interfaces;
using NeptunoNet2023.Entidades.Entidades;

namespace NeptunoFer2023.DatosSec
{
	public class RepositorioPaisesSecuencial : IRepositorioPaises
	{
        public RepositorioPaisesSecuencial()
        {
            
        }
        public void Agregar(Pais pais)
		{
			throw new NotImplementedException();
		}

		public void Borrar(int paisId)
		{
			throw new NotImplementedException();
		}

		public void Editar(Pais pais)
		{
			throw new NotImplementedException();
		}

		public List<Pais> GetAll()
		{
			return new List<Pais>
			{
				new Pais()
				{
					PaisId=1,
					NombrePais="Angola"
				},
				new Pais()
				{
					PaisId=2,
					NombrePais="Zaire"

				},
				new Pais()
				{
					PaisId=3,
					NombrePais="Sudáfrica"
				}
			};
		}
	}
}