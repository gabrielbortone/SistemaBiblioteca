using Sistema_de_Biblioteca.Models;
using Sistema_de_Biblioteca.Models.ValueObjects;
using Sistema_de_Biblioteca.Repositories.Interfaces;
using System.Linq;

namespace Sistema_de_Biblioteca.Repositories
{
    public class TelefoneFuncionarioRepository : ITelefoneFuncionarioRepository
    {
        private AppDbContext _context;
        public TelefoneFuncionarioRepository(AppDbContext context)
        {
            _context = context;
        }
        public void AddTelefone(TelefoneFuncionario telefone)
        {
            _context.TelefoneDeFuncionarios.Add(telefone);
        }

        public TelefoneFuncionario GetTelefoneByIdFuncionario(string id)
        {
            return _context.TelefoneDeFuncionarios.FirstOrDefault(tf => tf.FuncionarioId == id);
        }

        public TelefoneFuncionario GetTelefoneByIdTelefone(int? id)
        {
            return _context.TelefoneDeFuncionarios.FirstOrDefault(tf => tf.TelefoneId == id);
        }

        public void RemoveTelefone(int idTelefone)
        {
            var telefoneFuncionario = GetTelefoneByIdTelefone(idTelefone);
            _context.TelefoneDeFuncionarios.Remove(telefoneFuncionario);
        }

        public void UpdateTelefone(TelefoneFuncionario telefone)
        {
            _context.TelefoneDeFuncionarios.Update(telefone);
        }
    }
}
