using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;
using Microsoft.AspNetCore.Mvc;
using Sistema_de_Biblioteca.Models;
using Sistema_de_Biblioteca.Models.ValueObjects;
using Sistema_de_Biblioteca.Repositories;
using Sistema_de_Biblioteca.Repositories.Interfaces;
using Sistema_de_Biblioteca.Services;
using Sistema_de_Biblioteca.ViewModels;

namespace Sistema_de_Biblioteca.Controllers
{
    public class AlunoController : Controller
    {
        private IAlunoRepository _alunoRepository;
        private ILoginService _loginService;
        public AlunoController(IAlunoRepository alunoRepository, ILoginService loginService)
        {
            _alunoRepository = alunoRepository;
            _loginService = loginService;
        }
        public IActionResult Cadastrar()
        {
            if (_loginService.EstaLogado())
            {
                return View();
            }
            return View("../Account/Login");
        }

        [HttpPost]
        [ValidateAntiForgeryToken]
        public IActionResult Cadastrar(AlunoViewModel alunoVM)
        {
            if (_loginService.EstaLogado())
            {
                if (ModelState.IsValid)
                {
                    Aluno aluno = new Aluno(alunoVM.Nome, alunoVM.Sobrenome, alunoVM.CPF, 
                        new Endereco(alunoVM.CEP,alunoVM.Bairro,alunoVM.Cidade,alunoVM.Estado),
                        new Telefone(alunoVM.Tipo,alunoVM.DDD,alunoVM.Numero), alunoVM.Email, alunoVM.Matricula);
                    _alunoRepository.AddAluno(aluno);
                    ViewBag.Mensagem = "Cadastro feito com sucesso!";
                }
                ViewBag.Mensagem = "Cadastro não efetuado! Verifique as informações e tente novamente";
                return View(alunoVM);
            }
            return View("../Account/Login");
            
        }

        public IActionResult Editar()
        {
            if (_loginService.EstaLogado())
            {
                return View();
            }
            return View("../Account/Login");
        }

        [HttpPost]
        [ValidateAntiForgeryToken]
        public IActionResult Editar(AlunoViewModel alunoVM)
        {
            if (_loginService.EstaLogado())
            {
                if (ModelState.IsValid)
                {
                    Aluno aluno = new Aluno(alunoVM.Nome, alunoVM.Sobrenome, alunoVM.CPF,
                        new Endereco(alunoVM.CEP, alunoVM.Bairro, alunoVM.Cidade, alunoVM.Estado),
                        new Telefone(alunoVM.Tipo, alunoVM.DDD, alunoVM.Numero), alunoVM.Email, alunoVM.Matricula);
                    _alunoRepository.UpdateAluno(aluno);
                    ViewBag.Mensagem = "Edição feito com sucesso!";
                    return View("Listar");
                }
                ViewBag.Mensagem = "Edição não efetuada! Verifique as informações e tente novamente";
                return View(alunoVM);
            }
           
            return View("../Account/Login");
        }

        public IActionResult Deletar()
        {
            if (_loginService.EstaLogado())
            {
                return View();
            }

            return View("../Account/Login");
        }

        [HttpPost]
        [ValidateAntiForgeryToken]
        public IActionResult Deletar(Aluno aluno)
        {
            if (_loginService.EstaLogado())
            {
                if (ModelState.IsValid)
                {
                    if (aluno != null)
                    {
                        _alunoRepository.RemoveAluno(aluno);
                        ViewBag.Mensagem = "Aluno Removido feito com sucesso!";
                    }        
                }
                return View("Error");
            }
            return View("../Account/Login");
        }

        public IActionResult Listar()
        {
            if (_loginService.EstaLogado())
            {
                if (ModelState.IsValid)
                {
                    IEnumerable<Aluno> ListaAlunos = _alunoRepository.GetAllAluno();
                    List<AlunoViewModel> ListaAlunosViewModel = ConverterEmViewModel(ListaAlunos);
                    return View(ListaAlunosViewModel);
                }
                return View("Error");
            }
            return View("../Account/Login");
        }

        private List<AlunoViewModel> ConverterEmViewModel(IEnumerable<Aluno> alunos)
        {
            List<AlunoViewModel> ListaAlunosViewModel = new List<AlunoViewModel>();
            foreach (Aluno aluno in alunos)
            {
                AlunoViewModel livroViewModel = new AlunoViewModel()
                {
                    Id = aluno.AlunoId,
                    Nome = aluno.Nome,
                    Sobrenome = aluno.Sobrenome,
                    CPF = aluno.CPF,
                    CEP = aluno.Endereco.CEP,
                    Bairro = aluno.Endereco.Bairro,
                    Cidade = aluno.Endereco.Cidade,
                    Estado = aluno.Endereco.Estado,
                    Tipo = aluno.Telefone.Tipo,
                    DDD = aluno.Telefone.DDD,
                    Numero = aluno.Telefone.Numero,
                    Email = aluno.Email,
                    Matricula = aluno.Matricula
                };
                ListaAlunosViewModel.Add(livroViewModel);
            }
            return ListaAlunosViewModel;
        }


    }
}
