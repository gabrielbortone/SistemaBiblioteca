﻿using Microsoft.AspNetCore.Mvc;
using Sistema_de_Biblioteca.Models;
using Sistema_de_Biblioteca.Repositories.Interfaces;
using Sistema_de_Biblioteca.Services;
using Sistema_de_Biblioteca.ViewModels;
using System.Collections.Generic;
using System.Linq;

namespace Sistema_de_Biblioteca.Controllers
{
    public class LivroController : Controller
    {
        private IUnitOfWork _unitOfWork;
        public LivroController(IUnitOfWork unitOfWork)
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
        public IActionResult Cadastrar(LivroViewModel livroVM)
        {
            if (_unitOfWork.LoginService.EstaLogado())
            {
                if (ModelState.IsValid)
                {
                    Livro livro = new Livro(livroVM.Titulo,livroVM.Autor,livroVM.Edicao, livroVM.Ano, livroVM.Paginas,
                        livroVM.Genero, livroVM.Editora);
                    _unitOfWork.LivroRepository.AddLivro(livro);
                    ViewBag.Mensagem = "Cadastro feito com sucesso!";
                }
                ViewBag.Mensagem = "Cadastro não efetuado! Verifique as informações e tente novamente";
                return View(livroVM);
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
        public IActionResult Editar(LivroViewModel livroVM)
        {
            if (_unitOfWork.LoginService.EstaLogado())
            {
                if (ModelState.IsValid)
                {
                    Livro livro = new Livro(livroVM.Titulo, livroVM.Autor, livroVM.Edicao, livroVM.Ano, livroVM.Paginas,
                        livroVM.Genero, livroVM.Editora);
                    _unitOfWork.LivroRepository.UpdateLivro(livro);
                    ViewBag.Mensagem = "Edição feito com sucesso!";
                }
                ViewBag.Mensagem = "Edição não efetuada! Verifique as informações e tente novamente";
                return View(livroVM);
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
                    Livro livro = _unitOfWork.LivroRepository.GetLivroById(id);
                    if (livro != null)
                    {
                        _unitOfWork.LivroRepository.RemoveLivro(livro);
                        ViewBag.Mensagem = "Aluno Removido feito com sucesso!";
                    }
                }
                ViewBag.Mensagem = "Remoção não efetuada! Verifique as informações e tente novamente";
                return View(id);
            }
            return RedirectToAction("Login", "Account");

        }

        public IActionResult Listar()
        {
            if (_unitOfWork.LoginService.EstaLogado())
            {
                if (ModelState.IsValid)
                {
                    IEnumerable<Livro> ListaLivros = _unitOfWork.LivroRepository.GetAllLivro();
                    if (!ListaLivros.Any())
                    {
                        return View("ErroListaVazia");
                    }
                    return View(ListaLivros);
                }
                return View("Error");
            }
            return RedirectToAction("Login", "Account");
        }
    }
}
