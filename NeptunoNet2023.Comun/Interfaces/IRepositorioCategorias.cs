using NeptunoNet2023.Entidades.Entidades;

namespace NeptunoNet2023.Comun.Interfaces
{
	public interface IRepositorioCategorias
	{
		List<Categoria> GetAll();
        int Agregar(Categoria categoria);
        int Borrar(Categoria categoria);
        int Editar(Categoria categoria);

        bool Existe(Categoria categoria);
        bool EstaRelacionado(Categoria categoria);
        Categoria GetCategoria(int categoriaId);

    }
}