namespace ApiLyncas.DTO.Response
{
    public class ListarPessoaDTO
    {
        public int IdPessoa { get; set; }
        public string? Nome { get; set; }
        public string? Sobrenome { get; set; }
        public string? Email { get; set; }
        public string? Telefone { get; set; }
        public DateTime DataNascimento { get; set; }
        public bool Status { get; set; }
    }
}
