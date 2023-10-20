
using Domain.Entities;

namespace Domain.Interfaces;
public interface IProveedor : IGenericRepository<Proveedor>
{
    Task<IEnumerable<Proveedor>> CB4MedicamentoConProveedor(string proveedor);

}
