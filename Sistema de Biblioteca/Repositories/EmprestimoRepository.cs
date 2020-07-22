using Microsoft.EntityFrameworkCore;
using Sistema_de_Biblioteca.Models;
using Sistema_de_Biblioteca.Repositories.Interfaces;
using System.Collections.Generic;
using System.Linq;

namespace Sistema_de_Biblioteca.Repositories
{
    public class EmprestimoRepository : IEmprestimoRepository
    {
        private readonly AppDbContext _context;

        public EmprestimoRepository(AppDbContext context)
        {
            _context = context;
        }
        public void AddEmprestimo(Emprestimo emprestimo)
        {
            _context.Emprestimos.Add(emprestimo);
        }

        public IEnumerable<Emprestimo> GetAllEmprestimo()
        {
            return _context.Emprestimos.ToList();
        }

        public Emprestimo GetEmprestimoById(int? id)
        {
            return _context.Emprestimos.Find(id);
        }

        public IEnumerable<Emprestimo> GetEmprestimoByLivro(Livro livro)
        {
            return _context.Emprestimos.Where(e => e.Livro == livro).AsNoTracking().ToList();
        }

        public IEnumerable<Emprestimo> GetLivroByAluno(Aluno aluno)
        {
            return _context.Emprestimos.Where(e => e.Aluno == aluno).AsNoTracking().ToList();
        }

        public void RemoveEmprestimo(Emprestimo emprestimo)
        {
            _context.Emprestimos.Remove(emprestimo);
        }

        public void UpdateEmprestimo(Emprestimo emprestimo)
        {
            _context.Emprestimos.Update(emprestimo);
        }
    }
}
