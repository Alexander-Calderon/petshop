

using Domain.Interfaces;
using AutoMapper;
using Microsoft.AspNetCore.Mvc;
using ApiPetshop.Dtos;
using Domain.Entities;

namespace ApiPetshop.Controllers;

public class LaboratorioController : BaseApiController
{
    
    private readonly IUnitOfWork _unitOfWork;
    private readonly IMapper _mapper;
    public LaboratorioController(IMapper mapper, IUnitOfWork unitOfWork)
    {
        _mapper = mapper;
        _unitOfWork = unitOfWork;
    }



    /* RUTAS */
    
    // # CRUD Base

    [HttpGet]
    [ProducesResponseType(StatusCodes.Status200OK)]
    [ProducesResponseType(StatusCodes.Status400BadRequest)]
    public async Task<ActionResult<IEnumerable<LaboratorioDto>>> Get()
    {
        var laboratorios = await _unitOfWork.Laboratorios.GetAllAsync();
        return this._mapper.Map<List<LaboratorioDto>>(laboratorios);
    }

    [HttpGet("{id}")]
    [ProducesResponseType(StatusCodes.Status200OK)]
    [ProducesResponseType(StatusCodes.Status400BadRequest)]
    [ProducesResponseType(StatusCodes.Status404NotFound)]
    public async Task<ActionResult<LaboratorioDto>> Get(int id)
    {
        var laboratorio = await _unitOfWork.Laboratorios.GetByIdAsync(id);
        if (laboratorio == null){
            return NotFound();
        }
        return this._mapper.Map<LaboratorioDto>(laboratorio);
    }

    [HttpPost]
    [ProducesResponseType(StatusCodes.Status201Created)]
    [ProducesResponseType(StatusCodes.Status400BadRequest)]
    public async Task<ActionResult<Laboratorio>> Post(LaboratorioDto laboratorioDto)
    {
        var laboratorio = this._mapper.Map<Laboratorio>(laboratorioDto);
        this._unitOfWork.Laboratorios.Add(laboratorio);
        await _unitOfWork.SaveAsync();
        if(laboratorio == null)
        {
            return BadRequest();
        }
        laboratorioDto.Id = laboratorio.Id;
        return CreatedAtAction(nameof(Post), new {id = laboratorioDto.Id}, laboratorioDto);
    }

    [HttpPut("{id}")]
    [ProducesResponseType(StatusCodes.Status200OK)]
    [ProducesResponseType(StatusCodes.Status400BadRequest)]
    [ProducesResponseType(StatusCodes.Status404NotFound)]

    public async Task<ActionResult<LaboratorioDto>> Put(int id, [FromBody]LaboratorioDto laboratorioDto){
        if(laboratorioDto == null)
        {
            return NotFound();
        }
        var laboratorio = this._mapper.Map<Laboratorio>(laboratorioDto);
        _unitOfWork.Laboratorios.Update(laboratorio);
        await _unitOfWork.SaveAsync();
        return laboratorioDto;
    }

    [HttpDelete("{id}")]
    [ProducesResponseType(StatusCodes.Status204NoContent)]
    [ProducesResponseType(StatusCodes.Status404NotFound)]
    public async Task<IActionResult> Delete(int id){
        var laboratorio = await _unitOfWork.Laboratorios.GetByIdAsync(id);
        if(laboratorio == null)
        {
            return NotFound();
        }
        _unitOfWork.Laboratorios.Remove(laboratorio);
        await _unitOfWork.SaveAsync();
        return NoContent();
    }


}




