using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;

namespace Sistema_de_Biblioteca.Models.ValueObjects
{
    public class EnderecoAluno : Endereco
    {
        public int AlunoId { get; set; }
        public Aluno Aluno { get; set; }
        public EnderecoAluno(string cep, string bairro, string cidade, string estado) : base(cep, bairro, cidade, estado)
        {

        }
    }
}
