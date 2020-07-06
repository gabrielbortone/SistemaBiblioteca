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
        [ValidateAntiForgeryToken]
        public IActionResult Cadastrar(FuncionarioViewModel funcionarioVM)
        {
            if (_loginService.EstaLogado())
            {
                if (ModelState.IsValid)
                {
                    Funcionario funcionario = new Funcionario(funcionarioVM.Nome, funcionarioVM.Sobrenome, funcionarioVM.CPF, 
                        funcionarioVM.Username, funcionarioVM.Senha,
                        new Endereco(funcionarioVM.CEP, funcionarioVM.Bairro, funcionarioVM.Cidade, funcionarioVM.Estado),
                        new Telefone(funcionarioVM.Tipo, funcionarioVM.DDD, funcionarioVM.Numero), funcionarioVM.Email, funcionarioVM.Cargo, funcionarioVM.DataAdmissao);
                    _funcionarioRepository.AddFuncionario(funcionario);
                    ViewBag.Mensagem = "Cadastro feito com sucesso!";
                }
                ViewBag.Mensagem = "Cadastro não efetuado! Verifique as informações e tente novamente";
                return View(funcionarioVM);
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
        public IActionResult Editar(FuncionarioViewModel funcionarioVM)
        {
            if (_loginService.EstaLogado())
            {
                if (ModelState.IsValid)
                {
                    Funcionario funcionario = new Funcionario(funcionarioVM.Nome, funcionarioVM.Sobrenome, funcionarioVM.CPF,
                        funcionarioVM.Username, funcionarioVM.Senha,
                        new Endereco(funcionarioVM.CEP, funcionarioVM.Bairro, funcionarioVM.Cidade, funcionarioVM.Estado),
                        new Telefone(funcionarioVM.Tipo, funcionarioVM.DDD, funcionarioVM.Numero), funcionarioVM.Email, funcionarioVM.Cargo, funcionarioVM.DataAdmissao);
                    _funcionarioRepository.UpdateFuncionario(funcionario);
                    ViewBag.Mensagem = "Edição feito com sucesso!";
                }
                ViewBag.Mensagem = "Edição não efetuada! Verifique as informações e tente novamente";
                return View(funcionarioVM);
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
        public IActionResult Deletar(Funcionario funcionario)
        {
            if (_loginService.EstaLogado())
            {
                if (ModelState.IsValid)
                {
                    if (funcionario != null)
                    {
                        _funcionarioRepository.RemoveFuncionario(funcionario);
                        ViewBag.Mensagem = "Funcionário Removido feito com sucesso!";
                    }
                }
                ViewBag.Mensagem = "Remoção não efetuada! Verifique as informações e tente novamente";
                return View();
            }
            
            return View("../Account/Login");
        }

        public IActionResult Listar()
        {
            if (_loginService.EstaLogado())
            {
                if (ModelState.IsValid)
                {
                    IEnumerable<Funcionario> ListaFuncionario = _funcionarioRepository.GetAllFuncionario();
                    List<FuncionarioViewModel> ListaFuncionariosViewModel = ConverterEmViewModel(ListaFuncionario);
                    return View(ListaFuncionariosViewModel);
                }
                return View("Error");
            }
            return View("../Account/Login");
        }

        private List<FuncionarioViewModel> ConverterEmViewModel(IEnumerable<Funcionario> funcionarios)
        {
            List<FuncionarioViewModel> ListaFuncionariosViewModel = new List<FuncionarioViewModel>();
            foreach (Funcionario funcionario in funcionarios)
            {
                FuncionarioViewModel funcionarioViewModel = new FuncionarioViewModel()
                {
                    Id = funcionario.FuncionarioId,
                    Nome = funcionario.Nome,
                    Sobrenome = funcionario.Sobrenome,
                    CPF = funcionario.CPF,
                    Username = funcionario.Username,
                    Senha = funcionario.Senha,
                    CEP = funcionario.Endereco.CEP,
                    Bairro = funcionario.Endereco.Bairro,
                    Cidade = funcionario.Endereco.Cidade,
                    Estado = funcionario.Endereco.Estado,
                    Tipo = funcionario.Telefone.Tipo,
                    DDD = funcionario.Telefone.DDD,
                    Numero = funcionario.Telefone.Numero,
                    Email = funcionario.Email,
                    Cargo = funcionario.Cargo,
                    DataAdmissao = funcionario.DataAdmissao
                };
                ListaFuncionariosViewModel.Add(funcionarioViewModel);
            }
            return ListaFuncionariosViewModel;
        }


    }
}
