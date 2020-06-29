using Sistema_de_Biblioteca.Models;
using Sistema_de_Biblioteca.Repositories.Interfaces;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;

namespace Sistema_de_Biblioteca.Repositories
{
    public class EmprestimoRepository : IEmprestimoRepository
    {
        private readonly AppDbContext _context;

        public EmprestimoRepository(AppDbContext context)
        {
            _context = context;
        }
        void IEmprestimoRepository.AddEmprestimo(Emprestimo emprestimo)
        {
            throw new NotImplementedException();
        }

        IEnumerable<Emprestimo> IEmprestimoRepository.GetAllEmprestimo()
        {
            throw new NotImplementedException();
        }

        Emprestimo IEmprestimoRepository.GetEmprestimoById(int? id)
        {
            throw new NotImplementedException();
        }

        IEnumerable<Emprestimo> IEmprestimoRepository.GetEmprestimoByLivro(Livro livro)
        {
            throw new NotImplementedException();
        }

        IEnumerable<Emprestimo> IEmprestimoRepository.GetLivroByAluno(Aluno aluno)
        {
            throw new NotImplementedException();
        }

        void IEmprestimoRepository.RemoveEmprestimo(Emprestimo emprestimo)
        {
            throw new NotImplementedException();
        }

        void IEmprestimoRepository.UpdateEmprestimo(Emprestimo emprestimo)
        {
            throw new NotImplementedException();
        }
    }
}
