using Sistema_de_Biblioteca.Models;
using Sistema_de_Biblioteca.Repositories;
using System;

namespace Sistema_de_Biblioteca.Services
{
    public interface ILoginService 
    {
        public void Logar(string username, string password);
        public Funcionario ObterFuncionarioLogado();
        public bool EstaLogado();
        public void Logout();
    }
}
