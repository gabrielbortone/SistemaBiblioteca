using Microsoft.EntityFrameworkCore;
using Sistema_de_Biblioteca.Models;
using Sistema_de_Biblioteca.Repositories.Interfaces;
using System.Collections.Generic;
using System.Linq;

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
            _context.Livros.Add(livro);
            _context.SaveChanges();
        }

        IEnumerable<Livro> ILivroRepository.GetAllLivro()
        {
            return _context.Livros.ToList();
        }

        IEnumerable<Livro> ILivroRepository.GetLivroByAuthor(string autor)
        {
            return _context.Livros.Where(l => l.Autor == autor).AsNoTracking().ToList();
        }

        IEnumerable<Livro> ILivroRepository.GetLivroByGenre(string genero)
        {
            return _context.Livros.Where(l => l.Genero == genero).AsNoTracking().ToList();
        }

        Livro ILivroRepository.GetLivroById(int? id)
        {
            return _context.Livros.Find(id);
        }

        void ILivroRepository.RemoveLivro(Livro livro)
        {
            _context.Livros.Remove(livro);
            _context.SaveChanges();
        }

        void ILivroRepository.UpdateLivro(Livro livro)
        {
            _context.Livros.Update(livro);
            _context.SaveChanges();
        }
    }
}
