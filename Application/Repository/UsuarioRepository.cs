
using Persistence;
using Domain.Entities;
using Domain.Interfaces;
using Microsoft.EntityFrameworkCore;

namespace Application.Repository;

public class UsuarioRepository : GenericRepository<Usuario>, IUsuario
{
    private readonly PetshopContext _context;

    public UsuarioRepository(PetshopContext context) : base(context)
    {
        _context = context;
    }

    // Implementaciones simples (CRUD Básico):



    // Implementaciones detalladas (Consultas específicas):






    // Paginación
    // public override async Task<(int totalRegistros, IEnumerable<Usuario> registros)> GetAllAsync(int pageIndex, int pageSize, string _search)
    // {
    //     var totalRegistros = await _context.Set<Usuario>().CountAsync();
    //     var registros = await _context.Set<Usuario>()
    //         .Skip((pageIndex - 1) * pageSize)
    //         .Take(pageSize)
    //         .Include(c => c.Mascota).ThenInclude(m =>m.Propietario)
    //         .Include(c => c.Veterinario)
    //         .ToListAsync();
    //     return (totalRegistros, registros);
    // }



}
