using Microsoft.AspNetCore.Mvc;
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
            return View("../Home/Index");
        }

        [HttpPost]
        [ValidateAntiForgeryToken]
        public IActionResult Cadastrar(LivroViewModel livroVM)
        {
            if (_loginService.EstaLogado())
            {
                if (ModelState.IsValid)
                {
                    Livro livro = new Livro(livroVM.Titulo,livroVM.Autor,livroVM.Edicao, livroVM.Ano, livroVM.Paginas,
                        livroVM.Genero, livroVM.Editora);
                    _livroRepository.AddLivro(livro);
                    ViewBag.Mensagem = "Cadastro feito com sucesso!";
                }
                ViewBag.Mensagem = "Cadastro não efetuado! Verifique as informações e tente novamente";
                return View(livroVM);
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
        public IActionResult Editar(LivroViewModel livroVM)
        {
            if (_loginService.EstaLogado())
            {
                if (ModelState.IsValid)
                {
                    Livro livro = new Livro(livroVM.Titulo, livroVM.Autor, livroVM.Edicao, livroVM.Ano, livroVM.Paginas,
                        livroVM.Genero, livroVM.Editora);
                    _livroRepository.UpdateLivro(livro);
                    ViewBag.Mensagem = "Edição feito com sucesso!";
                }
                ViewBag.Mensagem = "Edição não efetuada! Verifique as informações e tente novamente";
                return View(livroVM);
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
        public IActionResult Deletar(int id)
        {
            if (_loginService.EstaLogado())
            {
                if (ModelState.IsValid)
                {
                    Livro livro = _livroRepository.GetLivroById(id);
                    if (livro != null)
                    {
                        _livroRepository.RemoveLivro(livro);
                        ViewBag.Mensagem = "Aluno Removido feito com sucesso!";
                    }
                }
                ViewBag.Mensagem = "Remoção não efetuada! Verifique as informações e tente novamente";
                return View(id);
            }
            return View("../Account/Login");
            
        }

        public IActionResult Listar()
        {
            if (_loginService.EstaLogado())
            {
                if (ModelState.IsValid)
                {
                    IEnumerable<Livro> ListaLivros = _livroRepository.GetAllLivro();
                    if (!ListaLivros.Any())
                    {
                        return View("ErroListaVazia");
                    }
                    return View(ListaLivros);
                }
                return View("Error");
            }
            return View("../Account/Login");
        }
    }
}
