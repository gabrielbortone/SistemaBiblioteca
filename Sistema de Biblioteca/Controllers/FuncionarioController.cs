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
        private UserManager<Funcionario> _userManager;
        public FuncionarioController(IUnitOfWork unitOfWork, UserManager<Funcionario> userManager)
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
                Endereco endereco = new Endereco(funcionarioVM.EnderecoVM.CEP, funcionarioVM.EnderecoVM.Bairro, 
                    funcionarioVM.EnderecoVM.Cidade, funcionarioVM.EnderecoVM.Estado);
                
                Telefone telefone = new Telefone(funcionarioVM.TelefoneVM.Tipo, funcionarioVM.TelefoneVM.DDD, funcionarioVM.TelefoneVM.Numero);

                EnderecoFuncionario enderecoFuncionario = new EnderecoFuncionario();
                enderecoFuncionario.EnderecoId = endereco.EnderecoId;
                enderecoFuncionario.Endereco = endereco;

                TelefoneFuncionario telefoneFuncionario = new TelefoneFuncionario();
                telefoneFuncionario.TelefoneId = telefone.TelefoneId;
                telefoneFuncionario.Telefone = telefone;

                Funcionario funcionario = new Funcionario(funcionarioVM.Nome, funcionarioVM.Sobrenome, funcionarioVM.CPF, 
                    funcionarioVM.Username, enderecoFuncionario, telefoneFuncionario, funcionarioVM.Email, funcionarioVM.Cargo, funcionarioVM.DataAdmissao);

                enderecoFuncionario.FuncionarioId = funcionario.Id;
                enderecoFuncionario.Funcionario = funcionario;

                _unitOfWork.EnderecoRepository.AddEndereco(endereco);
                _unitOfWork.TelefoneRepository.AddTelefone(telefone);

                var result = await _userManager.CreateAsync(funcionario, funcionarioVM.Senha);


                if (result.Succeeded)
                {
                    await _userManager.AddToRoleAsync(funcionario, "Funcionário");
                    _unitOfWork.EnderecoFuncionarioRepository.AddEndereco(enderecoFuncionario);
                    _unitOfWork.TelefoneFuncionarioRepository.AddTelefone(telefoneFuncionario);
                    _unitOfWork.Commit();
                }
                else
                {
                    var errors = result.Errors;
                    var message = string.Join(", ", errors);
                    ModelState.AddModelError("", message);
                    return View(funcionarioVM);
                }

                ViewBag.Mensagem = "Cadastro feito com sucesso!";
                return RedirectToAction("Listar");
            }
                ViewBag.Mensagem = "Cadastro não efetuado! Verifique as informações e tente novamente";
                return View(funcionarioVM);
        }

        public IActionResult Editar(string? id)
        {
            if (id == null)
            {
                return NotFound();
            }

            var funcionario = _unitOfWork.FuncionarioRepository.GetFuncionarioById(id);
            var enderecoFuncionario = _unitOfWork.EnderecoFuncionarioRepository.GetEnderecoByIdFuncionario(id);
            var endereco = _unitOfWork.EnderecoRepository.GetEnderecoById(enderecoFuncionario.EnderecoId);
            var telefoneFuncionario = _unitOfWork.TelefoneFuncionarioRepository.GetTelefoneByIdFuncionario(id);
            var telefone = _unitOfWork.TelefoneRepository.GetTelefoneById(telefoneFuncionario.TelefoneId);

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

            FuncionarioViewModel funcionarioVM = new FuncionarioViewModel(funcionario.Id, funcionario.Nome, funcionario.Sobrenome,
                funcionario.CPF, funcionario.UserName, enderecoVM, telefoneVM, funcionario.Email, funcionario.Cargo, funcionario.DataAdmissao );

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
                Endereco endereco = new Endereco(funcionarioVM.EnderecoVM.CEP, funcionarioVM.EnderecoVM.Bairro, funcionarioVM.EnderecoVM.Cidade, funcionarioVM.EnderecoVM.Estado);
                Telefone telefone = new Telefone(funcionarioVM.TelefoneVM.Tipo, funcionarioVM.TelefoneVM.DDD, funcionarioVM.TelefoneVM.Numero);

                EnderecoFuncionario enderecoFuncionario = _unitOfWork.EnderecoFuncionarioRepository.GetEnderecoByIdFuncionario(funcionarioVM.Id);
                TelefoneFuncionario telefoneFuncionario = _unitOfWork.TelefoneFuncionarioRepository.GetTelefoneByIdFuncionario(funcionarioVM.Id);
                endereco.EnderecoId = enderecoFuncionario.EnderecoId;
                telefone.TelefoneId = telefoneFuncionario.TelefoneId;

                Funcionario funcionario = new Funcionario(funcionarioVM.Id, funcionarioVM.Nome, funcionarioVM.Sobrenome, funcionarioVM.CPF,
                    funcionarioVM.Username, enderecoFuncionario, telefoneFuncionario, funcionarioVM.Email, funcionarioVM.Cargo, funcionarioVM.DataAdmissao);
                
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

        public IActionResult Deletar(string? id)
        {
            if (id == null)
            {
                return NotFound();
            }

            var funcionario = _unitOfWork.FuncionarioRepository.GetFuncionarioById(id);
            var endereoFuncionario = _unitOfWork.EnderecoFuncionarioRepository.GetEnderecoByIdFuncionario(funcionario.Id);
            var endereco = _unitOfWork.EnderecoRepository.GetEnderecoById(endereoFuncionario.EnderecoId);
            var telefoneFuncionario = _unitOfWork.TelefoneFuncionarioRepository.GetTelefoneByIdFuncionario(funcionario.Id);
            var telefone = _unitOfWork.TelefoneRepository.GetTelefoneById(telefoneFuncionario.TelefoneId);

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

            FuncionarioViewModel funcionarioVM = new FuncionarioViewModel(funcionario.Id, funcionario.Nome, funcionario.Sobrenome,
                funcionario.CPF, funcionario.UserName, enderecoVM, telefoneVM, funcionario.Email, funcionario.Cargo, funcionario.DataAdmissao);

            if (funcionario == null)
            {
                return NotFound();
            }

            return View(funcionarioVM);
        }

        [HttpPost]
        [ValidateAntiForgeryToken]
        public IActionResult Deletar(FuncionarioViewModel funcionarioVM)
        {
            if (ModelState.IsValid)
            {
                Funcionario funcionario = _unitOfWork.FuncionarioRepository.GetFuncionarioById(funcionarioVM.Id);

                if (funcionario != null)
                {
                    var enderecoFuncionario = _unitOfWork.EnderecoFuncionarioRepository.GetEnderecoByIdFuncionario(funcionario.Id);
                    var endereco = _unitOfWork.EnderecoRepository.GetEnderecoById(enderecoFuncionario.EnderecoId);
                    var telefoneFuncionario = _unitOfWork.TelefoneFuncionarioRepository.GetTelefoneByIdFuncionario(funcionario.Id);
                    var telefone = _unitOfWork.TelefoneRepository.GetTelefoneById(telefoneFuncionario.TelefoneId);

                    _unitOfWork.EnderecoFuncionarioRepository.RemoveEndereco(enderecoFuncionario.EnderecoId);
                    _unitOfWork.TelefoneFuncionarioRepository.RemoveTelefone(telefoneFuncionario.TelefoneId);

                    _unitOfWork.EnderecoRepository.RemoveEndereco(endereco.EnderecoId);
                    _unitOfWork.TelefoneRepository.RemoveTelefone(telefone.TelefoneId);
                    _unitOfWork.FuncionarioRepository.RemoveFuncionario(funcionario);

                    ViewBag.Mensagem = "Funcionário Removido feito com sucesso!";

                    _unitOfWork.Commit();

                    return RedirectToAction("Listar");
                }
            }
            ViewBag.Mensagem = "Remoção não efetuada! Verifique as informações e tente novamente";
            return View(funcionarioVM);
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
                    var endereoFuncionario = _unitOfWork.EnderecoFuncionarioRepository.GetEnderecoByIdFuncionario(funcionario.Id);
                    var endereco = _unitOfWork.EnderecoRepository.GetEnderecoById(endereoFuncionario.EnderecoId);
                    var telefoneFuncionario = _unitOfWork.TelefoneFuncionarioRepository.GetTelefoneByIdFuncionario(funcionario.Id);
                    var telefone = _unitOfWork.TelefoneRepository.GetTelefoneById(telefoneFuncionario.TelefoneId);

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

                    FuncionarioViewModel funcionarioVM = new FuncionarioViewModel(funcionario.Id, funcionario.Nome, funcionario.Sobrenome,
                        funcionario.CPF, funcionario.UserName, enderecoVM, telefoneVM, funcionario.Email, funcionario.Cargo, funcionario.DataAdmissao);

                    ListaFuncionarioViewModels.Add(funcionarioVM);
                }
                return View(ListaFuncionarioViewModels);
            }
            return View("Error");
        }
    }
}
