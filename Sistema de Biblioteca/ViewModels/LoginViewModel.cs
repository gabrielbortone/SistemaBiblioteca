using System.ComponentModel.DataAnnotations;

namespace Sistema_de_Biblioteca.ViewModels
{
    public class LoginViewModel
    {
        [Display(Name = "Informe seu UserName")]
        [StringLength(12, MinimumLength = 3)]
        public string Username { get; set; }

        [Display(Name = "Informe a sua senha")]
        [StringLength(12, MinimumLength = 3)]
        [DataType(DataType.Password)]
        public string Senha { get; set; }

        public bool Rememberme { get; set; }
    }
}
