using ApiLyncas.ApiLyncasInterfaces;
using ApiLyncas.Authorization;
using ApiLyncas.DTO.Request;
using ApiLyncas.DTO.Response;
using Microsoft.AspNetCore.Mvc;

namespace ApiLyncas.Controllers
{
    [Authorize]
    [Route("api/[controller]")]
    [ApiController]
    public class PessoasController : ControllerBase
    {
        private readonly IPessoaService _pessoaService;
        public PessoasController(IPessoaService pessoaService)
        {
            _pessoaService = pessoaService;
        }

        [HttpGet("todos")]
        public async Task<ActionResult<IEnumerable<ListarPessoaDTO>>> BuscarTodos()
        {
            return Ok(await _pessoaService.BuscarTodos());
        }

        [HttpGet("{id}")]
        public async Task<ActionResult<ListarPessoaDTO>> BuscarPorId(int id)
        {
            return await _pessoaService.BuscarPorId(id);
        }

        [HttpPost("cadastro")]
        public async Task<ActionResult<ListarPessoaDTO>> AdicionarPessoa(PessoaDTO pessoaDto)
        {
            return await _pessoaService.AdicionarPessoa(pessoaDto);
        }

        [HttpPut("{id}")]
        public async Task<ActionResult<ListarPessoaDTO>> AtualizarPessoa(int id, AtualizarPessoaDTO atualizarpessoaDto)
        {
            return await _pessoaService.AtualizarPessoa(id, atualizarpessoaDto);
        }

        [HttpDelete("{id}")]
        public async Task<ActionResult> DeletarPessoa(int id)
        {
            await _pessoaService.DeletarPessoa(id);
            return Ok();
        }
    }
}
