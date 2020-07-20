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
        public int AlunoId { get; set; }


        [Required]
        public int LivroId { get; set; }

    }
}
