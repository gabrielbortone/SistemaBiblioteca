using Sistema_de_Biblioteca.Models;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;

namespace Sistema_de_Biblioteca.Services
{
    public interface ILoginService
    {
        public void Logar(string username, string password);
        public Funcionario ObterFuncionarioLogado();
        public void Logout();
    }
}
