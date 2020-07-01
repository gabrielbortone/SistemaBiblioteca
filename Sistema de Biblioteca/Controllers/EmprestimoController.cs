using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;
using Microsoft.AspNetCore.Mvc;
using Sistema_de_Biblioteca.Repositories;
using Sistema_de_Biblioteca.Services;

namespace Sistema_de_Biblioteca.Controllers
{
    public class EmprestimoController : Controller
    {
        private EmprestimoRepository _emprestimoRepository;
        private LoginService _loginService;
        public EmprestimoController(EmprestimoRepository emprestimoRepository, LoginService loginService)
        {
            _emprestimoRepository = emprestimoRepository;
            _loginService = loginService;
        }
        
    }
}
