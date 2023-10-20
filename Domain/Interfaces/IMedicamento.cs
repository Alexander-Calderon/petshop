
using Domain.Entities;


namespace Domain.Interfaces;
public interface IMedicamento : IGenericRepository<Medicamento>
{

    // Declaraciones métodos de las consultas
    Task<IEnumerable<Medicamento>> CA2LaboratorioGenfar();
    Task<IEnumerable<Medicamento>> CA5Mayor50000();
    Task<object> CB2MovimientosConTotal();

    
    
}
