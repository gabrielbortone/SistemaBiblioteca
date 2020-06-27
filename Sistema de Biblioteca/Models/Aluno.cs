using System;
using System.Collections.Generic;
using System.ComponentModel.DataAnnotations;
using System.Linq;
using System.Threading.Tasks;

namespace Sistema_de_Biblioteca.Models
{
    public class Aluno : Pessoa
    {
        [Display(Name = "Informe o seu número de matrícula")]
        [StringLength(12, MinimumLength = 12)]
        public string Matricula { get; set; }

    }
}
