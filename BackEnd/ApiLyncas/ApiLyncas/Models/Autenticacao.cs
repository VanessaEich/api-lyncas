using System.ComponentModel.DataAnnotations;
using System.ComponentModel.DataAnnotations.Schema;

namespace ApiLyncas.Models
{
    [Table("autenticacao")]
    public class Autenticacao
    {
        [Key]
        public int Id { get; set; }

        [Required]
        [MaxLength(255)]
        public string? Senha { get; set; }

        [Required]
        public bool Status { get; set; }

        [ForeignKey("IdPessoa")]
        public int IdPessoa { get; set; }

        [NotMapped()]
        public virtual Pessoa? Pessoa { get; set; }
    }
}
