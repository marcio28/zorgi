using Microsoft.AspNetCore.Identity.EntityFrameworkCore;
using Microsoft.EntityFrameworkCore;
using Zorgi.Business.Models;
using Zorgi.Data.Mappings;

namespace Zorgi.Data.Context
{
    public class AppDbContext : IdentityDbContext
    {
        public DbSet<Assistido> Assistidos { get; set; }

        public DbSet<Cuidador> Cuidadores { get; set; }

        public AppDbContext(DbContextOptions<AppDbContext> options) : base(options) { }

        protected override void OnModelCreating(ModelBuilder modelBuilder)
        {
            base.OnModelCreating(modelBuilder);

            modelBuilder.ApplyConfiguration(new AssistidoMapping());
            modelBuilder.ApplyConfiguration(new CuidadorMapping());
        }
    }
}
