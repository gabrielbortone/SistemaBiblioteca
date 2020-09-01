using Sistema_de_Biblioteca.Models;
using System.Collections.Generic;

namespace Sistema_de_Biblioteca.Repositories.Interfaces
{
    public interface IFuncionarioRepository
    {
        public void AddFuncionario(Funcionario funcionario);
        public void RemoveFuncionario(Funcionario funcionario);
        public void UpdateFuncionario(Funcionario funcionario);
        public Funcionario GetFuncionarioById(int? id);
        public Funcionario GetFuncionarioByCPF(string cpf);
        public Funcionario GetFuncionarioByAccount(Account account);
        public IEnumerable<Funcionario> GetAllFuncionario();
    }
}
