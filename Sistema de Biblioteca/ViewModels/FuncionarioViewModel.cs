using Microsoft.AspNetCore.Mvc.Routing;
using Sistema_de_Biblioteca.Models.Enums;
using System;
using System.ComponentModel.DataAnnotations;

namespace Sistema_de_Biblioteca.ViewModels
{
    public class FuncionarioViewModel
    {
        public string Id { get; set; }
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

        [Display(Name = "Informe seu UserName")]
        [StringLength(20, MinimumLength = 3)]
        public string Username { get; set; }

        [Display(Name = "Informe a sua senha")]
        [StringLength(20, MinimumLength = 3)]
        [DataType(DataType.Password)]
        public string Senha { get; set; }

        [Required]
        public EnderecoViewModel EnderecoVM { get; set; }

        [Required]
        public TelefoneViewModel TelefoneVM { get; set; }



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

        public FuncionarioViewModel(string nome, string sobrenome, string cPF, string username, EnderecoViewModel enderecoVM, TelefoneViewModel telefoneVM, string email, string cargo, DateTime dataAdmissao)
        {
            Nome = nome;
            Sobrenome = sobrenome;
            CPF = cPF;
            Username = username;
            EnderecoVM = enderecoVM;
            TelefoneVM = telefoneVM;
            Email = email;
            Cargo = cargo;
            DataAdmissao = dataAdmissao;
        }

        public FuncionarioViewModel(string id, string nome, string sobrenome, string cPF, string username, 
            EnderecoViewModel enderecoVM, TelefoneViewModel telefoneVM, string email, string cargo, DateTime dataAdmissao)
        {
            Id = id;
            Nome = nome;
            Sobrenome = sobrenome;
            CPF = cPF;
            Username = username;
            EnderecoVM = enderecoVM;
            TelefoneVM = telefoneVM;
            Email = email;
            Cargo = cargo;
            DataAdmissao = dataAdmissao;
        }
    }
}
