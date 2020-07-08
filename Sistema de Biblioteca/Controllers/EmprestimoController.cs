using Microsoft.AspNetCore.Mvc;
using Sistema_de_Biblioteca.Models;
using Sistema_de_Biblioteca.Repositories.Interfaces;
using Sistema_de_Biblioteca.Services;
using Sistema_de_Biblioteca.ViewModels;
using System;
using System.Collections.Generic;
using System.Linq;

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
                    Emprestimo emprestimo = new Emprestimo((DateTime)emprestimoVM.DataEntrega, emprestimoVM.Livro, emprestimoVM.Aluno,
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
                    Emprestimo emprestimo = new Emprestimo((DateTime)emprestimoVM.DataEntrega, emprestimoVM.Livro, emprestimoVM.Aluno,
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
        public IActionResult Deletar(int id)
        {
            if (_loginService.EstaLogado())
            {
                if (ModelState.IsValid)
                {
                    Emprestimo emprestimo = _emprestimoRepository.GetEmprestimoById(id);
                    if (emprestimo != null)
                    {
                        _emprestimoRepository.RemoveEmprestimo(emprestimo);
                        ViewBag.Mensagem = "Emprestimo Removido feito com sucesso!";
                    }
                }
                ViewBag.Mensagem = "Remoção não efetuada! Verifique as informações e tente novamente";
                return View(id);
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
                    if (!ListaEmprestimo.Any())
                    {
                        return View("ErroListaVazia");
                    }
                    return View(ListaEmprestimo);
                }
                return View("Error");
            }
            return View("../Account/Login");
        }
    }
}
