using Microsoft.AspNetCore.Mvc;
using Sistema_de_Biblioteca.Models;
using Sistema_de_Biblioteca.Repositories.Interfaces;
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
            return View();
        }

        [HttpPost]
        [ValidateAntiForgeryToken]
        public IActionResult Cadastrar(EmprestimoViewModel emprestimoVM)
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

        public IActionResult Editar()
        {
            return View();
        }

        [HttpPost]
        [ValidateAntiForgeryToken]
        public IActionResult Editar(EmprestimoViewModel emprestimoVM)
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

        public IActionResult Deletar()
        {
            return View();
        }

        [HttpPost]
        [ValidateAntiForgeryToken]
        public IActionResult Deletar(int id)
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

        public IActionResult Listar()
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
          
    }
}
