using Zorgi.Business.Models;

namespace Zorgi.Business.Services
{
    public interface ICuidadorService : IDisposable
    {
        Task Adicionar(Cuidador cuidador);
        Task Atualizar(Cuidador cuidador);
        Task Remover(Guid id);
    }
}
