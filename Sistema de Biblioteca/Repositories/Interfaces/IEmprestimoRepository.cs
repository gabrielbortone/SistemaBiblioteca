using Sistema_de_Biblioteca.Models;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;

namespace Sistema_de_Biblioteca.Repositories.Interfaces
{
    public interface IEmprestimoRepository
    {
        void AddEmprestimo(Emprestimo emprestimo);
        void RemoveEmprestimo(Emprestimo emprestimo);
        void UpdateEmprestimo(Emprestimo emprestimo);
        Emprestimo GetEmprestimoById(int? id);
        IEnumerable<Emprestimo> GetAllEmprestimo();
        IEnumerable<Emprestimo> GetEmprestimoByLivro(Livro livro);
        IEnumerable<Emprestimo> GetLivroByAluno(Aluno aluno);
    }
}
