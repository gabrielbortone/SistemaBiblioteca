using Sistema_de_Biblioteca.Models.ValueObjects;

namespace Sistema_de_Biblioteca.Repositories.Interfaces
{
    public interface ITelefoneAlunoRepository
    {
        public void AddTelefone(TelefoneAluno telefone);
        public void RemoveTelefone(int idTelefone);
        public void UpdateTelefone(TelefoneAluno telefone);
        public TelefoneAluno GetTelefoneByIdTelefone(int? id);
        public TelefoneAluno GetTelefoneByIdAluno(int? id);
    }
}
