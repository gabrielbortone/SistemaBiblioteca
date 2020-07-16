using Sistema_de_Biblioteca.Models.ValueObjects;

namespace Sistema_de_Biblioteca.Repositories.Interfaces
{
    public interface IUnitOfWork
    {
        FuncionarioRepository FuncionarioRepository { get; }
        AlunoRepository AlunoRepository { get; }
        LivroRepository LivroRepository { get; }
        EmprestimoRepository EmprestimoRepository { get; }
        EnderecoRepository EnderecoRepository { get;}
        TelefoneRepository TelefoneRepository { get; }
        Endereco GetEnderecoByAluno(int idAluno);
        Endereco GetEnderecoByFuncionario(int idFuncionario);
        void RemoveEnderecoByAluno(int idAluno);
        void RemoveEnderecoByFuncionario(int idFuncionario);
        Telefone GetTelefoneByAluno(int idAluno);
        Telefone GetTelefoneByFuncionario(int idFuncionario);
        void RemoveTelefoneByAluno(int idAluno);
        void RemoveTelefoneByFuncionario(int idFuncionario);
        void Commit();
    }
}
