

using Domain.Interfaces;
using AutoMapper;
using Microsoft.AspNetCore.Mvc;
using ApiPetshop.Dtos;
using Domain.Entities;

namespace ApiPetshop.Controllers;

public class MascotaController : BaseApiController
{
    
    private readonly IUnitOfWork _unitOfWork;
    private readonly IMapper _mapper;
    public MascotaController(IMapper mapper, IUnitOfWork unitOfWork)
    {
        _mapper = mapper;
        _unitOfWork = unitOfWork;
    }



    /* RUTAS */
    
    // # CRUD Base

    [HttpGet]
    [ProducesResponseType(StatusCodes.Status200OK)]
    [ProducesResponseType(StatusCodes.Status400BadRequest)]
    public async Task<ActionResult<IEnumerable<MascotaDto>>> Get()
    {
        var mascotas = await _unitOfWork.Mascotas.GetAllAsync();
        return this._mapper.Map<List<MascotaDto>>(mascotas);
    }

    [HttpGet("{id}")]
    [ProducesResponseType(StatusCodes.Status200OK)]
    [ProducesResponseType(StatusCodes.Status400BadRequest)]
    [ProducesResponseType(StatusCodes.Status404NotFound)]
    public async Task<ActionResult<MascotaDto>> Get(int id)
    {
        var mascota = await _unitOfWork.Mascotas.GetByIdAsync(id);
        if (mascota == null){
            return NotFound();
        }
        return this._mapper.Map<MascotaDto>(mascota);
    }

    [HttpPost]
    [ProducesResponseType(StatusCodes.Status201Created)]
    [ProducesResponseType(StatusCodes.Status400BadRequest)]
    public async Task<ActionResult<Mascota>> Post(MascotaDto mascotaDto)
    {
        var mascota = this._mapper.Map<Mascota>(mascotaDto);
        this._unitOfWork.Mascotas.Add(mascota);
        await _unitOfWork.SaveAsync();
        if(mascota == null)
        {
            return BadRequest();
        }
        mascotaDto.Id = mascota.Id;
        return CreatedAtAction(nameof(Post), new {id = mascotaDto.Id}, mascotaDto);
    }

    [HttpPut("{id}")]
    [ProducesResponseType(StatusCodes.Status200OK)]
    [ProducesResponseType(StatusCodes.Status400BadRequest)]
    [ProducesResponseType(StatusCodes.Status404NotFound)]

    public async Task<ActionResult<MascotaDto>> Put(int id, [FromBody]MascotaDto mascotaDto){
        if(mascotaDto == null)
        {
            return NotFound();
        }
        var mascota = this._mapper.Map<Mascota>(mascotaDto);
        _unitOfWork.Mascotas.Update(mascota);
        await _unitOfWork.SaveAsync();
        return mascotaDto;
    }

    [HttpDelete("{id}")]
    [ProducesResponseType(StatusCodes.Status204NoContent)]
    [ProducesResponseType(StatusCodes.Status404NotFound)]
    public async Task<IActionResult> Delete(int id){
        var mascota = await _unitOfWork.Mascotas.GetByIdAsync(id);
        if(mascota == null)
        {
            return NotFound();
        }
        _unitOfWork.Mascotas.Remove(mascota);
        await _unitOfWork.SaveAsync();
        return NoContent();
    }




     // # Consultas

    [HttpGet("CA3EspecieFelina")]
    [ProducesResponseType(StatusCodes.Status200OK)]
    [ProducesResponseType(StatusCodes.Status400BadRequest)]
    public async Task<ActionResult<IEnumerable<MascotaDto>>> CA3EspecieFelina()
    {
        var mascota = await _unitOfWork.Mascotas.CA3EspecieFelina();
        return _mapper.Map<List<MascotaDto>>(mascota);
    }

    [HttpGet("CA6VacunacionPrimerTrimestre")]
    [ProducesResponseType(StatusCodes.Status200OK)]
    [ProducesResponseType(StatusCodes.Status400BadRequest)]
    public async Task<ActionResult<IEnumerable<MascotaDto>>> CA6VacunacionPrimerTrimestre()
    {
        var mascota = await _unitOfWork.Mascotas.CA6VacunacionPrimerTrimestre();
        return _mapper.Map<List<MascotaDto>>(mascota);
    }

    




}




