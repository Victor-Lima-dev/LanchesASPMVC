using Lanches.Context;
using Lanches.Models;
using Lanches.Repositorio.Interfaces;

namespace Lanches.Repositorio
{
    public class CategoriaRepositorio : ICategoriasRepositorio
    {
        private readonly AppDbContext _context;

        public CategoriaRepositorio(AppDbContext context)
        {
            _context = context;
        }

        public IEnumerable<Categoria> Categorias => _context.Categorias;
    }
}
