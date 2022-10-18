using System.ComponentModel.DataAnnotations;
using System.ComponentModel.DataAnnotations.Schema;

namespace Lanches.Models
{
   
    public class Lanche
    {
        public int LancheId { get; set; }


        //Regras que o banco de dados ta exigindo
        [Required(ErrorMessage = "Informe o nome")]
        [Display(Name = "Nome do lanche")]
        [StringLength(80, MinimumLength = 10,
          ErrorMessage = "O {0} deve ter no minimo {1} e no maximo{2}")]
        public string Nome { get; set; }


        
        [Required(ErrorMessage = "Informe o descrição")]
        [Display(Name = "Nome do lanche")]
        [MinLength(20, ErrorMessage ="Descrição deve ter no minimo {1} caracteres")]
        [MaxLength(200, ErrorMessage = "Descrição nao pode exceder {1{ caracteres")]
        public string DescricaoCurta { get; set; }



        [Required(ErrorMessage = "Informe o descrição")]
        [Display(Name = "Nome do lanche")]
        [MinLength(20, ErrorMessage = "Descrição deve ter no minimo {1} caracteres")]
        [MaxLength(200, ErrorMessage = "Descrição nao pode exceder {1{ caracteres")]

        public string DescricaoDetalhada{ get; set; }


        [Required(ErrorMessage = "Informe o preço")]
        [Display(Name ="Preço")]
        [Column(TypeName = "decimal(10,2)")]
        [Range(1,999.99, ErrorMessage ="O preço esta entre 1 e 9999999")]

        public decimal Preco { get; set; }




        [Display(Name = "Caminho Imagem Normal")]
        [StringLength(200, ErrorMessage = "O {0} deve ter no máximo {1} caracteres")]
        public string ImagemUrl { get; set; }




        [Display(Name = "Caminho Imagem Miniatura")]
        [StringLength(200, ErrorMessage = "O {0} deve ter no máximo {1} caracteres")]

        public string ImagemTumbUrl { get; set; }

        [Display(Name ="Preferido")]
        public bool IsLanchePreferido { get; set; }

        [Display(Name = "Estoque")]
        public bool EmEstoque { get; set; }

        //Propriedades de Navegação
        public int CategoriaId { get; set; }
        public virtual Categoria Categoria { get; set; }
    }
}
