using Domain.Entities;
using Microsoft.EntityFrameworkCore;
using Microsoft.EntityFrameworkCore.Metadata.Builders;

namespace Persistence.Data.Configuration;
public class CitaConfiguration : IEntityTypeConfiguration<Cita>
{
    public void Configure(EntityTypeBuilder<Cita> builder)
    {
        builder.ToTable("CITAS");

        builder.Property(cta => cta.FechaEmision)
        .HasColumnName("fecha_emision")
        .HasColumnType("datetime")
        .IsRequired();

        builder.Property(cta => cta.FechaCita)
        .HasColumnName("fecha_cita")
        .HasColumnType("datetime")
        .IsRequired();

        builder.Property(cta => cta.Motivo)
        .HasColumnName("motivo")
        .HasMaxLength(75)
        .IsRequired();

        

        builder.HasOne(cta => cta.Mascota)
        .WithMany(masc => masc.Citas)
        .HasForeignKey(cta => cta.IdMascotaFk);

        builder.HasOne(cta => cta.Veterinario)
        .WithMany(vet => vet.Citas)
        .HasForeignKey(cta => cta.IdVeterinarioFk);



    }
}
