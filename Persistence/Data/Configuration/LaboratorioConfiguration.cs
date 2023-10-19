using Domain.Entities;
using Microsoft.EntityFrameworkCore;
using Microsoft.EntityFrameworkCore.Metadata.Builders;

namespace Persistence.Data.Configuration;




public class LaboratorioConfiguration : IEntityTypeConfiguration<Laboratorio> {
  public void Configure(EntityTypeBuilder<Laboratorio> builder) {
    builder.ToTable("LABORATORIOS");
    
    builder.Property(l => l.Nombre)
      .HasColumnName("nombre")
      .HasColumnType("varchar(45)");

    builder.Property(l => l.Direccion)
      .HasColumnName("direccion") 
      .HasColumnType("varchar(45)");

    builder.Property(l => l.Telefono)
      .HasColumnName("telefono")
      .HasColumnType("varchar(45)");
  }
}

