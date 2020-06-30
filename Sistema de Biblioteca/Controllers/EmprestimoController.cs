using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;
using Microsoft.AspNetCore.Mvc;
using Sistema_de_Biblioteca.Repositories;

namespace Sistema_de_Biblioteca.Controllers
{
    public class EmprestimoController : Controller
    {
        private EmprestimoRepository _emprestimoRepository;
        public EmprestimoController(EmprestimoRepository emprestimoRepository)
        {
            _emprestimoRepository = emprestimoRepository;
        }
        public IActionResult Index()
        {
            return View();
        }
    }
}
