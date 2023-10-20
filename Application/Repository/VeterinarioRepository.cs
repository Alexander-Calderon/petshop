
using Persistence;
using Domain.Entities;
using Domain.Interfaces;
using Microsoft.EntityFrameworkCore;

namespace Application.Repository;

public class VeterinarioRepository : GenericRepository<Veterinario>, IVeterinario
{
    private readonly PetshopContext _context;

    public VeterinarioRepository(PetshopContext context) : base(context)
    {
        _context = context;
    }

    // # Implementaciones simples (CRUD Básico):



    // # Implementaciones detalladas (Consultas específicas):

    // Crear un consulta que permita visualizar los veterinarios cuya especialidad sea Cirujano vascular
    public async Task<IEnumerable<Veterinario>> CA1VeterinariosEspecialidad()
    {
        return await _context.Veterinarios.Where(v => v.IdEspecialidadFk == 1).ToListAsync();
    }


    //Listar las mascotas que fueron atendidas por un determinado veterinario.
    public async Task<IEnumerable<Veterinario>> CB3Mascotas(string nombre_veterinario)
    {
        return await _context.Veterinarios
            .Where(v => v.Nombre.Contains(nombre_veterinario))
            .Include(v => v.Citas).ThenInclude(c => c.Mascota)
            .ToListAsync();
    }



    // Paginación
    // public override async Task<(int totalRegistros, IEnumerable<Veterinario> registros)> GetAllAsync(int pageIndex, int pageSize, string _search)
    // {
    //     var totalRegistros = await _context.Set<Veterinario>().CountAsync();
    //     var registros = await _context.Set<Veterinario>()
    //         .Skip((pageIndex - 1) * pageSize)
    //         .Take(pageSize)
    //         .Include(c => c.Mascota).ThenInclude(m =>m.Propietario)
    //         .Include(c => c.Veterinario)
    //         .ToListAsync();
    //     return (totalRegistros, registros);
    // }



}
