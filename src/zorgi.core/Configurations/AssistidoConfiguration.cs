﻿using Microsoft.EntityFrameworkCore;
using Microsoft.EntityFrameworkCore.Metadata.Builders;
using zorgi.core.Models;

namespace zorgi.core.Configurations
{
    public class AssistidoConfiguration : IEntityTypeConfiguration<Assistido>
    {
        public void Configure(EntityTypeBuilder<Assistido> builder)
        {
            builder.ToTable("Assistidos");
            builder.HasKey(a => a.Id);
            builder.Property(a => a.Nome).IsRequired().HasMaxLength(100);
            builder.Property(a => a.DataDeNascimento).IsRequired();
            builder.HasOne(a => a.CuidadorPrincipal).WithMany().HasForeignKey(a => a.CuidadorPrincipalId).OnDelete(DeleteBehavior.Restrict);
        }
    }
}
