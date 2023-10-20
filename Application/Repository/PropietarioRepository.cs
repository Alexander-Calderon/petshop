
using Persistence;
using Domain.Entities;
using Domain.Interfaces;
using Microsoft.EntityFrameworkCore;

namespace Application.Repository;

public class PropietarioRepository : GenericRepository<Propietario>, IPropietario
{
    private readonly PetshopContext _context;

    public PropietarioRepository(PetshopContext context) : base(context)
    {
        _context = context;
    }

    // Implementaciones simples (CRUD Básico):



    // Implementaciones detalladas (Consultas específicas):



    // Listar los propietarios y sus mascotas
    public async Task<IEnumerable<Propietario>> CA4Mascotas()
    {
        return await _context.Propietarios.Include(p => p.Mascotas).Where(p => p.Mascotas.Any()).ToListAsync();
    }



    // Paginación
    // public override async Task<(int totalRegistros, IEnumerable<Propietario> registros)> GetAllAsync(int pageIndex, int pageSize, string _search)
    // {
    //     var totalRegistros = await _context.Set<Propietario>().CountAsync();
    //     var registros = await _context.Set<Propietario>()
    //         .Skip((pageIndex - 1) * pageSize)
    //         .Take(pageSize)
    //         .Include(c => c.Mascota).ThenInclude(m =>m.Propietario)
    //         .Include(c => c.Veterinario)
    //         .ToListAsync();
    //     return (totalRegistros, registros);
    // }



}
