using Microsoft.EntityFrameworkCore.Metadata.Conventions;
using Sistema_de_Biblioteca.Models.Validation;
using Sistema_de_Biblioteca.Models.ValueObjects;
using System;
using System.Collections.Generic;
using System.ComponentModel.DataAnnotations;
using System.ComponentModel.DataAnnotations.Schema;
using System.Linq;
using System.Threading.Tasks;

namespace Sistema_de_Biblioteca.Models
{
    public class Funcionario
    {

        public int FuncionarioId { get; set; }

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
        [CustomValidationCPF(ErrorMessage = "CPF inválido")]
        public string CPF { get; set; }

        [Display(Name = "Informe seu UserName")]
        [StringLength(12, MinimumLength = 3)]
        public string Username { get; set; }

        [Display(Name = "Informe a sua senha")]
        [StringLength(12, MinimumLength = 3)]
        [DataType(DataType.Password)]
        public string Senha { get; set; }


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


        [Required]
        [Display(Name = "Informe o cargo do funcionário")]
        [StringLength(30, MinimumLength = 4)]
        public string Cargo { get; set; }

        [Required]
        [Display(Name = "Informe a data de admissão")]
        public DateTime DataAdmissao { get; set; }
        public DateTime? DataDemissao { get; set; }

        public Funcionario(){}
        public Funcionario(string nome, string sobrenome, string cpf, string username, string password, Endereco endereco, Telefone telefone, string email, string cargo, DateTime dataAdmissao)
        {
            Nome = nome;
            Sobrenome = sobrenome;
            CPF = cpf;
            Username = username;
            Senha = password;
            Endereco = endereco;
            Telefone = telefone;
            Email = email;
            Cargo = cargo;
            DataAdmissao = dataAdmissao;
        }
    }
}
