using Microsoft.AspNetCore.Identity.EntityFrameworkCore;
using Microsoft.EntityFrameworkCore;
using zorgi.core.Configurations;
using zorgi.core.Models;

namespace zorgi.core.Data
{
    public class AppDbContext : IdentityDbContext
    {
        public DbSet<Assistido> Assistidos { get; set; }

        public DbSet<Cuidador> Cuidadores { get; set; }

        public AppDbContext(DbContextOptions<AppDbContext> options) : base(options) { }

        protected override void OnModelCreating(ModelBuilder modelBuilder)
        {
            base.OnModelCreating(modelBuilder);

            modelBuilder.ApplyConfiguration(new AssistidoConfiguration());
            modelBuilder.ApplyConfiguration(new CuidadorConfiguration());
        }
    }
}
