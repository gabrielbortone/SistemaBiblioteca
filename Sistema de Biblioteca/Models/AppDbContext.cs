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
        public DbSet<EnderecoAluno> EnderecoDeAlunos { get; set; }
        public DbSet<EnderecoFuncionario> EnderecoDeFuncionarios { get; set; }
        public DbSet<TelefoneAluno> TelefoneDeAlunos { get; set; }
        public DbSet<TelefoneFuncionario> TelefoneDeFuncionarios { get; set; }
        public DbSet<Livro> Livros { get; set; }
        public DbSet<Emprestimo> Emprestimos { get; set; }


        public AppDbContext(DbContextOptions<AppDbContext> options) : base(options)
        {

        }


    }
}
