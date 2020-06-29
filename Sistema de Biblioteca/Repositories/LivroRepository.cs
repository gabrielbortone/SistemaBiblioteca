using Sistema_de_Biblioteca.Models;
using Sistema_de_Biblioteca.Repositories.Interfaces;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;

namespace Sistema_de_Biblioteca.Repositories
{
    public class LivroRepository : ILivroRepository
    {
        private readonly AppDbContext _context;

        public LivroRepository(AppDbContext context)
        {
            _context = context;
        }
        void ILivroRepository.AddLivro(Livro livro)
        {
            throw new NotImplementedException();
        }

        IEnumerable<Livro> ILivroRepository.GetAllLivro()
        {
            throw new NotImplementedException();
        }

        IEnumerable<Livro> ILivroRepository.GetLivroByAuthor(string autor)
        {
            throw new NotImplementedException();
        }

        IEnumerable<Livro> ILivroRepository.GetLivroByGenre(string genero)
        {
            throw new NotImplementedException();
        }

        Livro ILivroRepository.GetLivroById(int? id)
        {
            throw new NotImplementedException();
        }

        void ILivroRepository.RemoveLivro(Livro livro)
        {
            throw new NotImplementedException();
        }

        void ILivroRepository.UpdateLivro(Livro livro)
        {
            throw new NotImplementedException();
        }
    }
}
