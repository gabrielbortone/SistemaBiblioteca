using Sistema_de_Biblioteca.Models.ValueObjects;
using System;
using System.ComponentModel.DataAnnotations;

namespace Sistema_de_Biblioteca.Models
{
    public class Funcionario
    {

        public int FuncionarioId { get; set; }

        [Required]
        [Display(Name = "Informe o seu nome")]
        [StringLength(30, MinimumLength = 3)]
        public string Nome { get; set; }

        [Required]
        [Display(Name = "Informe o seu sobrenome")]
        [StringLength(30, MinimumLength = 3)]
        public string Sobrenome { get; set; }

        [Display(Name = "Informe o seu número de CPF")]
        [StringLength(11, MinimumLength = 11)]
        public string CPF { get; set; }

        public Account Account { get; set; }
        public EnderecoFuncionario Endereco { get; set; }
        public TelefoneFuncionario Telefone { get; set; }


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
        public Funcionario(string nome, string sobrenome, string cpf, string username, string password, 
            EnderecoFuncionario endereco, TelefoneFuncionario telefone, string email, string cargo, DateTime dataAdmissao)
        {
            Account = new Account();
            Nome = nome;
            Sobrenome = sobrenome;
            CPF = cpf;
            Account.UserName = username;
            Account.PasswordHash = password;
            Endereco = endereco;
            Telefone = telefone;
            Email = email;
            Cargo = cargo;
            DataAdmissao = dataAdmissao;
        }
    }
}
