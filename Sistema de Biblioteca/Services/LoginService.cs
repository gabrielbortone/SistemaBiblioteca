using Sistema_de_Biblioteca.Models;
using Sistema_de_Biblioteca.Repositories.Interfaces;
using System;

namespace Sistema_de_Biblioteca.Services
{
    public class LoginService : ILoginService
    {
        public bool IsLogged { get; set; }
        private Funcionario Funcionario { get; set; }
        private IFuncionarioRepository _funcionarioRepository { get; set; }

        public LoginService(IFuncionarioRepository funcionarioRepository)
        {
            _funcionarioRepository = funcionarioRepository;
            Funcionario = null;
            IsLogged = false;
        }

        public void Logar(string username, string password)
        {
            var user = _funcionarioRepository.GetFuncionarioByUserName(username);
            if(user != null)
            {
                if(user.Senha == password)
                {
                    Funcionario = user;
                    IsLogged = true;
                }
                throw new Exception("Senha incorreta!");
            }
            throw new Exception("Usuário inexistente!");
        }
        public Funcionario ObterFuncionarioLogado()
        {
            if(Funcionario == null)
            {
                throw new Exception("Nenhum funcionário está logado!");
            }
            return Funcionario;
        }

        public void Logout()
        {
            Funcionario = null;
        }
    }
}
