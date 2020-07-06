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
        public void AddLivro(Livro livro)
        {
            _context.Livros.Add(livro);
            _context.SaveChanges();
        }

        public IEnumerable<Livro> GetAllLivro()
        {
            return _context.Livros.ToList();
        }

        public IEnumerable<Livro> GetLivroByAuthor(string autor)
        {
            return _context.Livros.Where(l => l.Autor == autor).AsNoTracking().ToList();
        }

        public IEnumerable<Livro> GetLivroByGenre(string genero)
        {
            return _context.Livros.Where(l => l.Genero == genero).AsNoTracking().ToList();
        }

        public Livro GetLivroById(int? id)
        {
            return _context.Livros.Find(id);
        }

        public Livro GetLivroByTitle(string titulo)
        {
            return _context.Livros.Where(l => l.Titulo == titulo).FirstOrDefault();
        }

        public void RemoveLivro(Livro livro)
        {
            _context.Livros.Remove(livro);
            _context.SaveChanges();
        }

        public void UpdateLivro(Livro livro)
        {
            _context.Livros.Update(livro);
            _context.SaveChanges();
        }
    }
}
