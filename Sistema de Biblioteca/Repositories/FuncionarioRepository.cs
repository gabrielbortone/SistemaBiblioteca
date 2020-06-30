using Microsoft.EntityFrameworkCore;
using Sistema_de_Biblioteca.Models;
using Sistema_de_Biblioteca.Repositories.Interfaces;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;

namespace Sistema_de_Biblioteca.Repositories
{
    public class FuncionarioRepository : IFuncionarioRepository
    {
        private readonly AppDbContext _context;

        public FuncionarioRepository(AppDbContext context)
        {
            _context = context;
        }

        void IFuncionarioRepository.AddFuncionario(Funcionario funcionario)
        {
            _context.Funcionarios.Add(funcionario);
            _context.SaveChanges();
        }

        IEnumerable<Funcionario> IFuncionarioRepository.GetAllFuncionario()
        {
            return _context.Funcionarios.ToList();
        }

        Funcionario IFuncionarioRepository.GetFuncionarioById(int? id)
        {
            return _context.Funcionarios.Find(id);
        }

        void IFuncionarioRepository.RemoveFuncionario(Funcionario funcionario)
        {
            _context.Funcionarios.Remove(funcionario);
            _context.SaveChanges();
        }

        void IFuncionarioRepository.UpdateFuncionario(Funcionario funcionario)
        {
            _context.Funcionarios.Update(funcionario);
            _context.SaveChanges();
        }
    }
}
