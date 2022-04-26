using ApiLyncas.DTO.Request;
using ApiLyncas.DTO.Response;

namespace ApiLyncas.ApiLyncasInterfaces
{
    public interface ILoginService
    {
        Task<ListarPessoaDTO> ValidarPessoaExistentePeloLogin(LoginDTO loginDto);
    }
}
