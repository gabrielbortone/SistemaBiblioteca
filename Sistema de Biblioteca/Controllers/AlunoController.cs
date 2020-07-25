using Microsoft.AspNetCore.Mvc;
using Sistema_de_Biblioteca.Models;
using Sistema_de_Biblioteca.Models.ValueObjects;
using Sistema_de_Biblioteca.Repositories.Interfaces;
using Sistema_de_Biblioteca.ViewModels;
using System;
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
                EnderecoAluno endereco = new EnderecoAluno(alunoVM.CEP, alunoVM.Bairro, alunoVM.Cidade, alunoVM.Estado);
                TelefoneAluno telefone = new TelefoneAluno(alunoVM.Tipo, alunoVM.DDD, alunoVM.Numero);
                
                Aluno aluno = new Aluno(alunoVM.Nome, alunoVM.Sobrenome, alunoVM.CPF, endereco,
                    telefone, alunoVM.Email, alunoVM.Matricula);

                _unitOfWork.AlunoRepository.AddAluno(aluno);
                _unitOfWork.Commit();

                Aluno aux = _unitOfWork.AlunoRepository.GetAlunoByCPF(aluno.CPF);
                aluno.AlunoId = aux.AlunoId;
                endereco.Aluno = aluno;
                endereco.AlunoId = aluno.AlunoId;
                telefone.Aluno = aluno;
                telefone.AlunoId = aluno.AlunoId;

                _unitOfWork.EnderecoAlunoRepository.AddEndereco(endereco);
                _unitOfWork.TelefoneAlunoRepository.AddTelefone(telefone);
                _unitOfWork.Commit();

                ViewBag.Mensagem = "Cadastro feito com sucesso!";
                return RedirectToAction("Listar");
            }
            ViewBag.Mensagem = "Cadastro não efetuado! Verifique as informações e tente novamente";
            return View(alunoVM);
        }

        public IActionResult Editar(int? id)
        {
            if (id == null)
            {
                return NotFound();
            }

            var aluno = _unitOfWork.AlunoRepository.GetAlunoById(id);
            var endereco = _unitOfWork.EnderecoAlunoRepository.GetEnderecoByAluno(aluno);
            var telefone = _unitOfWork.TelefoneAlunoRepository.GetTelefoneByAluno(aluno);

            aluno.Endereco = endereco;
            aluno.Telefone = telefone;


            AlunoViewModel alunoVM = new AlunoViewModel()
            {
                Id = aluno.AlunoId,
                Nome = aluno.Nome,
                Sobrenome = aluno.Sobrenome,
                CPF = aluno.CPF,
                CEP = aluno.Endereco.CEP,
                Bairro = aluno.Endereco.Bairro,
                Cidade = aluno.Endereco.Cidade,
                Estado = aluno.Endereco.Estado,
                Tipo = aluno.Telefone.Tipo,
                DDD = aluno.Telefone.DDD,
                Numero = aluno.Telefone.Numero,
                Email = aluno.Email,
                Matricula = aluno.Matricula
            };

            if (aluno == null)
            {
                return NotFound();
            }

            return View(alunoVM);
        }

        [HttpPost("Editar/{alunoVM}")]
        [ValidateAntiForgeryToken]
        public IActionResult Editar(AlunoViewModel alunoVM)
        {
            if (ModelState.IsValid)
            {
                EnderecoAluno endereco = new EnderecoAluno(alunoVM.CEP, alunoVM.Bairro, alunoVM.Cidade, alunoVM.Estado);
                TelefoneAluno telefone = new TelefoneAluno(alunoVM.Tipo, alunoVM.DDD, alunoVM.Numero);

                Aluno aluno = new Aluno(alunoVM.Nome, alunoVM.Sobrenome, alunoVM.CPF, endereco,
                    telefone, alunoVM.Email, alunoVM.Matricula);
                Aluno aux = _unitOfWork.AlunoRepository.GetAlunoByCPF(aluno.CPF);
                aluno.AlunoId = aux.AlunoId;

                endereco.Aluno = aluno;
                endereco.AlunoId = aluno.AlunoId;

                telefone.Aluno = aluno;
                telefone.AlunoId = aluno.AlunoId;

                _unitOfWork.TelefoneAlunoRepository.UpdateTelefone(telefone);
                _unitOfWork.EnderecoAlunoRepository.UpdateEndereco(endereco);
                _unitOfWork.AlunoRepository.UpdateAluno(aluno);
                _unitOfWork.Commit();

                ViewBag.Mensagem = "Edição feito com sucesso!";
                return View("Listar");
            }
            ViewBag.Mensagem = "Edição não efetuada! Verifique as informações e tente novamente";
            return View(alunoVM);
        }

        public IActionResult Deletar(int? id)
        {
            if (id == null)
            {
                return NotFound();
            }

            var aluno = _unitOfWork.AlunoRepository.GetAlunoById(id);
            var endereco = _unitOfWork.EnderecoAlunoRepository.GetEnderecoByAluno(aluno);
            var telefone = _unitOfWork.TelefoneAlunoRepository.GetTelefoneByAluno(aluno);

            aluno.Endereco = endereco;
            aluno.Telefone = telefone;

            if (aluno == null)
            {
                return NotFound();
            }

            return View(aluno);
        }

    [HttpPost]
    [ValidateAntiForgeryToken]
    public IActionResult Deletar(int id)
    {
        Aluno aluno = _unitOfWork.AlunoRepository.GetAlunoById(id);
        if (aluno != null)
        {
            _unitOfWork.EnderecoAlunoRepository.RemoveEnderecoByAluno(aluno.AlunoId);
            _unitOfWork.TelefoneAlunoRepository.RemoveTelefoneByAluno(aluno.AlunoId);
            _unitOfWork.AlunoRepository.RemoveAluno(aluno);
            _unitOfWork.Commit();
            ViewBag.Mensagem = "Aluno Removido feito com sucesso!";
            return RedirectToAction("Listar");
        }
        return View(aluno);
    }

    public IActionResult Listar()
    {
        if (ModelState.IsValid)
        {
            IEnumerable<Aluno> ListaAlunos = _unitOfWork.AlunoRepository.GetAllAluno();
            List<AlunoViewModel> ListaAlunosViewModel = new List<AlunoViewModel>();

            if (!ListaAlunos.Any())
            {
                ViewData["Url"] = "/Aluno";
                return View("ErroListaVazia", ViewData["Url"]);
            }

            foreach (Aluno aluno in ListaAlunos)
            {
                EnderecoAluno endereco = _unitOfWork.EnderecoAlunoRepository.GetEnderecoByAluno(aluno);
                TelefoneAluno telefone = _unitOfWork.TelefoneAlunoRepository.GetTelefoneByAluno(aluno);

                aluno.Endereco = endereco;
                aluno.Telefone = telefone;

                AlunoViewModel alunoVM = new AlunoViewModel()
                {
                    Id = aluno.AlunoId,
                    Nome = aluno.Nome,
                    Sobrenome = aluno.Sobrenome,
                    CPF = aluno.CPF,
                    CEP = aluno.Endereco.CEP,
                    Bairro = aluno.Endereco.Bairro,
                    Cidade = aluno.Endereco.Cidade,
                    Estado = aluno.Endereco.Estado,
                    Tipo = aluno.Telefone.Tipo,
                    DDD = aluno.Telefone.DDD,
                    Numero = aluno.Telefone.Numero,
                    Email = aluno.Email,
                    Matricula = aluno.Matricula
                };
            ListaAlunosViewModel.Add(alunoVM);
            }
                return View(ListaAlunosViewModel);
        }
        return View("Error");
    }

    }
}
