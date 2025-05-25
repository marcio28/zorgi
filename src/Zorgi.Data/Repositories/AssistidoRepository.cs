using Zorgi.Business.Models;
using Zorgi.Business.Repositories;
using Zorgi.Data.Context;

namespace Zorgi.Data.Repositories
{
    public class AssistidoRepository : Repository<Assistido>, IAssistidoRepository
    {
        public AssistidoRepository(AppDbContext context) : base(context) { }
    }
}
