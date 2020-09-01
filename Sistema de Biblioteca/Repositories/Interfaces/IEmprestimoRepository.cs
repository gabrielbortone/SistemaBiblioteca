using Sistema_de_Biblioteca.Models;
using System.Collections.Generic;

namespace Sistema_de_Biblioteca.Repositories.Interfaces
{
    public interface IEmprestimoRepository
    {
        public void AddEmprestimo(Emprestimo emprestimo);
        public void RemoveEmprestimo(Emprestimo emprestimo);
        public void UpdateEmprestimo(Emprestimo emprestimo);
        public Emprestimo GetEmprestimoById(int? id);
        public IEnumerable<Emprestimo> GetAllEmprestimo();
        public IEnumerable<Emprestimo> GetEmprestimoByLivro(Livro livro);
        public IEnumerable<Emprestimo> GetLivroByAluno(Aluno aluno);
    }
}
