using AutoMapper;
using Microsoft.AspNetCore.Mvc;
using Zorgi.Api.ViewModels;
using Zorgi.Business.Models;
using Zorgi.Business.Notifications;
using Zorgi.Business.Repositories;
using Zorgi.Business.Services;

namespace Zorgi.Api.Controllers
{
    [Route("api/assistidos")]
    public class AssistidosController(IAssistidoRepository assistidoRepository,
                                    IAssistidoService assistidoService,
                                    IMapper mapper,
                                    INotifier notifier) : MainController(notifier)
    {
        readonly IAssistidoRepository _assistidoRepository = assistidoRepository;
        readonly IAssistidoService _assistidoService = assistidoService;
        readonly IMapper _mapper = mapper;

        [HttpGet]
        public async Task<IEnumerable<AssistidoViewModel>> ObterTodos()
        {
            var assistidos = _mapper.Map<IEnumerable<AssistidoViewModel>>(await _assistidoRepository.ObterTodos());
            return assistidos;
        }

        [HttpGet("{id:guid}")]
        public async Task<ActionResult<AssistidoViewModel>> ObterPorId(Guid id)
        {
            var assistidoViewModel = await ObterAssistidoCuidadores(id);

            if (assistidoViewModel == null) return NotFound();

            return assistidoViewModel;
        }

        async Task<AssistidoViewModel> ObterAssistidoCuidadores(Guid id)
        {
            return _mapper.Map<AssistidoViewModel>(await _assistidoRepository.ObterAssistidoCuidadores(id));
        }

        [HttpPost]
        public async Task<ActionResult<AssistidoViewModel>> Adicionar(AssistidoViewModel assistidoViewModel)
        {
            if (!ModelState.IsValid) return CustomResponse(ModelState);

            var assistido = _mapper.Map<Assistido>(assistidoViewModel);
            var sucesso = await _assistidoService.Adicionar(assistido);

            if (!sucesso) return CustomResponse(ModelState);

            return CreatedAtAction(nameof(ObterPorId), new { id = assistido.Id }, assistidoViewModel);
        }

        [HttpPut("{id:guid}")]
        public async Task<ActionResult<AssistidoViewModel>> Atualizar(Guid id, AssistidoViewModel assistidoViewModel)
        {
            if (id != assistidoViewModel.Id)
            {
                NotificarErro("O Id informado difere do Id do assistido.");
                return CustomResponse(assistidoViewModel);
            }

            if (!ModelState.IsValid) return CustomResponse(ModelState);

            await _assistidoService.Atualizar(_mapper.Map<Assistido>(assistidoViewModel));

            return CustomResponse(assistidoViewModel);
        }

        [HttpDelete("{id:guid}")]
        public async Task<ActionResult> Excluir(Guid id)
        {
            var assistidoViewModel = await ObterAssistidoCuidadores(id);

            if (assistidoViewModel == null) return NotFound();
            
            await _assistidoService.Remover(id);

            return CustomResponse(assistidoViewModel);
        }
    }
}
