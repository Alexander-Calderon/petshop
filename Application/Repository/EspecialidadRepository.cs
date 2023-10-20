using Persistence;
using Domain.Entities;
using Domain.Interfaces;
using Microsoft.EntityFrameworkCore;

namespace Application.Repository
{
    public class EspecialidadRepository : GenericRepository<Especialidad>, IEspecialidad
    {
        private readonly PetshopContext _context;

        public EspecialidadRepository(PetshopContext context) : base(context)
        {
            _context = context;
        }

        // Implementaciones simples (CRUD Básico):

        // Implementaciones detalladas (Consultas específicas):

        // Paginación
        // public override async Task<(int totalRegistros, IEnumerable<Especialidad> registros)> GetAllAsync(int pageIndex, int pageSize, string _search)
        // {
        //     var totalRegistros = await _context.Set<Especialidad>().CountAsync();
        //     var registros = await _context.Set<Especialidad>()
        //         .Skip((pageIndex - 1) * pageSize)
        //         .Take(pageSize)
        //         .ToListAsync();
        //     return (totalRegistros, registros);
        // }
    }
}
