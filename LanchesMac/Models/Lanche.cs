using System.ComponentModel.DataAnnotations;
using System.ComponentModel.DataAnnotations.Schema;

namespace LanchesMac.Models
{
    [Table("Lanches")]
    public class Lanche
    {
        [Key]
        public int LancheId { get; set; }

        [StringLength(100, MinimumLength =10, ErrorMessage = "O tamanho máximo é 100 caracteres")]
        [Required(ErrorMessage = "Informe o nome do lanche")]
        [Display(Name = "Nome")]
        public string Nome { get; set; }

        [Required(ErrorMessage = "Informe a descrição do lanche")]
        [Display(Name = "Descrição")]
        [MinLength(20, ErrorMessage = "Descrição deve ter no mínimo {1} caracteres")]
        [MaxLength(50, ErrorMessage = "Descrição pode exceder {1} caracteres")]
        public string DescricaoCurta { get; set; }

        [StringLength(200, MinimumLength = 100, ErrorMessage = "O tamanho máximo é 200 caracteres")]
        [Required(ErrorMessage = "Informe a descrição detalhada do lanche")]
        [Display(Name = "Descrição detalhada")]
        public string DescricaoDetalhada { get; set; }

        [Required(ErrorMessage = "Informe a descrição detalhada do lanche")]
        [Display(Name = "Preço do lanche")]
        [Column(TypeName = "decimal(10,2)")]
        [Range(1,999.99,ErrorMessage = " O preço deve estar entre 1 e 999,99 R$")]
        public decimal Preco { get; set; }

        [StringLength(100, MinimumLength = 10, ErrorMessage = "O tamanho máximo é 100 caracteres")]
        [Display(Name = "Caminho da imagem normal")]
        public string ImagemUrl { get; set; }


        [StringLength(100, MinimumLength = 10, ErrorMessage = "O tamanho máximo é 100 caracteres")]
        [Display(Name = "Caminho da imagem miniatura")]
        public string ImagemThumbnailUrl { get; set; }

        [Display(Name = "Preferido?")]
        public bool IsLanchePreferido { get; set; }

        [Display(Name = "Estoque")]
        public bool EmEstoque { get; set; }
  

        [Display(Name = "Categorias")]
        public int CategoriaId { get; set; }

        //Propriedade de navegação
        public virtual Categoria Categoria { get; set; }





    }
}
