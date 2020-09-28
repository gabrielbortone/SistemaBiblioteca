using Sistema_de_Biblioteca.Models;
using Sistema_de_Biblioteca.Models.ValueObjects;
using Sistema_de_Biblioteca.Repositories.Interfaces;
using System.Linq;

namespace Sistema_de_Biblioteca.Repositories
{
    public class EnderecoRepository : IEnderecoRepository
    {
        private readonly AppDbContext _context;
        public EnderecoRepository(AppDbContext contexto)
        {
            _context = contexto;
        }

        public void AddEndereco(Endereco endereco)
        {
            _context.Enderecos.Add(endereco);
        }

        public Endereco GetEnderecoById(int? id)
        {
            return _context.Enderecos.FirstOrDefault(e => e.EnderecoId == id);
        }

        public void RemoveEndereco(int idEndereco)
        {
            var endereco = GetEnderecoById(idEndereco);
            _context.Enderecos.Remove(endereco);
        }

        public void UpdateEndereco(Endereco endereco)
        {
            _context.Enderecos.Update(endereco);
        }
    }
}
