

using Domain.Interfaces;
using AutoMapper;
using Microsoft.AspNetCore.Mvc;
using ApiPetshop.Dtos;
using Domain.Entities;

namespace ApiPetshop.Controllers;

public class RolController : BaseApiController
{
    
    private readonly IUnitOfWork _unitOfWork;
    private readonly IMapper _mapper;
    public RolController(IMapper mapper, IUnitOfWork unitOfWork)
    {
        _mapper = mapper;
        _unitOfWork = unitOfWork;
    }



    /* RUTAS */
    
    // # CRUD Base

    [HttpGet]
    [ProducesResponseType(StatusCodes.Status200OK)]
    [ProducesResponseType(StatusCodes.Status400BadRequest)]
    public async Task<ActionResult<IEnumerable<RolDto>>> Get()
    {
        var rols = await _unitOfWork.Roles.GetAllAsync();
        return this._mapper.Map<List<RolDto>>(rols);
    }

    [HttpGet("{id}")]
    [ProducesResponseType(StatusCodes.Status200OK)]
    [ProducesResponseType(StatusCodes.Status400BadRequest)]
    [ProducesResponseType(StatusCodes.Status404NotFound)]
    public async Task<ActionResult<RolDto>> Get(int id)
    {
        var rol = await _unitOfWork.Roles.GetByIdAsync(id);
        if (rol == null){
            return NotFound();
        }
        return this._mapper.Map<RolDto>(rol);
    }

    [HttpPost]
    [ProducesResponseType(StatusCodes.Status201Created)]
    [ProducesResponseType(StatusCodes.Status400BadRequest)]
    public async Task<ActionResult<Rol>> Post(RolDto rolDto)
    {
        var rol = this._mapper.Map<Rol>(rolDto);
        this._unitOfWork.Roles.Add(rol);
        await _unitOfWork.SaveAsync();
        if(rol == null)
        {
            return BadRequest();
        }
        rolDto.Id = rol.Id;
        return CreatedAtAction(nameof(Post), new {id = rolDto.Id}, rolDto);
    }

    [HttpPut("{id}")]
    [ProducesResponseType(StatusCodes.Status200OK)]
    [ProducesResponseType(StatusCodes.Status400BadRequest)]
    [ProducesResponseType(StatusCodes.Status404NotFound)]

    public async Task<ActionResult<RolDto>> Put(int id, [FromBody]RolDto rolDto){
        if(rolDto == null)
        {
            return NotFound();
        }
        var rol = this._mapper.Map<Rol>(rolDto);
        _unitOfWork.Roles.Update(rol);
        await _unitOfWork.SaveAsync();
        return rolDto;
    }

    [HttpDelete("{id}")]
    [ProducesResponseType(StatusCodes.Status204NoContent)]
    [ProducesResponseType(StatusCodes.Status404NotFound)]
    public async Task<IActionResult> Delete(int id){
        var rol = await _unitOfWork.Roles.GetByIdAsync(id);
        if(rol == null)
        {
            return NotFound();
        }
        _unitOfWork.Roles.Remove(rol);
        await _unitOfWork.SaveAsync();
        return NoContent();
    }


}




