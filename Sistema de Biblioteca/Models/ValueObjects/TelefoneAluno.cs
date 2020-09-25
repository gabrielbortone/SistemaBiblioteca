using System.ComponentModel.DataAnnotations;

namespace Sistema_de_Biblioteca.Models.ValueObjects
{
    public class TelefoneAluno
    {
        [Required]
        public int AlunoId { get; set; }
        public Aluno Aluno { get; set; }

        [Required]
        public int TelefoneId { get; set; }
        public Telefone Telefone { get; set; }
    }
}
