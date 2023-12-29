using NeptunoNet2023.DatosSql;
using NeptunoNet2023.Entidades.Entidades;
using NeptunoNet2023.Servicios.Interfaces;

namespace NeptunoNet2023.Servicios.Servicios
{
    public class ServiciosCategorias : IServiciosCategorias
    {
        private readonly RepositorioCategorias _repositorioCategorias;
        public ServiciosCategorias()
        {
            _repositorioCategorias = new RepositorioCategorias();
        }

        public int Borrar(Categoria categoria)
        {
            try
            {
                return _repositorioCategorias.Borrar(categoria);
            }
            catch (Exception)
            {

                throw;
            }
        }

        public bool EstaRelacionado(Categoria categoria)
        {
            try
            {
                return _repositorioCategorias.EstaRelacionado(categoria);
            }
            catch (Exception)
            {

                throw;
            }
        }

        public bool Existe(Categoria categoria)
        {
            try
            {
                return _repositorioCategorias.Existe(categoria);
            }
            catch (Exception)
            {

                throw;
            }
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

        public Categoria GetCategoria(int categoriaId)
        {
            try
            {
                return _repositorioCategorias.GetCategoria(categoriaId);
            }
            catch (Exception)
            {

                throw;
            }
        }

        public int Guardar(Categoria categoria)
        {
            try
            {
                if (categoria.CategoriaId==0)
                {
                    return _repositorioCategorias.Agregar(categoria);
                }
                else
                {
                    return _repositorioCategorias.Editar(categoria);    
                }
            }
            catch (Exception)
            {

                throw;
            }
        }
    }
}
