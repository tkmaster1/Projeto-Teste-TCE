using AutoMapper;
using Livraria.Application.ViewModels;
using Livraria.Domain.Entities;

namespace Livraria.Application.AutoMapper.CustomProfiles.DomainToViewModelProfile
{
    public class LivroToLivroVmProfileConfig : Profile
    {
        protected LivroToLivroVmProfileConfig()
        {
            CreateMap<LivroViewModel, Livro>()
                .ForMember(src => src.LivroId, opt => opt.MapFrom(x => x.LivroId))
                .ForMember(src => src.LivroISBN, opt => opt.MapFrom(x => x.LivroISBN))
                .ForMember(src => src.NomeLivro, opt => opt.MapFrom(x => x.NomeLivro))
                .ForMember(src => src.NomeAutor, opt => opt.MapFrom(x => x.NomeAutor))
                .ForMember(src => src.Preco, opt => opt.MapFrom(x => x.Preco))
                .ForMember(src => src.DataPublicacao, opt => opt.MapFrom(x => x.DataPublicacao))
                .ForMember(src => src.DataInclusao, opt => opt.MapFrom(x => x.DataInclusao))
                .ForMember(src => src.DataAlteracao, opt => opt.MapFrom(x => x.DataAlteracao))
                .ForMember(src => src.Ativo, opt => opt.MapFrom(x => x.Ativo))
                //Upload
                .ForMember(src => src.FileName, opt => opt.MapFrom(x => x.FileName))
                .ForMember(src => src.FileLength, opt => opt.MapFrom(x => x.FileLength))
                .ForMember(src => src.FileCreatedTime, opt => opt.MapFrom(x => x.FileCreatedTime));
        }
    }
}
