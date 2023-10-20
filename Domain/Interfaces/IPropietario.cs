
using Domain.Entities;

namespace Domain.Interfaces;
public interface IPropietario : IGenericRepository<Propietario>
{
    Task<IEnumerable<Propietario>> CA4Mascotas();
}
