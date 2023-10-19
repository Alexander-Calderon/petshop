

namespace Domain.Entities;

public class CompraProveedor : BaseEntity
{
    public decimal Precio { get; set; }
    public int Cantidad { get; set; }
    public DateTime FechaCompra { get; set; }


    public int IdProveedorFk { get; set; }
    public int IdMedicamentoFk { get; set; }
    public int IdFacturaFk { get; set; }

    public Laboratorio Laboratorios {get;set;}
    public Medicamento Medicamentos {get;set;}
    public Factura Facturas {get;set;}

}
