using Zorgi.Business.Models;

namespace Zorgi.Business.Repositories
{
    public interface ICuidadorRepository : IRepository<Cuidador>
    {
        public Task<Cuidador> ObterCuidadorAssistidos(Guid id);
    }
}
