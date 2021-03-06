﻿using System.ComponentModel.DataAnnotations;

namespace Sistema_de_Biblioteca.Models.ValueObjects
{
    public class Endereco
    {
        public int EnderecoId { get; set; }

        [Required]
        [Display(Name = "Informe o CEP:")]
        [StringLength(9, MinimumLength = 9)]
        public string CEP { get; set; }

        [Required]
        [Display(Name = "Informe o bairro:")]
        [StringLength(30, MinimumLength = 4)]
        public string Bairro { get; set; }

        [Required]
        [Display(Name = "Informe a cidade:")]
        [StringLength(35, MinimumLength = 4)]
        public string Cidade { get; set; }

        [Required]
        [Display(Name = "Informe o Estado:")]
        [StringLength(35, MinimumLength = 4)]
        public string Estado { get; set; }

        public Endereco()
        {

        }
        public Endereco(string cep, string bairro, string cidade, string estado)
        {
            CEP = cep;
            Bairro = bairro;
            Cidade = cidade;
            Estado = estado;
        }
    }
}
