using Sistema_de_Biblioteca.Models.ValueObjects;

namespace Sistema_de_Biblioteca.Repositories.Interfaces
{
    public interface IEnderecoAlunoRepository
    {
        public void AddEndereco(EnderecoAluno endereco);
        public void RemoveEndereco(int idEndereco);
        public void UpdateEndereco(EnderecoAluno endereco);
        public EnderecoAluno GetEnderecoByIdEndereco(int? id);
        public EnderecoAluno GetEnderecoByIdAluno(int? id);
    }
}
