using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;
using Microsoft.AspNetCore.Http;
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
        private IUnitOfWork _unitOfWork;
        public AlunoController(IUnitOfWork unitOfWork)
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
        public IActionResult Cadastrar(AlunoViewModel alunoVM)
        {
            if (_unitOfWork.LoginService.EstaLogado())
            {
                if (ModelState.IsValid)
                {
                    Aluno aluno = new Aluno(alunoVM.Nome, alunoVM.Sobrenome, alunoVM.CPF, 
                        new Endereco(alunoVM.CEP,alunoVM.Bairro,alunoVM.Cidade,alunoVM.Estado),
                        new Telefone(alunoVM.Tipo,alunoVM.DDD,alunoVM.Numero), alunoVM.Email, alunoVM.Matricula);
                    _unitOfWork.AlunoRepository.AddAluno(aluno);
                    ViewBag.Mensagem = "Cadastro feito com sucesso!";
                }
                ViewBag.Mensagem = "Cadastro não efetuado! Verifique as informações e tente novamente";
                return View(alunoVM);
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
        public IActionResult Editar(AlunoViewModel alunoVM)
        {
            if (_unitOfWork.LoginService.EstaLogado())
            {
                if (ModelState.IsValid)
                {
                    Aluno aluno = new Aluno(alunoVM.Nome, alunoVM.Sobrenome, alunoVM.CPF,
                        new Endereco(alunoVM.CEP, alunoVM.Bairro, alunoVM.Cidade, alunoVM.Estado),
                        new Telefone(alunoVM.Tipo, alunoVM.DDD, alunoVM.Numero), alunoVM.Email, alunoVM.Matricula);
                    _unitOfWork.AlunoRepository.UpdateAluno(aluno);
                    ViewBag.Mensagem = "Edição feito com sucesso!";
                    return View("Listar");
                }
                ViewBag.Mensagem = "Edição não efetuada! Verifique as informações e tente novamente";
                return View(alunoVM);
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
                    Aluno aluno = _unitOfWork.AlunoRepository.GetAlunoById(id);
                    if (aluno != null)
                    {
                        _unitOfWork.AlunoRepository.RemoveAluno(aluno);
                        ViewBag.Mensagem = "Aluno Removido feito com sucesso!";
                    }        
                }
                return View("Error");
            }
            return RedirectToAction("Login", "Account");
        }

        public IActionResult Listar()
        {
            if (_unitOfWork.LoginService.EstaLogado())
            {
                if (ModelState.IsValid)
                {
                    IEnumerable<Aluno> ListaAlunos = _unitOfWork.AlunoRepository.GetAllAluno();
                    if (!ListaAlunos.Any())
                    {
                        return View("ErroListaVazia");
                    }
                    return View(ListaAlunos);
                }
                return View("Error");
            }
            return RedirectToAction("Login", "Account");
        }


    }
}
