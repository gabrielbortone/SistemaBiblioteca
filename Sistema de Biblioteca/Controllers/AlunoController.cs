using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;
using Microsoft.AspNetCore.Mvc;
using Sistema_de_Biblioteca.Models;
using Sistema_de_Biblioteca.Models.ValueObjects;
using Sistema_de_Biblioteca.Repositories;
using Sistema_de_Biblioteca.Repositories.Interfaces;
using Sistema_de_Biblioteca.Services;
using Sistema_de_Biblioteca.ViewModels;

namespace Sistema_de_Biblioteca.Controllers
{
    public class AlunoController : Controller
    {
        private IAlunoRepository _alunoRepository;
        private ILoginService _loginService;
        public AlunoController(IAlunoRepository alunoRepository, ILoginService loginService)
        {
            _alunoRepository = alunoRepository;
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
        public IActionResult Cadastrar(AlunoViewModel alunoVM)
        {
            if (ModelState.IsValid)
            {
                if (_loginService.EstaLogado())
                {
                    Aluno aluno = new Aluno(alunoVM.Nome, alunoVM.Sobrenome, alunoVM.CPF, 
                        new Endereco(alunoVM.CEP,alunoVM.Bairro,alunoVM.Cidade,alunoVM.Estado),
                        new Telefone(alunoVM.Tipo,alunoVM.DDD,alunoVM.Numero), alunoVM.Email, alunoVM.Matricula);
                    _alunoRepository.AddAluno(aluno);
                    ViewBag.Mensagem = "Cadastro feito com sucesso!";
                }
                RedirectToAction("Index", "Home");
            }
            ViewBag.Mensagem = "Cadastro não efetuado! Verifique as informações e tente novamente";
            return View(alunoVM);
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
        public IActionResult Editar(AlunoViewModel alunoVM)
        {
            if (ModelState.IsValid)
            {
                if (_loginService.EstaLogado())
                {
                    Aluno aluno = new Aluno(alunoVM.Nome, alunoVM.Sobrenome, alunoVM.CPF,
                        new Endereco(alunoVM.CEP, alunoVM.Bairro, alunoVM.Cidade, alunoVM.Estado),
                        new Telefone(alunoVM.Tipo, alunoVM.DDD, alunoVM.Numero), alunoVM.Email, alunoVM.Matricula);
                    _alunoRepository.UpdateAluno(aluno);
                    ViewBag.Mensagem = "Edição feito com sucesso!";
                }
                RedirectToAction("Index", "Home");
            }
            ViewBag.Mensagem = "Edição não efetuada! Verifique as informações e tente novamente";
            return View(alunoVM);
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
                    Aluno aluno = _alunoRepository.GetAlunoById(id);
                    if (aluno != null)
                    {
                        _alunoRepository.RemoveAluno(aluno);
                        ViewBag.Mensagem = "Aluno Removido feito com sucesso!";
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
                if (_loginService.EstaLogado())
                {
                    IEnumerable<Aluno> ListaAlunos = _alunoRepository.GetAllAluno();
                    return View(ListaAlunos);
                }
                RedirectToAction("Index", "Home");
            }
            return View("Nada a ser exibido!");
        }


    }
}
