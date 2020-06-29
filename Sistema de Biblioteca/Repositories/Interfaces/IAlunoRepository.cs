using Sistema_de_Biblioteca.Models;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;

namespace Sistema_de_Biblioteca.Repositories.Interfaces
{
    public interface IAlunoRepository
    {
        void AddAluno(Aluno aluno);
        void RemoveAluno(Aluno aluno);
        void UpdateAluno(Aluno aluno);
        Aluno GetAlunoById(int? id);
        IEnumerable<Aluno> GetAllAluno();
    }
}
