using System.ComponentModel.DataAnnotations;
using System.ComponentModel.DataAnnotations.Schema;

namespace ApiLyncas.Models
{
    [Table("pessoa")]
    public class Pessoa
    {
        [Key]
        public int IdPessoa { get; set; }

        [Required]
        [MaxLength(100)]
        public string? Nome { get; set; }

        [Required]
        [MaxLength(100)]
        public string? Sobrenome { get; set; }

        [Required]
        [MaxLength(50)]
        public string? Email { get; set; }

        [Required]
        [MaxLength(14)]
        public string? Telefone { get; set; }

        [Required]
        [Column(TypeName = "Date")]
        public DateTime DataNascimento { get; set; }
        public Autenticacao Autenticacao { get; set; }
    }
}
