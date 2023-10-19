using Domain.Entities;
using Microsoft.EntityFrameworkCore;
using Microsoft.EntityFrameworkCore.Metadata.Builders;

namespace Persistence.Data.Configuration;



public class FacturaConfiguration : IEntityTypeConfiguration<Factura> {
  public void Configure(EntityTypeBuilder<Factura> builder) {
    builder.ToTable("FACTURAS");
    
    builder.Property(f => f.FechaCreacion)
      .HasColumnName("fecha_creacion")
      .HasColumnType("datetime");
  }
}

