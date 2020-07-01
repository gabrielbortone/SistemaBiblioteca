using System;
using System.Collections.Generic;
using System.ComponentModel.DataAnnotations;
using System.Linq;
using System.Threading.Tasks;

namespace Sistema_de_Biblioteca.Models.ValueObjects
{
    public class Telefone
    {
        [Key]
        public int TelefoneId { get; set; }

        [Required]
        public TipoTelefone Tipo { get; set; }

        [Required]
        [Display(Name = "Informe o seu DDD")]
        [Range(000,999)]
        public int DDD { get; set; }

        [Required]
        [Display(Name = "Informe o seu número:")]
        [StringLength(11, MinimumLength = 10)]
        public string Numero { get; set; }

        public Telefone(TipoTelefone tipo, int ddd, string numero)
        {
            Tipo = tipo;
            DDD = ddd;
            Numero = numero;
        }
    }
}
