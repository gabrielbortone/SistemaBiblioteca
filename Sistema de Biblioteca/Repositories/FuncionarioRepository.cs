using Microsoft.EntityFrameworkCore;
using Sistema_de_Biblioteca.Models;
using Sistema_de_Biblioteca.Repositories.Interfaces;
using System.Collections.Generic;
using System.Linq;

namespace Sistema_de_Biblioteca.Repositories
{
    public class FuncionarioRepository : IFuncionarioRepository
    {
        private readonly AppDbContext _context;
        public FuncionarioRepository(AppDbContext context)
        {
            _context = context;
        }

        public void AddFuncionario(Funcionario funcionario)
        {
            _context.Funcionarios.Add(funcionario);
        }

        public IEnumerable<Funcionario> GetAllFuncionario()
        {
            return _context.Funcionarios.AsNoTracking().ToList();
        }

        public Funcionario GetFuncionarioById(int? id)
        {
            return _context.Funcionarios.Include(f => f.Endereco).Include(f => f.Telefone).Include(f => f.Account).FirstOrDefault(f=>f.FuncionarioId == id);
        }

        public Funcionario GetFuncionarioByAccount(Account account)
        {
            return _context.Funcionarios.AsNoTracking().FirstOrDefault(F => F.Account == account);
        }

        public void RemoveFuncionario(Funcionario funcionario)
        {
            _context.Funcionarios.Remove(funcionario);
        }

        public void UpdateFuncionario(Funcionario funcionario)
        {
            _context.Funcionarios.Update(funcionario);
        }

        public Funcionario GetFuncionarioByCPF(string cpf)
        {
            return _context.Funcionarios.AsNoTracking().FirstOrDefault(F => F.CPF == cpf);
        }
    }
}
