using Microsoft.EntityFrameworkCore;
using Microsoft.EntityFrameworkCore.Metadata.Builders;
using zorgi.core.Models;

namespace zorgi.core.Configurations
{
    public class CuidadorConfiguration : IEntityTypeConfiguration<Cuidador>
    {
        public void Configure(EntityTypeBuilder<Cuidador> builder)
        {
            builder.ToTable("Cuidadores");
            builder.HasKey(c => c.Id);
            builder.Property(c => c.Nome).IsRequired().HasMaxLength(100);
            builder.Property(c => c.Email).IsRequired().HasMaxLength(100);
            builder.Property(c => c.SalarioPorHora).IsRequired().HasColumnType("decimal(9,2)");
        }
    }
}
