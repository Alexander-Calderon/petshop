using Persistence;
using Domain.Entities;
using Domain.Interfaces;
using Microsoft.EntityFrameworkCore;

namespace Application.Repository
{
    public class EspecieRepository : GenericRepository<Especie>, IEspecie
    {
        private readonly PetshopContext _context;

        public EspecieRepository(PetshopContext context) : base(context)
        {
            _context = context;
        }

        // Implementaciones simples (CRUD Básico):

        // Implementaciones detalladas (Consultas específicas):

        // Paginación
        // public override async Task<(int totalRegistros, IEnumerable<Especie> registros)> GetAllAsync(int pageIndex, int pageSize, string _search)
        // {
        //     var totalRegistros = await _context.Set<Especie>().CountAsync();
        //     var registros = await _context.Set<Especie>()
        //         .Skip((pageIndex - 1) * pageSize)
        //         .Take(pageSize)
        //         .ToListAsync();
        //     return (totalRegistros, registros);
        // }




        // Listar todas las mascotas agrupadas por especie
        public async Task<IEnumerable<Especie>> CB1Mascotas()
        {
            return await _context.Especies.Include(e => e.Razas)
            .ThenInclude(r => r.Mascotas).ToListAsync();
        }

        



    }



}
