using Microsoft.AspNetCore.Mvc;
using Sistema_de_Biblioteca.Models;
using Sistema_de_Biblioteca.Repositories.Interfaces;
using Sistema_de_Biblioteca.Services;
using Sistema_de_Biblioteca.ViewModels;
using System.Collections.Generic;
using System.Threading;

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
            return View("../Account/Login");
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
        public IActionResult Deletar(Livro livro)
        {
            if (_loginService.EstaLogado())
            {
                if (ModelState.IsValid)
                {
                    if (livro != null)
                    {
                        _livroRepository.RemoveLivro(livro);
                        ViewBag.Mensagem = "Aluno Removido feito com sucesso!";
                    }
                }
                ViewBag.Mensagem = "Remoção não efetuada! Verifique as informações e tente novamente";
                return View(livro);
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
                    List<LivroViewModel> ListaLivrosViewModel = ConverterEmViewModel(ListaLivros);
                    
                    return View(ListaLivrosViewModel);
                }
                return View("Error");
            }
            return View("../Account/Login");
        }

        private List<LivroViewModel> ConverterEmViewModel(IEnumerable<Livro> livros)
        {
            List<LivroViewModel> ListaLivrosViewModel = new List<LivroViewModel>();
            foreach (Livro livro in livros)
            {
                LivroViewModel livroViewModel = new LivroViewModel()
                {
                    Id = livro.LivroId,
                    Titulo = livro.Titulo,
                    Autor = livro.Autor,
                    Edicao = livro.Edicao,
                    Ano = livro.Ano,
                    Paginas = livro.Paginas,
                    Genero = livro.Genero,
                    Editora = livro.Editora

                };
                ListaLivrosViewModel.Add(livroViewModel);
            }
            return ListaLivrosViewModel;
        }
    }
}
