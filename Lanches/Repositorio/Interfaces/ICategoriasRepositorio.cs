using Lanches.Models;

namespace Lanches.Repositorio.Interfaces
{
    public interface ICategoriasRepositorio
    {
        IEnumerable<Categoria> Categorias { get; }
    }
}
