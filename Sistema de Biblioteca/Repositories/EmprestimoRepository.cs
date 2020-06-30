using Microsoft.EntityFrameworkCore;
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
            _context.Emprestimos.Add(emprestimo);
            _context.SaveChanges();
        }

        IEnumerable<Emprestimo> IEmprestimoRepository.GetAllEmprestimo()
        {
            return _context.Emprestimos.ToList();
        }

        Emprestimo IEmprestimoRepository.GetEmprestimoById(int? id)
        {
            return _context.Emprestimos.Find(id);
        }

        IEnumerable<Emprestimo> IEmprestimoRepository.GetEmprestimoByLivro(Livro livro)
        {
            return _context.Emprestimos.Where(e => e.Livro == livro).AsNoTracking().ToList();
        }

        IEnumerable<Emprestimo> IEmprestimoRepository.GetLivroByAluno(Aluno aluno)
        {
            return _context.Emprestimos.Where(e => e.Aluno == aluno).AsNoTracking().ToList();
        }

        void IEmprestimoRepository.RemoveEmprestimo(Emprestimo emprestimo)
        {
            _context.Emprestimos.Remove(emprestimo);
            _context.SaveChanges();
        }

        void IEmprestimoRepository.UpdateEmprestimo(Emprestimo emprestimo)
        {
            _context.Emprestimos.Update(emprestimo);
            _context.SaveChanges();
        }
    }
}
