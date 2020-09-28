using Sistema_de_Biblioteca.Models.ValueObjects;
using System.ComponentModel.DataAnnotations;

namespace Sistema_de_Biblioteca.Models
{
    public class Aluno
    {
        public int AlunoId { get; set; }

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

        public EnderecoAluno Endereco { get; set; }
        public TelefoneAluno Telefone { get; set; }


        [Required(ErrorMessage = "Informe o seu email")]
        [RegularExpression(".+\\@.+\\..+", ErrorMessage = "Informe um email válido...")]
        public string Email { get; set; }
        [Display(Name = "Informe o seu número de matrícula")]

        [StringLength(12, MinimumLength = 12)]
        public string Matricula { get; set; }

        public Aluno(){}
        public Aluno(string nome, string sobrenome, string CPF, EnderecoAluno endereco, TelefoneAluno telefone, string email, string matricula)
        {
            Nome = nome;
            Sobrenome = sobrenome;
            this.CPF = CPF;
            Endereco = endereco;
            Telefone = telefone;
            Email = email;
            Matricula = matricula;
        }

        public Aluno(int alunoId, string nome, string sobrenome, string cPF, EnderecoAluno endereco, TelefoneAluno telefone, string email, string matricula)
        {
            AlunoId = alunoId;
            Nome = nome;
            Sobrenome = sobrenome;
            CPF = cPF;
            Endereco = endereco;
            Telefone = telefone;
            Email = email;
            Matricula = matricula;
        }
    }
}
