using System.ComponentModel.DataAnnotations;

namespace Sistema_de_Biblioteca.Models.ValueObjects
{
    public class TelefoneFuncionario
    {
        [Required]
        public string FuncionarioId { get; set; }
        public Funcionario Funcionario { get; set; }

        [Required]
        public int TelefoneId { get; set; }
        public Telefone Telefone { get; set; }
    }
}
