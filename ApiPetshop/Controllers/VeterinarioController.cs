

using Domain.Interfaces;
using AutoMapper;
using Microsoft.AspNetCore.Mvc;
using ApiPetshop.Dtos;
using Domain.Entities;

namespace ApiPetshop.Controllers;

public class VeterinarioController : BaseApiController
{
    
    private readonly IUnitOfWork _unitOfWork;
    private readonly IMapper _mapper;
    public VeterinarioController(IMapper mapper, IUnitOfWork unitOfWork)
    {
        _mapper = mapper;
        _unitOfWork = unitOfWork;
    }



    /* RUTAS */
    
    // # CRUD Base

    [HttpGet]
    [ProducesResponseType(StatusCodes.Status200OK)]
    [ProducesResponseType(StatusCodes.Status400BadRequest)]
    public async Task<ActionResult<IEnumerable<VeterinarioDto>>> Get()
    {
        var veterinarios = await _unitOfWork.Veterinarios.GetAllAsync();
        return this._mapper.Map<List<VeterinarioDto>>(veterinarios);
    }

    [HttpGet("{id}")]
    [ProducesResponseType(StatusCodes.Status200OK)]
    [ProducesResponseType(StatusCodes.Status400BadRequest)]
    [ProducesResponseType(StatusCodes.Status404NotFound)]
    public async Task<ActionResult<VeterinarioDto>> Get(int id)
    {
        var veterinario = await _unitOfWork.Veterinarios.GetByIdAsync(id);
        if (veterinario == null){
            return NotFound();
        }
        return this._mapper.Map<VeterinarioDto>(veterinario);
    }

    [HttpPost]
    [ProducesResponseType(StatusCodes.Status201Created)]
    [ProducesResponseType(StatusCodes.Status400BadRequest)]
    public async Task<ActionResult<Veterinario>> Post(VeterinarioDto veterinarioDto)
    {
        var veterinario = this._mapper.Map<Veterinario>(veterinarioDto);
        this._unitOfWork.Veterinarios.Add(veterinario);
        await _unitOfWork.SaveAsync();
        if(veterinario == null)
        {
            return BadRequest();
        }
        veterinarioDto.Id = veterinario.Id;
        return CreatedAtAction(nameof(Post), new {id = veterinarioDto.Id}, veterinarioDto);
    }

    [HttpPut("{id}")]
    [ProducesResponseType(StatusCodes.Status200OK)]
    [ProducesResponseType(StatusCodes.Status400BadRequest)]
    [ProducesResponseType(StatusCodes.Status404NotFound)]

    public async Task<ActionResult<VeterinarioDto>> Put(int id, [FromBody]VeterinarioDto veterinarioDto){
        if(veterinarioDto == null)
        {
            return NotFound();
        }
        var veterinario = this._mapper.Map<Veterinario>(veterinarioDto);
        _unitOfWork.Veterinarios.Update(veterinario);
        await _unitOfWork.SaveAsync();
        return veterinarioDto;
    }

    [HttpDelete("{id}")]
    [ProducesResponseType(StatusCodes.Status204NoContent)]
    [ProducesResponseType(StatusCodes.Status404NotFound)]
    public async Task<IActionResult> Delete(int id){
        var veterinario = await _unitOfWork.Veterinarios.GetByIdAsync(id);
        if(veterinario == null)
        {
            return NotFound();
        }
        _unitOfWork.Veterinarios.Remove(veterinario);
        await _unitOfWork.SaveAsync();
        return NoContent();
    }


    // # Consultas

    [HttpGet("CA1EspecialidadCirujanoV")]
    [ProducesResponseType(StatusCodes.Status200OK)]
    [ProducesResponseType(StatusCodes.Status400BadRequest)]
    public async Task<ActionResult<IEnumerable<VeterinarioDto>>> CA1VeterinariosEspecialidad()
    {        
        var veterinario = await _unitOfWork.Veterinarios.CA1VeterinariosEspecialidad();
        return _mapper.Map<List<VeterinarioDto>>(veterinario);
    }

    
    [HttpGet("CB3MascotasAtendidas/{nombreVeterinario}")]
    [ProducesResponseType(StatusCodes.Status200OK)]
    [ProducesResponseType(StatusCodes.Status400BadRequest)]
    public async Task<ActionResult<IEnumerable<VeterinarioDto>>> CB3Mascotas(string nombreVeterinario)
    {        
        var veterinario = await _unitOfWork.Veterinarios.CB3Mascotas(nombreVeterinario);
        return _mapper.Map<List<VeterinarioDto>>(veterinario);
    }



}




