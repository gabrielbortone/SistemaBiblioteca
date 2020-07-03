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
        private ILoginService _loginService;
        public EmprestimoController(IEmprestimoRepository emprestimoRepository, ILoginService loginService)
        {
            _emprestimoRepository = emprestimoRepository;
            _loginService = loginService;
        }

        public IActionResult Cadastrar()
        {
            if (_loginService.EstaLogado())
            {
                return View();
            }
            ViewBag.Mensagem = "Precisa estar logado para acessar essa área!";
            RedirectToAction("Login", "Account");
            return null;
        }

        [HttpPost]
        public IActionResult Cadastrar(EmprestimoViewModel emprestimoVM)
        {
            if (ModelState.IsValid)
            {
                if (_loginService.EstaLogado())
                {
                    Emprestimo emprestimo = new Emprestimo((DateTime)emprestimoVM.DataEntrega, emprestimoVM.Livro, emprestimoVM.Aluno,
                        _loginService.ObterFuncionarioLogado());
                    _emprestimoRepository.AddEmprestimo(emprestimo);
                    ViewBag.Mensagem = "Cadastro feito com sucesso!";
                }
                ViewBag.Mensagem = "Precisa estar logado para acessar essa área!";
                RedirectToAction("Login", "Account");
            }
            ViewBag.Mensagem = "Cadastro não efetuado! Verifique as informações e tente novamente";
            return View(emprestimoVM);
        }

        public IActionResult Editar()
        {
            if (_loginService.EstaLogado())
            {
                return View();
            }
            ViewBag.Mensagem = "Precisa estar logado para acessar essa área!";
            RedirectToAction("Login", "Account");
            return null;
        }

        [HttpPost]
        public IActionResult Editar(EmprestimoViewModel emprestimoVM)
        {
            if (ModelState.IsValid)
            {
                if (_loginService.EstaLogado())
                {
                    Emprestimo emprestimo = new Emprestimo((DateTime)emprestimoVM.DataEntrega, emprestimoVM.Livro, emprestimoVM.Aluno,
                        _loginService.ObterFuncionarioLogado());
                    _emprestimoRepository.UpdateEmprestimo(emprestimo);
                    ViewBag.Mensagem = "Edição feito com sucesso!";
                }
                ViewBag.Mensagem = "Precisa estar logado para acessar essa área!";
                RedirectToAction("Login", "Account");
            }
            ViewBag.Mensagem = "Edição não efetuada! Verifique as informações e tente novamente";
            return View(emprestimoVM);
        }

        public IActionResult Deletar()
        {
            if (_loginService.EstaLogado())
            {
                return View();
            }
            ViewBag.Mensagem = "Precisa estar logado para acessar essa área!";
            RedirectToAction("Login", "Account");
            return null;
        }

        [HttpPost]
        public IActionResult Deletar(int id)
        {
            if (ModelState.IsValid)
            {
                if (_loginService.EstaLogado())
                {
                    Emprestimo emprestimo = _emprestimoRepository.GetEmprestimoById(id);
                    if (emprestimo != null)
                    {
                        _emprestimoRepository.RemoveEmprestimo(emprestimo);
                        ViewBag.Mensagem = "Emprestimo Removido feito com sucesso!";
                    }
                }
                ViewBag.Mensagem = "Precisa estar logado para acessar essa área!";
                RedirectToAction("Login", "Account");
            }
            ViewBag.Mensagem = "Remoção não efetuada! Verifique as informações e tente novamente";
            return View();
        }

        public IActionResult Listar()
        {
            if (ModelState.IsValid)
            {
                if (_loginService.EstaLogado())
                {
                    IEnumerable<Emprestimo> ListaEmprestimo = _emprestimoRepository.GetAllEmprestimo();
                    return View(ListaEmprestimo);
                }
                RedirectToAction("Index", "Home");
            }
            return View("Nada a ser exibido!");
        }
    }
}
