using Sistema_de_Biblioteca.Models;
using Sistema_de_Biblioteca.Repositories.Interfaces;

namespace Sistema_de_Biblioteca.Repositories
{
    public class UnitOfWork : IUnitOfWork
    {
        public FuncionarioRepository FuncionarioRepository { get; }
        public AlunoRepository AlunoRepository { get; }
        public LivroRepository LivroRepository { get; }
        public EmprestimoRepository EmprestimoRepository { get; }
        public EnderecoRepository EnderecoAlunoRepository { get; }
        public EnderecoFuncionarioRepository EnderecoFuncionarioRepository { get; }
        public TelefoneRepository TelefoneAlunoRepository { get; }
        public TelefoneFuncionarioRepository TelefoneFuncionarioRepository { get; }

        private AppDbContext _context;

        public UnitOfWork(AppDbContext contexto)
        {
            _context = contexto;
            FuncionarioRepository = new FuncionarioRepository(contexto);
            AlunoRepository = new AlunoRepository(contexto);
            LivroRepository = new LivroRepository(contexto);
            EmprestimoRepository = new EmprestimoRepository(contexto);
            EnderecoAlunoRepository = new EnderecoRepository(contexto);
            EnderecoFuncionarioRepository = new EnderecoFuncionarioRepository(contexto);
            TelefoneAlunoRepository = new TelefoneRepository(contexto);
            TelefoneFuncionarioRepository = new TelefoneFuncionarioRepository(contexto);
        }
        
        public void Commit()
        {
            _context.SaveChanges();
        }

        
    }
}
