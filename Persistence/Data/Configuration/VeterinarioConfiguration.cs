using Domain.Entities;
using Microsoft.EntityFrameworkCore;
using Microsoft.EntityFrameworkCore.Metadata.Builders;

namespace Persistence.Data.Configuration;



public class VeterinarioConfiguration : IEntityTypeConfiguration<Veterinario> {
  public void Configure(EntityTypeBuilder<Veterinario> builder) {
    builder.ToTable("VETERINARIOS");
    
    builder.Property(v => v.Nombre)
      .HasColumnName("nombre")
      .HasColumnType("varchar(45)");

    builder.Property(v => v.Email)
      .HasColumnName("email")
      .HasColumnType("varchar(45)");

    builder.Property(v => v.Telefono)
      .HasColumnName("telefono")
      .HasColumnType("varchar(45)");

    builder.HasOne(v => v.Especialidad)
      .WithMany(e => e.Veterinarios)
      .HasForeignKey(v => v.IdEspecialidadFk);
  }
}

