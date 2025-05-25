using Zorgi.Business.Models;

namespace Zorgi.Business.Services
{
    public interface IAssistidoService : IDisposable
    {
        Task Adicionar(Assistido assistido);
        Task Atualizar(Assistido assistido);
        Task Remover(Guid id);
    }
}
