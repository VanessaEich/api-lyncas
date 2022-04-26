using ApiLyncas.ApiLyncasInterfaces;
using ApiLyncas.DTO.Request;
using ApiLyncas.DTO.Response;
using Microsoft.AspNetCore.Mvc;

namespace ApiLyncas.Controllers
{
    [Route("api/[controller]")]
    [ApiController]
    public class LoginController : ControllerBase
    {
        private readonly ILoginService _loginService;
        public LoginController(ILoginService loginService)
        {
            _loginService = loginService;
        }

        [HttpPost("login")]
        public async Task<ActionResult<ListarPessoaDTO>> Login(LoginDTO loginDto)
        {
            return await _loginService.ValidarPessoaExistentePeloLogin(loginDto);
        }
    }
}
