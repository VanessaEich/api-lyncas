using System.ComponentModel.DataAnnotations;

namespace ApiLyncas.DTO.Request
{
    public class PessoaDTO
    {
        [Required(ErrorMessage = "Campo nome é obrigatório.")]
        [StringLength(50, MinimumLength = 3, ErrorMessage = "Mínimo 3 caracteres.")]
        public string? Nome { get; set; }

        [Required(ErrorMessage = "Campo sobrenome é obrigatório.")]
        [StringLength(50, MinimumLength = 3, ErrorMessage = "Mínimo 3 caracteres.")]
        public string? Sobrenome { get; set; }

        [Required(ErrorMessage = "Campo e-mail é obrigatório.")]
        [RegularExpression(@"^([\w\.\-]+)@([\w\-]+)((\.(\w){2,3})+)$", ErrorMessage = "E-mail deve conter @ e .")]
        public string? Email { get; set; }

        [Required(ErrorMessage = "Campo telefone é obrigatório!")]
        [RegularExpression(@"[0-9]{2}([9]{1})?([0-9]{4})([0-9]{4})$", ErrorMessage = "Telefone somente números, formato XX XXXXXXXXX ou XX XXXXXXXX")]
        public string? Telefone { get; set; }

        [Required(ErrorMessage = "Campo data de nascimento é obrigatório.")]
        public DateTime DataNascimento { get; set; }

        [Required(ErrorMessage = "Campo senha é obrigatório.")]
        [RegularExpression("^(?=.*[0-9])(?=.*[a-zA-Z])[a-zA-Z0-9]{6,}$", ErrorMessage = "Senha deve conter 6 caracteres e pelo menos um número.")]
        public string? Senha { get; set; }
        public bool Status { get; set; }
    }
}
