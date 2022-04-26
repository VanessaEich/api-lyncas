using ApiLyncas.DTO.Request;
using ApiLyncas.Models;

namespace ApiLyncas.Repository
{
    public interface IPessoaRepository
    {
        Task<IEnumerable<Pessoa>> BuscarTodos();
        Task<Pessoa> BuscarPorId(int id);
        Task<Pessoa> AdicionarPessoa(Pessoa pessoa);
        Task<Pessoa> AtualizarPessoa(Pessoa pessoa);
        void DeletarPessoa(Pessoa pessoa);
        Task<Pessoa> BuscarPessoaPeloLogin(LoginDTO loginDto);

    }
}
