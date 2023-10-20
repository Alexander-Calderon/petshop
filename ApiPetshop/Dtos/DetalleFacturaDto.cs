

namespace ApiPetshop.Dtos;

public class DetalleFacturaDto
{
    public int Id {get;set;}
    public decimal Precio { get; set; }
    public int Cantidad { get; set; }
    public DateTime FechaVenta { get; set; }

    public int IdMedicamentoFk { get; set; }
    public int IdFacturaFk { get; set; }
    

}
