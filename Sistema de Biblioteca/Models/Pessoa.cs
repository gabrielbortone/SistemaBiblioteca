using Sistema_de_Biblioteca.Models.ValueObjects;
using System;
using System.Collections.Generic;
using System.ComponentModel.DataAnnotations;
using System.ComponentModel.DataAnnotations.Schema;
using System.Linq;
using System.Threading.Tasks;

namespace Sistema_de_Biblioteca.Models
{
    public abstract class Pessoa
    {
        [Key]
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
        public string CPF { get; set; }

        [ForeignKey("EnderecoId")]
        public Endereco Endereco { get; set; }
        public int EnderecoId { get; set; }

        [ForeignKey("TelefoneId")]
        public Telefone Telefone { get; set; }
        public int TelefoneId { get; set; }

        [Required(ErrorMessage = "Informe o seu email")]
        [RegularExpression(".+\\@.+\\..+", ErrorMessage = "Informe um email válido...")]
        public string Email { get; set; }
    }
}
