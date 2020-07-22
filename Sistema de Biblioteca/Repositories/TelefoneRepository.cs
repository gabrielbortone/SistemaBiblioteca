using Sistema_de_Biblioteca.Models;
using Sistema_de_Biblioteca.Models.ValueObjects;
using Sistema_de_Biblioteca.Repositories.Interfaces;
using System.Linq;

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

        public Telefone GetTelefoneByAluno(int idAluno)
        {
            return _context.Telefones.FirstOrDefault(t => t.AlunoId == idAluno);
        }

        public Telefone GetTelefoneByFuncionario(int idFuncionario)
        {
            return _context.Telefones.FirstOrDefault(t => t.FuncionarioId == idFuncionario);
        }

        public void RemoveTelefoneByAluno(int idAluno)
        {
            Telefone telefone = GetTelefoneByAluno(idAluno);
            RemoveTelefone(telefone.AlunoId);
        }

        public void RemoveTelefoneByFuncionario(int idFuncionario)
        {
            Telefone telefone = GetTelefoneByFuncionario(idFuncionario);
            RemoveTelefone(telefone.AlunoId);
        }
    }
}
