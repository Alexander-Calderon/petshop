

namespace Domain.Entities;

public class CompraProveedor : BaseEntity
{
    public decimal Precio { get; set; }
    public int Cantidad { get; set; }
    public DateTime FechaCompra { get; set; }


    public int IdProveedorFk { get; set; }
    public int IdMedicamentoFk { get; set; }
    public int IdFacturaFk { get; set; }

    public Proveedor Proveedor {get;set;}
    public Medicamento Medicamento {get;set;}
    public Factura Factura {get;set;}

}
