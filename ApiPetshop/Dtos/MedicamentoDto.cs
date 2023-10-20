

namespace ApiPetshop.Dtos;

public class MedicamentoDto
{
    public int Id {get;set;}
    public string Nombre { get; set; }
    public int Stock { get; set; }
    public decimal PrecioActual { get; set; }

    public int IdLaboratorioFk { get; set; }



}
