

namespace Domain.Entities;

public class Proveedor : BaseEntity
{
    public string Nombre { get; set; }
    public string Direccion { get; set; }
    public string Telefono { get; set; }



    public ICollection<CompraProveedor> ComprasProveedores { get; set; }

}
