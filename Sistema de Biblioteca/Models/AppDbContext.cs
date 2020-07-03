using Microsoft.EntityFrameworkCore;
using Sistema_de_Biblioteca.Models.ValueObjects;
using Sistema_de_Biblioteca.ViewModels;

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


        public DbSet<Sistema_de_Biblioteca.ViewModels.AlunoViewModel> AlunoViewModel { get; set; }


        public DbSet<Sistema_de_Biblioteca.ViewModels.EmprestimoViewModel> EmprestimoViewModel { get; set; }


        public DbSet<Sistema_de_Biblioteca.ViewModels.FuncionarioViewModel> FuncionarioViewModel { get; set; }


        public DbSet<Sistema_de_Biblioteca.ViewModels.LivroViewModel> LivroViewModel { get; set; }

    }
}
