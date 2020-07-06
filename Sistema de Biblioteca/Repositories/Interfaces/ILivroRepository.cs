using Sistema_de_Biblioteca.Models;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;

namespace Sistema_de_Biblioteca.Repositories.Interfaces
{
    public interface ILivroRepository
    {
        public void AddLivro(Livro livro);
        public void RemoveLivro(Livro livro);
        public void UpdateLivro(Livro livro);
        public Livro GetLivroById(int? id);
        public IEnumerable<Livro> GetAllLivro();
        public Livro GetLivroByTitle(string titulo);
        public IEnumerable<Livro> GetLivroByAuthor(string autor);
        public IEnumerable<Livro> GetLivroByGenre(string genero);
    }
}
