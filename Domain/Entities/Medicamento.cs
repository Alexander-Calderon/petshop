using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;

namespace Domain.Entities;

public class Medicamento : BaseEntity
{
    public string Nombre { get; set; }
    public int Stock { get; set; }
    public decimal PrecioActual { get; set; }


    public int IdLaboratorioFk { get; set; }

    public Laboratorio Laboratorios {get;set;}


    public ICollection<CompraProveedor> ComprasProveedores { get; set; }
    public ICollection<DetalleFactura> DetallesFacturas { get; set; }
    public ICollection<TratamientoMedico> TratamientosMedicos { get; set; }

}
