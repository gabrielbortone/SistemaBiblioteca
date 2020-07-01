using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;
using Microsoft.AspNetCore.Authorization;
using Microsoft.AspNetCore.Mvc;
using Sistema_de_Biblioteca.Models;
using Sistema_de_Biblioteca.Repositories;
using Sistema_de_Biblioteca.Services;
using Sistema_de_Biblioteca.ViewModels;

namespace Sistema_de_Biblioteca.Controllers
{
    public class LivroController : Controller
    {
        private LivroRepository _livroRepository;
        private LoginService _loginService;
        public LivroController(LivroRepository livroRepository, LoginService loginService)
        {
            _livroRepository = livroRepository;
            _loginService = loginService;
        }

        public IActionResult Cadastrar()
        {
            return View();
        }

        [HttpPost]
        public IActionResult Cadastrar(LivroViewModel livroVM)
        {
            if (ModelState.IsValid)
            {
                if (_loginService.IsLogged)
                {
                    Livro livro = new Livro(livroVM.Titulo,livroVM.Autor,livroVM.Edicao, livroVM.Ano, livroVM.Paginas,
                        livroVM.Genero, livroVM.Editora);
                    _livroRepository.AddLivro(livro);
                    ViewBag.Mensagem = "Cadastro feito com sucesso!";
                }
                RedirectToAction("Index", "Home");
            }
            ViewBag.Mensagem = "Cadastro não efetuado! Verifique as informações e tente novamente";
            return View(livroVM);
        }

        public IActionResult Editar()
        {
            return View();
        }

        [HttpPost]
        public IActionResult Editar(LivroViewModel livroVM)
        {
            if (ModelState.IsValid)
            {
                if (_loginService.IsLogged)
                {
                    Livro livro = new Livro(livroVM.Titulo, livroVM.Autor, livroVM.Edicao, livroVM.Ano, livroVM.Paginas,
                        livroVM.Genero, livroVM.Editora);
                    _livroRepository.UpdateLivro(livro);
                    ViewBag.Mensagem = "Edição feito com sucesso!";
                }
                RedirectToAction("Index", "Home");
            }
            ViewBag.Mensagem = "Edição não efetuada! Verifique as informações e tente novamente";
            return View(livroVM);
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
                    Livro livro = _livroRepository.GetLivroById(id);
                    if (livro != null)
                    {
                        _livroRepository.RemoveLivro(livro);
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
                if (_loginService.IsLogged)
                {
                    IEnumerable<Livro> ListaLivros = _livroRepository.GetAllLivro();
                    return View(ListaLivros);
                }
                RedirectToAction("Index", "Home");
            }
            return View("Nada a ser exibido!");
        }
    }
}
