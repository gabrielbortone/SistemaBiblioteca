using Microsoft.EntityFrameworkCore;
using Sistema_de_Biblioteca.Models.ValueObjects;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;

namespace Sistema_de_Biblioteca.Models
{
    public class AppDbContext : DbContext
    {
        public DbSet<Aluno> Alunos { get; set; }
        public DbSet<Funcionario> Funcionarios { get; set; }
        public DbSet<Endereco> Enderecos { get; set; }
        public DbSet<Telefone> Telefones { get; set; }
        public DbSet<Livro> Livros { get; set; }
        public DbSet<Emprestimo> Emprestimos { get; set; }

        public AppDbContext(DbContextOptions<AppDbContext> options) : base(options)
        {

        }

        protected override void OnModelCreating(ModelBuilder modelBuilder)
        {

        }

    }
}
