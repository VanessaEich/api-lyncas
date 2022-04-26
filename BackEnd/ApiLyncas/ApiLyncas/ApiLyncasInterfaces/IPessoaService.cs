using ApiLyncas.DTO.Request;
using ApiLyncas.DTO.Response;
using ApiLyncas.Models;

namespace ApiLyncas.ApiLyncasInterfaces
{
    public interface IPessoaService
    {
        Task<IEnumerable<ListarPessoaDTO>> BuscarTodos();
        Task<ListarPessoaDTO> BuscarPorId(int id);
        Task<ListarPessoaDTO> AdicionarPessoa(PessoaDTO pessoaDto);
        Task<ListarPessoaDTO> AtualizarPessoa(int id, AtualizarPessoaDTO pessoaDto);
        Task DeletarPessoa(int id);
        Task<Pessoa> BuscarPessoaPeloLogin(LoginDTO loginDto);
    }
}
