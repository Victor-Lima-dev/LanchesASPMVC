using Lanches.Context;
using Lanches.Models;
using Lanches.Repositorio.Interfaces;
using Microsoft.EntityFrameworkCore;

namespace Lanches.Repositorio
{
    public class LancheRepositorio : ILancheRepositorio
    {
        private readonly AppDbContext _context;

        public LancheRepositorio(AppDbContext context)
        {
            _context = context;
        }

        public IEnumerable<Lanche> Lanches => _context.Lanches.Include(c=>c.Categoria);

        public IEnumerable<Lanche> LanchesPreferidos => 
                                                _context.Lanches.Where(f => f.IsLanchePreferido)
                                                 .Include(c => c.Categoria);

        public Lanche GetLancheById(int LancheId)
        {
            return _context.Lanches.FirstOrDefault(i => i.LancheId == LancheId);
        }
    }
}
