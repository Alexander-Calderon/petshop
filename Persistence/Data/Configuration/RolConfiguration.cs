using Domain.Entities;
using Microsoft.EntityFrameworkCore;
using Microsoft.EntityFrameworkCore.Metadata.Builders;

namespace Persistence.Data.Configuration;

public class RolConfiguration : IEntityTypeConfiguration<Rol> {
  public void Configure(EntityTypeBuilder<Rol> builder) {
    builder.ToTable("ROLES");
    
    builder.Property(r => r.Nombre)
      .HasColumnName("nombre")
      .HasColumnType("varchar(45)");
  }
}
