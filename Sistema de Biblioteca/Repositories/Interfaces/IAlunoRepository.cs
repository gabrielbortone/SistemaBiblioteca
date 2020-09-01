using Sistema_de_Biblioteca.Models;
using System.Collections.Generic;

namespace Sistema_de_Biblioteca.Repositories.Interfaces
{
    public interface IAlunoRepository
    {
        public void AddAluno(Aluno aluno);
        public void RemoveAluno(Aluno aluno);
        public void UpdateAluno(Aluno aluno);
        public Aluno GetAlunoById(int? id);
        public Aluno GetAlunoByCPF(string cpf);
        public IEnumerable<Aluno> GetAllAluno();
    }
}
