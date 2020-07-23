using Microsoft.AspNetCore.Identity;

namespace Sistema_de_Biblioteca.Models
{
    public class Account : IdentityUser
    {
        public Funcionario Funcionario { get; set; }
        public int FuncionarioId { get; set; }
    }
}
