
using Domain.Entities;

namespace Domain.Interfaces
{
    public interface IVeterinario : IGenericRepository<Veterinario>
    {
        
        // Declaraciones métodos de las consultas
        Task<IEnumerable<Veterinario>> CA1VeterinariosEspecialidad();
        Task<IEnumerable<Veterinario>> CB3Mascotas(string nombre_veterinario);

        
        
    }
}
