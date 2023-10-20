

using Domain.Interfaces;
using AutoMapper;
using Microsoft.AspNetCore.Mvc;
using ApiPetshop.Dtos;
using Domain.Entities;

namespace ApiPetshop.Controllers;

public class DetalleFacturaController : BaseApiController
{
    
    private readonly IUnitOfWork _unitOfWork;
    private readonly IMapper _mapper;
    public DetalleFacturaController(IMapper mapper, IUnitOfWork unitOfWork)
    {
        _mapper = mapper;
        _unitOfWork = unitOfWork;
    }



    /* RUTAS */
    
    // # CRUD Base

    [HttpGet]
    [ProducesResponseType(StatusCodes.Status200OK)]
    [ProducesResponseType(StatusCodes.Status400BadRequest)]
    public async Task<ActionResult<IEnumerable<DetalleFacturaDto>>> Get()
    {
        var detallefacturas = await _unitOfWork.DetallesFacturas.GetAllAsync();
        return this._mapper.Map<List<DetalleFacturaDto>>(detallefacturas);
    }

    [HttpGet("{id}")]
    [ProducesResponseType(StatusCodes.Status200OK)]
    [ProducesResponseType(StatusCodes.Status400BadRequest)]
    [ProducesResponseType(StatusCodes.Status404NotFound)]
    public async Task<ActionResult<DetalleFacturaDto>> Get(int id)
    {
        var detallefactura = await _unitOfWork.DetallesFacturas.GetByIdAsync(id);
        if (detallefactura == null){
            return NotFound();
        }
        return this._mapper.Map<DetalleFacturaDto>(detallefactura);
    }

    [HttpPost]
    [ProducesResponseType(StatusCodes.Status201Created)]
    [ProducesResponseType(StatusCodes.Status400BadRequest)]
    public async Task<ActionResult<DetalleFactura>> Post(DetalleFacturaDto detallefacturaDto)
    {
        var detallefactura = this._mapper.Map<DetalleFactura>(detallefacturaDto);
        this._unitOfWork.DetallesFacturas.Add(detallefactura);
        await _unitOfWork.SaveAsync();
        if(detallefactura == null)
        {
            return BadRequest();
        }
        detallefacturaDto.Id = detallefactura.Id;
        return CreatedAtAction(nameof(Post), new {id = detallefacturaDto.Id}, detallefacturaDto);
    }

    [HttpPut("{id}")]
    [ProducesResponseType(StatusCodes.Status200OK)]
    [ProducesResponseType(StatusCodes.Status400BadRequest)]
    [ProducesResponseType(StatusCodes.Status404NotFound)]

    public async Task<ActionResult<DetalleFacturaDto>> Put(int id, [FromBody]DetalleFacturaDto detallefacturaDto){
        if(detallefacturaDto == null)
        {
            return NotFound();
        }
        var detallefactura = this._mapper.Map<DetalleFactura>(detallefacturaDto);
        _unitOfWork.DetallesFacturas.Update(detallefactura);
        await _unitOfWork.SaveAsync();
        return detallefacturaDto;
    }

    [HttpDelete("{id}")]
    [ProducesResponseType(StatusCodes.Status204NoContent)]
    [ProducesResponseType(StatusCodes.Status404NotFound)]
    public async Task<IActionResult> Delete(int id){
        var detallefactura = await _unitOfWork.DetallesFacturas.GetByIdAsync(id);
        if(detallefactura == null)
        {
            return NotFound();
        }
        _unitOfWork.DetallesFacturas.Remove(detallefactura);
        await _unitOfWork.SaveAsync();
        return NoContent();
    }


}




