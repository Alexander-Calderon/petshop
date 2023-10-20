

using Domain.Interfaces;
using AutoMapper;
using Microsoft.AspNetCore.Mvc;
using ApiPetshop.Dtos;
using Domain.Entities;

namespace ApiPetshop.Controllers;


// Indicar que versiones existen
[ApiVersion("1.0")]
[ApiVersion("1.1")]

public class CitaController : BaseApiController
{
    
    private readonly IUnitOfWork _unitOfWork;
    private readonly IMapper _mapper;
    public CitaController(IMapper mapper, IUnitOfWork unitOfWork)
    {
        _mapper = mapper;
        _unitOfWork = unitOfWork;
    }



    /* RUTAS */
    
    // # CRUD Base

    [HttpGet]
    [ProducesResponseType(StatusCodes.Status200OK)]
    [ProducesResponseType(StatusCodes.Status400BadRequest)]
    // public async Task<ActionResult<IEnumerable<Cita>>> Get()
    public async Task<ActionResult<IEnumerable<CitaDto>>> Get()
    {
        var citas = await _unitOfWork.Citas.GetAllAsync();
        // return Ok(citas);
        return this._mapper.Map<List<CitaDto>>(citas);
    }

    [HttpGet("{id}")]
    [ProducesResponseType(StatusCodes.Status200OK)]
    [ProducesResponseType(StatusCodes.Status400BadRequest)]
    [ProducesResponseType(StatusCodes.Status404NotFound)]
    public async Task<ActionResult<CitaDto>> Get(int id)
    {
        var cita = await _unitOfWork.Citas.GetByIdAsync(id);
        if (cita == null){
            return NotFound();
        }
        return this._mapper.Map<CitaDto>(cita);
    }

    [HttpPost]
    [ProducesResponseType(StatusCodes.Status201Created)]
    [ProducesResponseType(StatusCodes.Status400BadRequest)]
    public async Task<ActionResult<Cita>> Post(CitaDto citaDto)
    {
        var cita = this._mapper.Map<Cita>(citaDto);
        this._unitOfWork.Citas.Add(cita);
        await _unitOfWork.SaveAsync();
        if(cita == null)
        {
            return BadRequest();
        }
        citaDto.Id = cita.Id;
        return CreatedAtAction(nameof(Post), new {id = citaDto.Id}, citaDto);
    }

    [HttpPut("{id}")]
    [ProducesResponseType(StatusCodes.Status200OK)]
    [ProducesResponseType(StatusCodes.Status400BadRequest)]
    [ProducesResponseType(StatusCodes.Status404NotFound)]

    public async Task<ActionResult<CitaDto>> Put(int id, [FromBody]CitaDto citaDto){
        if(citaDto == null)
        {
            return NotFound();            
        }
        var cita = this._mapper.Map<Cita>(citaDto);
        _unitOfWork.Citas.Update(cita);
        await _unitOfWork.SaveAsync();
        return citaDto;
    }

    [HttpDelete("{id}")]
    [ProducesResponseType(StatusCodes.Status204NoContent)]
    [ProducesResponseType(StatusCodes.Status404NotFound)]
    public async Task<IActionResult> Delete(int id){
        var cita = await _unitOfWork.Citas.GetByIdAsync(id);
        if(cita == null)
        {
            return NotFound();
        }
        _unitOfWork.Citas.Remove(cita);
        await _unitOfWork.SaveAsync();
        return NoContent();
    }
    


}




