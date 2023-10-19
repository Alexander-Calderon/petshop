using Domain.Entities;
using Microsoft.EntityFrameworkCore;
using Microsoft.EntityFrameworkCore.Metadata.Builders;

namespace Persistence.Data.Configuration;

public class UsuarioConfiguration : IEntityTypeConfiguration<Usuario> {
  public void Configure(EntityTypeBuilder<Usuario> builder) {
    builder.ToTable("USUARIOS");
    
    builder.Property(u => u.Nombre)
      .HasColumnName("nombre")
      .HasColumnType("varchar(50)");

    builder.Property(u => u.Email)
      .HasColumnName("email")
      .HasColumnType("varchar(50)");

    builder.Property(u => u.Password)
      .HasColumnName("password")
      .HasColumnType("varchar(255)");
  }
}
