using Domain.Entities;
using Microsoft.EntityFrameworkCore;
using Microsoft.EntityFrameworkCore.Metadata.Builders;

namespace Persistence.Data.Configuration;




public class TratamientoMedicoConfiguration : IEntityTypeConfiguration<TratamientoMedico> {
  public void Configure(EntityTypeBuilder<TratamientoMedico> builder) {
    builder.ToTable("TRATAMIENTOS_MEDICOS");
    
    builder.Property(tm => tm.Dosis)
      .HasColumnName("dosis")
      .HasColumnType("int");

    builder.Property(tm => tm.FechaAdministracion)
      .HasColumnName("fecha_administracion")
      .HasColumnType("datetime");

    builder.Property(tm => tm.Observacion)  
      .HasColumnName("observacion")
      .HasColumnType("varchar(255)");

    builder.HasOne(tm => tm.Cita)
      .WithMany(c => c.TratamientosMedicos)
      .HasForeignKey(tm => tm.IdCitaFk);

    builder.HasOne(tm => tm.Medicamento)
      .WithMany(m => m.TratamientosMedicos)
      .HasForeignKey(tm => tm.IdMedicamentoFk);
  }
} 

