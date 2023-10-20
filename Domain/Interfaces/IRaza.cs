
using Domain.Entities;

namespace Domain.Interfaces;
public interface IRaza : IGenericRepository<Raza>
{
    Task<IEnumerable<Raza>> CB5PropietariosMascotasGolden();
    Task<IEnumerable<CantidadMascotasXRaza>> CantidadMascotasXRaza();

    
    
}
