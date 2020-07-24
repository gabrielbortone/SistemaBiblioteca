using Sistema_de_Biblioteca.Models.ValueObjects;

namespace Sistema_de_Biblioteca.Repositories.Interfaces
{
    public interface IUnitOfWork
    {
        FuncionarioRepository FuncionarioRepository { get; }
        AlunoRepository AlunoRepository { get; }
        LivroRepository LivroRepository { get; }
        EmprestimoRepository EmprestimoRepository { get; }
        EnderecoAlunoRepository EnderecoAlunoRepository { get;}
        EnderecoFuncionarioRepository EnderecoFuncionarioRepository { get; }
        TelefoneAlunoRepository TelefoneAlunoRepository { get; }
        TelefoneFuncionarioRepository TelefoneFuncionarioRepository { get; }
        void Commit();
    }
}
