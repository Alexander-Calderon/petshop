using Domain.Entities;
using Microsoft.EntityFrameworkCore;
using Microsoft.EntityFrameworkCore.Metadata.Builders;

namespace Persistence.Data.Configuration;



public class MedicamentoConfiguration : IEntityTypeConfiguration<Medicamento> {
  public void Configure(EntityTypeBuilder<Medicamento> builder) {
    builder.ToTable("MEDICAMENTOS");
    
    builder.Property(m => m.Nombre)
      .HasColumnName("nombre")
      .HasColumnType("varchar(45)");

    builder.Property(m => m.Stock)
      .HasColumnName("stock")
      .HasColumnType("int");

    builder.Property(m => m.PrecioActual)
      .HasColumnName("precio_actual")
      .HasColumnType("decimal(22,2)");

    builder.HasOne(m => m.Laboratorio)
      .WithMany(l => l.Medicamentos)
      .HasForeignKey(m => m.IdLaboratorioFk);
  }
}

