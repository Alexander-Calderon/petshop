
using Persistence;
using Domain.Entities;
using Domain.Interfaces;
using Microsoft.EntityFrameworkCore;




namespace Application.Repository;

public class MedicamentoRepository : GenericRepository<Medicamento>, IMedicamento
{
    private readonly PetshopContext _context;

    public MedicamentoRepository(PetshopContext context) : base(context)
    {
        _context = context;
    }

    // # Implementaciones simples (CRUD Básico):



    // # Implementaciones detalladas (Consultas específicas):
    
    // Listar los medicamentos que pertenezcan a el laboratorio Genfar
    public async Task<IEnumerable<Medicamento>> CA2LaboratorioGenfar()
    {
        return await _context.Medicamentos.Where(m => m.IdLaboratorioFk == 1).ToListAsync();
    }

    // Listar los medicamentos que tenga un precio de venta mayor a 50000
    public async Task<IEnumerable<Medicamento>> CA5Mayor50000()
    {
        return await _context.Medicamentos
        .Where(m => m.PrecioActual > 50000)
        .ToListAsync();
    }

    // Listar todos los movimientos de medicamentos y el valor total de cada movimiento
    public async Task<Object> CB2MovimientosConTotal()
    {
        var results = await (
        from m in _context.Medicamentos
        join df in _context.DetallesFacturas on m.Id equals df.IdMedicamentoFk
        join f in _context.Facturas on df.IdFacturaFk equals f.Id
        where f != null
        select new
        {
            Id = m.Id,
            IdFac = f.Id,
            Nombre = m.Nombre,
            TotalMovimiento = df.Precio * df.Cantidad,
            TipoMovimiento = "Salida"
        }
    ).Union(
        from m in _context.Medicamentos
        join cp in _context.ComprasProveedores on m.Id equals cp.IdMedicamentoFk
        join f in _context.Facturas on cp.IdFacturaFk equals f.Id
        where f != null
        select new
        {
            Id = m.Id,
            IdFac = f.Id,
            Nombre = m.Nombre,
            TotalMovimiento = cp.Precio * cp.Cantidad,
            TipoMovimiento = "Entrada"
        }
    ).ToListAsync();

    return results;

    }

    // Otra forma con DTO nuevo:

    // public async Task<MovimientoConTotalDto> CB2MovimientosConTotal()
    // {
    //     string sql = @"
    //         SELECT m.id, f.id as idfac, m.nombre, (df.precio * df.cantidad) as total_movimiento, 'Salida' as tipo_movimiento
    //         FROM medicamentos m
    //         INNER JOIN detalles_facturas df ON df.IdMedicamentoFk = m.id
    //         INNER JOIN facturas f ON f.id = df.IdFacturaFk
    //         UNION
    //         SELECT m.id, f.id as idfac, m.nombre, (cp.precio * cp.cantidad) as total_movimiento, 'Entrada' as tipo_movimiento
    //         FROM medicamentos m
    //         INNER JOIN compras_proveedores cp ON cp.IdMedicamentoFk = m.id
    //         INNER JOIN facturas f ON f.id = cp.IdFacturaFk
    //     ";

    //     return await _context.Set<MovimientoConTotalDto>().FromSqlRaw(sql).ToListAsync();

    // }






    // Paginación
    // public override async Task<(int totalRegistros, IEnumerable<Medicamento> registros)> GetAllAsync(int pageIndex, int pageSize, string _search)
    // {
    //     var totalRegistros = await _context.Set<Medicamento>().CountAsync();
    //     var registros = await _context.Set<Medicamento>()
    //         .Skip((pageIndex - 1) * pageSize)
    //         .Take(pageSize)
    //         .Include(c => c.Mascota).ThenInclude(m =>m.Propietario)
    //         .Include(c => c.Veterinario)
    //         .ToListAsync();
    //     return (totalRegistros, registros);
    // }



}
