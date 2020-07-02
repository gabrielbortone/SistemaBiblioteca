using Sistema_de_Biblioteca.Models;
using Sistema_de_Biblioteca.Repositories;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;

namespace Sistema_de_Biblioteca.Services
{
    public class LoginService : ILoginService
    {
        public bool IsLogged { get; set; }
        private Funcionario Funcionario { get; set; }
        private FuncionarioRepository _funcionarioRepository { get; set; }

        public LoginService(FuncionarioRepository funcionarioRepository)
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
