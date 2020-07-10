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
        private IUnitOfWork _unitOfWork;
        public EmprestimoController(IUnitOfWork unitOfWork)
        {
            _unitOfWork = unitOfWork;
        }

        public IActionResult Cadastrar()
        {
            if (_unitOfWork.LoginService.EstaLogado())
            {
                return View();
            }
            return RedirectToAction("Login", "Account");
        }

        [HttpPost]
        [ValidateAntiForgeryToken]
        public IActionResult Cadastrar(EmprestimoViewModel emprestimoVM)
        {
            if (_unitOfWork.LoginService.EstaLogado())
            {
                if (ModelState.IsValid)
                {
                    Emprestimo emprestimo = new Emprestimo((DateTime)emprestimoVM.DataEntrega, emprestimoVM.Livro, emprestimoVM.Aluno,
                        _unitOfWork.LoginService.ObterFuncionarioLogado());
                    _unitOfWork.EmprestimoRepository.AddEmprestimo(emprestimo);
                    ViewBag.Mensagem = "Cadastro feito com sucesso!";
                }
                ViewBag.Mensagem = "Cadastro não efetuado! Verifique as informações e tente novamente";
                return View(emprestimoVM);
            }
            return RedirectToAction("Login", "Account");

        }

        public IActionResult Editar()
        {
            if (_unitOfWork.LoginService.EstaLogado())
            {
                return View();
            }
            return RedirectToAction("Login", "Account");
        }

        [HttpPost]
        [ValidateAntiForgeryToken]
        public IActionResult Editar(EmprestimoViewModel emprestimoVM)
        {
            if (_unitOfWork.LoginService.EstaLogado())
            {
                if (ModelState.IsValid)
                {
                    Emprestimo emprestimo = new Emprestimo((DateTime)emprestimoVM.DataEntrega, emprestimoVM.Livro, emprestimoVM.Aluno,
                        _unitOfWork.LoginService.ObterFuncionarioLogado());
                    _unitOfWork.EmprestimoRepository.UpdateEmprestimo(emprestimo);
                    ViewBag.Mensagem = "Edição feito com sucesso!";
                }
                ViewBag.Mensagem = "Edição não efetuada! Verifique as informações e tente novamente";
                return View(emprestimoVM);
            }
            return RedirectToAction("Login", "Account");

        }

        public IActionResult Deletar()
        {
            if (_unitOfWork.LoginService.EstaLogado())
            {
                return View();
            }
            return RedirectToAction("Login", "Account");
        }

        [HttpPost]
        [ValidateAntiForgeryToken]
        public IActionResult Deletar(int id)
        {
            if (_unitOfWork.LoginService.EstaLogado())
            {
                if (ModelState.IsValid)
                {
                    Emprestimo emprestimo = _unitOfWork.EmprestimoRepository.GetEmprestimoById(id);
                    if (emprestimo != null)
                    {
                        _unitOfWork.EmprestimoRepository.RemoveEmprestimo(emprestimo);
                        ViewBag.Mensagem = "Emprestimo Removido feito com sucesso!";
                    }
                }
                ViewBag.Mensagem = "Remoção não efetuada! Verifique as informações e tente novamente";
                return View(id);
            }
            return RedirectToAction("Login", "Account");

        }

        public IActionResult Listar()
        {
            if (_unitOfWork.LoginService.EstaLogado())
            {
                if (ModelState.IsValid)
                {
                    IEnumerable<Emprestimo> ListaEmprestimo = _unitOfWork.EmprestimoRepository.GetAllEmprestimo();
                    if (!ListaEmprestimo.Any())
                    {
                        return View("ErroListaVazia");
                    }
                    return View(ListaEmprestimo);
                }
                return View("Error");
            }
            return RedirectToAction("Login", "Account");
        }
    }
}
