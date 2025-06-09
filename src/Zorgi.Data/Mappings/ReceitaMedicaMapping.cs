using Microsoft.EntityFrameworkCore;
using Microsoft.EntityFrameworkCore.Metadata.Builders;
using Zorgi.Business.Models;

namespace Zorgi.Data.Mappings
{
    public class ReceitaMedicaMapping : IEntityTypeConfiguration<ReceitaMedica>
    {
        public void Configure(EntityTypeBuilder<ReceitaMedica> builder)
        {
            builder.ToTable("ReceitasMedicas");

            builder.HasKey(r => r.Id);

            builder.Property(r => r.DataDePrescricao)
                   .IsRequired();

            builder.HasOne(r => r.Assistido)
                   .WithMany()
                   .HasForeignKey(r => r.AssistidoId)
                   .OnDelete(DeleteBehavior.Cascade);
        }
    }
}
