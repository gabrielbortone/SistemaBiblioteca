using Sistema_de_Biblioteca.Models;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;

namespace Sistema_de_Biblioteca.Repositories.Interfaces
{
    public interface IAlunoRepository
    {
        public void AddAluno(Aluno aluno);
        public void RemoveAluno(Aluno aluno);
        public void UpdateAluno(Aluno aluno);
        public Aluno GetAlunoById(int? id);
        public Aluno GetAlunoByName(string nome, string sobrenome);
        public IEnumerable<Aluno> GetAllAluno();
    }
}
