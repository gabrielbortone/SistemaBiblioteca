﻿using Sistema_de_Biblioteca.Models.Enums;
using System.ComponentModel.DataAnnotations;

namespace Sistema_de_Biblioteca.Models
{
    public class Livro
    {
        public int LivroId { get; set; }

        [Required]
        [Display(Name = "Informe o título do livro")]
        [StringLength(50, MinimumLength = 4)]
        public string Titulo { get; set; }

        [Required]
        [Display(Name = "Informe o nome do autor")]
        [StringLength(35, MinimumLength = 4)]
        public string Autor { get; set; }

        [Required]
        public int Edicao { get; set; }
        
        [Required]
        public int Ano { get; set; }
        
        [Required]
        public int Paginas { get; set; }

        [Required]
        [Display(Name = "Informe o genero do livro")]
        [StringLength(35, MinimumLength = 4)]
        public string Genero { get; set; }

        [Required]
        [Display(Name = "Informe o nome da editora")]
        [StringLength(35, MinimumLength = 4)]
        public string Editora { get; set; }

        public Status Status { get; set; }

        public Livro() { }

        public Livro(string titulo, string autor, int edicao, int ano, int paginas, string genero, string editora)
        {
            Titulo = titulo;
            Autor = autor;
            Edicao = edicao;
            Ano = ano;
            Paginas = paginas;
            Genero = genero;
            Editora = editora;
            Status = Status.Disponivel;
        }
    }
}
