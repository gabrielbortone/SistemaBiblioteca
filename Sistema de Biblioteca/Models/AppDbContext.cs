using Microsoft.AspNetCore.Identity.EntityFrameworkCore;
using Microsoft.EntityFrameworkCore;
using Sistema_de_Biblioteca.Models.ValueObjects;

namespace Sistema_de_Biblioteca.Models
{
    public class AppDbContext : IdentityDbContext<Account>
    {
        public DbSet<Aluno> Alunos { get; set; }
        public DbSet<Account> Accounts { get; set; }
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
            modelBuilder.Entity<Aluno>()
                .HasOne(a => a.Telefone)
                .WithOne(t => t.Aluno)
                .HasForeignKey<Telefone>(t => t.AlunoId);

            modelBuilder.Entity<Aluno>()
                .HasOne(a => a.Endereco)
                .WithOne(e => e.Aluno)
                .HasForeignKey<Endereco>(e => e.AlunoId);

            modelBuilder.Entity<Funcionario>()
                .HasOne(f => f.Telefone)
                .WithOne(t => t.Funcionario)
                .HasForeignKey<Telefone>(t => t.FuncionarioId);

            modelBuilder.Entity<Funcionario>()
                .HasOne(f => f.Endereco)
                .WithOne(e => e.Funcionario)
                .HasForeignKey<Endereco>(e => e.FuncionarioId);
        }

    }
}
