using Microsoft.AspNetCore.Mvc;
using Sistema_de_Biblioteca.Services;
using Sistema_de_Biblioteca.ViewModels;
using System;

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
            if (ModelState.IsValid)
            {
                _loginService.Logar(loginVM.Username, loginVM.Senha);
                if (_loginService.ObterFuncionarioLogado() != null)
                {

                    return View("../Home/Index");
                }
            }
            return View(loginVM);
        }

        [HttpPost]
        [ValidateAntiForgeryToken]
        public IActionResult Logout()
        {
            if (_loginService.ObterFuncionarioLogado() != null)
            {
                _loginService.Logout();
                return View("../Home/Index");
            }
            throw new Exception("Usuário não está logado!");
        }


    }
}
