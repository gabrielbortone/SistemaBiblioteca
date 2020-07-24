using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;

namespace Sistema_de_Biblioteca.Models.ValueObjects
{
    public class TelefoneFuncionario : Telefone
    {
        public int FuncionarioId { get; set; }
        public Funcionario Funcionario { get; set; }

        public TelefoneFuncionario(string tipo, int ddd, string numero) : base(tipo, ddd, numero)
        {

        }
    }
}
