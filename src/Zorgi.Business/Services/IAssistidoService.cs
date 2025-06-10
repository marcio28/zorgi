using Zorgi.Business.Models;

namespace Zorgi.Business.Services
{
    public interface IAssistidoService : IDisposable
    {
        Task<bool> Adicionar(Assistido assistido);
        Task<bool> Atualizar(Assistido assistido);
        Task<bool> Remover(Guid id);
    }
}
