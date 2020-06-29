using Sistema_de_Biblioteca.Models;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;

namespace Sistema_de_Biblioteca.Repositories.Interfaces
{
    public interface IFuncionarioRepository
    {
        void AddFuncionario(Funcionario funcionario);
        void RemoveFuncionario(Funcionario funcionario);
        void UpdateFuncionario(Funcionario funcionario);
        Funcionario GetFuncionarioById(int? id);
        IEnumerable<Funcionario> GetAllFuncionario();
    }
}
