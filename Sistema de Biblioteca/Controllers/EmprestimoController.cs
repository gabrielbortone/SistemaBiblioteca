using Microsoft.AspNetCore.Mvc;
using Sistema_de_Biblioteca.Models;
using Sistema_de_Biblioteca.Repositories.Interfaces;
using Sistema_de_Biblioteca.Services;
using Sistema_de_Biblioteca.ViewModels;
using System;
using System.Collections.Generic;

namespace Sistema_de_Biblioteca.Controllers
{
    public class EmprestimoController : Controller
    {
        private IEmprestimoRepository _emprestimoRepository;
        private IAlunoRepository _alunoRepository;
        private ILivroRepository _livroRepository;
        private ILoginService _loginService;
        public EmprestimoController(IEmprestimoRepository emprestimoRepository, IAlunoRepository alunoRepository, ILivroRepository livroRepository,ILoginService loginService)
        {
            _emprestimoRepository = emprestimoRepository;
            _alunoRepository = alunoRepository;
            _livroRepository = livroRepository;
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
        public IActionResult Cadastrar(EmprestimoViewModel emprestimoVM)
        {
            if (_loginService.EstaLogado())
            {
                if (ModelState.IsValid)
                {
                    Livro livro = _livroRepository.GetLivroByTitle(emprestimoVM.TituloLivro);
                    Aluno aluno = _alunoRepository.GetAlunoByName(emprestimoVM.NomeAluno, emprestimoVM.SobrenomeAluno);
                    Emprestimo emprestimo = new Emprestimo((DateTime)emprestimoVM.DataEntrega, livro, aluno,
                        _loginService.ObterFuncionarioLogado());
                    _emprestimoRepository.AddEmprestimo(emprestimo);
                    ViewBag.Mensagem = "Cadastro feito com sucesso!";
                }
                ViewBag.Mensagem = "Cadastro não efetuado! Verifique as informações e tente novamente";
                return View(emprestimoVM);
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
        public IActionResult Editar(EmprestimoViewModel emprestimoVM)
        {
            if (_loginService.EstaLogado())
            {
                if (ModelState.IsValid)
                {
                    Livro livro = _livroRepository.GetLivroByTitle(emprestimoVM.TituloLivro);
                    Aluno aluno = _alunoRepository.GetAlunoByName(emprestimoVM.NomeAluno, emprestimoVM.SobrenomeAluno);
                    Emprestimo emprestimo = new Emprestimo((DateTime)emprestimoVM.DataEntrega, livro, aluno,
                        _loginService.ObterFuncionarioLogado());
                    _emprestimoRepository.UpdateEmprestimo(emprestimo);
                    ViewBag.Mensagem = "Edição feito com sucesso!";
                }
                ViewBag.Mensagem = "Edição não efetuada! Verifique as informações e tente novamente";
                return View(emprestimoVM);
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
        public IActionResult Deletar(Emprestimo emprestimo)
        {
            if (_loginService.EstaLogado())
            {
                if (ModelState.IsValid)
                {
                    if (emprestimo != null)
                    {
                        _emprestimoRepository.RemoveEmprestimo(emprestimo);
                        ViewBag.Mensagem = "Emprestimo Removido feito com sucesso!";
                    }
                }
                ViewBag.Mensagem = "Remoção não efetuada! Verifique as informações e tente novamente";
                return View(emprestimo);
            }
            return View("../Account/Login");
            
        }

        public IActionResult Listar()
        {
            if (_loginService.EstaLogado())
            {
                if (ModelState.IsValid)
                {
                    IEnumerable<Emprestimo> ListaEmprestimo = _emprestimoRepository.GetAllEmprestimo();
                    return View(ListaEmprestimo);
                }
                return View("Error");
            }
            return View("../Account/Login");
        }

        private List<EmprestimoViewModel> ConverterEmViewModel(IEnumerable<Emprestimo> emprestimos)
        {
            List <EmprestimoViewModel> ListaEmprestimosViewModel = new List<EmprestimoViewModel>();
            foreach (Emprestimo emprestimo in emprestimos)
            {
                EmprestimoViewModel emprestimoViewModel = new EmprestimoViewModel 
                { 
                    Id = emprestimo.EmprestimoId,

                
                };

                ListaEmprestimosViewModel.Add(emprestimoViewModel);
            }
            return ListaEmprestimosViewModel;
        }
    }
}
