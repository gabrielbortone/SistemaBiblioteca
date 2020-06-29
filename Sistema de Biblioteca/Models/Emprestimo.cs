using System;
using System.ComponentModel.DataAnnotations;

namespace Sistema_de_Biblioteca.Models
{
    public class Emprestimo
    {
        [Key]
        public int Id { get; set; }

        [Display(Name = "Data do Emprestimo")]
        [DisplayFormat(ApplyFormatInEditMode = true, DataFormatString = "{0:dd-MM-yyyy}")]
        [DataType(DataType.Date, ErrorMessage = "Data em formato inválido")]
        public DateTime DataEmprestimo { get; set; }

        [Display(Name = "Data de Limite de Entrega")]
        [DisplayFormat(ApplyFormatInEditMode = true, DataFormatString = "{0:dd-MM-yyyy}")]
        [DataType(DataType.Date, ErrorMessage = "Data em formato inválido")]
        public DateTime DataLimiteEntrega { get; set; }

        [Display(Name = "Data da Entrega do livro para a biblioteca")]
        [DisplayFormat(ApplyFormatInEditMode = true, DataFormatString = "{0:dd-MM-yyyy}")]
        [DataType(DataType.Date, ErrorMessage = "Data em formato inválido")]
        public DateTime? DataEntrega { get; set; }

        public Aluno Aluno { get; set; }
        public int AlunoId { get; set; }

        public Funcionario Funcionario { get; set; }
        public int FuncionarioId { get; set; }
    }
}
