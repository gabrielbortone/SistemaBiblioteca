using Microsoft.AspNetCore.Authorization;
using Microsoft.AspNetCore.Identity;
using Microsoft.AspNetCore.Mvc;
using Sistema_de_Biblioteca.Models;
using Sistema_de_Biblioteca.Models.ValueObjects;
using Sistema_de_Biblioteca.Repositories.Interfaces;
using Sistema_de_Biblioteca.ViewModels;
using System.Collections.Generic;
using System.Linq;

namespace Sistema_de_Biblioteca.Controllers
{
    //[Authorize]
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
                Endereco endereco = new Endereco(alunoVM.CEP, alunoVM.Bairro, alunoVM.Cidade, alunoVM.Estado);
                _unitOfWork.EnderecoRepository.AddEndereco(endereco);

                Telefone telefone = new Telefone(alunoVM.Tipo, alunoVM.DDD, alunoVM.Numero);
                _unitOfWork.TelefoneRepository.AddTelefone(telefone);

                Aluno aluno = new Aluno(alunoVM.Nome, alunoVM.Sobrenome, alunoVM.CPF, endereco, 
                    telefone, alunoVM.Email, alunoVM.Matricula);

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
                Endereco endereco = new Endereco(alunoVM.CEP, alunoVM.Bairro, alunoVM.Cidade, alunoVM.Estado);
                _unitOfWork.EnderecoRepository.UpdateEndereco(endereco);

                Telefone telefone = new Telefone(alunoVM.Tipo, alunoVM.DDD, alunoVM.Numero);
                _unitOfWork.TelefoneRepository.UpdateTelefone(telefone);

                Aluno aluno = new Aluno(alunoVM.Nome, alunoVM.Sobrenome, alunoVM.CPF, endereco,
                    telefone, alunoVM.Email, alunoVM.Matricula);

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
                    _unitOfWork.RemoveEnderecoByAluno(id);
                    _unitOfWork.RemoveTelefoneByAluno(id);
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
                    ViewData["Url"] = "/Aluno";
                    return View("ErroListaVazia", ViewData["Url"]);
                }
                return View(ListaAlunos);
            }
            return View("Error");
        }


    }
}
