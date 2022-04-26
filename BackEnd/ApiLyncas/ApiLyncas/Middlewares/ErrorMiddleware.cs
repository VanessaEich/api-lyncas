using Newtonsoft.Json;

namespace ApiLyncas
{
    public class ErrorMiddleware
    {
        private readonly RequestDelegate next;

        public ErrorMiddleware(RequestDelegate next)
        {
            this.next = next;
        }
        public async Task Invoke(HttpContext context)
        {
            try
            {
                await next(context);
            }
            catch (BadHttpRequestException ex)
            {
                await HandleExceptionAsync(context, ex, 400);
            }
            catch (UnauthorizedAccessException ex)
            {
                await HandleExceptionAsync(context, ex, 401);
            }
            catch (Microsoft.EntityFrameworkCore.DbUpdateException ex)
            {
                Exception excecaoTratada = new Exception("E-mail já existe!");
               await HandleExceptionAsync(context, excecaoTratada, 500);
            }
            catch (Exception ex)
            {
                await HandleExceptionAsync(context, ex, 500);
            }
        }
        private Task HandleExceptionAsync(HttpContext context, Exception ex, int statusCode)
        {
            ErrosResposta errorResponse;
            if (Environment.GetEnvironmentVariable("ASPNETCORE_ENVIRONMENT") == "Development" ||
                Environment.GetEnvironmentVariable("ASPNETCORE_ENVIRONMENT") == "Qa")
            {
                errorResponse = new ErrosResposta(statusCode.ToString(),
                                                      $"{ex.Message} {ex?.InnerException?.Message}");
            }
            else
            {
                errorResponse = new ErrosResposta(statusCode.ToString(),
                                                      "Não foi possível executar a solicitação.");
            }

            context.Response.StatusCode = statusCode;

            var result = JsonConvert.SerializeObject(errorResponse);
            context.Response.ContentType = "application/json";
            return context.Response.WriteAsync(result);
        }
    }
}

