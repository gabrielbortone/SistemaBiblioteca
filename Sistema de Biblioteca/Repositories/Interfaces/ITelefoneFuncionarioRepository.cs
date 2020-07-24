using Sistema_de_Biblioteca.Models;
using Sistema_de_Biblioteca.Models.ValueObjects;

namespace Sistema_de_Biblioteca.Repositories.Interfaces
{
    public interface ITelefoneFuncionarioRepository
    {
        public void AddTelefone(TelefoneFuncionario telefone);
        public void RemoveTelefone(int idTelefone);
        public void RemoveTelefoneByFuncionario(int idFuncionario);
        public void UpdateTelefone(TelefoneFuncionario telefone);
        public TelefoneFuncionario GetTelefoneById(int? id);
        public TelefoneFuncionario GetTelefoneByFuncionario(Funcionario funcionario);
    }
}
