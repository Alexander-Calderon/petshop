

namespace ApiPetshop.Dtos;

public class RazaMascotaDto
{
    public int Id {get;set;}    
    public string Nombre { get; set; }
    public List<MascotaDto> Mascotas { get; set; }



}
