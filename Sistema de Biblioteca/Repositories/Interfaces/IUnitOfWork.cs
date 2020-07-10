using Microsoft.Extensions.Logging;
using Sistema_de_Biblioteca.Services;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;

namespace Sistema_de_Biblioteca.Repositories.Interfaces
{
    public interface IUnitOfWork
    {
        FuncionarioRepository FuncionarioRepository { get; }
        AlunoRepository AlunoRepository { get; }
        LivroRepository LivroRepository { get; }
        EmprestimoRepository EmprestimoRepository { get; }
        LoginService LoginService { get; }
        void Commit();
    }
}
