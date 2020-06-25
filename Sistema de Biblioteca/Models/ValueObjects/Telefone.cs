using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;

namespace Sistema_de_Biblioteca.Models.ValueObjects
{
    public class Telefone
    {
        public int Id { get; set; }
        public int DDD { get; set; }
        public string Numero { get; set; }
        public Pessoa Pessoa { get; set; }
    }
}
