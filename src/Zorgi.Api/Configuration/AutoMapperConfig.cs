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
            CreateMap<Assistido, AssistidoViewModel>().ReverseMap();
            CreateMap<ReceitaMedica, ReceitaMedicaViewModel>().ReverseMap();
        }
    }
}
