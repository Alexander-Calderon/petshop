

using Domain.Interfaces;
using AutoMapper;
using Microsoft.AspNetCore.Mvc;
using ApiPetshop.Dtos;
using Domain.Entities;

namespace ApiPetshop.Controllers;

public class RazaController : BaseApiController
{
    
    private readonly IUnitOfWork _unitOfWork;
    private readonly IMapper _mapper;
    public RazaController(IMapper mapper, IUnitOfWork unitOfWork)
    {
        _mapper = mapper;
        _unitOfWork = unitOfWork;
    }



    /* RUTAS */
    
    // # CRUD Base

    [HttpGet]
    [ProducesResponseType(StatusCodes.Status200OK)]
    [ProducesResponseType(StatusCodes.Status400BadRequest)]
    public async Task<ActionResult<IEnumerable<RazaDto>>> Get()
    {
        var razas = await _unitOfWork.Razas.GetAllAsync();
        return this._mapper.Map<List<RazaDto>>(razas);
    }

    [HttpGet("{id}")]
    [ProducesResponseType(StatusCodes.Status200OK)]
    [ProducesResponseType(StatusCodes.Status400BadRequest)]
    [ProducesResponseType(StatusCodes.Status404NotFound)]
    public async Task<ActionResult<RazaDto>> Get(int id)
    {
        var raza = await _unitOfWork.Razas.GetByIdAsync(id);
        if (raza == null){
            return NotFound();
        }
        return this._mapper.Map<RazaDto>(raza);
    }

    [HttpPost]
    [ProducesResponseType(StatusCodes.Status201Created)]
    [ProducesResponseType(StatusCodes.Status400BadRequest)]
    public async Task<ActionResult<Raza>> Post(RazaDto razaDto)
    {
        var raza = this._mapper.Map<Raza>(razaDto);
        this._unitOfWork.Razas.Add(raza);
        await _unitOfWork.SaveAsync();
        if(raza == null)
        {
            return BadRequest();
        }
        razaDto.Id = raza.Id;
        return CreatedAtAction(nameof(Post), new {id = razaDto.Id}, razaDto);
    }

    [HttpPut("{id}")]
    [ProducesResponseType(StatusCodes.Status200OK)]
    [ProducesResponseType(StatusCodes.Status400BadRequest)]
    [ProducesResponseType(StatusCodes.Status404NotFound)]

    public async Task<ActionResult<RazaDto>> Put(int id, [FromBody]RazaDto razaDto){
        if(razaDto == null)
        {
            return NotFound();
        }
        var raza = this._mapper.Map<Raza>(razaDto);
        _unitOfWork.Razas.Update(raza);
        await _unitOfWork.SaveAsync();
        return razaDto;
    }

    [HttpDelete("{id}")]
    [ProducesResponseType(StatusCodes.Status204NoContent)]
    [ProducesResponseType(StatusCodes.Status404NotFound)]
    public async Task<IActionResult> Delete(int id){
        var raza = await _unitOfWork.Razas.GetByIdAsync(id);
        if(raza == null)
        {
            return NotFound();
        }
        _unitOfWork.Razas.Remove(raza);
        await _unitOfWork.SaveAsync();
        return NoContent();
    }


    // # Consultas

    [HttpGet("CB5PropietariosMascotasGolden")]    
    [ProducesResponseType(StatusCodes.Status200OK)]
    [ProducesResponseType(StatusCodes.Status400BadRequest)]
    public async Task<ActionResult<IEnumerable<RazaMascotaDto>>> CB5PropietariosMascotasGolden()
    {        
        // return BadRequest("Ingrese una Especialidad.");
        var razas = await _unitOfWork.Razas.CB5PropietariosMascotasGolden();
        return _mapper.Map<List<RazaMascotaDto>>(razas);
    } 


    
    [HttpGet("TotalMascotasPorRaza")]
    [ProducesResponseType(StatusCodes.Status200OK)]
    [ProducesResponseType(StatusCodes.Status400BadRequest)]
    public async Task<ActionResult<IEnumerable<CantidadMascotasXRaza>>> CantidadMascotasXRaza()
    {
        var razas = await _unitOfWork.Razas.CantidadMascotasXRaza();
        return _mapper.Map<List<CantidadMascotasXRaza>>(razas);
    } 



}




