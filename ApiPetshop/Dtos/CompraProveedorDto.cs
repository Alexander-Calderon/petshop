

namespace ApiPetshop.Dtos;

public class CompraProveedorDto
{
    public int Id {get;set;}    

    public decimal Precio { get; set; }
    public int Cantidad { get; set; }
    public DateTime FechaCompra { get; set; }


    public int IdProveedorFk { get; set; }
    public int IdMedicamentoFk { get; set; }
    public int IdFacturaFk { get; set; }


}
