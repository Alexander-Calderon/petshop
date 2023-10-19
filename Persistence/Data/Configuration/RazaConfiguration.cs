using Domain.Entities;
using Microsoft.EntityFrameworkCore;
using Microsoft.EntityFrameworkCore.Metadata.Builders;

namespace Persistence.Data.Configuration;


public class RazaConfiguration : IEntityTypeConfiguration<Raza> {
  public void Configure(EntityTypeBuilder<Raza> builder) {
    builder.ToTable("RAZAS");
    
    builder.Property(r => r.Nombre)
      .HasColumnName("nombre")
      .HasColumnType("varchar(45)");

    builder.HasOne(r => r.Especie)
      .WithMany(e => e.Razas)
      .HasForeignKey(r => r.IdEspecieFk);
  }
}

