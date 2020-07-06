using Sistema_de_Biblioteca.Models;
using System;
using System.ComponentModel.DataAnnotations;

namespace Sistema_de_Biblioteca.ViewModels
{
    public class EmprestimoViewModel
    {
        public int Id { get; set; }
        [Display(Name = "Data de Limite de Entrega")]
        [DisplayFormat(ApplyFormatInEditMode = true, DataFormatString = "{0:dd-MM-yyyy}")]
        [DataType(DataType.Date, ErrorMessage = "Data em formato inválido")]
        public DateTime DataLimiteEntrega { get; set; }

        [Display(Name = "Data da Entrega do livro para a biblioteca")]
        [DisplayFormat(ApplyFormatInEditMode = true, DataFormatString = "{0:dd-MM-yyyy}")]
        [DataType(DataType.Date, ErrorMessage = "Data em formato inválido")]
        public DateTime? DataEntrega { get; set; }

        [Required]
        public string TituloLivro { get; set; }


        [Required]
        public string NomeAluno { get; set; }

        [Required]
        public string SobrenomeAluno { get; set; }


        [Required]
        public Funcionario Funcionario { get; set; }

    }
}
