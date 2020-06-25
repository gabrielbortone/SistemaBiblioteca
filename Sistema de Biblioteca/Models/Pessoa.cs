using Sistema_de_Biblioteca.Models.ValueObjects;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;

namespace Sistema_de_Biblioteca.Models
{
    public abstract class Pessoa
    {
        public int Id { get; set; }
        public string Nome { get; set; }
        public string Sobrenome { get; set; }
        public string Matricula { get; set; }
        public string CPF { get; set; }
        public Endereco Endereco { get; set; }
        public Telefone Telefone { get; set; }
        public string Email { get; set; }
    }
}
