namespace Sistema_de_Biblioteca.Repositories.Interfaces
{
    public interface IUnitOfWork
    {
        FuncionarioRepository FuncionarioRepository { get; }
        AlunoRepository AlunoRepository { get; }
        LivroRepository LivroRepository { get; }
        EmprestimoRepository EmprestimoRepository { get; }
        EnderecoRepository EnderecoAlunoRepository { get;}
        EnderecoFuncionarioRepository EnderecoFuncionarioRepository { get; }
        TelefoneRepository TelefoneAlunoRepository { get; }
        TelefoneFuncionarioRepository TelefoneFuncionarioRepository { get; }
        void Commit();
    }
}
