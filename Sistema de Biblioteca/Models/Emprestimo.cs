using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;

namespace Sistema_de_Biblioteca.Models
{
    public class Emprestimo
    {
        public DateTime DataEmprestimo { get; set; }
        public DateTime DataLimiteEntrega { get; set; }
        public DateTime DataEntrega { get; set; }
        public Aluno Aluno { get; set; }
        public Funcionario Funcionario { get; set; }
    }
}
