using System;
using System.ComponentModel.DataAnnotations;

namespace Sistema_de_Biblioteca.ViewModels
{
    public class TelefoneViewModel
    {
        [Required]
        public string Tipo { get; set; }

        [Required]
        [Display(Name = "Informe o seu DDD")]
        [Range(000, 999)]
        public int DDD { get; set; }

        [Required]
        [Display(Name = "Informe o seu número:")]
        [StringLength(11, MinimumLength = 8)]
        public string Numero { get; set; }

    }
}
