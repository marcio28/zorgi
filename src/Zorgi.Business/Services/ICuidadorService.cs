using Zorgi.Business.Models;

namespace Zorgi.Business.Services
{
    public interface ICuidadorService : IDisposable
    {
        Task<bool> Adicionar(Cuidador cuidador);
        Task<bool> Atualizar(Cuidador cuidador);
        Task<bool> Remover(Guid id);
    }
}
