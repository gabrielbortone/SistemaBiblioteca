using Sistema_de_Biblioteca.Models;
using Sistema_de_Biblioteca.Models.ValueObjects;
using Sistema_de_Biblioteca.Repositories.Interfaces;
using System;
using System.Linq;

namespace Sistema_de_Biblioteca.Repositories
{
    public class EnderecoAlunoRepository : IEnderecoAlunoRepository
    {
        private AppDbContext _context;
        public EnderecoAlunoRepository(AppDbContext context)
        {
            _context = context;
        }
        public void AddEndereco(EnderecoAluno endereco)
        {
            _context.EnderecoDeAlunos.Add(endereco);
        }

        public EnderecoAluno GetEnderecoByIdAluno(int? id)
        {
            return _context.EnderecoDeAlunos.FirstOrDefault(ea => ea.AlunoId == id);
        }

        public EnderecoAluno GetEnderecoByIdEndereco(int? id)
        {
            return _context.EnderecoDeAlunos.FirstOrDefault(ea => ea.EnderecoId == id);
        }

        public void RemoveEndereco(int idEndereco)
        {
            var enderecoAluno = GetEnderecoByIdEndereco(idEndereco);
            _context.EnderecoDeAlunos.Remove(enderecoAluno);
        }

        public void UpdateEndereco(EnderecoAluno endereco)
        {
            _context.EnderecoDeAlunos.Update(endereco);
        }
    }
}
