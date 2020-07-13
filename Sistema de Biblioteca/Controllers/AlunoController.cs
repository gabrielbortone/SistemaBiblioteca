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
            return View();
        }

        [HttpPost]
        [ValidateAntiForgeryToken]
        public IActionResult Cadastrar(AlunoViewModel alunoVM)
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

        public IActionResult Editar()
        {
            return View();
        }

        [HttpPost]
        [ValidateAntiForgeryToken]
        public IActionResult Editar(AlunoViewModel alunoVM)
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
                Aluno aluno = _unitOfWork.AlunoRepository.GetAlunoById(id);
                if (aluno != null)
                {
                    _unitOfWork.AlunoRepository.RemoveAluno(aluno);
                    ViewBag.Mensagem = "Aluno Removido feito com sucesso!";
                }        
                return View(aluno);
            }
            return View("Error");
        }

        public IActionResult Listar()
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


    }
}
