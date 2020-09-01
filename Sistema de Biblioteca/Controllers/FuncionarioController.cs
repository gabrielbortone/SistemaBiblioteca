using Microsoft.AspNetCore.Authorization;
using Microsoft.AspNetCore.Identity;
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
    [Authorize]
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
                EnderecoFuncionario endereco = new EnderecoFuncionario(funcionarioVM.CEP, funcionarioVM.Bairro, funcionarioVM.Cidade, funcionarioVM.Estado);
                
                TelefoneFuncionario telefone = new TelefoneFuncionario(funcionarioVM.Tipo, funcionarioVM.DDD, funcionarioVM.Numero);
                
                Funcionario funcionario = new Funcionario(funcionarioVM.Nome, funcionarioVM.Sobrenome, funcionarioVM.CPF, 
                    funcionarioVM.Username, funcionarioVM.Senha, endereco, telefone, funcionarioVM.Email, funcionarioVM.Cargo, funcionarioVM.DataAdmissao);

                _unitOfWork.FuncionarioRepository.AddFuncionario(funcionario);
                _unitOfWork.Commit();

                endereco.Funcionario = funcionario;
                endereco.FuncionarioId = funcionario.FuncionarioId;
                telefone.Funcionario = funcionario;
                telefone.FuncionarioId = funcionario.FuncionarioId;

                var user = new Account() { Id_Funcionario= funcionario.FuncionarioId,UserName = funcionarioVM.Username};
                var result = await _userManager.CreateAsync(user, funcionarioVM.Senha);


                if (result.Succeeded)
                {
                    await _userManager.AddToRoleAsync(user, "Funcionário");
                    _unitOfWork.EnderecoFuncionarioRepository.AddEndereco(endereco);
                    _unitOfWork.TelefoneFuncionarioRepository.AddTelefone(telefone);
                }
                else
                {
                    var errors = result.Errors;
                    var message = string.Join(", ", errors);
                    ModelState.AddModelError("", message);
                    return View(funcionarioVM);
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
            var endereco = _unitOfWork.EnderecoFuncionarioRepository.GetEnderecoByFuncionario(funcionario);
            var telefone = _unitOfWork.TelefoneFuncionarioRepository.GetTelefoneByFuncionario(funcionario);
            
            funcionario.Endereco = endereco;
            funcionario.Telefone = telefone; 

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
                Cargo = funcionario.Cargo
            };

            if (funcionario == null)
            {
                return NotFound();
            }

            return View(funcionarioVM);
        }

        [HttpPost]
        [ValidateAntiForgeryToken]
        public IActionResult Editar(FuncionarioViewModel funcionarioVM)
        {
            if (ModelState.IsValid)
            {
                EnderecoFuncionario endereco = new EnderecoFuncionario(funcionarioVM.CEP, funcionarioVM.Bairro, funcionarioVM.Cidade, funcionarioVM.Estado);
                TelefoneFuncionario telefone = new TelefoneFuncionario(funcionarioVM.Tipo, funcionarioVM.DDD, funcionarioVM.Numero);
                
                Funcionario funcionario = new Funcionario(funcionarioVM.Nome, funcionarioVM.Sobrenome, funcionarioVM.CPF,
                    funcionarioVM.Username, funcionarioVM.Senha, endereco, telefone, funcionarioVM.Email, funcionarioVM.Cargo, funcionarioVM.DataAdmissao);
                funcionario.FuncionarioId = funcionarioVM.Id;

                Funcionario aux = _unitOfWork.FuncionarioRepository.GetFuncionarioByCPF(funcionario.CPF);
                funcionario.FuncionarioId = aux.FuncionarioId;
                endereco.Funcionario = aux;
                endereco.FuncionarioId = aux.FuncionarioId;
                telefone.Funcionario = aux;
                telefone.FuncionarioId = aux.FuncionarioId;
                funcionario.Account = aux.Account;

                _unitOfWork.EnderecoFuncionarioRepository.UpdateEndereco(endereco);
                _unitOfWork.TelefoneFuncionarioRepository.UpdateTelefone(telefone);
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
            var endereco = _unitOfWork.EnderecoFuncionarioRepository.GetEnderecoByFuncionario(funcionario);
            var telefone = _unitOfWork.TelefoneFuncionarioRepository.GetTelefoneByFuncionario(funcionario);
            funcionario.Endereco = endereco;
            funcionario.Telefone = telefone;

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
                Cargo = funcionario.Cargo
            };

            if (funcionario == null)
            {
                return NotFound();
            }

            return View(funcionarioVM);
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
                    _unitOfWork.EnderecoFuncionarioRepository.RemoveEnderecoByFuncionario(funcionario.FuncionarioId);
                    _unitOfWork.TelefoneFuncionarioRepository.RemoveTelefoneByFuncionario(funcionario.FuncionarioId);
                    _unitOfWork.FuncionarioRepository.RemoveFuncionario(funcionario);
                    ViewBag.Mensagem = "Funcionário Removido feito com sucesso!";
                    _unitOfWork.Commit();
                    return RedirectToAction("Listar");
                }
            }
            ViewBag.Mensagem = "Remoção não efetuada! Verifique as informações e tente novamente";
            return View(id);
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
                    EnderecoFuncionario enderecoFuncionario = _unitOfWork.EnderecoFuncionarioRepository.GetEnderecoByFuncionario(funcionario);
                    TelefoneFuncionario telefoneFuncionario = _unitOfWork.TelefoneFuncionarioRepository.GetTelefoneByFuncionario(funcionario);
                    funcionario.Endereco = enderecoFuncionario;
                    funcionario.Telefone = telefoneFuncionario;


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
