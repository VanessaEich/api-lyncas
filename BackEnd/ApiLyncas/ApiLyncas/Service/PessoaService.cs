using ApiLyncas.ApiLyncasInterfaces;
using ApiLyncas.DTO.Request;
using ApiLyncas.DTO.Response;
using ApiLyncas.Hash;
using ApiLyncas.Models;
using ApiLyncas.Repository;
using AutoMapper;

namespace ApiLyncas.Service
{
    public class PessoaService : IPessoaService
    {
        private readonly IPessoaRepository _repository;
        private readonly IMapper _mapper;
        public PessoaService(IPessoaRepository repository, IMapper mapper)
        {
            _repository = repository;
            _mapper = mapper;
        }
        public async Task<ListarPessoaDTO> AdicionarPessoa(PessoaDTO pessoaDto)
        {
            pessoaDto.Senha = HashSenha.HashingSenha(pessoaDto.Senha);
            Pessoa usuario = _mapper.Map<Pessoa>(pessoaDto);
            Pessoa novoUsuario = await _repository.AdicionarPessoa(usuario);
            return _mapper.Map<ListarPessoaDTO>(novoUsuario);
        }
        public async Task<ListarPessoaDTO> AtualizarPessoa(int id, AtualizarPessoaDTO atualizarpessoaDto)
        {
            Pessoa pessoaId = await _repository.BuscarPorId(id);
            if (pessoaId == null)
                throw new BadHttpRequestException("Não existe usuário com o id informado");

            if (atualizarpessoaDto.Senha == null || atualizarpessoaDto.Senha.Length == 0)
            {
                atualizarpessoaDto.Senha = pessoaId.Autenticacao.Senha;
            }

            if (atualizarpessoaDto.Senha != null && atualizarpessoaDto.Senha != "")
            {
                atualizarpessoaDto.Senha = HashSenha.HashingSenha(atualizarpessoaDto.Senha);
            }

            Pessoa pessoaDb = _mapper.Map(atualizarpessoaDto, pessoaId);
            Pessoa pessoaAtualizada = await _repository.AtualizarPessoa(pessoaDb);
            return _mapper.Map<ListarPessoaDTO>(pessoaAtualizada);
        }
        public async Task<ListarPessoaDTO> BuscarPorId(int id)
        {
            var pessoa = await _repository.BuscarPorId(id);
            if (pessoa == null)
                throw new BadHttpRequestException("Não existe usuário com o id informado");
            return _mapper.Map<ListarPessoaDTO>(pessoa);
        }
        public async Task<IEnumerable<ListarPessoaDTO>> BuscarTodos()
        {
            var listaPessoa = await _repository.BuscarTodos();
            return _mapper.Map<List<ListarPessoaDTO>>(listaPessoa); ;
        }
        public async Task DeletarPessoa(int id)
        {
            Pessoa pessoa = await _repository.BuscarPorId(id);
            if (pessoa == null)
            {
                throw new BadHttpRequestException(@"Não existe usuário com o id informado");
            }
            _repository.DeletarPessoa(pessoa);
        }
        public async Task<Pessoa> BuscarPessoaPeloLogin(LoginDTO loginDto)
        {
            return await _repository.BuscarPessoaPeloLogin(loginDto);
        }
    }
}

