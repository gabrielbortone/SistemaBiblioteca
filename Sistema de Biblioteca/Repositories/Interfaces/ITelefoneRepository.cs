using Sistema_de_Biblioteca.Models.ValueObjects;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;

namespace Sistema_de_Biblioteca.Repositories.Interfaces
{
    public interface ITelefoneRepository
    {
        public void AddTelefone(Telefone telefone);
        public void RemoveTelefone(int idTelefone);
        public void UpdateTelefone(Telefone telefone);
        public Telefone GetTelefoneById(int? id);
        public Telefone GetTelefoneByAluno(int idAluno);
        public Telefone GetTelefoneByFuncionario(int idFuncionario);
        public void RemoveTelefoneByAluno(int idAluno);
        public void RemoveTelefoneByFuncionario(int idFuncionario);
    }
}
