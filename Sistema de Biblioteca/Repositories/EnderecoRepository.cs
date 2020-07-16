using Microsoft.AspNetCore.Mvc;
using Sistema_de_Biblioteca.Models;
using Sistema_de_Biblioteca.Models.ValueObjects;
using Sistema_de_Biblioteca.Repositories.Interfaces;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;

namespace Sistema_de_Biblioteca.Repositories
{
    public class EnderecoRepository : IEnderecoRepository
    {
        private readonly AppDbContext _context;
        public EnderecoRepository(AppDbContext context)
        {
            _context = context;
        }
        public void AddEndereco(Endereco endereco)
        {
            _context.Enderecos.Add(endereco);
        }

        public Endereco GetEnderecoById(int? id)
        {
            return _context.Enderecos.Find(id);
        }

        public void RemoveEndereco(int idEndereco)
        {
            var endereco = this.GetEnderecoById(idEndereco);
            _context.Enderecos.Remove(endereco);
        }
        public void UpdateEndereco(Endereco endereco)
        {
            _context.Enderecos.Update(endereco);
        }
    }
}
