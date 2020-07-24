using Microsoft.EntityFrameworkCore;
using Sistema_de_Biblioteca.Models;
using Sistema_de_Biblioteca.Models.ValueObjects;
using Sistema_de_Biblioteca.Repositories.Interfaces;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;

namespace Sistema_de_Biblioteca.Repositories
{
    public class EnderecoAlunoRepository : IEnderecoAlunoRepository
    {
        private readonly AppDbContext _context;
        public EnderecoAlunoRepository(AppDbContext contexto)
        {
            _context = contexto;
        }

        public void AddEndereco(EnderecoAluno endereco)
        {
            _context.EnderecoDeAlunos.Add(endereco);
        }

        public EnderecoAluno GetEnderecoByAluno(Aluno aluno)
        {
            return _context.EnderecoDeAlunos.AsNoTracking().FirstOrDefault(ea => ea.Aluno == aluno);
        }

        public EnderecoAluno GetEnderecoById(int? id)
        {
            return _context.EnderecoDeAlunos.AsNoTracking().FirstOrDefault(ea => ea.EnderecoId == id);
        }

        public void RemoveEndereco(int idEndereco)
        {
            var endereco = GetEnderecoById(idEndereco);
            _context.Remove(endereco);
        }

        public void RemoveEnderecoByAluno(int idAluno)
        {
            var endereco = _context.EnderecoDeAlunos.AsNoTracking().FirstOrDefault(ea => ea.AlunoId == idAluno);
            _context.Remove(endereco);
        }

        public void UpdateEndereco(EnderecoAluno endereco)
        {
            _context.Update(endereco);
        }
    }
}
