using AutoMapper;
using Livraria.Application.ViewModels;
using Livraria.Domain.Entities;

namespace Livraria.Application.AutoMapper
{
    public class MappingProfile : Profile
    {
        public MappingProfile()
        {
            //* DOMAIN TO VIEWMODEL *//
            CreateMap<Livro, LivroViewModel>();
            
            //* VIEWMODEL TO DOMAIN *//
            CreateMap<LivroViewModel, Livro>();
        }
    }
}
