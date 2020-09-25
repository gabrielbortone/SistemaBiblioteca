using Sistema_de_Biblioteca.Models.ValueObjects;

namespace Sistema_de_Biblioteca.Repositories.Interfaces
{
    public interface ITelefoneRepository
    {
        public void AddTelefone(TelefoneAluno telefone);
        public void RemoveTelefone(int idTelefone);
        public void UpdateTelefone(TelefoneAluno telefone);
        public Telefone GetTelefoneById(int? id);
    }
}
