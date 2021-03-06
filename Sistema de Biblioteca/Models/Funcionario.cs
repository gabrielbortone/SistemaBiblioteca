﻿using Microsoft.AspNetCore.Identity;
using Sistema_de_Biblioteca.Models.ValueObjects;
using System;
using System.ComponentModel.DataAnnotations;

namespace Sistema_de_Biblioteca.Models
{
    public class Funcionario : IdentityUser
    {

        [Required]
        [Display(Name = "Informe o seu nome")]
        [StringLength(30, MinimumLength = 3)]
        public string Nome { get; set; }

        [Required]
        [Display(Name = "Informe o seu sobrenome")]
        [StringLength(30, MinimumLength = 3)]
        public string Sobrenome { get; set; }

        [Display(Name = "Informe o seu número de CPF")]
        [StringLength(11, MinimumLength = 11)]
        public string CPF { get; set; }

        public EnderecoFuncionario Endereco { get; set; }
        public TelefoneFuncionario Telefone { get; set; }


        [Required]
        [Display(Name = "Informe o cargo do funcionário")]
        [StringLength(30, MinimumLength = 4)]
        public string Cargo { get; set; }

        [Required]
        [Display(Name = "Informe a data de admissão")]
        public DateTime DataAdmissao { get; set; }
        public DateTime? DataDemissao { get; set; }

        public Funcionario(){}
        public Funcionario(string id, string nome, string sobrenome, string cpf, string username,
            EnderecoFuncionario endereco, TelefoneFuncionario telefone, string email, string cargo, DateTime dataAdmissao)
        {
            Id = id;
            Nome = nome;
            Sobrenome = sobrenome;
            CPF = cpf;
            UserName = username;
            Endereco = endereco;
            Telefone = telefone;
            Email = email;
            Cargo = cargo;
            DataAdmissao = dataAdmissao;
        }
        public Funcionario(string nome, string sobrenome, string cpf, string username,
            EnderecoFuncionario endereco, TelefoneFuncionario telefone, string email, string cargo, DateTime dataAdmissao)
        {
            Nome = nome;
            Sobrenome = sobrenome;
            CPF = cpf;
            UserName = username;
            Endereco = endereco;
            Telefone = telefone;
            Email = email;
            Cargo = cargo;
            DataAdmissao = dataAdmissao;
        }
    }
}
