using Domain.Entities;
using Microsoft.EntityFrameworkCore;
using Microsoft.EntityFrameworkCore.Metadata.Builders;

namespace Persistence.Data.Configuration;

public class DetalleFacturaConfiguration : IEntityTypeConfiguration<DetalleFactura>
{
    public void Configure(EntityTypeBuilder<DetalleFactura> builder)
    {
        builder.ToTable("DETALLES_FACTURAS");

        builder.Property(dfac => dfac.Precio)
        .HasColumnName("precio")
        .HasColumnType("decimal(22,2)")
        .IsRequired();

        builder.Property(dfac => dfac.Cantidad)
        .HasColumnName("cantidad")
        .HasColumnType("int")
        .IsRequired();

        builder.Property(dfac => dfac.FechaVenta)
        .HasColumnName("fecha_compra")
        .HasColumnType("datetime")
        .IsRequired();

        

        builder.HasOne(dfac => dfac.Factura)
        .WithMany(fac => fac.DetallesFacturas)
        .HasForeignKey(dfac => dfac.IdMedicamentoFk);

        builder.HasOne(dfac => dfac.Medicamento)
        .WithMany(fac => fac.DetallesFacturas)
        .HasForeignKey(dfac => dfac.IdFacturaFk);


    }
}
