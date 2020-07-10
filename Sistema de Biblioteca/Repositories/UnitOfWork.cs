using Sistema_de_Biblioteca.Models;
using Sistema_de_Biblioteca.Repositories.Interfaces;
using Sistema_de_Biblioteca.Services;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;

namespace Sistema_de_Biblioteca.Repositories
{
    public class UnitOfWork : IUnitOfWork
    {
        public FuncionarioRepository FuncionarioRepository { get; }
        public AlunoRepository AlunoRepository { get; }
        public LivroRepository LivroRepository { get; }
        public EmprestimoRepository EmprestimoRepository { get; }
        public LoginService LoginService { get; }
        private AppDbContext _context;

        public UnitOfWork(AppDbContext contexto)
        {
            _context = contexto;
            FuncionarioRepository = new FuncionarioRepository(contexto);
            AlunoRepository = new AlunoRepository(contexto);
            LivroRepository = new LivroRepository(contexto);
            EmprestimoRepository = new EmprestimoRepository(contexto);
            LoginService = new LoginService(FuncionarioRepository);
        }
        
        public void Commit()
        {
            _context.SaveChanges();
        }
    }
}
