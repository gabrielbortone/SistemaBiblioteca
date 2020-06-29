using Sistema_de_Biblioteca.Models;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;

namespace Sistema_de_Biblioteca.Repositories.Interfaces
{
    public interface ILivroRepository
    {
        void AddLivro(Livro livro);
        void RemoveLivro(Livro livro);
        void UpdateLivro(Livro livro);
        Livro GetLivroById(int? id);
        IEnumerable<Livro> GetAllLivro();
        IEnumerable<Livro> GetLivroByAuthor(string autor);
        IEnumerable<Livro> GetLivroByGenre(string genero);
    }
}
