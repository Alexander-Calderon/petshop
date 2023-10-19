

namespace Domain.Entities;

public class Factura : BaseEntity
{    
    public DateTime FechaCreacion { get; set; }
    
    

    public ICollection<DetalleFactura> DetallesFacturas {get; set;}
    public ICollection<CompraProveedor> ComprasProveedores {get; set;}

}
