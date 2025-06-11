using AutoMapper;
using Zorgi.Api.ViewModels;
using Zorgi.Business.Models;

namespace Zorgi.Api.Configuration
{
    public class AutoMapperConfig : Profile
    {
        public AutoMapperConfig()
        {
            CreateMap<Cuidador, CuidadorViewModel>().ReverseMap();

            CreateMap<Assistido, AssistidoViewModel>()
                .ForMember(dest => dest.NomeDoCuidadorPrincipal, opt => opt.MapFrom(src => src.CuidadorPrincipal.Nome));

            CreateMap<AssistidoViewModel, Assistido>();

            CreateMap<ReceitaMedica, ReceitaMedicaViewModel>().ReverseMap();
        }
    }
}
