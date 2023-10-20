

using Domain.Interfaces;
using AutoMapper;
using Microsoft.AspNetCore.Mvc;
using ApiPetshop.Dtos;
using Domain.Entities;

namespace ApiPetshop.Controllers;

public class CompraProveedorController : BaseApiController
{
    
    private readonly IUnitOfWork _unitOfWork;
    private readonly IMapper _mapper;
    public CompraProveedorController(IMapper mapper, IUnitOfWork unitOfWork)
    {
        _mapper = mapper;
        _unitOfWork = unitOfWork;
    }



    /* RUTAS */
    
    // # CRUD Base

    [HttpGet]
    [ProducesResponseType(StatusCodes.Status200OK)]
    [ProducesResponseType(StatusCodes.Status400BadRequest)]
    public async Task<ActionResult<IEnumerable<CompraProveedorDto>>> Get()
    {
        var compraproveedors = await _unitOfWork.ComprasProveedores.GetAllAsync();
        return this._mapper.Map<List<CompraProveedorDto>>(compraproveedors);
    }

    [HttpGet("{id}")]
    [ProducesResponseType(StatusCodes.Status200OK)]
    [ProducesResponseType(StatusCodes.Status400BadRequest)]
    [ProducesResponseType(StatusCodes.Status404NotFound)]
    public async Task<ActionResult<CompraProveedorDto>> Get(int id)
    {
        var compraproveedor = await _unitOfWork.ComprasProveedores.GetByIdAsync(id);
        if (compraproveedor == null){
            return NotFound();
        }
        return this._mapper.Map<CompraProveedorDto>(compraproveedor);
    }

    [HttpPost]
    [ProducesResponseType(StatusCodes.Status201Created)]
    [ProducesResponseType(StatusCodes.Status400BadRequest)]
    public async Task<ActionResult<CompraProveedor>> Post(CompraProveedorDto compraproveedorDto)
    {
        var compraproveedor = this._mapper.Map<CompraProveedor>(compraproveedorDto);
        this._unitOfWork.ComprasProveedores.Add(compraproveedor);
        await _unitOfWork.SaveAsync();
        if(compraproveedor == null)
        {
            return BadRequest();
        }
        compraproveedorDto.Id = compraproveedor.Id;
        return CreatedAtAction(nameof(Post), new {id = compraproveedorDto.Id}, compraproveedorDto);
    }

    [HttpPut("{id}")]
    [ProducesResponseType(StatusCodes.Status200OK)]
    [ProducesResponseType(StatusCodes.Status400BadRequest)]
    [ProducesResponseType(StatusCodes.Status404NotFound)]

    public async Task<ActionResult<CompraProveedorDto>> Put(int id, [FromBody]CompraProveedorDto compraproveedorDto){
        if(compraproveedorDto == null)
        {
            return NotFound();
        }
        var compraproveedor = this._mapper.Map<CompraProveedor>(compraproveedorDto);
        _unitOfWork.ComprasProveedores.Update(compraproveedor);
        await _unitOfWork.SaveAsync();
        return compraproveedorDto;
    }

    [HttpDelete("{id}")]
    [ProducesResponseType(StatusCodes.Status204NoContent)]
    [ProducesResponseType(StatusCodes.Status404NotFound)]
    public async Task<IActionResult> Delete(int id){
        var compraproveedor = await _unitOfWork.ComprasProveedores.GetByIdAsync(id);
        if(compraproveedor == null)
        {
            return NotFound();
        }
        _unitOfWork.ComprasProveedores.Remove(compraproveedor);
        await _unitOfWork.SaveAsync();
        return NoContent();
    }


}




