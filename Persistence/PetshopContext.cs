
using Microsoft.EntityFrameworkCore;
using Domain.Entities;
using System.Reflection;



namespace Persistence
{
    public class PetshopContext : DbContext
    {

        // public FarmaciaContext(DbContextOptions<FarmaciaContext> options) : base(options)
        public PetshopContext(DbContextOptions options) : base(options)
        {

        }

        // public DbSet<Cita> Citas {get;set;}
        // public DbSet<CompraProveedor> ComprasProveedores {get;set;}
        // public DbSet<DetalleFactura> DetallesFacturas {get;set;}
        // public DbSet<Especialidad> Especialidades {get;set;}
        // public DbSet<Especie> Especies {get;set;}
        // public DbSet<Factura> Facturas {get;set;}
        // public DbSet<Laboratorio> Laboratorios {get;set;}
        // public DbSet<Mascota> Mascotas {get;set;}
        // public DbSet<Medicamento> Medicamentos {get;set;}
        // public DbSet<Propietario> Propietarios {get;set;}
        // public DbSet<Proveedor> Proveedores {get;set;}
        // public DbSet<Raza> Razas {get;set;}
        // public DbSet<Rol> Roles {get;set;}
        // public DbSet<RolUsuario> RolesUsuarios {get;set;}
        // public DbSet<TratamientoMedico> TratamientosMedicos {get;set;}
        // public DbSet<Usuario> Usuarios {get;set;}
        // public DbSet<Veterinario> Veterinarios {get;set;}


        protected override void OnModelCreating( ModelBuilder modelBuilder)
        {
            base.OnModelCreating(modelBuilder);

            // Con la siguiete línea, EF Core detecta las configuraciones en el ensamblado referenciado y las aplica automáticamente al construir el modelo,
            // por lo que los nombres de las tablas en los dbsets son ignorados y se usan los asignados desde las configuraciones,
            // en caso de no existir, sacará el nombre de la tabla en base al nombre de la entidad, si se comenta la línea, tomará los nombres de los dbset.
            modelBuilder.ApplyConfigurationsFromAssembly(Assembly.GetExecutingAssembly());
            // y en ese caso se usaría la otra forma para asignar renombrado a los campos en la bd directamente en las entidades, ej: 
            // [Column("id_producto")]
            // public int Id {get; set;}

        }
        

        
    }
}