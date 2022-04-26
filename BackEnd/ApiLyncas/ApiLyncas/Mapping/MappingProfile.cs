using ApiLyncas.DTO.Request;
using ApiLyncas.DTO.Response;
using ApiLyncas.Models;
using AutoMapper;
namespace ApiLyncas.Mapping
{
    public class MappingProfile : Profile
    {
        public MappingProfile()
        {
            CreateMap<Pessoa, PessoaDTO>()
                .ForMember(x => x.Status, a => a.MapFrom(p => p.Autenticacao.Status))
                .ForMember(x => x.Senha, a => a.MapFrom(p => p.Autenticacao.Senha)).ReverseMap();

            CreateMap<Pessoa, ListarPessoaDTO>()
                .ForMember(x => x.Status, a => a.MapFrom(p => p.Autenticacao.Status)).ReverseMap();

            CreateMap<Pessoa, AtualizarPessoaDTO>()
                .ForMember(x => x.Status, a => a.MapFrom(p => p.Autenticacao.Status))
                .ForMember(x => x.Senha, a => a.MapFrom(p => p.Autenticacao.Senha)).ReverseMap();

            CreateMap<ListarPessoaDTO, LoginDTO>()
                .ForMember(x => x.Email, a => a.MapFrom(p => p.Email)).ReverseMap();
        }
    }
}
