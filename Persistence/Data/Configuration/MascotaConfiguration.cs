using Domain.Entities;
using Microsoft.EntityFrameworkCore;
using Microsoft.EntityFrameworkCore.Metadata.Builders;

namespace Persistence.Data.Configuration;


public class MascotaConfiguration : IEntityTypeConfiguration<Mascota> {
  public void Configure(EntityTypeBuilder<Mascota> builder) {
    builder.ToTable("MASCOTAS");
    
    builder.Property(m => m.Nombre)
      .HasColumnName("nombre")
      .HasColumnType("varchar(45)");

    builder.Property(m => m.FechaNacimiento)
      .HasColumnName("fecha_nacimiento")
      .HasColumnType("datetime");
      

    builder.HasOne(m => m.Propietario)
      .WithMany(p => p.Mascotas)
      .HasForeignKey(m => m.IdPropietarioFk);

    builder.HasOne(m => m.Raza)
      .WithMany(r => r.Mascotas)
      .HasForeignKey(m => m.IdRazaFk);
  }
}

