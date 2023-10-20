

using Domain.Interfaces;
using AutoMapper;
using Microsoft.AspNetCore.Mvc;
using ApiPetshop.Dtos;
using Domain.Entities;

namespace ApiPetshop.Controllers;

public class TratamientoMedicoController : BaseApiController
{
    
    private readonly IUnitOfWork _unitOfWork;
    private readonly IMapper _mapper;
    public TratamientoMedicoController(IMapper mapper, IUnitOfWork unitOfWork)
    {
        _mapper = mapper;
        _unitOfWork = unitOfWork;
    }



    /* RUTAS */
    
    // # CRUD Base

    [HttpGet]
    [ProducesResponseType(StatusCodes.Status200OK)]
    [ProducesResponseType(StatusCodes.Status400BadRequest)]
    public async Task<ActionResult<IEnumerable<TratamientoMedicoDto>>> Get()
    {
        var tratamientomedicos = await _unitOfWork.TratamientosMedicos.GetAllAsync();
        return this._mapper.Map<List<TratamientoMedicoDto>>(tratamientomedicos);
    }

    [HttpGet("{id}")]
    [ProducesResponseType(StatusCodes.Status200OK)]
    [ProducesResponseType(StatusCodes.Status400BadRequest)]
    [ProducesResponseType(StatusCodes.Status404NotFound)]
    public async Task<ActionResult<TratamientoMedicoDto>> Get(int id)
    {
        var tratamientomedico = await _unitOfWork.TratamientosMedicos.GetByIdAsync(id);
        if (tratamientomedico == null){
            return NotFound();
        }
        return this._mapper.Map<TratamientoMedicoDto>(tratamientomedico);
    }

    [HttpPost]
    [ProducesResponseType(StatusCodes.Status201Created)]
    [ProducesResponseType(StatusCodes.Status400BadRequest)]
    public async Task<ActionResult<TratamientoMedico>> Post(TratamientoMedicoDto tratamientomedicoDto)
    {
        var tratamientomedico = this._mapper.Map<TratamientoMedico>(tratamientomedicoDto);
        this._unitOfWork.TratamientosMedicos.Add(tratamientomedico);
        await _unitOfWork.SaveAsync();
        if(tratamientomedico == null)
        {
            return BadRequest();
        }
        tratamientomedicoDto.Id = tratamientomedico.Id;
        return CreatedAtAction(nameof(Post), new {id = tratamientomedicoDto.Id}, tratamientomedicoDto);
    }

    [HttpPut("{id}")]
    [ProducesResponseType(StatusCodes.Status200OK)]
    [ProducesResponseType(StatusCodes.Status400BadRequest)]
    [ProducesResponseType(StatusCodes.Status404NotFound)]

    public async Task<ActionResult<TratamientoMedicoDto>> Put(int id, [FromBody]TratamientoMedicoDto tratamientomedicoDto){
        if(tratamientomedicoDto == null)
        {
            return NotFound();
        }
        var tratamientomedico = this._mapper.Map<TratamientoMedico>(tratamientomedicoDto);
        _unitOfWork.TratamientosMedicos.Update(tratamientomedico);
        await _unitOfWork.SaveAsync();
        return tratamientomedicoDto;
    }

    [HttpDelete("{id}")]
    [ProducesResponseType(StatusCodes.Status204NoContent)]
    [ProducesResponseType(StatusCodes.Status404NotFound)]
    public async Task<IActionResult> Delete(int id){
        var tratamientomedico = await _unitOfWork.TratamientosMedicos.GetByIdAsync(id);
        if(tratamientomedico == null)
        {
            return NotFound();
        }
        _unitOfWork.TratamientosMedicos.Remove(tratamientomedico);
        await _unitOfWork.SaveAsync();
        return NoContent();
    }


}




