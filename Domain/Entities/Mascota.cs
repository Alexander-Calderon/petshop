

namespace Domain.Entities;

public class Mascota : BaseEntity
{
    
    public string Nombre { get; set; }
    public DateTime FechaNacimiento { get; set; }
    


    public int IdPropietarioFk { get; set; }    
    public int IdRazaFk { get; set; }    

    public Propietario Propietario {get;set;}
    public Raza Raza {get;set;}

    public ICollection<Cita> Citas {get; set;}

}
