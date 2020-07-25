using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;

namespace Sistema_de_Biblioteca.Models.ValueObjects
{
    public class EnderecoFuncionario : Endereco
    {
        public int FuncionarioId { get; set; }
        public Funcionario Funcionario { get; set; }

        public EnderecoFuncionario() : base()
        {

        }
        public EnderecoFuncionario(string cep, string bairro, string cidade, string estado) : base(cep, bairro, cidade, estado)
        {
        }

        
    }
}
