using ApiLyncas.ApiLyncasInterfaces;
using System.Net.Http.Headers;
using System.Text;

namespace ApiLyncas.Middlewares
{
    public class BasicAuthMiddleware
    {
        private readonly RequestDelegate _next;

        public BasicAuthMiddleware(RequestDelegate next)
        {
            _next = next;
        }
        public async Task Invoke(HttpContext context, ILoginService loginService)
        {
            try
            {
                var authHeader = AuthenticationHeaderValue.Parse(context.Request.Headers["Authorization"]);
                var credentialBytes = Convert.FromBase64String(authHeader.Parameter);
                var credentials = Encoding.UTF8.GetString(credentialBytes).Split(':', 2);
                var email = credentials[0];
                var senha = credentials[1];

                DTO.Request.LoginDTO loginDTO = new DTO.Request.LoginDTO { Email = email, Senha = senha };
                context.Items["Pessoa"] = await loginService.ValidarPessoaExistentePeloLogin(loginDTO);

            }
            catch
            {

            }
            await _next(context);
        }
    }
}
