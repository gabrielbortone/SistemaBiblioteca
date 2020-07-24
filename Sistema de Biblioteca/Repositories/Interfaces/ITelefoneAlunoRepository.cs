using Sistema_de_Biblioteca.Models;
using Sistema_de_Biblioteca.Models.ValueObjects;

namespace Sistema_de_Biblioteca.Repositories.Interfaces
{
    public interface ITelefoneAlunoRepository
    {
        public void AddTelefone(TelefoneAluno telefone);
        public void RemoveTelefone(int idTelefone);
        public void RemoveTelefoneByAluno(int idAluno);
        public void UpdateTelefone(TelefoneAluno telefone);
        public TelefoneAluno GetTelefoneById(int? id);
        public TelefoneAluno GetTelefoneByAluno(Aluno aluno);
    }
}
