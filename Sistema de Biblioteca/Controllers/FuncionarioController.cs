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
    //[Authorize]
    public class FuncionarioController : Controller
    {
        private IUnitOfWork _unitOfWork;
        public FuncionarioController(IUnitOfWork unitOfWork)
        {
            _unitOfWork = unitOfWork;
        }
        public IActionResult Cadastrar()
        {
            return View();
        }

        [HttpPost]
        [ValidateAntiForgeryToken]
        public IActionResult Cadastrar(FuncionarioViewModel funcionarioVM)
        {
            if (ModelState.IsValid)
            {
                Endereco endereco = new Endereco(funcionarioVM.CEP, funcionarioVM.Bairro, funcionarioVM.Cidade, funcionarioVM.Estado);
                _unitOfWork.EnderecoRepository.AddEndereco(endereco);
                Telefone telefone = new Telefone(funcionarioVM.Tipo, funcionarioVM.DDD, funcionarioVM.Numero);
                _unitOfWork.TelefoneRepository.AddTelefone(telefone);
                Funcionario funcionario = new Funcionario(funcionarioVM.Nome, funcionarioVM.Sobrenome, funcionarioVM.CPF, 
                    funcionarioVM.Username, funcionarioVM.Senha, endereco, telefone, funcionarioVM.Email, funcionarioVM.Cargo, funcionarioVM.DataAdmissao);
                _unitOfWork.FuncionarioRepository.AddFuncionario(funcionario);
                ViewBag.Mensagem = "Cadastro feito com sucesso!";
            }
                ViewBag.Mensagem = "Cadastro não efetuado! Verifique as informações e tente novamente";
                return View(funcionarioVM);
        }

        public IActionResult Editar()
        {
            return View();
        }

        [HttpPost]
        [ValidateAntiForgeryToken]
        public IActionResult Editar(FuncionarioViewModel funcionarioVM)
        {
            if (ModelState.IsValid)
            {
                Endereco endereco = new Endereco(funcionarioVM.CEP, funcionarioVM.Bairro, funcionarioVM.Cidade, funcionarioVM.Estado);
                _unitOfWork.EnderecoRepository.UpdateEndereco(endereco);
                Telefone telefone = new Telefone(funcionarioVM.Tipo, funcionarioVM.DDD, funcionarioVM.Numero);
                _unitOfWork.TelefoneRepository.UpdateTelefone(telefone);
                Funcionario funcionario = new Funcionario(funcionarioVM.Nome, funcionarioVM.Sobrenome, funcionarioVM.CPF,
                    funcionarioVM.Username, funcionarioVM.Senha, endereco, telefone, funcionarioVM.Email, funcionarioVM.Cargo, funcionarioVM.DataAdmissao);
                _unitOfWork.FuncionarioRepository.UpdateFuncionario(funcionario);
                 ViewBag.Mensagem = "Edição feito com sucesso!";
            }
            ViewBag.Mensagem = "Edição não efetuada! Verifique as informações e tente novamente";
            return View(funcionarioVM);
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
                Funcionario funcionario = _unitOfWork.FuncionarioRepository.GetFuncionarioById(id);
                if (funcionario != null)
                {
                    _unitOfWork.EnderecoRepository.RemoveEnderecoByFuncionario(id);
                    _unitOfWork.TelefoneRepository.RemoveTelefoneByFuncionario(id);
                    _unitOfWork.FuncionarioRepository.RemoveFuncionario(funcionario);
                    ViewBag.Mensagem = "Funcionário Removido feito com sucesso!";
                }
            }
            ViewBag.Mensagem = "Remoção não efetuada! Verifique as informações e tente novamente";
            return View();
        }

        public IActionResult Listar()
        {
            if (ModelState.IsValid)
            {
                IEnumerable<Funcionario> ListaFuncionario = _unitOfWork.FuncionarioRepository.GetAllFuncionario();
                if (!ListaFuncionario.Any())
                {
                    ViewData["Url"] = "/Funcionario";
                    return View("ErroListaVazia", ViewData["Url"]);
                }
                return View(ListaFuncionario);
            }
            return View("Error");
        }
    }
}
