using Sistema_de_Biblioteca.Models;
using Sistema_de_Biblioteca.Models.ValueObjects;
using Sistema_de_Biblioteca.Repositories.Interfaces;
using System.Linq;

namespace Sistema_de_Biblioteca.Repositories
{
    public class EnderecoFuncionarioRepository : IEnderecoFuncionarioRepository
    {
        private AppDbContext _context;
        public EnderecoFuncionarioRepository(AppDbContext context)
        {
            _context = context;
        }
        public void AddEndereco(EnderecoFuncionario endereco)
        {
            _context.EnderecoDeFuncionarios.Add(endereco);
        }

        public EnderecoFuncionario GetEnderecoById(int? id)
        {
            return _context.EnderecoDeFuncionarios.FirstOrDefault(ef=>ef.EnderecoId == id);
        }

        public EnderecoFuncionario GetEnderecoByIdFuncionario(string id)
        {
            return _context.EnderecoDeFuncionarios.FirstOrDefault(ef => ef.FuncionarioId == id);
        }

        public void RemoveEndereco(int idEndereco)
        {
            var enderecoFuncionario = GetEnderecoById(idEndereco);
            _context.EnderecoDeFuncionarios.Remove(enderecoFuncionario);
        }

        public void UpdateEndereco(EnderecoFuncionario endereco)
        {
            _context.EnderecoDeFuncionarios.Update(endereco);
        }
    }
}
