

namespace Domain.Entities;

public class TratamientoMedico : BaseEntity
{
    public int Dosis { get; set; }
    public DateTime FechaAdministracion { get; set; }
    public string Observacion { get; set; }


    public int IdCitaFk { get; set; }
    public int IdMedicamentoFk { get; set; }
    

    public Medicamento Medicamento {get;set;}
    public Cita Cita {get;set;}

}
