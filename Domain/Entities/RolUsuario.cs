

namespace Domain.Entities;

public class RolUsuario
{
    public int IdRolFk {get; set;}        
    public int IdUsuarioFk {get; set;}


    public Rol Roles {get; set;}
    public Usuario Usuarios {get; set;}

}
