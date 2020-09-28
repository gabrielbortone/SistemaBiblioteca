using System.ComponentModel.DataAnnotations;

namespace Sistema_de_Biblioteca.Models.ValueObjects
{
    public class EnderecoFuncionario 
    {
        [Required]
        public string FuncionarioId { get; set; }
        public Funcionario Funcionario { get; set; }

        [Required]
        public int EnderecoId { get; set; }
        public Endereco Endereco { get; set; }
    }
}
