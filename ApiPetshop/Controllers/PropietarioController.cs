

using Domain.Interfaces;
using AutoMapper;
using Microsoft.AspNetCore.Mvc;
using ApiPetshop.Dtos;
using Domain.Entities;

namespace ApiPetshop.Controllers;

public class PropietarioController : BaseApiController
{
    
    private readonly IUnitOfWork _unitOfWork;
    private readonly IMapper _mapper;
    public PropietarioController(IMapper mapper, IUnitOfWork unitOfWork)
    {
        _mapper = mapper;
        _unitOfWork = unitOfWork;
    }



    /* RUTAS */
    
    // # CRUD Base

    [HttpGet]
    [ProducesResponseType(StatusCodes.Status200OK)]
    [ProducesResponseType(StatusCodes.Status400BadRequest)]
    public async Task<ActionResult<IEnumerable<PropietarioDto>>> Get()
    {
        var propietarios = await _unitOfWork.Propietarios.GetAllAsync();
        return this._mapper.Map<List<PropietarioDto>>(propietarios);
    }

    [HttpGet("{id}")]
    [ProducesResponseType(StatusCodes.Status200OK)]
    [ProducesResponseType(StatusCodes.Status400BadRequest)]
    [ProducesResponseType(StatusCodes.Status404NotFound)]
    public async Task<ActionResult<PropietarioDto>> Get(int id)
    {
        var propietario = await _unitOfWork.Propietarios.GetByIdAsync(id);
        if (propietario == null){
            return NotFound();
        }
        return this._mapper.Map<PropietarioDto>(propietario);
    }

    [HttpPost]
    [ProducesResponseType(StatusCodes.Status201Created)]
    [ProducesResponseType(StatusCodes.Status400BadRequest)]
    public async Task<ActionResult<Propietario>> Post(PropietarioDto propietarioDto)
    {
        var propietario = this._mapper.Map<Propietario>(propietarioDto);
        this._unitOfWork.Propietarios.Add(propietario);
        await _unitOfWork.SaveAsync();
        if(propietario == null)
        {
            return BadRequest();
        }
        propietarioDto.Id = propietario.Id;
        return CreatedAtAction(nameof(Post), new {id = propietarioDto.Id}, propietarioDto);
    }

    [HttpPut("{id}")]
    [ProducesResponseType(StatusCodes.Status200OK)]
    [ProducesResponseType(StatusCodes.Status400BadRequest)]
    [ProducesResponseType(StatusCodes.Status404NotFound)]

    public async Task<ActionResult<PropietarioDto>> Put(int id, [FromBody]PropietarioDto propietarioDto){
        if(propietarioDto == null)
        {
            return NotFound();
        }
        var propietario = this._mapper.Map<Propietario>(propietarioDto);
        _unitOfWork.Propietarios.Update(propietario);
        await _unitOfWork.SaveAsync();
        return propietarioDto;
    }

    [HttpDelete("{id}")]
    [ProducesResponseType(StatusCodes.Status204NoContent)]
    [ProducesResponseType(StatusCodes.Status404NotFound)]
    public async Task<IActionResult> Delete(int id){
        var propietario = await _unitOfWork.Propietarios.GetByIdAsync(id);
        if(propietario == null)
        {
            return NotFound();
        }
        _unitOfWork.Propietarios.Remove(propietario);
        await _unitOfWork.SaveAsync();
        return NoContent();
    }

    // # Consultas

    [HttpGet("CA4Mascotas")]
    [ProducesResponseType(StatusCodes.Status200OK)]
    [ProducesResponseType(StatusCodes.Status400BadRequest)]
    public async Task<ActionResult<IEnumerable<PropietarioMascotaDto>>> CA4Mascotas()
    {
        var veterinario = await _unitOfWork.Propietarios.CA4Mascotas();
        return _mapper.Map<List<PropietarioMascotaDto>>(veterinario);
    }


    


}




