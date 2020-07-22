using Microsoft.AspNetCore.Identity;

namespace Sistema_de_Biblioteca.Models
{
    public class Account : IdentityUser
    {
        public int Id { get; set; }
        public Funcionario Funcionario { get; set; }
        public int FuncionarioId { get; set; }
    }
}
