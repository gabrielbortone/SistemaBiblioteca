﻿using Microsoft.AspNetCore.Authorization;
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
    [Authorize]
    public class EmprestimoController : Controller
    {
        private IUnitOfWork _unitOfWork;
        private UserManager<Funcionario> _userManager;
        public EmprestimoController(IUnitOfWork unitOfWork, UserManager<Funcionario> userManager)
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
        public async Task<IActionResult> Cadastrar(EmprestimoViewModel emprestimoVM)
        {
            Funcionario funcionario;
            Aluno aluno;
            Livro livro;

            if (ModelState.IsValid)
            {
                try
                {
                    funcionario = await _userManager.GetUserAsync(User);
                    aluno = _unitOfWork.AlunoRepository.GetAlunoById(emprestimoVM.AlunoId);
                    livro = _unitOfWork.LivroRepository.GetLivroById(emprestimoVM.LivroId);
                    Emprestimo emprestimo = new Emprestimo((DateTime)emprestimoVM.DataEntrega, livro, aluno, funcionario);
                    _unitOfWork.EmprestimoRepository.AddEmprestimo(emprestimo);
                    _unitOfWork.Commit();
                    ViewBag.Mensagem = "Cadastro feito com sucesso!";
                }
                catch(Exception ex)
                {
                    throw new Exception("Referência Invalida" + ex.Message);
                }
            }
            ViewBag.Mensagem = "Cadastro não efetuado! Verifique as informações e tente novamente";
            return View(emprestimoVM);
        }

        public IActionResult Editar(int? id)
        {
            if (id == null)
            {
                return NotFound();
            }

            var emprestimo = _unitOfWork.EmprestimoRepository.GetEmprestimoById(id);
            EmprestimoViewModel emprestimoVM = new EmprestimoViewModel()
            {
                Id = emprestimo.EmprestimoId,
                DataEntrega = emprestimo.DataEntrega,
                DataLimiteEntrega = emprestimo.DataLimiteEntrega,
                AlunoId = emprestimo.AlunoId,
                LivroId = emprestimo.LivroId
            };

            if (emprestimo == null)
            {
                return NotFound();
            }

            return View(emprestimoVM);
        }

        [HttpPost("Editar/{emprestimoVM}")]
        [ValidateAntiForgeryToken]
        public async Task<IActionResult> Editar(EmprestimoViewModel emprestimoVM)
        {
            if (ModelState.IsValid)
            {
                Funcionario funcionario = await _userManager.GetUserAsync(User);
                Emprestimo emprestimo = new Emprestimo((DateTime)emprestimoVM.DataEntrega, _unitOfWork.LivroRepository.GetLivroById(emprestimoVM.LivroId),
                    _unitOfWork.AlunoRepository.GetAlunoById(emprestimoVM.AlunoId), funcionario);
                emprestimo.EmprestimoId = emprestimoVM.Id;
                _unitOfWork.EmprestimoRepository.UpdateEmprestimo(emprestimo);
                ViewBag.Mensagem = "Edição feito com sucesso!";
                _unitOfWork.Commit();
                return RedirectToAction("Listar");
            }
            ViewBag.Mensagem = "Edição não efetuada! Verifique as informações e tente novamente";
            return View(emprestimoVM);

        }

        public IActionResult Deletar(int? id)
        {
            if (id == null)
            {
                return NotFound();
            }

            var emprestimo = _unitOfWork.EmprestimoRepository.GetEmprestimoById(id);
            EmprestimoViewModel emprestimoVM = new EmprestimoViewModel()
            {
                Id = emprestimo.EmprestimoId,
                DataEntrega = emprestimo.DataEntrega,
                DataLimiteEntrega = emprestimo.DataLimiteEntrega,
                AlunoId = emprestimo.AlunoId,
                LivroId = emprestimo.LivroId
            };

            if (emprestimo == null)
            {
                return NotFound();
            }

            return View(emprestimoVM);
        }

        [HttpPost, ActionName("Deletar")]
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
                    _unitOfWork.Commit();
                    return RedirectToAction("Listar");
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
                List<EmprestimoViewModel> ListaEmprestimoVM = new List<EmprestimoViewModel>();

                if (!ListaEmprestimo.Any())
                {
                    ViewData["Url"] = "/Emprestimo";
                    return View("ErroListaVazia", ViewData["Url"]);
                }

                foreach(Emprestimo emprestimo in ListaEmprestimo)
                {
                    EmprestimoViewModel emprestimoVM = new EmprestimoViewModel()
                    {
                        Id = emprestimo.EmprestimoId,
                        DataEntrega = emprestimo.DataEntrega,
                        DataLimiteEntrega = emprestimo.DataLimiteEntrega,
                        AlunoId = emprestimo.AlunoId,
                        LivroId = emprestimo.LivroId
                    };
                    ListaEmprestimoVM.Add(emprestimoVM);
                }
                return View(ListaEmprestimo);
            }
                return View("Error");
         }
          
    }
}
