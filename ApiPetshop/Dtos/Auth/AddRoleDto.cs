using System.ComponentModel.DataAnnotations;

namespace ApiPetshop.Dtos;

public class AddRoleDto
{
    [Required]
    public string Username { get; set; }
    [Required]
    public string Password { get; set; }
    [Required]
    public string Rol { get; set; }
}
