
using Persistence;
using Domain.Entities;
using Domain.Interfaces;
using Microsoft.EntityFrameworkCore;

namespace Application.Repository;

public class ProveedorRepository : GenericRepository<Proveedor>, IProveedor
{
    private readonly PetshopContext _context;

    public ProveedorRepository(PetshopContext context) : base(context)
    {
        _context = context;
    }

    // Implementaciones simples (CRUD Básico):



    // Implementaciones detalladas (Consultas específicas):


    // Listar los proveedores que me venden un determinado medicamento.
    public async Task<IEnumerable<Proveedor>> CB4MedicamentoConProveedor(string medicamento)
    {
        return await _context.Medicamentos
        .Where(m => m.Nombre == medicamento)
        .Include(m => m.ComprasProveedores)
        .ThenInclude(cp => cp.Proveedor)
        .SelectMany(m => m.ComprasProveedores.Select(cp => cp.Proveedor))
        .Distinct()
        .ToListAsync();

    }



    // Paginación
    // public override async Task<(int totalRegistros, IEnumerable<Proveedor> registros)> GetAllAsync(int pageIndex, int pageSize, string _search)
    // {
    //     var totalRegistros = await _context.Set<Proveedor>().CountAsync();
    //     var registros = await _context.Set<Proveedor>()
    //         .Skip((pageIndex - 1) * pageSize)
    //         .Take(pageSize)
    //         .Include(c => c.Mascota).ThenInclude(m =>m.Propietario)
    //         .Include(c => c.Veterinario)
    //         .ToListAsync();
    //     return (totalRegistros, registros);
    // }

    



}
