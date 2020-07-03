using System;
using System.ComponentModel.DataAnnotations;
using System.ComponentModel.DataAnnotations.Schema;

namespace Sistema_de_Biblioteca.Models
{
    public class Emprestimo
    {
        public int EmprestimoId { get; set; }

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

        [Required]
        [ForeignKey("LivroId")]
        public virtual Livro Livro { get; set; }
        public int LivroId { get; set; }

        [Required]
        [ForeignKey("AlunoId")]
        public virtual Aluno Aluno { get; set; }
        public int AlunoId { get; set; }

        [Required]
        [ForeignKey("FuncionarioId")]
        public virtual Funcionario Funcionario { get; set; }
        public int FuncionarioId { get; set; }

        public Emprestimo(){}
        public Emprestimo(DateTime dataLimiteEntrega, Livro livro, Aluno aluno, Funcionario funcionario)
        {
            DataEmprestimo = DateTime.Now;
            DataLimiteEntrega = dataLimiteEntrega;
            Livro = livro;
            Aluno = aluno;
            Funcionario = funcionario;
        }

    }
}
