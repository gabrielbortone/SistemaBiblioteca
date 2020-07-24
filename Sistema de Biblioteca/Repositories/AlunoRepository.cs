using Microsoft.EntityFrameworkCore;
using Sistema_de_Biblioteca.Models;
using Sistema_de_Biblioteca.Repositories.Interfaces;
using System.Collections.Generic;
using System.Linq;

namespace Sistema_de_Biblioteca.Repositories
{
    public class AlunoRepository : IAlunoRepository
    {
        private readonly AppDbContext _context;

        public AlunoRepository(AppDbContext context)
        {
            _context = context;
        }

        public void AddAluno(Aluno aluno)
        {
            _context.Alunos.Add(aluno);
        }

        public void UpdateAluno(Aluno aluno)
        {
            _context.Alunos.Update(aluno);
        }

        public IEnumerable<Aluno> GetAllAluno()
        {
            return _context.Alunos.AsNoTracking().ToList();
        }

        public Aluno GetAlunoById(int? id)
        {
            return _context.Alunos.AsNoTracking().FirstOrDefault(a => a.AlunoId == id);
        }

        public void RemoveAluno(Aluno aluno)
        {
            _context.Alunos.Remove(aluno);
        }

        public Aluno GetAlunoByCPF(string cpf)
        {
            return _context.Alunos.AsNoTracking().FirstOrDefault(a => a.CPF == cpf);
        }
    }
}
