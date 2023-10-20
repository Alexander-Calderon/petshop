

using Domain.Interfaces;
using AutoMapper;
using Microsoft.AspNetCore.Mvc;
using ApiPetshop.Dtos;
using Domain.Entities;

namespace ApiPetshop.Controllers;

public class MedicamentoController : BaseApiController
{
    
    private readonly IUnitOfWork _unitOfWork;
    private readonly IMapper _mapper;
    public MedicamentoController(IMapper mapper, IUnitOfWork unitOfWork)
    {
        _mapper = mapper;
        _unitOfWork = unitOfWork;
    }



    /* RUTAS */
    
    // # CRUD Base

    [HttpGet]
    [ProducesResponseType(StatusCodes.Status200OK)]
    [ProducesResponseType(StatusCodes.Status400BadRequest)]
    public async Task<ActionResult<IEnumerable<MedicamentoDto>>> Get()
    {
        var medicamentos = await _unitOfWork.Medicamentos.GetAllAsync();
        return this._mapper.Map<List<MedicamentoDto>>(medicamentos);
    }

    [HttpGet("{id}")]
    [ProducesResponseType(StatusCodes.Status200OK)]
    [ProducesResponseType(StatusCodes.Status400BadRequest)]
    [ProducesResponseType(StatusCodes.Status404NotFound)]
    public async Task<ActionResult<MedicamentoDto>> Get(int id)
    {
        var medicamento = await _unitOfWork.Medicamentos.GetByIdAsync(id);
        if (medicamento == null){
            return NotFound();
        }
        return this._mapper.Map<MedicamentoDto>(medicamento);
    }

    [HttpPost]
    [ProducesResponseType(StatusCodes.Status201Created)]
    [ProducesResponseType(StatusCodes.Status400BadRequest)]
    public async Task<ActionResult<Medicamento>> Post(MedicamentoDto medicamentoDto)
    {
        var medicamento = this._mapper.Map<Medicamento>(medicamentoDto);
        this._unitOfWork.Medicamentos.Add(medicamento);
        await _unitOfWork.SaveAsync();
        if(medicamento == null)
        {
            return BadRequest();
        }
        medicamentoDto.Id = medicamento.Id;
        return CreatedAtAction(nameof(Post), new {id = medicamentoDto.Id}, medicamentoDto);
    }

    [HttpPut("{id}")]
    [ProducesResponseType(StatusCodes.Status200OK)]
    [ProducesResponseType(StatusCodes.Status400BadRequest)]
    [ProducesResponseType(StatusCodes.Status404NotFound)]

    public async Task<ActionResult<MedicamentoDto>> Put(int id, [FromBody]MedicamentoDto medicamentoDto){
        if(medicamentoDto == null)
        {
            return NotFound();
        }
        var medicamento = this._mapper.Map<Medicamento>(medicamentoDto);
        _unitOfWork.Medicamentos.Update(medicamento);
        await _unitOfWork.SaveAsync();
        return medicamentoDto;
    }

    [HttpDelete("{id}")]
    [ProducesResponseType(StatusCodes.Status204NoContent)]
    [ProducesResponseType(StatusCodes.Status404NotFound)]
    public async Task<IActionResult> Delete(int id){
        var medicamento = await _unitOfWork.Medicamentos.GetByIdAsync(id);
        if(medicamento == null)
        {
            return NotFound();
        }
        _unitOfWork.Medicamentos.Remove(medicamento);
        await _unitOfWork.SaveAsync();
        return NoContent();
    }




    // # Consultas

    [HttpGet("CA2LaboratorioGenfar")]
    [ProducesResponseType(StatusCodes.Status200OK)]
    [ProducesResponseType(StatusCodes.Status400BadRequest)]
    public async Task<ActionResult<IEnumerable<MedicamentoDto>>> CA2LaboratorioGenfar()
    {        
        var medicamento = await _unitOfWork.Medicamentos.CA2LaboratorioGenfar();
        return _mapper.Map<List<MedicamentoDto>>(medicamento);
    }

    
    //
    [HttpGet("CA5Mayor50000")]
    [ProducesResponseType(StatusCodes.Status200OK)]
    [ProducesResponseType(StatusCodes.Status400BadRequest)]
    public async Task<ActionResult<IEnumerable<MedicamentoDto>>> CA5Mayor50000()
    {
        var medicamentos = await _unitOfWork.Medicamentos.CA5Mayor50000();
        return _mapper.Map<List<MedicamentoDto>>(medicamentos);
    }

    // [HttpGet("CB2MovimientosConTotal")]
    // [ProducesResponseType(StatusCodes.Status200OK)]
    // [ProducesResponseType(StatusCodes.Status400BadRequest)]
    // public async Task<ActionResult<IEnumerable<object>>> CB2MovimientosConTotal()
    // {
    //     var medicamentos = await _unitOfWork.Medicamentos.CB2MovimientosConTotal();
    //     return _mapper.Map<IEnumerable<object>>(medicamentos);
    // }

    [HttpGet("CB2MovimientosConTotal")]
    [ProducesResponseType(StatusCodes.Status200OK)]
    [ProducesResponseType(StatusCodes.Status400BadRequest)]
    public async Task<ActionResult<object>> CB2MovimientosConTotal()
    {
        var entidad = await _unitOfWork.Medicamentos.CB2MovimientosConTotal();
        var dto = _mapper.Map<IEnumerable<object>>(entidad);
        return Ok(dto);
    }


}




