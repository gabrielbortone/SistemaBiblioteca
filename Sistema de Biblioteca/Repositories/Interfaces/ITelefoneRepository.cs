using Sistema_de_Biblioteca.Models.ValueObjects;

namespace Sistema_de_Biblioteca.Repositories.Interfaces
{
    public interface ITelefoneRepository
    {
        public void AddTelefone(Telefone telefone);
        public void RemoveTelefone(int idTelefone);
        public void UpdateTelefone(Telefone telefone);
        public Telefone GetTelefoneById(int? id);
    }
}
