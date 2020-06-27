using System;
using System.Collections.Generic;
using System.ComponentModel.DataAnnotations;
using System.Linq;
using System.Threading.Tasks;

namespace Sistema_de_Biblioteca.Models
{
    public class Funcionario : Pessoa
    {
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
