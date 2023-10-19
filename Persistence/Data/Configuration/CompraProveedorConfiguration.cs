using Domain.Entities;
using Microsoft.EntityFrameworkCore;
using Microsoft.EntityFrameworkCore.Metadata.Builders;

namespace Persistence.Data.Configuration;

public class CompraProveedorConfiguration : IEntityTypeConfiguration<CompraProveedor>
{
    public void Configure(EntityTypeBuilder<CompraProveedor> builder)
    {
        builder.ToTable("COMPRAS_PROVEEDORES");

        builder.Property(cprov => cprov.Precio)
        .HasColumnName("precio")
        .HasColumnType("decimal(22,2)")
        .IsRequired();

        builder.Property(cprov => cprov.Cantidad)
        .HasColumnName("cantidad")
        .HasColumnType("int")
        .IsRequired();

        builder.Property(cprov => cprov.FechaCompra)
        .HasColumnName("fecha_compra")
        .HasColumnType("datetime")
        .IsRequired();

        

        builder.HasOne(cprov => cprov.Proveedor)
        .WithMany(prov => prov.ComprasProveedores)
        .HasForeignKey(cprov => cprov.IdProveedorFk);

        builder.HasOne(cprov => cprov.Medicamento)
        .WithMany(med => med.ComprasProveedores)
        .HasForeignKey(cprov => cprov.IdMedicamentoFk);

        builder.HasOne(cprov => cprov.Factura)
        .WithMany(fac => fac.ComprasProveedores)
        .HasForeignKey(cprov => cprov.IdFacturaFk);



    }
}
