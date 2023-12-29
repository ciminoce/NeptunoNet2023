using NeptunoNet2023.Entidades.Entidades;

namespace NeptunoNet2023.Servicios.Interfaces
{
    public interface IServiciosCategorias
    {
        List<Categoria> GetAll();
        int Guardar(Categoria categoria);
        int Borrar(Categoria categoria);

        bool Existe(Categoria categoria);
        bool EstaRelacionado(Categoria categoria);
        Categoria GetCategoria(int categoriaId);

    }
}