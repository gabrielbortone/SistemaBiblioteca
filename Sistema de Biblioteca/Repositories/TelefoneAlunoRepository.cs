using Microsoft.EntityFrameworkCore;
using Sistema_de_Biblioteca.Models;
using Sistema_de_Biblioteca.Models.ValueObjects;
using Sistema_de_Biblioteca.Repositories.Interfaces;
using System.Linq;

namespace Sistema_de_Biblioteca.Repositories
{
    public class TelefoneAlunoRepository : ITelefoneAlunoRepository
    {
        private readonly AppDbContext _context;
        public TelefoneAlunoRepository(AppDbContext context)
        {
            _context = context;
        }

        public void AddTelefone(TelefoneAluno telefone)
        {
            _context.TelefoneDeAlunos.Add(telefone);
        }

        public TelefoneAluno GetTelefoneByAluno(Aluno aluno)
        {
            return _context.TelefoneDeAlunos.AsNoTracking().FirstOrDefault(ta => ta.Aluno == aluno);
        }

        public TelefoneAluno GetTelefoneById(int? id)
        {
            return _context.TelefoneDeAlunos.AsNoTracking().FirstOrDefault(ta => ta.TelefoneId == id);
        }

        public void RemoveTelefone(int idTelefone)
        {
            var telefone = GetTelefoneById(idTelefone);
            _context.TelefoneDeAlunos.Remove(telefone);
        }

        public void RemoveTelefoneByAluno(int idAluno)
        {
            var telefone = _context.TelefoneDeAlunos.AsNoTracking().FirstOrDefault(ta => ta.AlunoId == idAluno);
            _context.TelefoneDeAlunos.Remove(telefone);
        }

        public void UpdateTelefone(TelefoneAluno telefone)
        {
            _context.TelefoneDeAlunos.Update(telefone);
        }
    }
}
