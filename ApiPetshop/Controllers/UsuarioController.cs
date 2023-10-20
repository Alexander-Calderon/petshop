

using Domain.Interfaces;
using AutoMapper;
using Microsoft.AspNetCore.Mvc;
using ApiPetshop.Dtos;
using Domain.Entities;

namespace ApiPetshop.Controllers;

public class UsuarioController : BaseApiController
{
    
    private readonly IUnitOfWork _unitOfWork;
    private readonly IMapper _mapper;
    public UsuarioController(IMapper mapper, IUnitOfWork unitOfWork)
    {
        _mapper = mapper;
        _unitOfWork = unitOfWork;
    }



    /* RUTAS */
    
    // # CRUD Base

    [HttpGet]
    [ProducesResponseType(StatusCodes.Status200OK)]
    [ProducesResponseType(StatusCodes.Status400BadRequest)]
    public async Task<ActionResult<IEnumerable<UsuarioDto>>> Get()
    {
        var usuarios = await _unitOfWork.Usuarios.GetAllAsync();
        return this._mapper.Map<List<UsuarioDto>>(usuarios);
    }

    [HttpGet("{id}")]
    [ProducesResponseType(StatusCodes.Status200OK)]
    [ProducesResponseType(StatusCodes.Status400BadRequest)]
    [ProducesResponseType(StatusCodes.Status404NotFound)]
    public async Task<ActionResult<UsuarioDto>> Get(int id)
    {
        var usuario = await _unitOfWork.Usuarios.GetByIdAsync(id);
        if (usuario == null){
            return NotFound();
        }
        return this._mapper.Map<UsuarioDto>(usuario);
    }

    [HttpPost]
    [ProducesResponseType(StatusCodes.Status201Created)]
    [ProducesResponseType(StatusCodes.Status400BadRequest)]
    public async Task<ActionResult<Usuario>> Post(UsuarioDto usuarioDto)
    {
        var usuario = this._mapper.Map<Usuario>(usuarioDto);
        this._unitOfWork.Usuarios.Add(usuario);
        await _unitOfWork.SaveAsync();
        if(usuario == null)
        {
            return BadRequest();
        }
        usuarioDto.Id = usuario.Id;
        return CreatedAtAction(nameof(Post), new {id = usuarioDto.Id}, usuarioDto);
    }

    [HttpPut("{id}")]
    [ProducesResponseType(StatusCodes.Status200OK)]
    [ProducesResponseType(StatusCodes.Status400BadRequest)]
    [ProducesResponseType(StatusCodes.Status404NotFound)]

    public async Task<ActionResult<UsuarioDto>> Put(int id, [FromBody]UsuarioDto usuarioDto){
        if(usuarioDto == null)
        {
            return NotFound();
        }
        var usuario = this._mapper.Map<Usuario>(usuarioDto);
        _unitOfWork.Usuarios.Update(usuario);
        await _unitOfWork.SaveAsync();
        return usuarioDto;
    }

    [HttpDelete("{id}")]
    [ProducesResponseType(StatusCodes.Status204NoContent)]
    [ProducesResponseType(StatusCodes.Status404NotFound)]
    public async Task<IActionResult> Delete(int id){
        var usuario = await _unitOfWork.Usuarios.GetByIdAsync(id);
        if(usuario == null)
        {
            return NotFound();
        }
        _unitOfWork.Usuarios.Remove(usuario);
        await _unitOfWork.SaveAsync();
        return NoContent();
    }


}




