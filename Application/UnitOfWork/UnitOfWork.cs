
using Application.Repository;
using Domain.Interfaces;
using Persistence;

// using System.Runtime.CompilerServices;

namespace Aplicacion.UnitOfWork;

public class UnitOfWork : IUnitOfWork, IDisposable
{
    private readonly PetshopContext _context;
    public UnitOfWork(PetshopContext context)
    {
        _context = context;
    }
    
    CitaRepository _cita;
    CompraProveedorRepository _compraProveedor;
    DetalleFacturaRepository _detalleFactura;
    EspecialidadRepository _especialidad;
    EspecieRepository _especie;
    FacturaRepository _factura;
    LaboratorioRepository _laboratorio;
    MascotaRepository _mascota;
    MedicamentoRepository _medicamento;
    PropietarioRepository _propietario;
    ProveedorRepository _proveedor;
    RazaRepository _raza;
    RolRepository _rol;
    TratamientoMedicoRepository _tratamientoMedico;
    UsuarioRepository _usuario;
    VeterinarioRepository _veterinario;



    public ICita Citas
    {
        get
        {
            if (_cita is not null)
            {
                return _cita;
            }
            return _cita = new CitaRepository(_context);
        }
    }

    public ICompraProveedor ComprasProveedores 
    {
        get
        {
            if( _compraProveedor is not null)
            {
                return _compraProveedor; 
            }
            return _compraProveedor = new CompraProveedorRepository(_context);
        }
    }

    public IDetalleFactura DetallesFacturas 
    {
        get
        {
            if( _detalleFactura is not null)
            {
                return _detalleFactura; 
            }
            return _detalleFactura = new DetalleFacturaRepository(_context);
        }
    }

    public IEspecialidad Especialidades 
    {
        get
        {
            if( _especialidad is not null)
            {
                return  _especialidad;
            }
            return _especialidad = new EspecialidadRepository(_context);
        }
    }

    public IEspecie Especies 
    {
        get
        {
            if( _especie is not null)
            {
                return _especie ;
            }
            return _especie = new EspecieRepository(_context);
        }
    }

    public IFactura Facturas 
    {
        get
        {
            if( _factura is not null)
            {
                return _factura ;
            }
            return _factura = new FacturaRepository(_context);
        }
    }

    public ILaboratorio Laboratorios 
    {
        get
        {
            if( _laboratorio is not null)
            {
                return _laboratorio ;
            }
            return _laboratorio = new LaboratorioRepository(_context);
        }
    }

    public IMascota Mascotas 
    {
        get
        {
            if( _mascota is not null)
            {
                return _mascota ;
            }
            return _mascota = new MascotaRepository(_context);
        }
    }

    public IMedicamento Medicamentos 
    {
        get
        {
            if( _medicamento is not null)
            {
                return _medicamento ;
            }
            return _medicamento = new MedicamentoRepository(_context);
        }
    }

    public IPropietario Propietarios 
    {
        get
        {
            if( _propietario is not null)
            {
                return _propietario ;
            }
            return _propietario = new PropietarioRepository(_context);
        }
    }

    public IProveedor Proveedores 
    {
        get
        {
            if( _proveedor is not null)
            {
                return _proveedor;
            }
            return _proveedor = new ProveedorRepository(_context);
        }
    }

    public IRaza Razas
    {
        get
        {
            if (_raza is not null)
            {
                return _raza;
            }
            return _raza = new RazaRepository(_context);
        }
    }
    public IRol Roles 
    {
        get
        {
            if( _rol is not null)
            {
                return _rol ;
            }
            return _rol = new RolRepository(_context);
        }
    }
    
    public ITratamientoMedico TratamientosMedicos
    {
        get
        {
            if (_tratamientoMedico is not null)
            {
                return _tratamientoMedico;
            }
            return _tratamientoMedico = new TratamientoMedicoRepository(_context);
        }
    }
    public IUsuario Usuarios 
    {
        get
        {
            if( _usuario is not null)
            {
                return _usuario ;
            }
            return _usuario = new UsuarioRepository(_context);
        }
    }
    public IVeterinario Veterinarios 
    {
        get
        {
            if( _veterinario is not null)
            {
                return _veterinario ;
            }
            return _veterinario = new VeterinarioRepository(_context);
        }
    }

    public void Dispose()
    {
        _context.Dispose();
    }
    public async Task<int> SaveAsync()
    {
        return await _context.SaveChangesAsync();
    }
}