using System.ComponentModel.DataAnnotations;
using System.ComponentModel.DataAnnotations.Schema;

namespace Lanches.Models
{
    [Table("Categorias")]
    public class Categoria
    {
        [Key]
        public int CategoriaId { get; set; }

        [StringLength(100, ErrorMessage ="O tamanho máximo é de 100")]
        [Required(ErrorMessage ="Informe a categoria")]
        [Display(Name ="Nome do lanche")]

        public string CategoriaNome { get; set; }

        [StringLength(200, ErrorMessage = "O tamanho máximo é de 100")]
        [Required(ErrorMessage = "Informe a descrição categoria")]
        [Display(Name = "Nome")]

        public string Descricao { get; set; }

        public List<Lanche> Lanches { get; set; }
    }
}
