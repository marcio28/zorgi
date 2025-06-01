using AutoMapper;
using Microsoft.AspNetCore.Mvc;
using Zorgi.Api.ViewModels;
using Zorgi.Business.Repositories;

namespace Zorgi.Api.Controllers
{
    [ApiController]
    [Route("api/cuidadores")]
    public class CuidadorController(ICuidadorRepository cuidadorRepository, 
                                    IMapper mapper) : MainController
    {
        private readonly ICuidadorRepository _cuidadorRepository = cuidadorRepository;
        private readonly IMapper _mapper = mapper;

        public async Task<IEnumerable<CuidadorViewModel>> ObterTodos()
        {
            var cuidadores = _mapper.Map<IEnumerable<CuidadorViewModel>>(await _cuidadorRepository.ObterTodos());
            return cuidadores;
        }
    }
}
