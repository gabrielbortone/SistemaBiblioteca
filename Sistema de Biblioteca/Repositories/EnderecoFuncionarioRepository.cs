using Microsoft.EntityFrameworkCore;
using Sistema_de_Biblioteca.Models;
using Sistema_de_Biblioteca.Models.ValueObjects;
using Sistema_de_Biblioteca.Repositories.Interfaces;
using System.Linq;

namespace Sistema_de_Biblioteca.Repositories
{
    public class EnderecoFuncionarioRepository : IEnderecoFuncionarioRepository
    {
        private readonly AppDbContext _context;
        public EnderecoFuncionarioRepository(AppDbContext context)
        {
            _context = context;
        }

        public void AddEndereco(EnderecoFuncionario endereco)
        {
            _context.EnderecoDeFuncionarios.Add(endereco);
        }

        public EnderecoFuncionario GetEnderecoByFuncionario(Funcionario funcionario)
        {
            return _context.EnderecoDeFuncionarios.AsNoTracking().FirstOrDefault(ef => ef.Funcionario == funcionario);
        }

        public EnderecoFuncionario GetEnderecoById(int? id)
        {
            return _context.EnderecoDeFuncionarios.AsNoTracking().FirstOrDefault(ef => ef.Id == id);
        }

        public void RemoveEndereco(int idEndereco)
        {
            var endereco = GetEnderecoById(idEndereco);
            _context.EnderecoDeFuncionarios.Remove(endereco);
        }

        public void RemoveEnderecoByFuncionario(int idFuncionario)
        {
            var endereco = _context.EnderecoDeFuncionarios.FirstOrDefault(ef => ef.FuncionarioId == idFuncionario);
            _context.Remove(endereco);
        }

        public void UpdateEndereco(EnderecoFuncionario endereco)
        {
            _context.EnderecoDeFuncionarios.Update(endereco);
        }
    }
}
