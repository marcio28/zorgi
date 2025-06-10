using Zorgi.Business.Models;

namespace Zorgi.Business.Repositories
{
    public interface IAssistidoRepository : IRepository<Assistido>
    {
        public Task<Assistido> ObterAssistidoCuidadores(Guid id);
    }
}
