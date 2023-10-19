

namespace Domain.Entities;

public class DetalleFactura : BaseEntity
{
    public decimal Precio { get; set; }
    public int Cantidad { get; set; }
    public DateTime FechaVenta { get; set; }

    
    public int IdMedicamentoFk { get; set; }
    public int IdFacturaFk { get; set; }

    public Medicamento Medicamentos {get;set;}
    public Factura Facturas {get;set;}

}
