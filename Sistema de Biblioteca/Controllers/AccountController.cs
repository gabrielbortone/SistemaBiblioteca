using Microsoft.AspNetCore.Mvc;
using Sistema_de_Biblioteca.Services;
using Sistema_de_Biblioteca.ViewModels;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;

namespace Sistema_de_Biblioteca.Controllers
{
    public class AccountController : Controller
    {
        private ILoginService _loginService { get; }

        public AccountController( ILoginService loginService)
        {
            _loginService = loginService;
        }

        public IActionResult Login()
        {
            return View();
        }

        [HttpPost]
        [ValidateAntiForgeryToken]
        public IActionResult Login(LoginViewModel loginVM)
        {
            if (_loginService.ObterFuncionarioLogado() == null)
            {
                if (ModelState.IsValid)
                {
                    _loginService.Logar(loginVM.Username, loginVM.Senha);
                    if (_loginService.ObterFuncionarioLogado() != null)
                    {
                        RedirectToAction("Home", "Index");
                    }
                }
                return View(loginVM);
            }
            throw new Exception("Usuário já está logado!");
        }

        [HttpPost]
        [ValidateAntiForgeryToken]
        public IActionResult Logout()
        {
            if (_loginService.ObterFuncionarioLogado() != null)
            {
                _loginService.Logout();
                RedirectToAction("Index", "Home");
            }
            throw new Exception("Usuário não está logado!");
        }


    }
}
