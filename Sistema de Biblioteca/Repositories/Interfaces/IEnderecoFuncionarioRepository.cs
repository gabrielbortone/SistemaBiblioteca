﻿using Sistema_de_Biblioteca.Models.ValueObjects;

namespace Sistema_de_Biblioteca.Repositories.Interfaces
{
    public interface IEnderecoFuncionarioRepository
    {
        public void AddEndereco(EnderecoFuncionario endereco);
        public void RemoveEndereco(int idEndereco);
        public void UpdateEndereco(EnderecoFuncionario endereco);
        public EnderecoFuncionario GetEnderecoById(int? id);
        public EnderecoFuncionario GetEnderecoByIdFuncionario(string? id);
    }
}
