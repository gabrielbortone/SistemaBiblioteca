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
            throw new NotImplementedException();
        }

        IEnumerable<Funcionario> IFuncionarioRepository.GetAllFuncionario()
        {
            throw new NotImplementedException();
        }

        Funcionario IFuncionarioRepository.GetFuncionarioById(int? id)
        {
            throw new NotImplementedException();
        }

        void IFuncionarioRepository.RemoveFuncionario(Funcionario funcionario)
        {
            throw new NotImplementedException();
        }

        void IFuncionarioRepository.UpdateFuncionario(Funcionario funcionario)
        {
            throw new NotImplementedException();
        }
    }
}
