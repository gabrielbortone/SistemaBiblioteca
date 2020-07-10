using Microsoft.AspNetCore.Mvc;
using Sistema_de_Biblioteca.Models;
using Sistema_de_Biblioteca.Models.ValueObjects;
using Sistema_de_Biblioteca.Repositories.Interfaces;
using Sistema_de_Biblioteca.Services;
using Sistema_de_Biblioteca.ViewModels;
using System.Collections.Generic;
using System.Linq;

namespace Sistema_de_Biblioteca.Controllers
{
    public class FuncionarioController : Controller
    {
        private IUnitOfWork _unitOfWork;
        public FuncionarioController(IUnitOfWork unitOfWork)
        {
            _unitOfWork = unitOfWork;
        }
        public IActionResult Cadastrar()
        {
            if (_unitOfWork.LoginService.EstaLogado())
            {
                return View();
            }
            ViewBag.Mensagem = "Precisa estar logado para acessar essa área!";
            return RedirectToAction("Login", "Account");
        }

        [HttpPost]
        [ValidateAntiForgeryToken]
        public IActionResult Cadastrar(FuncionarioViewModel funcionarioVM)
        {
            if (_unitOfWork.LoginService.EstaLogado())
            {
                if (ModelState.IsValid)
                {
                    Funcionario funcionario = new Funcionario(funcionarioVM.Nome, funcionarioVM.Sobrenome, funcionarioVM.CPF, 
                        funcionarioVM.Username, funcionarioVM.Senha,
                        new Endereco(funcionarioVM.CEP, funcionarioVM.Bairro, funcionarioVM.Cidade, funcionarioVM.Estado),
                        new Telefone(funcionarioVM.Tipo, funcionarioVM.DDD, funcionarioVM.Numero), funcionarioVM.Email, funcionarioVM.Cargo, funcionarioVM.DataAdmissao);
                    _unitOfWork.FuncionarioRepository.AddFuncionario(funcionario);
                    ViewBag.Mensagem = "Cadastro feito com sucesso!";
                }
                ViewBag.Mensagem = "Cadastro não efetuado! Verifique as informações e tente novamente";
                return View(funcionarioVM);
            }
            return RedirectToAction("Login", "Account");
        }

        public IActionResult Editar()
        {
            if (_unitOfWork.LoginService.EstaLogado())
            {
                return View();
            }
            return View("../Account/Login");
        }

        [HttpPost]
        [ValidateAntiForgeryToken]
        public IActionResult Editar(FuncionarioViewModel funcionarioVM)
        {
            if (_unitOfWork.LoginService.EstaLogado())
            {
                if (ModelState.IsValid)
                {
                    Funcionario funcionario = new Funcionario(funcionarioVM.Nome, funcionarioVM.Sobrenome, funcionarioVM.CPF,
                        funcionarioVM.Username, funcionarioVM.Senha,
                        new Endereco(funcionarioVM.CEP, funcionarioVM.Bairro, funcionarioVM.Cidade, funcionarioVM.Estado),
                        new Telefone(funcionarioVM.Tipo, funcionarioVM.DDD, funcionarioVM.Numero), funcionarioVM.Email, funcionarioVM.Cargo, funcionarioVM.DataAdmissao);
                    _unitOfWork.FuncionarioRepository.UpdateFuncionario(funcionario);
                    ViewBag.Mensagem = "Edição feito com sucesso!";
                }
                ViewBag.Mensagem = "Edição não efetuada! Verifique as informações e tente novamente";
                return View(funcionarioVM);
            }

            return RedirectToAction("Login", "Account");
        }

        public IActionResult Deletar()
        {
            if (_unitOfWork.LoginService.EstaLogado())
            {
                return View();
            }
            return View("../Account/Login");
        }

        [HttpPost]
        [ValidateAntiForgeryToken]
        public IActionResult Deletar(int id)
        {
            if (_unitOfWork.LoginService.EstaLogado())
            {
                if (ModelState.IsValid)
                {
                    Funcionario funcionario = _unitOfWork.FuncionarioRepository.GetFuncionarioById(id);
                    if (funcionario != null)
                    {
                        _unitOfWork.FuncionarioRepository.RemoveFuncionario(funcionario);
                        ViewBag.Mensagem = "Funcionário Removido feito com sucesso!";
                    }
                }
                ViewBag.Mensagem = "Remoção não efetuada! Verifique as informações e tente novamente";
                return View();
            }

            return RedirectToAction("Login", "Account");
        }

        public IActionResult Listar()
        {
            if (_unitOfWork.LoginService.EstaLogado())
            {
                if (ModelState.IsValid)
                {
                    IEnumerable<Funcionario> ListaFuncionario = _unitOfWork.FuncionarioRepository.GetAllFuncionario();
                    if (!ListaFuncionario.Any())
                    {
                        return View("ErroListaVazia");
                    }
                    return View(ListaFuncionario);
                }
                return View("Error");
            }
            return RedirectToAction("Login", "Account");
        }
    }
}
