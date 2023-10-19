

namespace Domain.Entities;

public class Rol : BaseEntity
{
    public string Nombre { get; set; }

    
    public ICollection<RolUsuario> RolesUsuarios { get; set; }
}
