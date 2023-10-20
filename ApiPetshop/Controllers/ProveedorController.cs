

using Domain.Interfaces;
using AutoMapper;
using Microsoft.AspNetCore.Mvc;
using ApiPetshop.Dtos;
using Domain.Entities;

namespace ApiPetshop.Controllers;

public class ProveedorController : BaseApiController
{
    
    private readonly IUnitOfWork _unitOfWork;
    private readonly IMapper _mapper;
    public ProveedorController(IMapper mapper, IUnitOfWork unitOfWork)
    {
        _mapper = mapper;
        _unitOfWork = unitOfWork;
    }



    /* RUTAS */
    
    // # CRUD Base

    [HttpGet]
    [ProducesResponseType(StatusCodes.Status200OK)]
    [ProducesResponseType(StatusCodes.Status400BadRequest)]
    public async Task<ActionResult<IEnumerable<ProveedorDto>>> Get()
    {
        var proveedors = await _unitOfWork.Proveedores.GetAllAsync();
        return this._mapper.Map<List<ProveedorDto>>(proveedors);
    }

    [HttpGet("{id}")]
    [ProducesResponseType(StatusCodes.Status200OK)]
    [ProducesResponseType(StatusCodes.Status400BadRequest)]
    [ProducesResponseType(StatusCodes.Status404NotFound)]
    public async Task<ActionResult<ProveedorDto>> Get(int id)
    {
        var proveedor = await _unitOfWork.Proveedores.GetByIdAsync(id);
        if (proveedor == null){
            return NotFound();
        }
        return this._mapper.Map<ProveedorDto>(proveedor);
    }

    [HttpPost]
    [ProducesResponseType(StatusCodes.Status201Created)]
    [ProducesResponseType(StatusCodes.Status400BadRequest)]
    public async Task<ActionResult<Proveedor>> Post(ProveedorDto proveedorDto)
    {
        var proveedor = this._mapper.Map<Proveedor>(proveedorDto);
        this._unitOfWork.Proveedores.Add(proveedor);
        await _unitOfWork.SaveAsync();
        if(proveedor == null)
        {
            return BadRequest();
        }
        proveedorDto.Id = proveedor.Id;
        return CreatedAtAction(nameof(Post), new {id = proveedorDto.Id}, proveedorDto);
    }

    [HttpPut("{id}")]
    [ProducesResponseType(StatusCodes.Status200OK)]
    [ProducesResponseType(StatusCodes.Status400BadRequest)]
    [ProducesResponseType(StatusCodes.Status404NotFound)]

    public async Task<ActionResult<ProveedorDto>> Put(int id, [FromBody]ProveedorDto proveedorDto){
        if(proveedorDto == null)
        {
            return NotFound();
        }
        var proveedor = this._mapper.Map<Proveedor>(proveedorDto);
        _unitOfWork.Proveedores.Update(proveedor);
        await _unitOfWork.SaveAsync();
        return proveedorDto;
    }

    [HttpDelete("{id}")]
    [ProducesResponseType(StatusCodes.Status204NoContent)]
    [ProducesResponseType(StatusCodes.Status404NotFound)]
    public async Task<IActionResult> Delete(int id){
        var proveedor = await _unitOfWork.Proveedores.GetByIdAsync(id);
        if(proveedor == null)
        {
            return NotFound();
        }
        _unitOfWork.Proveedores.Remove(proveedor);
        await _unitOfWork.SaveAsync();
        return NoContent();
    }


    // # Consultas

    [HttpGet("CB4MedicamentoConProveedor/{medicamento}")]
    [ProducesResponseType(StatusCodes.Status200OK)]
    [ProducesResponseType(StatusCodes.Status400BadRequest)]
    public async Task<ActionResult<IEnumerable<Proveedor>>> CB4MedicamentoConProveedor(string medicamento)
    {
        var medicamentos = await _unitOfWork.Proveedores.CB4MedicamentoConProveedor(medicamento);
        return _mapper.Map<List<Proveedor>>(medicamentos);
    }

    
    


}




