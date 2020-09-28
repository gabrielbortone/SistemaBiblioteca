using Sistema_de_Biblioteca.Models.ValueObjects;

namespace Sistema_de_Biblioteca.Repositories.Interfaces
{
    public interface ITelefoneFuncionarioRepository
    {
        public void AddTelefone(TelefoneFuncionario telefone);
        public void RemoveTelefone(int idTelefone);
        public void UpdateTelefone(TelefoneFuncionario telefone);
        public TelefoneFuncionario GetTelefoneByIdTelefone(int? id);
        public TelefoneFuncionario GetTelefoneByIdFuncionario(string? id);
    }
}
