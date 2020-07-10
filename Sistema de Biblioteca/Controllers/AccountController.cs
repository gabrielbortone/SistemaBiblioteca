using Microsoft.AspNetCore.Http;
using Microsoft.AspNetCore.Mvc;
using Sistema_de_Biblioteca.Repositories;
using Sistema_de_Biblioteca.Repositories.Interfaces;
using Sistema_de_Biblioteca.Services;
using Sistema_de_Biblioteca.ViewModels;
using System;

namespace Sistema_de_Biblioteca.Controllers
{
    public class AccountController : Controller
    {
        private IUnitOfWork _unitOfWork { get; }

        public AccountController( IUnitOfWork unitOfWork)
        {
            _unitOfWork = unitOfWork;
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
                _unitOfWork.LoginService.Logar(loginVM.Username, loginVM.Senha);
                if (_unitOfWork.LoginService.ObterFuncionarioLogado() != null)
                {
                    HttpContext.Session.SetString("Username", loginVM.Username);
                    HttpContext.Session.SetString("Password", loginVM.Senha);
                    HttpContext.Session.SetInt32("EstaLogado", 1);
                    return View("../Home/Index");
                }
            }
            return View(loginVM);
        }

        [HttpPost]
        [ValidateAntiForgeryToken]
        public IActionResult Logout()
        {
            if (_unitOfWork.LoginService.ObterFuncionarioLogado() != null)
            {
                _unitOfWork.LoginService.Logout();
                HttpContext.Session.SetString("Username", null);
                HttpContext.Session.SetString("Password", null);
                HttpContext.Session.SetInt32("IsLogged", 0);
                return View("../Home/Index");
            }
            throw new Exception("Usuário não está logado!");
        }


    }
}
