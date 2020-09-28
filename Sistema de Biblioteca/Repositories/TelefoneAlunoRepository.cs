using Sistema_de_Biblioteca.Models;
using Sistema_de_Biblioteca.Models.ValueObjects;
using Sistema_de_Biblioteca.Repositories.Interfaces;
using System;
using System.Linq;

namespace Sistema_de_Biblioteca.Repositories
{
    public class TelefoneAlunoRepository : ITelefoneAlunoRepository
    {
        public AppDbContext _context;
        public TelefoneAlunoRepository(AppDbContext context)
        {
            _context = context;
        }
        public void AddTelefone(TelefoneAluno telefone)
        {
            _context.TelefoneDeAlunos.Add(telefone);
        }

        public TelefoneAluno GetTelefoneByIdAluno(int? id)
        {
            return _context.TelefoneDeAlunos.FirstOrDefault(ta => ta.AlunoId == id);
        }

        public TelefoneAluno GetTelefoneByIdTelefone(int? id)
        {
            return _context.TelefoneDeAlunos.FirstOrDefault(ta => ta.TelefoneId == id);
        }

        public void RemoveTelefone(int idTelefone)
        {
            var telefoneAluno = GetTelefoneByIdTelefone(idTelefone);
            _context.TelefoneDeAlunos.Remove(telefoneAluno);
        }

        public void UpdateTelefone(TelefoneAluno telefone)
        {
            _context.TelefoneDeAlunos.Update(telefone);
        }
    }
}
