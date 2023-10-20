

namespace ApiPetshop.Dtos;

public class CitaDto
{
    public int Id {get;set;}    
    public DateTime FechaEmision { get; set; }
    public DateTime FechaCita { get; set; }
    public string Motivo { get; set; }

    public int IdMascotaFk { get; set; }
    public int IdVeterinarioFk { get; set; }


}
