using Microsoft.AspNetCore.Identity;
using System;

namespace Sistema_de_Biblioteca.Models
{
    public class Account : IdentityUser
    {
        public Funcionario Funcionario { get; set; }
        public int Id_Funcionario { get; set; }

        public static implicit operator Account(Funcionario v)
        {
            throw new NotImplementedException();
        }
    }
}
