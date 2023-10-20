

namespace ApiPetshop.Dtos;

public class VeterinarioDto
{
    public int Id {get;set;}
    public string Nombre { get; set; }
    public string Email { get; set; }
    public string Telefono { get; set; }

    public int IdEspecialidadFk { get; set; }    


}
