using Zorgi.Business.Models;
using Zorgi.Business.Repositories;
using Zorgi.Data.Context;

namespace Zorgi.Data.Repositories
{
    public class CuidadorRepository : Repository<Cuidador>, ICuidadorRepository
    {
        public CuidadorRepository(AppDbContext context) : base(context) { }
    }
}
