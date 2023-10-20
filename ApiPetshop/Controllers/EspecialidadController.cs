

using Domain.Interfaces;
using AutoMapper;
using Microsoft.AspNetCore.Mvc;
using ApiPetshop.Dtos;
using Domain.Entities;

namespace ApiPetshop.Controllers;

public class EspecialidadController : BaseApiController
{
    
    private readonly IUnitOfWork _unitOfWork;
    private readonly IMapper _mapper;
    public EspecialidadController(IMapper mapper, IUnitOfWork unitOfWork)
    {
        _mapper = mapper;
        _unitOfWork = unitOfWork;
    }



    /* RUTAS */
    
    // # CRUD Base

    [HttpGet]
    [ProducesResponseType(StatusCodes.Status200OK)]
    [ProducesResponseType(StatusCodes.Status400BadRequest)]
    public async Task<ActionResult<IEnumerable<EspecialidadDto>>> Get()
    {
        var especialidads = await _unitOfWork.Especialidades.GetAllAsync();
        return this._mapper.Map<List<EspecialidadDto>>(especialidads);
    }

    [HttpGet("{id}")]
    [ProducesResponseType(StatusCodes.Status200OK)]
    [ProducesResponseType(StatusCodes.Status400BadRequest)]
    [ProducesResponseType(StatusCodes.Status404NotFound)]
    public async Task<ActionResult<EspecialidadDto>> Get(int id)
    {
        var especialidad = await _unitOfWork.Especialidades.GetByIdAsync(id);
        if (especialidad == null){
            return NotFound();
        }
        return this._mapper.Map<EspecialidadDto>(especialidad);
    }

    [HttpPost]
    [ProducesResponseType(StatusCodes.Status201Created)]
    [ProducesResponseType(StatusCodes.Status400BadRequest)]
    public async Task<ActionResult<Especialidad>> Post(EspecialidadDto especialidadDto)
    {
        var especialidad = this._mapper.Map<Especialidad>(especialidadDto);
        this._unitOfWork.Especialidades.Add(especialidad);
        await _unitOfWork.SaveAsync();
        if(especialidad == null)
        {
            return BadRequest();
        }
        especialidadDto.Id = especialidad.Id;
        return CreatedAtAction(nameof(Post), new {id = especialidadDto.Id}, especialidadDto);
    }

    [HttpPut("{id}")]
    [ProducesResponseType(StatusCodes.Status200OK)]
    [ProducesResponseType(StatusCodes.Status400BadRequest)]
    [ProducesResponseType(StatusCodes.Status404NotFound)]

    public async Task<ActionResult<EspecialidadDto>> Put(int id, [FromBody]EspecialidadDto especialidadDto){
        if(especialidadDto == null)
        {
            return NotFound();
        }
        var especialidad = this._mapper.Map<Especialidad>(especialidadDto);
        _unitOfWork.Especialidades.Update(especialidad);
        await _unitOfWork.SaveAsync();
        return especialidadDto;
    }

    [HttpDelete("{id}")]
    [ProducesResponseType(StatusCodes.Status204NoContent)]
    [ProducesResponseType(StatusCodes.Status404NotFound)]
    public async Task<IActionResult> Delete(int id){
        var especialidad = await _unitOfWork.Especialidades.GetByIdAsync(id);
        if(especialidad == null)
        {
            return NotFound();
        }
        _unitOfWork.Especialidades.Remove(especialidad);
        await _unitOfWork.SaveAsync();
        return NoContent();
    }


}




