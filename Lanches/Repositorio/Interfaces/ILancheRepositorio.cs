using Lanches.Context;
using Lanches.Models;

namespace Lanches.Repositorio.Interfaces
{
    public interface ILancheRepositorio
    {
        IEnumerable<Lanche> Lanches { get; }
        IEnumerable<Lanche> LanchesPreferidos { get; }
        Lanche GetLancheById (int LancheId);
    }
}
