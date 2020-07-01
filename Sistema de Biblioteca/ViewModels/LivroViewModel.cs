using Sistema_de_Biblioteca.Models.ValueObjects;
using System;
using System.Collections.Generic;
using System.ComponentModel.DataAnnotations;
using System.Linq;
using System.Threading.Tasks;

namespace Sistema_de_Biblioteca.ViewModels
{
    public class LivroViewModel
    {
        [Required]
        [Display(Name = "Informe o título do livro")]
        [StringLength(50, MinimumLength = 4)]
        public string Titulo { get; set; }

        [Required]
        [Display(Name = "Informe o nome do autor")]
        [StringLength(35, MinimumLength = 4)]
        public string Autor { get; set; }

        [Required]
        public int Edicao { get; set; }

        [Required]
        public int Ano { get; set; }

        [Required]
        public int Paginas { get; set; }

        [Required]
        [Display(Name = "Informe o genero do livro")]
        [StringLength(35, MinimumLength = 4)]
        public string Genero { get; set; }

        [Required]
        [Display(Name = "Informe o nome da editora")]
        [StringLength(35, MinimumLength = 4)]
        public string Editora { get; set; }
    }
}
