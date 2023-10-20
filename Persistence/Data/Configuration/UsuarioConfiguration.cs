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

    builder.HasMany(usu => usu.Roles)
    .WithMany(rl => rl.Usuarios)
    .UsingEntity<RolUsuario>(

      j => j
          .HasOne(ru => ru.Rol)
          .WithMany(u => u.RolesUsuarios)
          .HasForeignKey(ru => ru.IdUsuarioFk),

      j => j
          .HasOne(ru => ru.Usuario)
          .WithMany(u => u.RolesUsuarios)
          .HasForeignKey(ru => ru.IdUsuarioFk),

      j =>
      {
          j.ToTable("ROLES_USUARIOS");
          j.HasKey(ru => new { ru.IdRolFk, ru.IdUsuarioFk });

      }




    );


  }



}
