using System.ComponentModel.DataAnnotations;

namespace Sistema_de_Biblioteca.Models.ValueObjects
{
    public class EnderecoAluno
    {
        [Required]
        public int AlunoId { get; set; }
        public Aluno Aluno { get; set; }

        [Required]
        public int EnderecoId { get; set; }
        public Endereco Endereco { get; set; }
    }
}
