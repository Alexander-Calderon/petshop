

namespace Domain.Entities;

public class Rol : BaseEntity
{
    public string Descripcion { get; set; }
    public ICollection<Usuario> Usuarios { get; set; } = new HashSet<Usuario>();
    public ICollection<RolUsuario> UsuariosRoles { get; set; }
    
}
