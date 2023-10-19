

namespace Domain.Entities;

public class Cita : BaseEntity
{
    
    public DateTime FechaEmision { get; set; }
    public DateTime FechaCita { get; set; }
    public string Motivo { get; set; }


    public int IdMascotaFk { get; set; }
    public int IdVeterinarioFk { get; set; }
    

    public Mascota Mascota {get;set;}
    public Veterinario Veterinario {get;set;}

    public ICollection<TratamientoMedico> TratamientosMedicos { get; set; }


}
