

namespace ApiPetshop.Dtos;

public class PropietarioMascotaDto
{
    public int Id { get; set; }
    public string Nombre { get; set; }
    public List<MascotaDto> Mascotas { get; set; }



}
