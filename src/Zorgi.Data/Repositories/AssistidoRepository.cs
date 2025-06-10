using Microsoft.EntityFrameworkCore;
using Zorgi.Business.Models;
using Zorgi.Business.Repositories;
using Zorgi.Data.Context;

namespace Zorgi.Data.Repositories
{
    public class AssistidoRepository(AppDbContext context) : Repository<Assistido>(context), IAssistidoRepository
    {
        public async Task<Assistido> ObterAssistidoCuidadores(Guid id)
        {
            return await Db.Assistidos.AsNoTracking()
                                      .Include(a => a.Cuidadores)
                                      .FirstOrDefaultAsync(a => a.Id == id);
        }
    }
}
