using Microsoft.AspNetCore.Mvc;
using Sistema_de_Biblioteca.Models;
using Sistema_de_Biblioteca.Models.ValueObjects;
using Sistema_de_Biblioteca.Repositories.Interfaces;
using Sistema_de_Biblioteca.Services;
using Sistema_de_Biblioteca.ViewModels;
using System.Collections.Generic;

namespace Sistema_de_Biblioteca.Controllers
{
    public class FuncionarioController : Controller
    {
        private IFuncionarioRepository _funcionarioRepository;
        private ILoginService _loginService;
        public FuncionarioController(IFuncionarioRepository funcionarioRepository, ILoginService loginService)
        {
            _funcionarioRepository = funcionarioRepository;
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
        public IActionResult Cadastrar(FuncionarioViewModel funcionarioVM)
        {
            if (ModelState.IsValid)
            {
                if (_loginService.EstaLogado())
                {
                    Funcionario funcionario = new Funcionario(funcionarioVM.Nome, funcionarioVM.Sobrenome, funcionarioVM.CPF, 
                        funcionarioVM.Username, funcionarioVM.Senha,
                        new Endereco(funcionarioVM.CEP, funcionarioVM.Bairro, funcionarioVM.Cidade, funcionarioVM.Estado),
                        new Telefone(funcionarioVM.Tipo, funcionarioVM.DDD, funcionarioVM.Numero), funcionarioVM.Email, funcionarioVM.Cargo, funcionarioVM.DataAdmissao);
                    _funcionarioRepository.AddFuncionario(funcionario);
                    ViewBag.Mensagem = "Cadastro feito com sucesso!";
                }
                ViewBag.Mensagem = "Precisa estar logado para acessar essa área!";
                RedirectToAction("Login", "Account");
            }
            ViewBag.Mensagem = "Cadastro não efetuado! Verifique as informações e tente novamente";
            return View(funcionarioVM);
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
        public IActionResult Editar(FuncionarioViewModel funcionarioVM)
        {
            if (ModelState.IsValid)
            {
                if (_loginService.EstaLogado())
                {
                    Funcionario funcionario = new Funcionario(funcionarioVM.Nome, funcionarioVM.Sobrenome, funcionarioVM.CPF,
                        funcionarioVM.Username, funcionarioVM.Senha,
                        new Endereco(funcionarioVM.CEP, funcionarioVM.Bairro, funcionarioVM.Cidade, funcionarioVM.Estado),
                        new Telefone(funcionarioVM.Tipo, funcionarioVM.DDD, funcionarioVM.Numero), funcionarioVM.Email, funcionarioVM.Cargo, funcionarioVM.DataAdmissao);
                    _funcionarioRepository.UpdateFuncionario(funcionario);
                    ViewBag.Mensagem = "Edição feito com sucesso!";
                }
                ViewBag.Mensagem = "Precisa estar logado para acessar essa área!";
                RedirectToAction("Login", "Account");
            }
            ViewBag.Mensagem = "Edição não efetuada! Verifique as informações e tente novamente";
            return View(funcionarioVM);
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
                    Funcionario funcionario = _funcionarioRepository.GetFuncionarioById(id);
                    if (funcionario != null)
                    {
                        _funcionarioRepository.RemoveFuncionario(funcionario);
                        ViewBag.Mensagem = "Funcionário Removido feito com sucesso!";
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
                    IEnumerable<Funcionario> ListaFuncionario = _funcionarioRepository.GetAllFuncionario();
                    return View(ListaFuncionario);
                }
                ViewBag.Mensagem = "Precisa estar logado para acessar essa área!";
                RedirectToAction("Login", "Account");
            }
            return View("Nada a ser exibido!");
        }
    }
}
