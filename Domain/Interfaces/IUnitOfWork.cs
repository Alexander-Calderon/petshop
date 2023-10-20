

namespace Domain.Interfaces
{
    public interface IUnitOfWork
    {
        ICita Citas { get; }
        ICompraProveedor ComprasProveedores { get; }
        IDetalleFactura DetallesFacturas { get; }
        IEspecialidad Especialidades { get; }
        IEspecie Especies { get; }
        IFactura Facturas { get; }
        ILaboratorio Laboratorios { get; }
        IMascota Mascotas { get; }
        IMedicamento Medicamentos { get; }
        IPropietario Propietarios { get; }
        IProveedor Proveedores { get; }
        IRaza Razas { get; }
        IRol Roles { get; }
        ITratamientoMedico TratamientosMedicos { get; }
        IUsuario Usuarios { get; }
        IVeterinario Veterinarios { get; }

        Task<int> SaveAsync();
    }
}

















