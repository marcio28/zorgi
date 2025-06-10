using Zorgi.Business.Models;
using Zorgi.Business.Models.Validations;
using Zorgi.Business.Notifications;
using Zorgi.Business.Repositories;

namespace Zorgi.Business.Services
{
    public class AssistidoService(IAssistidoRepository assistidoRepository,
                                 INotifier notifier) : BaseService(notifier), IAssistidoService
    {
        private readonly IAssistidoRepository _assistidoRepository = assistidoRepository;

        public async Task<bool> Adicionar(Assistido assistido)
        {
            if (!ExecutarValidacao(new AssistidoValidation(), assistido)) return false;

            if (_assistidoRepository.Buscar(a => a.Documento == assistido.Documento).Result.Any())
            {
                Notificar("Já existe um assistido com o documento informado.");
                return false;
            }

            await _assistidoRepository.Adicionar(assistido);
            return true;
        }

        public async Task<bool> Atualizar(Assistido assistido)
        {
            if (!ExecutarValidacao(new AssistidoValidation(), assistido)) return false;

            if (_assistidoRepository.Buscar(a => a.Documento == assistido.Documento && a.Id != assistido.Id).Result.Any())
            {
                Notificar("Já existe um assistido com o documento infomado.");
                return false;
            }

            await _assistidoRepository.Atualizar(assistido);
            return true;
        }

        public void Dispose()
        {
            _assistidoRepository?.Dispose();
        }

        public async Task<bool> Remover(Guid id)
        {
            await _assistidoRepository.Remover(id);
            return true;
        }
    }
}
