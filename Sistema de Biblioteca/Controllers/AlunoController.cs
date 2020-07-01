﻿using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;
using Microsoft.AspNetCore.Mvc;
using Sistema_de_Biblioteca.Repositories;

namespace Sistema_de_Biblioteca.Controllers
{
    public class AlunoController : Controller
    {
        private AlunoRepository _alunoRepository;
        public AlunoController(AlunoRepository alunoRepository)
        {
            _alunoRepository = alunoRepository;
        }
        public IActionResult Cadastrar()
        {
            return View();
        }

        [HttpPost]
        public Task<IActionResult> Cadastrar()
        {
            return View();
        }



    }
}
