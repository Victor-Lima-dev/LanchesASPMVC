namespace Lanches.Models.NovaPasta
{
    public class LancheViewModel
    {
        public IEnumerable<Lanche> Lanches { get; set; }
        public string CategoriaAtual { get; set; } = "Categoria A";


    }
}
