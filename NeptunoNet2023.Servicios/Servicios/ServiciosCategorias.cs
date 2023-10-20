using NeptunoNet2023.DatosSql;
using NeptunoNet2023.Entidades.Entidades;

namespace NeptunoNet2023.Servicios.Servicios
{
    public class ServiciosCategorias
    {
        private readonly RepositorioCategorias _repositorioCategorias;
        public ServiciosCategorias()
        {
            _repositorioCategorias = new RepositorioCategorias();
        }

        public List<Categoria> GetAll()
        {
            try
            {
                return _repositorioCategorias.GetAll();
            }
            catch (Exception ex)
            {

                throw ex;
            }
        }

       
    }
}
