
using Persistence;
using Domain.Entities;
using Domain.Interfaces;
using Microsoft.EntityFrameworkCore;

namespace Application.Repository;

public class MascotaRepository : GenericRepository<Mascota>, IMascota
{
    private readonly PetshopContext _context;

    public MascotaRepository(PetshopContext context) : base(context)
    {
        _context = context;
    }

    // Implementaciones simples (CRUD Básico):



    // Implementaciones detalladas (Consultas específicas):

    // # Mostrar las mascotas que se encuentren registradas cuya especie sea felina

    public async Task<IEnumerable<Mascota>> CA3EspecieFelina()
    {
        // Forma 1 ok
        return await _context.Mascotas
        .Where(m => m.Raza.Especie.Id == 1)
        .ToListAsync();
            
        // Forma2 ok
        // return await _context.Mascotas.Include(v => v.Raza)
        // .Where(m => m.Raza.IdEspecieFk == 1)
        // .ToListAsync();
    }
 
    // Forma 3 pero debe ir en el otro repository, Especie.
    // public async Task<IEnumerable<Especie>> CA3EspecieFelina()
    // {
    //     return await _context.Especies.Include(e => e.Razas).ThenInclude(r => r.Mascotas)
    //     .Where(v => v.Id == 1)
    //     .ToListAsync();
    // }

    // Listar las mascotas que fueron atendidas por motivo de vacunacion en el primer trimestre del 2023
    public async Task<IEnumerable<Mascota>> CA6VacunacionPrimerTrimestre()
    {        
        DateTime startDate = new DateTime(2023, 1, 1);
        DateTime endDate = new DateTime(2023, 3, 31);

        return await _context.Mascotas
        .Include(m => m.Citas)
        .Where(m => m.Citas.Any(c => c.Motivo.Contains("vacuna") && c.FechaCita >= startDate && c.FechaCita <= endDate))
        .ToListAsync();    
    }






    // Paginación
    // public override async Task<(int totalRegistros, IEnumerable<Mascota> registros)> GetAllAsync(int pageIndex, int pageSize, string _search)
    // {
    //     var totalRegistros = await _context.Set<Mascota>().CountAsync();
    //     var registros = await _context.Set<Mascota>()
    //         .Skip((pageIndex - 1) * pageSize)
    //         .Take(pageSize)
    //         .Include(c => c.Mascota).ThenInclude(m =>m.Propietario)
    //         .Include(c => c.Veterinario)
    //         .ToListAsync();
    //     return (totalRegistros, registros);
    // }



}
