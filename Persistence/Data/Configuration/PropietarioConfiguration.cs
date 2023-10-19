using Domain.Entities;
using Microsoft.EntityFrameworkCore;
using Microsoft.EntityFrameworkCore.Metadata.Builders;

namespace Persistence.Data.Configuration;


public class PropietarioConfiguration : IEntityTypeConfiguration<Propietario> {
  public void Configure(EntityTypeBuilder<Propietario> builder) {
    builder.ToTable("PROPIETARIOS");
    
    builder.Property(p => p.Nombre)
      .HasColumnName("nombre")
      .HasColumnType("varchar(45)");

    builder.Property(p => p.Email)  
      .HasColumnName("email")
      .HasColumnType("varchar(45)");

    builder.Property(p => p.Telefono)
      .HasColumnName("telefono")
      .HasColumnType("varchar(45)");
  }
}
