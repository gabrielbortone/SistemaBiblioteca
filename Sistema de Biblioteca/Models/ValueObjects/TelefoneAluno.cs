using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;

namespace Sistema_de_Biblioteca.Models.ValueObjects
{
    public class TelefoneAluno : Telefone
    {
        public int AlunoId { get; set; }
        public Aluno Aluno { get; set; }
        public TelefoneAluno() : base()
        {

        }
        public TelefoneAluno(string tipo, int ddd, string numero) : base(tipo, ddd,numero)
        {

        }
    }
}
