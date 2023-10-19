

namespace Domain.Entities;

public class Especialidad : BaseEntity
{
    
    public string Nombre { get; set; }

    
    public ICollection<Veterinario> Veterinarios {get; set;}

}
