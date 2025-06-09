using Microsoft.EntityFrameworkCore;
using Microsoft.EntityFrameworkCore.Metadata.Builders;
using Zorgi.Business.Models;

namespace Zorgi.Data.Mappings
{
    public class CuidadorMapping : IEntityTypeConfiguration<Cuidador>
    {
        public void Configure(EntityTypeBuilder<Cuidador> builder)
        {
            builder.ToTable("Cuidadores");

            builder.HasKey(c => c.Id);

            builder.Property(c => c.Nome)
                   .IsRequired().HasMaxLength(100);

            builder.Property(c => c.Email)
                   .IsRequired()
                   .HasMaxLength(100);

            builder.Property(c => c.SalarioPorHora)
                   .IsRequired()
                   .HasColumnType("decimal(9,2)");

            builder.HasMany(c => c.Assistidos)
                   .WithMany(a => a.Cuidadores)
                   .UsingEntity(
                        "Cuidadores__Assistidos",
                        r => r.HasOne(typeof(Assistido)).WithMany().HasForeignKey("AssistidoId").HasPrincipalKey(nameof(Assistido.Id)),
                        l => l.HasOne(typeof(Cuidador)).WithMany().HasForeignKey("CuidadorId").HasPrincipalKey(nameof(Cuidador.Id)),
                        j => j.HasKey("CuidadorId", "AssistidoId"));
        }
    }
}
