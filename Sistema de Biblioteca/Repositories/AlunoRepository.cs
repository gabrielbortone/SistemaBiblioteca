using Sistema_de_Biblioteca.Models;
using Sistema_de_Biblioteca.Repositories.Interfaces;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;

namespace Sistema_de_Biblioteca.Repositories
{
    public class AlunoRepository : IAlunoRepository
    {
        private readonly AppDbContext _context;

        public AlunoRepository(AppDbContext context)
        {
            _context = context;
        }

        void IAlunoRepository.AddAluno(Aluno aluno)
        {
            _context.Alunos.Add(aluno);
            _context.SaveChanges();
        }

        void IAlunoRepository.UpdateAluno(Aluno aluno)
        {
            _context.Alunos.Update(aluno);
            _context.SaveChanges();
        }

        IEnumerable<Aluno> IAlunoRepository.GetAllAluno()
        {
            return _context.Alunos.ToList();
        }

        Aluno IAlunoRepository.GetAlunoById(int? id)
        {
            return _context.Alunos.Find(id);
        }

        void IAlunoRepository.RemoveAluno(Aluno aluno)
        {
            _context.Alunos.Remove(aluno);
            _context.SaveChanges();
        }

       
    }
}
