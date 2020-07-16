using Sistema_de_Biblioteca.Models;
using Sistema_de_Biblioteca.Models.ValueObjects;
using Sistema_de_Biblioteca.Repositories.Interfaces;

namespace Sistema_de_Biblioteca.Repositories
{
    public class UnitOfWork : IUnitOfWork
    {
        public FuncionarioRepository FuncionarioRepository { get; }
        public AlunoRepository AlunoRepository { get; }
        public LivroRepository LivroRepository { get; }
        public EmprestimoRepository EmprestimoRepository { get; }

        public EnderecoRepository EnderecoRepository { get; }

        public TelefoneRepository TelefoneRepository { get; }

        private AppDbContext _context;

        public UnitOfWork(AppDbContext contexto)
        {
            _context = contexto;
            FuncionarioRepository = new FuncionarioRepository(contexto);
            AlunoRepository = new AlunoRepository(contexto);
            LivroRepository = new LivroRepository(contexto);
            EmprestimoRepository = new EmprestimoRepository(contexto);
            EnderecoRepository = new EnderecoRepository(contexto);
            TelefoneRepository = new TelefoneRepository(contexto);
        }
        
        public void Commit()
        {
            _context.SaveChanges();
        }

        public Endereco GetEnderecoByAluno(int idAluno)
        {
            var aluno = AlunoRepository.GetAlunoById(idAluno);
            return EnderecoRepository.GetEnderecoById(aluno.EnderecoId);
        }

        public Endereco GetEnderecoByFuncionario(int idFuncionario)
        {
            var funcionario = FuncionarioRepository.GetFuncionarioById(idFuncionario);
            return EnderecoRepository.GetEnderecoById(funcionario.EnderecoId);
        }

        public void RemoveEnderecoByAluno(int idAluno)
        {
            var aluno = AlunoRepository.GetAlunoById(idAluno);
            EnderecoRepository.RemoveEndereco(aluno.EnderecoId);
        }

        public void RemoveEnderecoByFuncionario(int idFuncionario)
        {
            var funcionario = FuncionarioRepository.GetFuncionarioById(idFuncionario);
            EnderecoRepository.RemoveEndereco(funcionario.EnderecoId);
        }

        public Telefone GetTelefoneByAluno(int idAluno)
        {
            var aluno = AlunoRepository.GetAlunoById(idAluno);
            return TelefoneRepository.GetTelefoneById(aluno.TelefoneId);
        }

        public Telefone GetTelefoneByFuncionario(int idFuncionario)
        {
            var funcionario = FuncionarioRepository.GetFuncionarioById(idFuncionario);
            return TelefoneRepository.GetTelefoneById(funcionario.TelefoneId);
        }

        public void RemoveTelefoneByAluno(int idAluno)
        {
            var aluno = AlunoRepository.GetAlunoById(idAluno);
            TelefoneRepository.RemoveTelefone(aluno.TelefoneId);
        }

        public void RemoveTelefoneByFuncionario(int idFuncionario)
        {
            var funcionario = FuncionarioRepository.GetFuncionarioById(idFuncionario);
            TelefoneRepository.RemoveTelefone(funcionario.TelefoneId);
        }
    }
}
