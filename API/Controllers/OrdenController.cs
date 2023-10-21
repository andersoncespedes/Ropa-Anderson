using Microsoft.AspNetCore.Mvc;
using API.Dtos;
using API.Helpers;
using Dominio.Interfaces;
using Dominio.Entities;
using AutoMapper;
using Microsoft.AspNetCore.Authorization;

namespace API.Controllers;
public class OrdenController : BaseApiController
{
    private readonly IUnitOfWork _unitOfWork;
    private IMapper _mapper;
    public OrdenController(IUnitOfWork unitOfWork, IMapper mapper)
    {
        _unitOfWork = unitOfWork;
        _mapper = mapper;
    }
    [HttpGet]
    [ProducesResponseType(StatusCodes.Status200OK)]
    [ProducesResponseType(StatusCodes.Status400BadRequest)]
    public async Task<ActionResult<IEnumerable<OrdenDto>>> GetAll()
    {
        var datos = await _unitOfWork.Ordenes.GetAllAsync();
        var mapeo = _mapper.Map<List<OrdenDto>>(datos);
        return mapeo;
    }
    [MapToApiVersion("1.1")]
    [HttpGet]
    [ProducesResponseType(StatusCodes.Status200OK)]
    [ProducesResponseType(StatusCodes.Status400BadRequest)]
    public async Task<ActionResult<Pager<OrdenDto>>> Paginacion([FromQuery] Params productParams)
    {
        var labs = await _unitOfWork.Ordenes.paginacion(productParams.PageIndex, productParams.PageSize, productParams.Search);
        var mapeo = _mapper.Map<List<OrdenDto>>(labs.registros);
        return new Pager<OrdenDto>(mapeo, labs.totalRegistros, productParams.PageIndex, productParams.PageSize, productParams.Search);
    }

    [Authorize(Roles = "Administrador")]
    [HttpPost("create")]
    [ProducesResponseType(StatusCodes.Status201Created)]
    [ProducesResponseType(StatusCodes.Status400BadRequest)]
    public async Task<ActionResult<OrdenDto>> Post(OrdenDto dato)
    {
        var lab = _mapper.Map<Orden>(dato);
        if (lab == null)
        {
            return BadRequest();
        }
        _unitOfWork.Ordenes.Add(lab);
        await _unitOfWork.SaveAsync();
        return dato;
    }
    [Authorize(Roles = "Administrador")]
    [HttpDelete("delete/{id}")]
    [ProducesResponseType(StatusCodes.Status200OK)]
    [ProducesResponseType(StatusCodes.Status400BadRequest)]
    public async Task<ActionResult> Delete(int id)
    {
        var dato = await _unitOfWork.Ordenes.GetByIdAsync(id);
        if (dato == null)
        {
            return BadRequest();
        }
        _unitOfWork.Ordenes.Remove(dato);
        await _unitOfWork.SaveAsync();
        return NoContent();
    }
    [Authorize(Roles = "Administrador")]
    [HttpGet("Obtener/{id}")]
    [ProducesResponseType(StatusCodes.Status200OK)]
    [ProducesResponseType(StatusCodes.Status400BadRequest)]
    public async Task<ActionResult<OrdenDto>> GetById(int id)
    {
        var dato = await _unitOfWork.Ordenes.GetByIdAsync(id);
        if (dato == null)
        {
            return BadRequest();
        }
        return _mapper.Map<OrdenDto>(dato);
    }
    [Authorize(Roles = "Administrador")]
    [HttpPut("update")]
    [ProducesResponseType(StatusCodes.Status200OK)]
    [ProducesResponseType(StatusCodes.Status400BadRequest)]
    public async Task<ActionResult<OrdenDto>> Update(OrdenDto lab)
    {
        var dato = await _unitOfWork.Ordenes.GetByIdAsync(lab.Id);
        if (dato == null)
        {
            return BadRequest();
        }
        var datMap = _mapper.Map<Orden>(lab);
        _unitOfWork.Ordenes.Update(datMap);
        await _unitOfWork.SaveAsync();
        return lab;
    }
    [HttpGet("ByEstado")]
    [ProducesResponseType(StatusCodes.Status200OK)]
    [ProducesResponseType(StatusCodes.Status400BadRequest)]
    public async Task<ActionResult<IEnumerable<OrdenDto>>> GetByEstado()
    {
        var datos = await _unitOfWork.Ordenes.GetAllAsync();
        var mapeo = _mapper.Map<List<OrdenDto>>(datos);
        return mapeo;
    }
}
