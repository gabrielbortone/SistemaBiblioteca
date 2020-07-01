using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;
using Microsoft.AspNetCore.Mvc;
using Sistema_de_Biblioteca.Models;
using Sistema_de_Biblioteca.Models.ValueObjects;
using Sistema_de_Biblioteca.Repositories;
using Sistema_de_Biblioteca.Services;
using Sistema_de_Biblioteca.ViewModels;

namespace Sistema_de_Biblioteca.Controllers
{
    public class FuncionarioController : Controller
    {
        private FuncionarioRepository _funcionarioRepository;
        private LoginService _loginService;
        public FuncionarioController(FuncionarioRepository funcionarioRepository, LoginService loginService)
        {
            _funcionarioRepository = funcionarioRepository;
            _loginService = loginService;
        }
        public IActionResult Cadastrar()
        {
            return View();
        }

        [HttpPost]
        public IActionResult Cadastrar(FuncionarioViewModel funcionarioVM)
        {
            if (ModelState.IsValid)
            {
                if (_loginService.IsLogged)
                {
                    Funcionario funcionario = new Funcionario(funcionarioVM.Nome, funcionarioVM.Sobrenome, funcionarioVM.CPF, 
                        funcionarioVM.Username, funcionarioVM.Senha,
                        new Endereco(funcionarioVM.CEP, funcionarioVM.Bairro, funcionarioVM.Cidade, funcionarioVM.Estado),
                        new Telefone(funcionarioVM.Tipo, funcionarioVM.DDD, funcionarioVM.Numero), funcionarioVM.Email, funcionarioVM.Cargo, funcionarioVM.DataAdmissao);
                    _funcionarioRepository.AddFuncionario(funcionario);
                    ViewBag.Mensagem = "Cadastro feito com sucesso!";
                }
                RedirectToAction("Index", "Home");
            }
            ViewBag.Mensagem = "Cadastro não efetuado! Verifique as informações e tente novamente";
            return View(funcionarioVM);
        }

        public IActionResult Editar()
        {
            return View();
        }

        [HttpPost]
        public IActionResult Editar(FuncionarioViewModel funcionarioVM)
        {
            if (ModelState.IsValid)
            {
                if (_loginService.IsLogged)
                {
                    Funcionario funcionario = new Funcionario(funcionarioVM.Nome, funcionarioVM.Sobrenome, funcionarioVM.CPF,
                        funcionarioVM.Username, funcionarioVM.Senha,
                        new Endereco(funcionarioVM.CEP, funcionarioVM.Bairro, funcionarioVM.Cidade, funcionarioVM.Estado),
                        new Telefone(funcionarioVM.Tipo, funcionarioVM.DDD, funcionarioVM.Numero), funcionarioVM.Email, funcionarioVM.Cargo, funcionarioVM.DataAdmissao);
                    _funcionarioRepository.UpdateFuncionario(funcionario);
                    ViewBag.Mensagem = "Edição feito com sucesso!";
                }
                RedirectToAction("Index", "Home");
            }
            ViewBag.Mensagem = "Edição não efetuada! Verifique as informações e tente novamente";
            return View(funcionarioVM);
        }

        public IActionResult Deletar()
        {
            return View();
        }

        [HttpPost]
        public IActionResult Deletar(int id)
        {
            if (ModelState.IsValid)
            {
                if (_loginService.IsLogged)
                {
                    Funcionario funcionario = _funcionarioRepository.GetFuncionarioById(id);
                    if (funcionario != null)
                    {
                        _funcionarioRepository.RemoveFuncionario(funcionario);
                        ViewBag.Mensagem = "Funcionário Removido feito com sucesso!";
                    }
                }
                RedirectToAction("Index", "Home");
            }
            ViewBag.Mensagem = "Remoção não efetuada! Verifique as informações e tente novamente";
            return View();
        }

        public IActionResult Listar()
        {
            if (ModelState.IsValid)
            {
                if (_loginService.IsLogged)
                {
                    IEnumerable<Funcionario> ListaFuncionario = _funcionarioRepository.GetAllFuncionario();
                    return View(ListaFuncionario);
                }
                RedirectToAction("Index", "Home");
            }
            return View("Nada a ser exibido!");
        }
    }
}
