
using Domain.Entities;

namespace Domain.Interfaces;
public interface IMascota : IGenericRepository<Mascota>
{
    // Declaraciones métodos de las consultas
    Task<IEnumerable<Mascota>> CA3EspecieFelina();
    Task<IEnumerable<Mascota>> CA6VacunacionPrimerTrimestre();

    
    
}
