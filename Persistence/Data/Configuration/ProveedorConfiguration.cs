using Domain.Entities;
using Microsoft.EntityFrameworkCore;
using Microsoft.EntityFrameworkCore.Metadata.Builders;

namespace Persistence.Data.Configuration;




public class ProveedorConfiguration : IEntityTypeConfiguration<Proveedor> {
  public void Configure(EntityTypeBuilder<Proveedor> builder) {
    builder.ToTable("PROVEEDORES");
    
    builder.Property(p => p.Nombre)
      .HasColumnName("nombre")
      .HasColumnType("varchar(45)");

    builder.Property(p => p.Direccion)
      .HasColumnName("direccion")
      .HasColumnType("varchar(45)");

    builder.Property(p => p.Telefono)
      .HasColumnName("telefono")
      .HasColumnType("varchar(45)");
  }
} 

