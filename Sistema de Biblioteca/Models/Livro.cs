using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;

namespace Sistema_de_Biblioteca.Models
{
    public class Livro
    {
        public int Id { get; set; }
        public string Titulo { get; set; }
        public string Autor { get; set; }
        public int Edicao { get; set; }
        public int Ano { get; set; }
        public int Paginas { get; set; }
        public string Editora { get; set; }
        public int Quantidade { get; set; }
    }
}
