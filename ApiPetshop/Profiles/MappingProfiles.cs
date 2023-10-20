

using AutoMapper;
using Domain.Entities;
using ApiPetshop.Dtos;

namespace ApiPetshop.Profiles;

public class MappingProfiles : Profile
{
    public MappingProfiles()
    {        
        
        CreateMap<Cita, CitaDto>().ReverseMap();        
        CreateMap<CompraProveedor, CompraProveedorDto>().ReverseMap();
        CreateMap<DetalleFactura, DetalleFacturaDto>().ReverseMap();
        CreateMap<Especialidad, EspecialidadDto>().ReverseMap();
        CreateMap<Especie, EspecieDto>().ReverseMap();
        CreateMap<Factura, FacturaDto>().ReverseMap();
        CreateMap<Laboratorio, LaboratorioDto>().ReverseMap();
        CreateMap<Mascota, MascotaDto>().ReverseMap();
        CreateMap<Medicamento, MedicamentoDto>().ReverseMap();
        CreateMap<Propietario, PropietarioDto>().ReverseMap();
        CreateMap<Proveedor, ProveedorDto>().ReverseMap();
        CreateMap<Raza, RazaDto>().ReverseMap();
        CreateMap<Rol, RolDto>().ReverseMap();
        CreateMap<TratamientoMedico, TratamientoMedicoDto>().ReverseMap();
        CreateMap<Usuario, UsuarioDto>().ReverseMap();
        CreateMap<Veterinario, VeterinarioDto>().ReverseMap();


        // # Multiple 
        CreateMap<Propietario, PropietarioMascotaDto>().ReverseMap();
        
        //qggnea
        CreateMap<Especie, EspecieRazaDto>().ReverseMap();
        CreateMap<Raza, RazaMascotaDto>().ReverseMap();

        CreateMap<CantidadMascotasXRaza, CantidadMascotasXRazaDto>().ReverseMap();

        

        


    }
}
