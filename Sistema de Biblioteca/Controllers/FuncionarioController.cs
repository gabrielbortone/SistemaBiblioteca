using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;
using Microsoft.AspNetCore.Mvc;
using Sistema_de_Biblioteca.Repositories;

namespace Sistema_de_Biblioteca.Controllers
{
    public class FuncionarioController : Controller
    {
        private FuncionarioRepository _funcionarioRepository;
        public FuncionarioController(FuncionarioRepository funcionarioRepository)
        {
            _funcionarioRepository = funcionarioRepository;
        }
        public IActionResult Index()
        {
            return View();
        }
    }
}
