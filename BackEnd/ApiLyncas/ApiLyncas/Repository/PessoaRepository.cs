using ApiLyncas.Context;
using ApiLyncas.DTO.Request;
using ApiLyncas.Models;
using Microsoft.EntityFrameworkCore;

namespace ApiLyncas.Repository
{
    public class PessoaRepository : IPessoaRepository
    {
        private readonly AppDbContext _context;
        public PessoaRepository(AppDbContext contexto)
        {
            _context = contexto;
        }
        public async Task<Pessoa> AdicionarPessoa(Pessoa pessoa)
        {
            await _context.AddAsync(pessoa);
            await _context.SaveChangesAsync();
            return pessoa;
        }
        public async Task<IEnumerable<Pessoa>> BuscarTodos()
        {
            List<Pessoa> listaPessoa = await _context.Pessoa.Include(x => x.Autenticacao).AsNoTracking().ToListAsync();
            return listaPessoa;
        }
        public async Task<Pessoa> BuscarPorId(int id)
        {
            Pessoa pessoa = await _context.Pessoa.Include(x => x.Autenticacao).SingleOrDefaultAsync(x => x.IdPessoa == id);
            return pessoa;
        }
        public async Task<Pessoa> AtualizarPessoa(Pessoa pessoa)
        {
            _context.Update(pessoa);
            await _context.SaveChangesAsync();
            return pessoa;
        }
        public void DeletarPessoa(Pessoa pessoa)
        {
            _context.Pessoa.Remove(pessoa);
            _context.SaveChanges();
        }
        public async Task<Pessoa> BuscarPessoaPeloLogin(LoginDTO loginDto)
        {
            Pessoa pessoa = await _context.Pessoa.Include(x => x.Autenticacao)
                .AsNoTracking().FirstOrDefaultAsync(x => x.Email == loginDto.Email);
            return pessoa;
        }
    }
}
