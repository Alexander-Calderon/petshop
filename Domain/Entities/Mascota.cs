

namespace Domain.Entities;

public class Mascota : BaseEntity
{
    
    public string Nombre { get; set; }
    public DateTime FechaNacimiento { get; set; }
    


    public int IdPropietarioFk { get; set; }    
    public int IdRazaFk { get; set; }    

    public Propietario Propietarios {get;set;}
    public Raza Razas {get;set;}

    public ICollection<Cita> Citas {get; set;}

}
