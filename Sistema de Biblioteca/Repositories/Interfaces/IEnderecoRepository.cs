using Sistema_de_Biblioteca.Models.ValueObjects;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;

namespace Sistema_de_Biblioteca.Repositories.Interfaces
{
    public interface IEnderecoRepository
    {
        public void AddEndereco(Endereco endereco);
        public void RemoveEndereco(int idEndereco);
        public void UpdateEndereco(Endereco endereco);
        public Endereco GetEnderecoById(int? id);
    }
}
