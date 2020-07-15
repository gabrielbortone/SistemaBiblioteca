using Microsoft.AspNetCore.Authorization;
using Microsoft.AspNetCore.Mvc;
using Sistema_de_Biblioteca.Models;
using Sistema_de_Biblioteca.Repositories.Interfaces;
using Sistema_de_Biblioteca.ViewModels;
using System.Collections.Generic;
using System.Linq;

namespace Sistema_de_Biblioteca.Controllers
{
    //[Authorize]
    public class LivroController : Controller
    {
        private IUnitOfWork _unitOfWork;
        public LivroController(IUnitOfWork unitOfWork)
        {
            _unitOfWork = unitOfWork;
        }

        public IActionResult Cadastrar()
        {
            return View();
        }

        [HttpPost]
        [ValidateAntiForgeryToken]
        public IActionResult Cadastrar(LivroViewModel livroVM)
        {
            if (ModelState.IsValid)
            {
                Livro livro = new Livro(livroVM.Titulo,livroVM.Autor,livroVM.Edicao, livroVM.Ano, livroVM.Paginas,
                    livroVM.Genero, livroVM.Editora);
                _unitOfWork.LivroRepository.AddLivro(livro);
                ViewBag.Mensagem = "Cadastro feito com sucesso!";
            }
            ViewBag.Mensagem = "Cadastro não efetuado! Verifique as informações e tente novamente";
            return View(livroVM);;
        }

        public IActionResult Editar()
        {
           return View();
        }

        [HttpPost]
        [ValidateAntiForgeryToken]
        public IActionResult Editar(LivroViewModel livroVM)
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

        public IActionResult Listar()
        {
            if (ModelState.IsValid)
            {
                IEnumerable<Livro> ListaLivros = _unitOfWork.LivroRepository.GetAllLivro();
                if (!ListaLivros.Any())
                {
                    ViewData["Url"] = "/Livro";
                    return View("ErroListaVazia", ViewData["Url"]);
                }
                return View(ListaLivros);
            }
            return View("Error");
        }
    }
}
