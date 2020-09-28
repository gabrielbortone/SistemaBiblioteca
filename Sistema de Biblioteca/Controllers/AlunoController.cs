using Microsoft.AspNetCore.Authorization;
using Microsoft.AspNetCore.Mvc;
using Sistema_de_Biblioteca.Models;
using Sistema_de_Biblioteca.Models.ValueObjects;
using Sistema_de_Biblioteca.Repositories.Interfaces;
using Sistema_de_Biblioteca.ViewModels;
using System.Collections.Generic;
using System.Linq;

namespace Sistema_de_Biblioteca.Controllers
{
    [Authorize]
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
                Endereco endereco = new Endereco(alunoVM.EnderecoVM.CEP, alunoVM.EnderecoVM.Bairro, alunoVM.EnderecoVM.Cidade,
                    alunoVM.EnderecoVM.Estado);
                Telefone telefone = new Telefone(alunoVM.TelefoneVM.Tipo, alunoVM.TelefoneVM.DDD, alunoVM.TelefoneVM.Numero);
                
                EnderecoAluno enderecoAluno = new EnderecoAluno();
                enderecoAluno.Endereco = endereco;
                enderecoAluno.EnderecoId = endereco.EnderecoId;
                TelefoneAluno telefoneAluno = new TelefoneAluno();
                telefoneAluno.Telefone = telefone;
                telefoneAluno.TelefoneId = telefone.TelefoneId;

                Aluno aluno = new Aluno(alunoVM.Nome, alunoVM.Sobrenome, alunoVM.CPF, enderecoAluno,
                    telefoneAluno, alunoVM.Email, alunoVM.Matricula);

                _unitOfWork.EnderecoRepository.AddEndereco(endereco);
                _unitOfWork.TelefoneRepository.AddTelefone(telefone);
                _unitOfWork.AlunoRepository.AddAluno(aluno);
                _unitOfWork.EnderecoAlunoRepository.AddEndereco(enderecoAluno);
                _unitOfWork.TelefoneAlunoRepository.AddTelefone(telefoneAluno);

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

            if (aluno == null)
            {
                return NotFound();
            }

            var enderecoAluno = _unitOfWork.EnderecoAlunoRepository.GetEnderecoByIdAluno(id);
            var endereco = _unitOfWork.EnderecoRepository.GetEnderecoById(enderecoAluno.EnderecoId);
            var telefoneAluno = _unitOfWork.TelefoneAlunoRepository.GetTelefoneByIdAluno(id);
            var telefone = _unitOfWork.TelefoneRepository.GetTelefoneById(telefoneAluno.TelefoneId);

            EnderecoViewModel enderecoVM = new EnderecoViewModel()
            {
                CEP = endereco.CEP,
                Bairro = endereco.Bairro,
                Cidade = endereco.Cidade,
                Estado = endereco.Estado,
            };

            TelefoneViewModel telefoneVM = new TelefoneViewModel()
            {
                Tipo = telefone.Tipo,
                DDD = telefone.DDD,
                Numero = telefone.Numero,
            };

            AlunoViewModel alunoVM = new AlunoViewModel(aluno.AlunoId, aluno.Nome, aluno.Sobrenome,
                aluno.CPF, enderecoVM, telefoneVM, aluno.Email, aluno.Matricula);

            return View(alunoVM);
        }

        [HttpPost]
        [ValidateAntiForgeryToken]
        public IActionResult Editar(AlunoViewModel alunoVM)
        {
            if (ModelState.IsValid)
            {
                Endereco endereco = new Endereco(alunoVM.EnderecoVM.CEP, alunoVM.EnderecoVM.Bairro, alunoVM.EnderecoVM.Cidade, alunoVM.EnderecoVM.Estado);
                Telefone telefone = new Telefone(alunoVM.TelefoneVM.Tipo, alunoVM.TelefoneVM.DDD, alunoVM.TelefoneVM.Numero);

                EnderecoAluno enderecoAluno = _unitOfWork.EnderecoAlunoRepository.GetEnderecoByIdAluno(alunoVM.Id);
                TelefoneAluno telefoneAluno = _unitOfWork.TelefoneAlunoRepository.GetTelefoneByIdAluno(alunoVM.Id);
                endereco.EnderecoId = enderecoAluno.EnderecoId;
                telefone.TelefoneId = telefoneAluno.TelefoneId;

                Aluno aluno = new Aluno(alunoVM.Id, alunoVM.Nome, alunoVM.Sobrenome, alunoVM.CPF,enderecoAluno,
                    telefoneAluno, alunoVM.Email, alunoVM.Matricula);

                _unitOfWork.EnderecoRepository.UpdateEndereco(endereco);
                _unitOfWork.TelefoneRepository.UpdateTelefone(telefone);
                _unitOfWork.AlunoRepository.UpdateAluno(aluno);

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

            if (aluno == null)
            {
                return NotFound();
            }

            var enderecoAluno = _unitOfWork.EnderecoAlunoRepository.GetEnderecoByIdAluno(aluno.AlunoId);
            var telefoneAluno = _unitOfWork.TelefoneAlunoRepository.GetTelefoneByIdAluno(aluno.AlunoId);
            var endereco = _unitOfWork.EnderecoRepository.GetEnderecoById(enderecoAluno.AlunoId);
            var telefone = _unitOfWork.TelefoneRepository.GetTelefoneById(telefoneAluno.AlunoId);

            EnderecoViewModel enderecoVM = new EnderecoViewModel()
            {
                CEP = endereco.CEP,
                Bairro = endereco.Bairro,
                Cidade = endereco.Cidade,
                Estado = endereco.Estado,
            };

            TelefoneViewModel telefoneVM = new TelefoneViewModel()
            {
                Tipo = telefone.Tipo,
                DDD = telefone.DDD,
                Numero = telefone.Numero,
            };

            AlunoViewModel alunoVM = new AlunoViewModel(aluno.AlunoId, aluno.Nome, aluno.Sobrenome,
                aluno.CPF, enderecoVM, telefoneVM, aluno.Email, aluno.Matricula);

            return View(alunoVM);
        }

    [HttpPost]
    [ValidateAntiForgeryToken]
    public IActionResult Deletar(AlunoViewModel alunoVM)
    {
        Aluno aluno = _unitOfWork.AlunoRepository.GetAlunoById(alunoVM.Id);
        if (aluno != null)
        {
                var enderecoAluno = _unitOfWork.EnderecoAlunoRepository.GetEnderecoByIdAluno(alunoVM.Id);
                var endereco = _unitOfWork.EnderecoRepository.GetEnderecoById(enderecoAluno.EnderecoId);
                var telefoneAluno = _unitOfWork.TelefoneAlunoRepository.GetTelefoneByIdAluno(alunoVM.Id);
                var telefone = _unitOfWork.TelefoneRepository.GetTelefoneById(telefoneAluno.TelefoneId);

                _unitOfWork.EnderecoAlunoRepository.RemoveEndereco(enderecoAluno.EnderecoId);
                _unitOfWork.TelefoneFuncionarioRepository.RemoveTelefone(telefoneAluno.TelefoneId);

                _unitOfWork.EnderecoRepository.RemoveEndereco(endereco.EnderecoId);
                _unitOfWork.TelefoneRepository.RemoveTelefone(telefone.TelefoneId);
                _unitOfWork.AlunoRepository.RemoveAluno(aluno);

                ViewBag.Mensagem = "Aluno Removido feito com sucesso!";

                _unitOfWork.Commit();

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
                var enderecoAluno = _unitOfWork.EnderecoAlunoRepository.GetEnderecoByIdAluno(aluno.AlunoId);
                var telefoneAluno = _unitOfWork.TelefoneAlunoRepository.GetTelefoneByIdAluno(aluno.AlunoId);
                var endereco = _unitOfWork.EnderecoRepository.GetEnderecoById(enderecoAluno.AlunoId);
                var telefone = _unitOfWork.TelefoneRepository.GetTelefoneById(telefoneAluno.AlunoId);

                EnderecoViewModel enderecoVM = new EnderecoViewModel()
                {
                    CEP = endereco.CEP,
                    Bairro = endereco.Bairro,
                    Cidade = endereco.Cidade,
                    Estado = endereco.Estado,
                };

                TelefoneViewModel telefoneVM = new TelefoneViewModel()
                {
                    Tipo = telefone.Tipo,
                    DDD = telefone.DDD,
                    Numero = telefone.Numero,
                };

                AlunoViewModel alunoVM = new AlunoViewModel(aluno.AlunoId, aluno.Nome, aluno.Sobrenome,
                    aluno.CPF, enderecoVM, telefoneVM, aluno.Email, aluno.Matricula);
               ListaAlunosViewModel.Add(alunoVM);
            }
            return View(ListaAlunosViewModel);
        }
        return View("Error");
    }

    }
}
