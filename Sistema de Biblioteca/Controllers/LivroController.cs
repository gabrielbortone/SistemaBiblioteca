using Microsoft.AspNetCore.Mvc;
using Sistema_de_Biblioteca.Models;
using Sistema_de_Biblioteca.Repositories.Interfaces;
using Sistema_de_Biblioteca.Services;
using Sistema_de_Biblioteca.ViewModels;
using System.Collections.Generic;

namespace Sistema_de_Biblioteca.Controllers
{
    public class LivroController : Controller
    {
        private ILivroRepository _livroRepository;
        private ILoginService _loginService;
        public LivroController(ILivroRepository livroRepository, ILoginService loginService)
        {
            _livroRepository = livroRepository;
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
        public IActionResult Cadastrar(LivroViewModel livroVM)
        {
            if (ModelState.IsValid)
            {
                if (_loginService.EstaLogado())
                {
                    Livro livro = new Livro(livroVM.Titulo,livroVM.Autor,livroVM.Edicao, livroVM.Ano, livroVM.Paginas,
                        livroVM.Genero, livroVM.Editora);
                    _livroRepository.AddLivro(livro);
                    ViewBag.Mensagem = "Cadastro feito com sucesso!";
                }
                ViewBag.Mensagem = "Precisa estar logado para acessar essa área!";
                RedirectToAction("Login", "Account");
            }
            ViewBag.Mensagem = "Cadastro não efetuado! Verifique as informações e tente novamente";
            return View(livroVM);
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
        public IActionResult Editar(LivroViewModel livroVM)
        {
            if (ModelState.IsValid)
            {
                if (_loginService.EstaLogado())
                {
                    Livro livro = new Livro(livroVM.Titulo, livroVM.Autor, livroVM.Edicao, livroVM.Ano, livroVM.Paginas,
                        livroVM.Genero, livroVM.Editora);
                    _livroRepository.UpdateLivro(livro);
                    ViewBag.Mensagem = "Edição feito com sucesso!";
                }
                ViewBag.Mensagem = "Precisa estar logado para acessar essa área!";
                RedirectToAction("Login", "Account");
            }
            ViewBag.Mensagem = "Edição não efetuada! Verifique as informações e tente novamente";
            return View(livroVM);
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
                    Livro livro = _livroRepository.GetLivroById(id);
                    if (livro != null)
                    {
                        _livroRepository.RemoveLivro(livro);
                        ViewBag.Mensagem = "Aluno Removido feito com sucesso!";
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
                    IEnumerable<Livro> ListaLivros = _livroRepository.GetAllLivro();
                    return View(ListaLivros);
                }
                ViewBag.Mensagem = "Precisa estar logado para acessar essa área!";
                RedirectToAction("Login", "Account");
            }
            return View("Nada a ser exibido!");
        }
    }
}
