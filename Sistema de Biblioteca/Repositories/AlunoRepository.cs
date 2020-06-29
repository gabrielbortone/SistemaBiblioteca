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
            throw new NotImplementedException();
        }

        IEnumerable<Aluno> IAlunoRepository.GetAllAluno()
        {
            throw new NotImplementedException();
        }

        Aluno IAlunoRepository.GetAlunoById(int? id)
        {
            throw new NotImplementedException();
        }

        void IAlunoRepository.RemoveAluno(Aluno aluno)
        {
            throw new NotImplementedException();
        }

        void IAlunoRepository.UpdateAluno(Aluno aluno)
        {
            throw new NotImplementedException();
        }
    }
}
