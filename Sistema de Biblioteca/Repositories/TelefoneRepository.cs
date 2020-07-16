using Sistema_de_Biblioteca.Models;
using Sistema_de_Biblioteca.Models.ValueObjects;
using Sistema_de_Biblioteca.Repositories.Interfaces;
using System;

namespace Sistema_de_Biblioteca.Repositories
{
    public class TelefoneRepository : ITelefoneRepository
    {
        private readonly AppDbContext _context;
        public TelefoneRepository(AppDbContext context)
        {
            _context = context;
        }
        public void AddTelefone(Telefone telefone)
        {
            _context.Telefones.Add(telefone);
        }

        public Telefone GetTelefoneById(int? id)
        {
            return _context.Telefones.Find(id);
        }

        public void RemoveTelefone(int idTelefone)
        {
            var telefone = this.GetTelefoneById(idTelefone);
            _context.Telefones.Remove(telefone);
        }
        public void UpdateTelefone(Telefone telefone)
        {
            _context.Telefones.Update(telefone);
        }
    }
}
