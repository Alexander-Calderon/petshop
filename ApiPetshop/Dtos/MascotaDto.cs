

namespace ApiPetshop.Dtos;

public class MascotaDto
{
    public int Id {get;set;}
    public string Nombre { get; set; }
    public DateTime FechaNacimiento { get; set; }


    public int IdPropietarioFk { get; set; }    
    public int IdRazaFk { get; set; }   
    
}
