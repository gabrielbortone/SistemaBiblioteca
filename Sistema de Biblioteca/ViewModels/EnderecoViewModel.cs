using System.ComponentModel.DataAnnotations;

namespace Sistema_de_Biblioteca.ViewModels
{
    public class EnderecoViewModel
    {
        [Required]
        [Display(Name = "Informe o CEP:")]
        [StringLength(9, MinimumLength = 9)]
        public string CEP { get; set; }

        [Required]
        [Display(Name = "Informe o bairro:")]
        [StringLength(30, MinimumLength = 4)]
        public string Bairro { get; set; }

        [Required]
        [Display(Name = "Informe a cidade:")]
        [StringLength(35, MinimumLength = 4)]
        public string Cidade { get; set; }

        [Required]
        [Display(Name = "Informe o Estado:")]
        [StringLength(35, MinimumLength = 4)]
        public string Estado { get; set; }
    }
}
