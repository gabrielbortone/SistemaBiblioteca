using Sistema_de_Biblioteca.Models;
using Sistema_de_Biblioteca.Models.ValueObjects;

namespace Sistema_de_Biblioteca.Repositories.Interfaces
{
    public interface IEnderecoAlunoRepository
    {
        public void AddEndereco(EnderecoAluno endereco);
        public void RemoveEndereco(int idEndereco);
        public void RemoveEnderecoByAluno(int idAluno);
        public void UpdateEndereco(EnderecoAluno endereco);
        public EnderecoAluno GetEnderecoById(int? id);
        public EnderecoAluno GetEnderecoByAluno(Aluno aluno);
    }
}
