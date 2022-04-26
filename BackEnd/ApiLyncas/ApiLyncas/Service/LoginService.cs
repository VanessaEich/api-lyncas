using ApiLyncas.ApiLyncasInterfaces;
using ApiLyncas.DTO.Request;
using ApiLyncas.DTO.Response;
using ApiLyncas.Hash;
using ApiLyncas.Models;
using ApiLyncas.Repository;
using AutoMapper;

namespace ApiLyncas.Service
{
    public class LoginService : ILoginService
    {
        private readonly IPessoaService _pessoaService;
        private readonly IMapper _mapper;
        public LoginService(IPessoaService pessoaService, IMapper mapper)
        {
            _pessoaService = pessoaService;
            _mapper = mapper;
        }
        public async Task<ListarPessoaDTO> ValidarPessoaExistentePeloLogin(LoginDTO loginDto)
        {
            Pessoa pessoaLogin = await _pessoaService.BuscarPessoaPeloLogin(loginDto);
            loginDto.Senha = HashSenha.HashingSenha(loginDto.Senha);
            if (pessoaLogin == null)
            {
                throw new BadHttpRequestException("Email ou senha inválidos");
            }
            else if (loginDto.Senha != pessoaLogin.Autenticacao.Senha)
            {
                throw new BadHttpRequestException("Email ou senha inválidos");
            }
            return _mapper.Map<ListarPessoaDTO>(pessoaLogin);
        }
    }
}
