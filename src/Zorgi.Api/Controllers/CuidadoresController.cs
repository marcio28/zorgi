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
    public class CuidadoresController(ICuidadorRepository cuidadorRepository,
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

            var nomeDaFoto = $"{Guid.NewGuid()}_{cuidadorViewModel.Foto}";
            if (!UploadArquivo(cuidadorViewModel.FotoUpload, nomeDaFoto)) return CustomResponse(cuidadorViewModel);

            cuidadorViewModel.Foto = nomeDaFoto;

            var cuidador = _mapper.Map<Cuidador>(cuidadorViewModel);

            if (!await _cuidadorService.Adicionar(cuidador)) return CustomResponse(ModelState);

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

            var cuidadorExistenteViewModel = await ObterCuidadorAssistidos(id);
            if (cuidadorExistenteViewModel == null) return NotFound();

            cuidadorViewModel.Foto = cuidadorExistenteViewModel.Foto;
            if (!ModelState.IsValid) return CustomResponse(ModelState);

            if (cuidadorViewModel.FotoUpload != null && cuidadorViewModel.FotoUpload.Length > 0)
            {
                var nomeDaFoto = $"{Guid.NewGuid()}_{cuidadorViewModel.Foto}";
                if (!UploadArquivo(cuidadorViewModel.FotoUpload, nomeDaFoto)) return CustomResponse(cuidadorViewModel);
                cuidadorViewModel.Foto = nomeDaFoto;
            }

            cuidadorExistenteViewModel.Nome = cuidadorViewModel.Nome;
            cuidadorExistenteViewModel.Documento = cuidadorViewModel.Documento;
            cuidadorExistenteViewModel.Email = cuidadorViewModel.Email;
            cuidadorExistenteViewModel.SalarioPorHora = cuidadorViewModel.SalarioPorHora;

            await _cuidadorService.Atualizar(_mapper.Map<Cuidador>(cuidadorExistenteViewModel));

            return CustomResponse(cuidadorExistenteViewModel);
        }

        [HttpDelete("{id:guid}")]
        public async Task<ActionResult> Excluir(Guid id)
        {
            var cuidadorViewModel = await ObterCuidadorAssistidos(id);

            if (cuidadorViewModel == null) return NotFound();
            
            await _cuidadorService.Remover(id);

            return CustomResponse(cuidadorViewModel);
        }

        private bool UploadArquivo(string arquivo, string nomeDoArquivo)
        {
            if (string.IsNullOrEmpty(arquivo))
            {
                NotificarErro("Forneça uma foto do cuidador!");
                return false;
            }

            var caminhoDoArquivo = Path.Combine(Directory.GetCurrentDirectory(), "wwwroot/images", nomeDoArquivo);
            if (System.IO.File.Exists(caminhoDoArquivo))
            {
                NotificarErro("Já existe um arquivo com esse nome!");
                return false;
            }

            var arquivoDataByteArray = Convert.FromBase64String(arquivo);
            System.IO.File.WriteAllBytes(caminhoDoArquivo, arquivoDataByteArray);

            return true;
        }
    }
}
