

using Domain.Interfaces;
using AutoMapper;
using Microsoft.AspNetCore.Mvc;
using ApiPetshop.Dtos;
using Domain.Entities;

namespace ApiPetshop.Controllers;

public class FacturaController : BaseApiController
{
    
    private readonly IUnitOfWork _unitOfWork;
    private readonly IMapper _mapper;
    public FacturaController(IMapper mapper, IUnitOfWork unitOfWork)
    {
        _mapper = mapper;
        _unitOfWork = unitOfWork;
    }



    /* RUTAS */
    
    // # CRUD Base

    [HttpGet]
    [ProducesResponseType(StatusCodes.Status200OK)]
    [ProducesResponseType(StatusCodes.Status400BadRequest)]
    public async Task<ActionResult<IEnumerable<FacturaDto>>> Get()
    {
        var facturas = await _unitOfWork.Facturas.GetAllAsync();
        return this._mapper.Map<List<FacturaDto>>(facturas);
    }

    [HttpGet("{id}")]
    [ProducesResponseType(StatusCodes.Status200OK)]
    [ProducesResponseType(StatusCodes.Status400BadRequest)]
    [ProducesResponseType(StatusCodes.Status404NotFound)]
    public async Task<ActionResult<FacturaDto>> Get(int id)
    {
        var factura = await _unitOfWork.Facturas.GetByIdAsync(id);
        if (factura == null){
            return NotFound();
        }
        return this._mapper.Map<FacturaDto>(factura);
    }

    [HttpPost]
    [ProducesResponseType(StatusCodes.Status201Created)]
    [ProducesResponseType(StatusCodes.Status400BadRequest)]
    public async Task<ActionResult<Factura>> Post(FacturaDto facturaDto)
    {
        var factura = this._mapper.Map<Factura>(facturaDto);
        this._unitOfWork.Facturas.Add(factura);
        await _unitOfWork.SaveAsync();
        if(factura == null)
        {
            return BadRequest();
        }
        facturaDto.Id = factura.Id;
        return CreatedAtAction(nameof(Post), new {id = facturaDto.Id}, facturaDto);
    }

    [HttpPut("{id}")]
    [ProducesResponseType(StatusCodes.Status200OK)]
    [ProducesResponseType(StatusCodes.Status400BadRequest)]
    [ProducesResponseType(StatusCodes.Status404NotFound)]

    public async Task<ActionResult<FacturaDto>> Put(int id, [FromBody]FacturaDto facturaDto){
        if(facturaDto == null)
        {
            return NotFound();
        }
        var factura = this._mapper.Map<Factura>(facturaDto);
        _unitOfWork.Facturas.Update(factura);
        await _unitOfWork.SaveAsync();
        return facturaDto;
    }

    [HttpDelete("{id}")]
    [ProducesResponseType(StatusCodes.Status204NoContent)]
    [ProducesResponseType(StatusCodes.Status404NotFound)]
    public async Task<IActionResult> Delete(int id){
        var factura = await _unitOfWork.Facturas.GetByIdAsync(id);
        if(factura == null)
        {
            return NotFound();
        }
        _unitOfWork.Facturas.Remove(factura);
        await _unitOfWork.SaveAsync();
        return NoContent();
    }


}




