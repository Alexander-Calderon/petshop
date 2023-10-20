
using Domain.Entities;

namespace Domain.Interfaces;
public interface IEspecie : IGenericRepository<Especie>
{
    
    Task<IEnumerable<Especie>> CB1Mascotas();
    
}
