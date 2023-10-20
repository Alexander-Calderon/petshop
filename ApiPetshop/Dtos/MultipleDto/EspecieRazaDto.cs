

namespace ApiPetshop.Dtos;

public class EspecieRazaDto
{
    public int Id {get;set;}    
    public string Nombre { get; set; }
    public List<RazaMascotaDto> Razas { get; set; }



}
