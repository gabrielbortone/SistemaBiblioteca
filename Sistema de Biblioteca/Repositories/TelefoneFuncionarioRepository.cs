using Microsoft.EntityFrameworkCore;
using Sistema_de_Biblioteca.Models;
using Sistema_de_Biblioteca.Models.ValueObjects;
using Sistema_de_Biblioteca.Repositories.Interfaces;
using System.Linq;

namespace Sistema_de_Biblioteca.Repositories
{
    public class TelefoneFuncionarioRepository : ITelefoneFuncionarioRepository
    {
        private readonly AppDbContext _context;
        public TelefoneFuncionarioRepository(AppDbContext contexto)
        {
            _context = contexto;
        }

        public void AddTelefone(TelefoneFuncionario telefone)
        {
            _context.TelefoneDeFuncionarios.Add(telefone);
        }

        public TelefoneFuncionario GetTelefoneByFuncionario(Funcionario funcionario)
        {
            return _context.TelefoneDeFuncionarios.AsNoTracking().FirstOrDefault(tf => tf.Funcionario == funcionario);
        }

        public TelefoneFuncionario GetTelefoneById(int? id)
        {
            return _context.TelefoneDeFuncionarios.AsNoTracking().FirstOrDefault(tf => tf.Id == id);
        }

        public void RemoveTelefone(int idTelefone)
        {
            var endereco = GetTelefoneById(idTelefone);
            _context.TelefoneDeFuncionarios.Remove(endereco);
        }

        public void RemoveTelefoneByFuncionario(int idFuncionario)
        {
            var telefone = _context.TelefoneDeFuncionarios.AsNoTracking().FirstOrDefault(tf => tf.FuncionarioId == idFuncionario);
            _context.TelefoneDeFuncionarios.Remove(telefone);
        }

        public void UpdateTelefone(TelefoneFuncionario telefone)
        {
            _context.TelefoneDeFuncionarios.Update(telefone);
        }
    }
}
