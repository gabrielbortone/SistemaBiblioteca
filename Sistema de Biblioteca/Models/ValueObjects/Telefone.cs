using Sistema_de_Biblioteca.Models.Enums;
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
        public string Tipo { get; set; }

        [Required]
        [Display(Name = "Informe o seu DDD")]
        [Range(000,999)]
        public int DDD { get; set; }

        [Required]
        [Display(Name = "Informe o seu número:")]
        [StringLength(11, MinimumLength = 8)]
        public string Numero { get; set; }

        public int FuncionarioId { get; set; }
        public virtual Funcionario Funcionario { get; set; }

        public int AlunoId { get; set; }
        public virtual Aluno Aluno { get; set; }

        public Telefone() { }
        public Telefone(string tipo, int ddd, string numero)
        {
            Tipo = tipo;
            DDD = ddd;
            Numero = numero;
        }
    }
}
