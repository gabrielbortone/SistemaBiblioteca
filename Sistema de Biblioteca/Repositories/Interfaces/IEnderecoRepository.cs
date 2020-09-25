using Sistema_de_Biblioteca.Models;
using Sistema_de_Biblioteca.Models.ValueObjects;

namespace Sistema_de_Biblioteca.Repositories.Interfaces
{
    public interface IEnderecoRepository
    {
        public void AddEndereco(EnderecoFuncionario endereco);
        public void RemoveEndereco(int idEndereco);
        public void UpdateEndereco(Endereco endereco);
        public Endereco GetEnderecoById(int? id);
    }
}
