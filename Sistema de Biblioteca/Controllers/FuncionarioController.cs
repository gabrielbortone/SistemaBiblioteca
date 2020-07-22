﻿using Microsoft.AspNetCore.Identity;
using Microsoft.AspNetCore.Mvc;
using Sistema_de_Biblioteca.Models;
using Sistema_de_Biblioteca.Models.ValueObjects;
using Sistema_de_Biblioteca.Repositories.Interfaces;
using Sistema_de_Biblioteca.ViewModels;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;

namespace Sistema_de_Biblioteca.Controllers
{
    //[Authorize]
    public class FuncionarioController : Controller
    {
        private IUnitOfWork _unitOfWork;
        private UserManager<Account> _userManager;
        public FuncionarioController(IUnitOfWork unitOfWork, UserManager<Account> userManager)
        {
            _unitOfWork = unitOfWork;
            _userManager = userManager;
        }
        public IActionResult Cadastrar()
        {
            return View();
        }

        [HttpPost]
        [ValidateAntiForgeryToken]
        public async Task<IActionResult> Cadastrar(FuncionarioViewModel funcionarioVM)
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

                var user = new Account() { UserName = funcionarioVM.Username};
                var result = await _userManager.CreateAsync(user, funcionarioVM.Senha);

                if (result.Succeeded)
                {
                    await _userManager.AddToRoleAsync(user, "Funcionário");
                }

                _unitOfWork.Commit();

                ViewBag.Mensagem = "Cadastro feito com sucesso!";
                return RedirectToAction("Listar");
            }
                ViewBag.Mensagem = "Cadastro não efetuado! Verifique as informações e tente novamente";
                return View(funcionarioVM);
        }

        public IActionResult Editar(int? id)
        {
            if (id == null)
            {
                return NotFound();
            }

            var funcionario = _unitOfWork.FuncionarioRepository.GetFuncionarioById(id);
            FuncionarioViewModel funcionarioVM = new FuncionarioViewModel()
            {
                Id = funcionario.FuncionarioId,
                Nome = funcionario.Nome,
                Sobrenome = funcionario.Sobrenome,
                CPF = funcionario.CPF,
                CEP = funcionario.Endereco.CEP,
                Bairro = funcionario.Endereco.Bairro,
                Cidade = funcionario.Endereco.Cidade,
                Estado = funcionario.Endereco.Estado,
                Tipo = funcionario.Telefone.Tipo,
                DDD = funcionario.Telefone.DDD,
                Numero = funcionario.Telefone.Numero,
                Email = funcionario.Email,
                Username = funcionario.Account.UserName,
                Senha = funcionario.Account.PasswordHash,
                Cargo = funcionario.Cargo
            };

            if (funcionario == null)
            {
                return NotFound();
            }

            return View(funcionarioVM);
        }

        [HttpPost("Editar/{funcionarioVM}")]
        [ValidateAntiForgeryToken]
        public IActionResult Editar(FuncionarioViewModel funcionarioVM)
        {
            if (ModelState.IsValid)
            {
                Endereco endereco = new Endereco(funcionarioVM.CEP, funcionarioVM.Bairro, funcionarioVM.Cidade, funcionarioVM.Estado);
                Telefone telefone = new Telefone(funcionarioVM.Tipo, funcionarioVM.DDD, funcionarioVM.Numero);
                Funcionario funcionario = new Funcionario(funcionarioVM.Nome, funcionarioVM.Sobrenome, funcionarioVM.CPF,
                    funcionarioVM.Username, funcionarioVM.Senha, endereco, telefone, funcionarioVM.Email, funcionarioVM.Cargo, funcionarioVM.DataAdmissao);
                funcionario.FuncionarioId = funcionarioVM.Id;

                //endereco.EnderecoId = _unitOfWork.EnderecoRepository.GetEnderecoByFuncionario(funcionario.FuncionarioId).EnderecoId;
                //telefone.TelefoneId = _unitOfWork.TelefoneRepository.GetTelefoneByFuncionario(funcionario.FuncionarioId).TelefoneId;

                _unitOfWork.EnderecoRepository.UpdateEndereco(endereco);
                _unitOfWork.TelefoneRepository.UpdateTelefone(telefone);
                
                _unitOfWork.FuncionarioRepository.UpdateFuncionario(funcionario);
                 ViewBag.Mensagem = "Edição feito com sucesso!";
                _unitOfWork.Commit();
                return RedirectToAction("Listar");
            }
            ViewBag.Mensagem = "Edição não efetuada! Verifique as informações e tente novamente";
            return View(funcionarioVM);
        }

        public IActionResult Deletar(int? id)
        {
            if (id == null)
            {
                return NotFound();
            }

            var funcionario = _unitOfWork.FuncionarioRepository.GetFuncionarioById(id);

            if (funcionario == null)
            {
                return NotFound();
            }

            return View(funcionario);
        }

        [HttpPost, ActionName("Deletar")]
        [ValidateAntiForgeryToken]
        public IActionResult Deletar(int id)
        {
            if (ModelState.IsValid)
            {
                Funcionario funcionario = _unitOfWork.FuncionarioRepository.GetFuncionarioById(id);
                if (funcionario != null)
                {
                    _unitOfWork.EnderecoRepository.RemoveEndereco(funcionario.EnderecoId);
                    _unitOfWork.TelefoneRepository.RemoveTelefone(funcionario.TelefoneId);
                    _unitOfWork.FuncionarioRepository.RemoveFuncionario(funcionario);
                    ViewBag.Mensagem = "Funcionário Removido feito com sucesso!";
                    _unitOfWork.Commit();
                    return RedirectToAction("Listar");
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
                List<FuncionarioViewModel> ListaFuncionarioViewModels = new List<FuncionarioViewModel>();
                if (!ListaFuncionario.Any())
                {
                    ViewData["Url"] = "/Funcionario";
                    return View("ErroListaVazia", ViewData["Url"]);
                }
                foreach (Funcionario funcionario in ListaFuncionario)
                {
                    FuncionarioViewModel funcionarioVM = new FuncionarioViewModel()
                    {
                        Id = funcionario.FuncionarioId,
                        Nome = funcionario.Nome,
                        Sobrenome = funcionario.Sobrenome,
                        CPF = funcionario.CPF,
                        CEP = funcionario.Endereco.CEP,
                        Bairro = funcionario.Endereco.Bairro,
                        Cidade = funcionario.Endereco.Cidade,
                        Estado = funcionario.Endereco.Estado,
                        Tipo = funcionario.Telefone.Tipo,
                        DDD = funcionario.Telefone.DDD,
                        Numero = funcionario.Telefone.Numero,
                        Email = funcionario.Email,
                        Username = funcionario.Account.UserName,
                        Senha = funcionario.Account.PasswordHash,
                        Cargo = funcionario.Cargo
                    };
                    ListaFuncionarioViewModels.Add(funcionarioVM);
                }
                return View(ListaFuncionarioViewModels);
            }
            return View("Error");
        }
    }
}
