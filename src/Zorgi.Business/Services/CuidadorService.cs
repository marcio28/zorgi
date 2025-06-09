using Zorgi.Business.Models;
using Zorgi.Business.Models.Validations;
using Zorgi.Business.Notifications;
using Zorgi.Business.Repositories;

namespace Zorgi.Business.Services
{
    public class CuidadorService(ICuidadorRepository cuidadorRepository,
                                 INotifier notifier) : BaseService(notifier), ICuidadorService
    {
        private readonly ICuidadorRepository _cuidadorRepository = cuidadorRepository;

        public async Task<bool> Adicionar(Cuidador cuidador)
        {
            if (!ExecutarValidacao(new CuidadorValidation(), cuidador)) return false;

            if (_cuidadorRepository.Buscar(c => c.Documento == cuidador.Documento).Result.Any())
            {
                Notificar("Já existe um cuidador com o documento informado.");
                return false;
            }

            await _cuidadorRepository.Adicionar(cuidador);
            return true;
        }

        public async Task<bool> Atualizar(Cuidador cuidador)
        {
            if (!ExecutarValidacao(new CuidadorValidation(), cuidador)) return false;

            if (_cuidadorRepository.Buscar(c => c.Documento == cuidador.Documento && c.Id != cuidador.Id).Result.Any())
            {
                Notificar("Já existe um cuidador com o documento infomado.");
                return false;
            }

            await _cuidadorRepository.Atualizar(cuidador);
            return true;
        }

        public void Dispose()
        {
            _cuidadorRepository?.Dispose();
        }

        public async Task<bool> Remover(Guid id)
        {
            if (_cuidadorRepository.ObterCuidadorAssistidos(id).Result.Assistidos.Any())
            {
                Notificar("Este cuidador não pode ser excluído, porque cuida de assistidos.");
                return false;
            }

            await _cuidadorRepository.Remover(id);
            return true;
        }
    }
}
