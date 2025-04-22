using AutoMapper;
using Biblioteca.Domain.Entities;
using Biblioteca.Application.DTOs;
using System.Security.Cryptography;
using System.Text;

namespace Biblioteca.Application.Mappings
{
    public class AutoMapperProfile : Profile
    {
        public AutoMapperProfile()
        {
            // Mapeamento para usuários
            CreateMap<Usuario, UsuarioDto>().ReverseMap();

            // Mapeamento ajustado: Senha → SenhaHash para criação de usuário
            CreateMap<CriarUsuarioDto, Usuario>()
                .ForMember(dest => dest.SenhaHash, opt => opt.MapFrom(src => GerarHash(src.Senha)));

            // Mapeamentos dos livros
            CreateMap<Livro, LivroDto>().ReverseMap();
            CreateMap<Livro, CriarLivroDto>().ReverseMap();

            // Mapeamento para locações (para retorno de detalhes)
            CreateMap<Locacao, DetalhesLocacaoDto>()
                .ForMember(dest => dest.TituloLivro, opt => opt.MapFrom(src => src.Livro.Titulo))
                .ForMember(dest => dest.NomeUsuario, opt => opt.MapFrom(src => src.Usuario.Nome))
                .ForMember(dest => dest.DataLocacao, opt => opt.MapFrom(src => src.DataRetirada))
                .ForMember(dest => dest.DataDevolucaoPrevista, opt => opt.MapFrom(src => src.DataDevolucaoPrevista))
                .ForMember(dest => dest.DataDevolucaoReal, opt => opt.MapFrom(src => src.DataDevolucaoReal))
                .ForMember(dest => dest.ValorLocacao, opt => opt.MapFrom(src => src.ValorLocacao))
                .ForMember(dest => dest.Multa, opt => opt.MapFrom(src => src.Multa))
                .ForMember(dest => dest.ValorRecebido, opt => opt.MapFrom(src => src.ValorRecebido))
                .ForMember(dest => dest.Status, opt => opt.MapFrom(src => src.Status));

            // Novo mapeamento: criação de locações a partir de CriarLocacaoDto
            CreateMap<CriarLocacaoDto, Locacao>()
                .ForMember(dest => dest.LivroId, opt => opt.MapFrom(src => src.LivroId))
                .ForMember(dest => dest.UsuarioId, opt => opt.MapFrom(src => src.UsuarioId))
                .ForMember(dest => dest.DataRetirada, opt => opt.MapFrom(src => src.DataLocacao))
                .ForMember(dest => dest.DataDevolucaoPrevista, opt => opt.MapFrom(src => src.DataDevolucaoPrevista));
        }

        private static string GerarHash(string senha)
        {
            using var sha256 = SHA256.Create();
            var bytes = Encoding.UTF8.GetBytes(senha);
            var hash = sha256.ComputeHash(bytes);
            return Convert.ToBase64String(hash);
        }
    }
}
