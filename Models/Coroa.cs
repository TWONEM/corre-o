using System.ComponentModel.DataAnnotations.Schema;
using System.ComponentModel.DataAnnotations;

namespace FloriculturaFlores.Models
{
   
    
        [Table("Coroas")]
        public class Coroa
        {
            [Key]
            public int CoroaId { get; set; }

            [Required(ErrorMessage = "O nome da coroa deve ser informado")]
            [Display(Name = "Nome da coroa")]
            [StringLength(80, MinimumLength = 10, ErrorMessage = "O {0} deve ter no mínimo {1} e no máximo {2} caracteres")]
            public string Nome { get; set; }

            [Required(ErrorMessage = "A descrição da coroa deve ser informada")]
            [Display(Name = "Descrição da Coroa")]
            [MinLength(20, ErrorMessage = "Descrição deve ter no mínimo {1} caracteres")]
            [MaxLength(200, ErrorMessage = "Descrição pode exceder {1} caracteres")]
            public string DescricaoCurta { get; set; }

            [Required(ErrorMessage = "O descrição detalhada da coroa deve ser informada")]
            [Display(Name = "Descrição detalhada da Coroa")]
            [MinLength(20, ErrorMessage = "Descrição detalhada deve ter no mínimo {1} caracteres")]
            [MaxLength(200, ErrorMessage = "Descrição detalhada pode exceder {1} caracteres")]
            public string DescricaoDetalhada { get; set; }

            [Required(ErrorMessage = "Informe o preço da coroa")]
            [Display(Name = "Preço")]
            [Column(TypeName = "decimal(10,2)")]
            [Range(1, 999.99, ErrorMessage = "O preço deve estar entre 1 e 999,99")]
            public decimal Preco { get; set; }

            [Display(Name = "Caminho Imagem Normal")]
            [StringLength(200, ErrorMessage = "O {0} deve ter no máximo {1} caracteres")]
            public string ImagemUrl { get; set; }

            [Display(Name = "Caminho Imagem Miniatura")]
            [StringLength(200, ErrorMessage = "O {0} deve ter no máximo {1} caracteres")]
            public string ImagemThumbnailUrl { get; set; }

            [Display(Name = "Preferido?")]
            public bool IsCoroaPreferido { get; set; }

            [Display(Name = "Estoque")]
            public bool EmEstoque { get; set; }

            [Display(Name = "Categoria")]
            public int CategoriaId { get; set; }
            public virtual Categoria Categoria { get; set; }
        }
}

