

namespace Domain.Entities;

public class Veterinario : BaseEntity
{
    
    public string Nombre { get; set; }
    public string Email { get; set; }
    public string Telefono { get; set; }


    public int IdEspecialidadFk { get; set; }    

    public Especialidad Especialidades {get;set;}

    public ICollection<Cita> Citas {get; set;}

}
