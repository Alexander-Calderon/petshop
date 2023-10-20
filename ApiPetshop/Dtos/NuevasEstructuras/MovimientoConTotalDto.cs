

namespace ApiPetshop.Dtos;

public class MovimientoConTotalDto
{
    public int Id { get; set; }
    public int IdFac { get; set; }
    public string Nombre { get; set; }
    public decimal TotalMovimiento { get; set; }
    public string TipoMovimiento { get; set; }
}
