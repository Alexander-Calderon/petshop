

using Domain.Interfaces;
using AutoMapper;
using Microsoft.AspNetCore.Mvc;
using ApiPetshop.Dtos;
using Domain.Entities;

namespace ApiPetshop.Controllers;


// Indicar que versiones existen
[ApiVersion("1.0")]
[ApiVersion("1.1")]
public class EspecieController : BaseApiController
{
    
    private readonly IUnitOfWork _unitOfWork;
    private readonly IMapper _mapper;
    public EspecieController(IMapper mapper, IUnitOfWork unitOfWork)
    {
        _mapper = mapper;
        _unitOfWork = unitOfWork;
    }



    /* RUTAS */
    
    // # CRUD Base

    [HttpGet]
    [ProducesResponseType(StatusCodes.Status200OK)]
    [ProducesResponseType(StatusCodes.Status400BadRequest)]
    public async Task<ActionResult<IEnumerable<EspecieDto>>> Get()
    {
        var especies = await _unitOfWork.Especies.GetAllAsync();
        return this._mapper.Map<List<EspecieDto>>(especies);
    }

    [HttpGet("{id}")]
    [ProducesResponseType(StatusCodes.Status200OK)]
    [ProducesResponseType(StatusCodes.Status400BadRequest)]
    [ProducesResponseType(StatusCodes.Status404NotFound)]
    public async Task<ActionResult<EspecieDto>> Get(int id)
    {
        var especie = await _unitOfWork.Especies.GetByIdAsync(id);
        if (especie == null){
            return NotFound();
        }
        return this._mapper.Map<EspecieDto>(especie);
    }

    [HttpPost]
    [ProducesResponseType(StatusCodes.Status201Created)]
    [ProducesResponseType(StatusCodes.Status400BadRequest)]
    public async Task<ActionResult<Especie>> Post(EspecieDto especieDto)
    {
        var especie = this._mapper.Map<Especie>(especieDto);
        this._unitOfWork.Especies.Add(especie);
        await _unitOfWork.SaveAsync();
        if(especie == null)
        {
            return BadRequest();
        }
        especieDto.Id = especie.Id;
        return CreatedAtAction(nameof(Post), new {id = especieDto.Id}, especieDto);
    }

    [HttpPut("{id}")]
    [ProducesResponseType(StatusCodes.Status200OK)]
    [ProducesResponseType(StatusCodes.Status400BadRequest)]
    [ProducesResponseType(StatusCodes.Status404NotFound)]

    public async Task<ActionResult<EspecieDto>> Put(int id, [FromBody]EspecieDto especieDto){
        if(especieDto == null)
        {
            return NotFound();
        }
        var especie = this._mapper.Map<Especie>(especieDto);
        _unitOfWork.Especies.Update(especie);
        await _unitOfWork.SaveAsync();
        return especieDto;
    }

    [HttpDelete("{id}")]
    [ProducesResponseType(StatusCodes.Status204NoContent)]
    [ProducesResponseType(StatusCodes.Status404NotFound)]
    public async Task<IActionResult> Delete(int id){
        var especie = await _unitOfWork.Especies.GetByIdAsync(id);
        if(especie == null)
        {
            return NotFound();
        }
        _unitOfWork.Especies.Remove(especie);
        await _unitOfWork.SaveAsync();
        return NoContent();
    }




    // Consultas
    [MapToApiVersion("1.1")]
    [HttpGet("CB1Mascotas")]
    [ProducesResponseType(StatusCodes.Status200OK)]
    [ProducesResponseType(StatusCodes.Status400BadRequest)]
    public async Task<ActionResult<IEnumerable<EspecieRazaDto>>> CB1Mascotas()
    {
        var mascota = await _unitOfWork.Especies.CB1Mascotas();
        return _mapper.Map<List<EspecieRazaDto>>(mascota);
    }




}




