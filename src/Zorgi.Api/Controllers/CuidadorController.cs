using AutoMapper;
using Microsoft.AspNetCore.Mvc;
using Zorgi.Api.ViewModels;
using Zorgi.Business.Models;
using Zorgi.Business.Notifications;
using Zorgi.Business.Repositories;
using Zorgi.Business.Services;

namespace Zorgi.Api.Controllers
{
    [Route("api/cuidadores")]
    public class CuidadorController(ICuidadorRepository cuidadorRepository,
                                    ICuidadorService cuidadorService,
                                    IMapper mapper,
                                    INotifier notifier) : MainController(notifier)
    {
        readonly ICuidadorRepository _cuidadorRepository = cuidadorRepository;
        readonly ICuidadorService _cuidadorService = cuidadorService;
        readonly IMapper _mapper = mapper;

        [HttpGet]
        public async Task<IEnumerable<CuidadorViewModel>> ObterTodos()
        {
            var cuidadores = _mapper.Map<IEnumerable<CuidadorViewModel>>(await _cuidadorRepository.ObterTodos());
            return cuidadores;
        }

        [HttpGet("{id:guid}")]
        public async Task<ActionResult<CuidadorViewModel>> ObterPorId(Guid id)
        {
            var cuidadorViewModel = await ObterCuidadorAssistidos(id);

            if (cuidadorViewModel == null) return NotFound();

            return cuidadorViewModel;
        }

        async Task<CuidadorViewModel> ObterCuidadorAssistidos(Guid id)
        {
            return _mapper.Map<CuidadorViewModel>(await _cuidadorRepository.ObterCuidadorAssistidos(id));
        }

        [HttpPost]
        public async Task<ActionResult<CuidadorViewModel>> Adicionar(CuidadorViewModel cuidadorViewModel)
        {
            if (!ModelState.IsValid) return CustomResponse(ModelState);

            var cuidador = _mapper.Map<Cuidador>(cuidadorViewModel);
            var sucesso = await _cuidadorService.Adicionar(cuidador);

            if (!sucesso) return CustomResponse(ModelState);

            return CreatedAtAction(nameof(ObterPorId), new { id = cuidador.Id }, cuidadorViewModel);
        }

        [HttpPut("{id:guid}")]
        public async Task<ActionResult<CuidadorViewModel>> Atualizar(Guid id, CuidadorViewModel cuidadorViewModel)
        {
            if (id != cuidadorViewModel.Id)
            {
                NotificarErro("O Id informado difere do Id do cuidador.");
                return CustomResponse(cuidadorViewModel);
            }

            if (!ModelState.IsValid) return CustomResponse(ModelState);

            await _cuidadorService.Atualizar(_mapper.Map<Cuidador>(cuidadorViewModel));

            return CustomResponse(cuidadorViewModel);
        }

        [HttpDelete("{id:guid}")]
        public async Task<ActionResult> Excluir(Guid id)
        {
            var cuidadorViewModel = await ObterCuidadorAssistidos(id);

            if (cuidadorViewModel == null) return NotFound();
            
            await _cuidadorService.Remover(id);

            return CustomResponse(cuidadorViewModel);
        }
    }
}
