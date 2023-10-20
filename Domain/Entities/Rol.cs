

namespace Domain.Entities;

public class Rol : BaseEntity
{
    public string Nombre { get; set; }

    
    public ICollection<RolUsuario> RolesUsuarios { get; set; }

    public ICollection<Usuario> Usuarios { get; set; } = new HashSet<Usuario>();
    
}
