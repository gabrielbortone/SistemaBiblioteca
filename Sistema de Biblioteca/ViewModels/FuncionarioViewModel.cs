using Sistema_de_Biblioteca.Models;
using Sistema_de_Biblioteca.Models.Validation;
using System;
using System.Collections.Generic;
using System.ComponentModel.DataAnnotations;
using System.Linq;
using System.Threading.Tasks;

namespace Sistema_de_Biblioteca.ViewModels
{
    public class FuncionarioViewModel
    {
        public int Id { get; set; }
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
        [Display(Name = "Informe o CEP:")]
        [StringLength(9, MinimumLength = 9)]
        public string CEP { get; set; }

        [Required]
        [Display(Name = "Informe o bairro:")]
        [StringLength(30, MinimumLength = 4)]
        public string Bairro { get; set; }

        [Required]
        [Display(Name = "Informe a cidade:")]
        [StringLength(35, MinimumLength = 4)]
        public string Cidade { get; set; }

        [Required]
        [Display(Name = "Informe o Estado:")]
        [StringLength(35, MinimumLength = 4)]
        public string Estado { get; set; }

        [Required]
        public TipoTelefone Tipo { get; set; }

        [Required]
        [Display(Name = "Informe o seu DDD")]
        [Range(000, 999)]
        public int DDD { get; set; }

        [Required]
        [Display(Name = "Informe o seu número:")]
        [StringLength(11, MinimumLength = 10)]
        public string Numero { get; set; }


        [Required(ErrorMessage = "Informe o seu email")]
        [RegularExpression(".+\\@.+\\..+", ErrorMessage = "Informe um email válido...")]
        public string Email { get; set; }


        [Required]
        [Display(Name = "Informe o cargo do funcionário")]
        [StringLength(30, MinimumLength = 4)]
        public string Cargo { get; set; }

        [Required]
        [Display(Name = "Informe o seu nome")]
        public DateTime DataAdmissao { get; set; }
        public DateTime? DataDemissao { get; set; }

    }
}
