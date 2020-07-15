using Microsoft.AspNetCore.Authorization;
using Microsoft.AspNetCore.Identity;
using Microsoft.AspNetCore.Mvc;
using Sistema_de_Biblioteca.Models;
using Sistema_de_Biblioteca.Repositories.Interfaces;
using Sistema_de_Biblioteca.ViewModels;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;

namespace Sistema_de_Biblioteca.Controllers
{
    //[Authorize]
    public class EmprestimoController : Controller
    {
        private IUnitOfWork _unitOfWork;
        private UserManager<Account> _userManager;
        public EmprestimoController(IUnitOfWork unitOfWork, UserManager<Account> userManager)
        {
            _unitOfWork = unitOfWork;
            _userManager = userManager;
        }

        public IActionResult Cadastrar()
        {
            return View();
        }

        [HttpPost]
        [ValidateAntiForgeryToken]
        public async Task<IActionResult> CadastrarAsync(EmprestimoViewModel emprestimoVM)
        {
            if (ModelState.IsValid)
            {
                Funcionario funcionario = _unitOfWork.FuncionarioRepository.GetFuncionarioByAccount(await _userManager.GetUserAsync(User));
                Emprestimo emprestimo = new Emprestimo((DateTime)emprestimoVM.DataEntrega, emprestimoVM.Livro, emprestimoVM.Aluno,
                    funcionario);
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
        public async Task<IActionResult> Editar(EmprestimoViewModel emprestimoVM)
        {
            if (ModelState.IsValid)
            {
                Funcionario funcionario = _unitOfWork.FuncionarioRepository.GetFuncionarioByAccount(await _userManager.GetUserAsync(User));
                Emprestimo emprestimo = new Emprestimo((DateTime)emprestimoVM.DataEntrega, emprestimoVM.Livro, emprestimoVM.Aluno,
                    funcionario);
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
                    ViewData["Url"] = "/Emprestimo";
                    return View("ErroListaVazia", ViewData["Url"]);
                }
                return View(ListaEmprestimo);
            }
                return View("Error");
         }
          
    }
}
