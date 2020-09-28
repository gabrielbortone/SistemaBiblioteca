using Sistema_de_Biblioteca.Models.Enums;
using System;
using System.ComponentModel.DataAnnotations;

namespace Sistema_de_Biblioteca.ViewModels
{
    public class AlunoViewModel
    {
        public int Id { get; set; }

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

        [Required]
        public EnderecoViewModel EnderecoVM { get; set; }

        [Required]
        public TelefoneViewModel TelefoneVM { get; set; }

        [Required(ErrorMessage = "Informe o seu email")]
        [RegularExpression(".+\\@.+\\..+", ErrorMessage = "Informe um email válido...")]
        public string Email { get; set; }

        [Display(Name = "Informe o seu número de matrícula")]
        [StringLength(12, MinimumLength = 8)]
        public string Matricula { get; set; }

        public AlunoViewModel(int id, string nome, string sobrenome, string cPF, EnderecoViewModel enderecoVM, TelefoneViewModel telefoneVM, string email, string matricula)
        {
            Id = id;
            Nome = nome;
            Sobrenome = sobrenome;
            CPF = cPF;
            EnderecoVM = enderecoVM;
            TelefoneVM = telefoneVM;
            Email = email;
            Matricula = matricula;
        }

        public AlunoViewModel(string nome, string sobrenome, string cPF, EnderecoViewModel enderecoVM, TelefoneViewModel telefoneVM, string email, string matricula)
        {
            Nome = nome;
            Sobrenome = sobrenome;
            CPF = cPF;
            EnderecoVM = enderecoVM;
            TelefoneVM = telefoneVM;
            Email = email;
            Matricula = matricula;
        }
    }
}
