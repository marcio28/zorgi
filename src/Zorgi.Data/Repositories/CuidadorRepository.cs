using Microsoft.EntityFrameworkCore;
using Zorgi.Business.Models;
using Zorgi.Business.Repositories;
using Zorgi.Data.Context;

namespace Zorgi.Data.Repositories
{
    public class CuidadorRepository(AppDbContext context) : Repository<Cuidador>(context), ICuidadorRepository
    {
        public async Task<Cuidador> ObterCuidadorAssistidos(Guid id)
        {
            return await Db.Cuidadores.AsNoTracking()
                                      .Include(c => c.Assistidos)
                                      .FirstOrDefaultAsync(c => c.Id == id);
        }
    }
}
