using Sistema_de_Biblioteca.Models.ValueObjects;
using System;
using System.Collections.Generic;
using System.ComponentModel.DataAnnotations;
using System.ComponentModel.DataAnnotations.Schema;
using System.Linq;
using System.Threading.Tasks;

namespace Sistema_de_Biblioteca.Models
{
    public class Aluno
    {
        public int AlunoId { get; set; }

        [Required]
        [Display(Name = "Informe o seu nome")]
        [StringLength(30, MinimumLength = 4)]
        public string Nome { get; set; }

        [Required]
        [Display(Name = "Informe o seu sobrenome")]
        [StringLength(30, MinimumLength = 4)]
        public string Sobrenome { get; set; }

        [Display(Name = "Informe o seu número de CPF")]
        [StringLength(11, MinimumLength = 11)]
        public string CPF { get; set; }


        [Required]
        [ForeignKey("EnderecoId")]
        public virtual Endereco Endereco { get; set; }
        public int EnderecoId { get; set; }

        [Required]
        [ForeignKey("TelefoneId")]
        public virtual Telefone Telefone { get; set; }
        public int TelefoneId { get; set; }


        [Required(ErrorMessage = "Informe o seu email")]
        [RegularExpression(".+\\@.+\\..+", ErrorMessage = "Informe um email válido...")]
        public string Email { get; set; }
        [Display(Name = "Informe o seu número de matrícula")]
        [StringLength(12, MinimumLength = 12)]
        public string Matricula { get; set; }

        public Aluno(){}
        public Aluno(string nome, string sobrenome, string CPF, Endereco endereco, Telefone telefone, string email, string matricula)
        {
            Nome = nome;
            Sobrenome = sobrenome;
            this.CPF = CPF;
            Endereco = endereco;
            Telefone = telefone;
            Email = email;
            Matricula = matricula;
        }

    }
}
