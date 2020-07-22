using Microsoft.AspNetCore.Authorization;
using Microsoft.AspNetCore.Mvc;
using Sistema_de_Biblioteca.Models;
using Sistema_de_Biblioteca.Repositories.Interfaces;
using Sistema_de_Biblioteca.ViewModels;
using System.Collections.Generic;
using System.Linq;

namespace Sistema_de_Biblioteca.Controllers
{
    [Authorize]
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
                Livro livro = new Livro(livroVM.Titulo, livroVM.Autor, livroVM.Edicao, livroVM.Ano, livroVM.Paginas,
                    livroVM.Genero, livroVM.Editora);

                _unitOfWork.LivroRepository.AddLivro(livro);
                ViewBag.Mensagem = "Cadastro feito com sucesso!";
                _unitOfWork.Commit();
                
                return RedirectToAction("Listar");
            }
            ViewBag.Mensagem = "Cadastro não efetuado! Verifique as informações e tente novamente";
            return View(livroVM); ;
        }

        public IActionResult Editar(int? id)
        {
            if (id == null)
            {
                return NotFound();
            }

            var livro = _unitOfWork.LivroRepository.GetLivroById(id);
            LivroViewModel livroVM = new LivroViewModel()
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

            if (livro == null)
            {
                return NotFound();
            }

            return View(livroVM);
        }

        [HttpPost]
        [ValidateAntiForgeryToken]
        public IActionResult Editar(LivroViewModel livroVM)
        {
            if (ModelState.IsValid)
            {
                Livro livro = new Livro(livroVM.Titulo, livroVM.Autor, livroVM.Edicao, livroVM.Ano, livroVM.Paginas,
                livroVM.Genero, livroVM.Editora);
                livro.LivroId = livroVM.Id;

                _unitOfWork.LivroRepository.UpdateLivro(livro);
                _unitOfWork.Commit();

                ViewBag.Mensagem = "Edição feito com sucesso!";

                return RedirectToAction("Listar");
            }
            ViewBag.Mensagem = "Edição não efetuada! Verifique as informações e tente novamente";
            return View(livroVM);
        }

        public IActionResult Deletar(int? id)
        {
            if(id == null)
            {
                return NotFound();
            }

            var livro = _unitOfWork.LivroRepository.GetLivroById(id);

            if(livro == null)
            {
                return NotFound();
            }

            return View(livro);
        }

        [HttpPost, ActionName("Deletar")]
        [ValidateAntiForgeryToken]
        public IActionResult Deletar(int id)
        {
            Livro livro = _unitOfWork.LivroRepository.GetLivroById(id);
            if (livro != null)
            {
                _unitOfWork.LivroRepository.RemoveLivro(livro);
                _unitOfWork.Commit();
                ViewBag.Mensagem = "Aluno Removido feito com sucesso!";
                return RedirectToAction("Listar");
            }
            ViewBag.Mensagem = "Remoção não efetuada! Verifique as informações e tente novamente";
            return View(id);
        }

        public IActionResult Listar()
        {
            if (ModelState.IsValid)
            {
                IEnumerable<Livro> ListaLivros = _unitOfWork.LivroRepository.GetAllLivro();
                List<LivroViewModel> ListaLivrosViewModels = new List<LivroViewModel>();
                if (!ListaLivros.Any())
                {
                    ViewData["Url"] = "/Livro";
                    return View("ErroListaVazia", ViewData["Url"]);
                }
                foreach (Livro L in ListaLivros)
                {
                    LivroViewModel livroViewModel = new LivroViewModel()
                    {
                        Id = L.LivroId,
                        Titulo = L.Titulo,
                        Autor = L.Autor,
                        Edicao = L.Edicao,
                        Ano = L.Ano,
                        Paginas = L.Paginas,
                        Genero = L.Genero,
                        Editora = L.Editora
                    };
                    ListaLivrosViewModels.Add(livroViewModel);
                }
                return View(ListaLivrosViewModels);
            }
            return View("Error");
        }
    }
}
