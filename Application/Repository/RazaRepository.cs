
using Persistence;
using Domain.Entities;
using Domain.Interfaces;
using Microsoft.EntityFrameworkCore;

namespace Application.Repository;

public class RazaRepository : GenericRepository<Raza>, IRaza
{
    private readonly PetshopContext _context;

    public RazaRepository(PetshopContext context) : base(context)
    {
        _context = context;
    }

    // Implementaciones simples (CRUD Básico):



    // Implementaciones detalladas (Consultas específicas):

    // Listar las mascotas y sus propietarios cuya raza sea Golden Retriver.
    public async Task<IEnumerable<Raza>> CB5PropietariosMascotasGolden()
    {
        return await _context.Razas
            .Where(r => r.Id == 2)
            .Include(r => r.Mascotas).ThenInclude(m => m.Propietario)
            .ToListAsync();
    }

     //Listar la cantidad de mascotas que pertenecen a una raza
    public async Task<IEnumerable<CantidadMascotasXRaza>> CantidadMascotasXRaza()
    {
        return await _context.Razas
            .Include(r => r.Mascotas)
            .Select(raza => new CantidadMascotasXRaza
            {
                Id = raza.Id,
                Nombre = raza.Nombre,
                Cantidad = raza.Mascotas.Count()
            })
            .ToListAsync();
    }




    // Paginación
    // public override async Task<(int totalRegistros, IEnumerable<Raza> registros)> GetAllAsync(int pageIndex, int pageSize, string _search)
    // {
    //     var totalRegistros = await _context.Set<Raza>().CountAsync();
    //     var registros = await _context.Set<Raza>()
    //         .Skip((pageIndex - 1) * pageSize)
    //         .Take(pageSize)
    //         .Include(c => c.Mascota).ThenInclude(m =>m.Propietario)
    //         .Include(c => c.Veterinario)
    //         .ToListAsync();
    //     return (totalRegistros, registros);
    // }



}
