﻿using Microsoft.AspNetCore.Identity.EntityFrameworkCore;
using Microsoft.EntityFrameworkCore;
using Sistema_de_Biblioteca.Models.ValueObjects;

namespace Sistema_de_Biblioteca.Models
{
    public class AppDbContext : IdentityDbContext<Funcionario>
    {
        public DbSet<Aluno> Alunos { get; set; }
        public DbSet<Funcionario> Funcionarios { get; set; }
        public DbSet<Endereco> Enderecos { get; set; }
        public DbSet<EnderecoAluno> EnderecoDeAlunos { get; set; }
        public DbSet<EnderecoFuncionario> EnderecoDeFuncionarios { get; set; }
        public DbSet<Telefone> Telefones { get; set; }
        public DbSet<TelefoneAluno> TelefoneDeAlunos { get; set; }
        public DbSet<TelefoneFuncionario> TelefoneDeFuncionarios { get; set; }
        public DbSet<Livro> Livros { get; set; }
        public DbSet<Emprestimo> Emprestimos { get; set; }


        public AppDbContext(DbContextOptions<AppDbContext> options) : base(options)
        {

        }

        protected override void OnModelCreating(ModelBuilder builder)
        {
            base.OnModelCreating(builder);
            builder.Entity<Funcionario>()
                .HasOne(f => f.Endereco)
                .WithOne(ef => ef.Funcionario)
                .HasForeignKey<EnderecoFuncionario>(ef => ef.FuncionarioId);

            builder.Entity<Funcionario>()
                .HasOne(f => f.Telefone)
                .WithOne(tf => tf.Funcionario)
                .HasForeignKey<TelefoneFuncionario>(tf => tf.FuncionarioId);

            builder.Entity<Aluno>()
                .HasOne(a => a.Endereco)
                .WithOne(ea => ea.Aluno)
                .HasForeignKey<EnderecoAluno>(ea => ea.AlunoId);

            builder.Entity<Aluno>()
                .HasOne(a => a.Telefone)
                .WithOne(af => af.Aluno)
                .HasForeignKey<TelefoneAluno>(af => af.AlunoId);
        }

    }
}
