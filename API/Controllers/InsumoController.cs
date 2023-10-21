using Microsoft.AspNetCore.Mvc;
using API.Dtos;
using API.Helpers;
using Dominio.Interfaces;
using Dominio.Entities;
using AutoMapper;
using Microsoft.AspNetCore.Authorization;

namespace API.Controllers;
public class InsumoController : BaseApiController
{
    private readonly IUnitOfWork _unitOfWork;
    private IMapper _mapper;
    public InsumoController(IUnitOfWork unitOfWork, IMapper mapper)
    {
        _unitOfWork = unitOfWork;
        _mapper = mapper;
    }
    [HttpGet]
    [ProducesResponseType(StatusCodes.Status200OK)]
    [ProducesResponseType(StatusCodes.Status400BadRequest)]
    public async Task<ActionResult<IEnumerable<InsumoDto>>> GetAll()
    {
        var datos = await _unitOfWork.Insumos.GetAllAsync();
        var mapeo = _mapper.Map<List<InsumoDto>>(datos);
        return mapeo;
    }
    [MapToApiVersion("1.1")]
    [HttpGet]
    [ProducesResponseType(StatusCodes.Status200OK)]
    [ProducesResponseType(StatusCodes.Status400BadRequest)]
    public async Task<ActionResult<Pager<InsumoDto>>> Paginacion([FromQuery] Params productParams)
    {
        var labs = await _unitOfWork.Insumos.paginacion(productParams.PageIndex, productParams.PageSize, productParams.Search);
        var mapeo = _mapper.Map<List<InsumoDto>>(labs.registros);
        return new Pager<InsumoDto>(mapeo, labs.totalRegistros, productParams.PageIndex, productParams.PageSize, productParams.Search);
    }

    [Authorize(Roles = "Administrador")]
    [HttpPost("create")]
    [ProducesResponseType(StatusCodes.Status201Created)]
    [ProducesResponseType(StatusCodes.Status400BadRequest)]
    public async Task<ActionResult<InsumoDto>> Post(InsumoDto dato)
    {
        var lab = _mapper.Map<Insumo>(dato);
        if (lab == null)
        {
            return BadRequest();
        }
        _unitOfWork.Insumos.Add(lab);
        await _unitOfWork.SaveAsync();
        return dato;
    }
    [Authorize(Roles = "Administrador")]
    [HttpDelete("delete/{id}")]
    [ProducesResponseType(StatusCodes.Status200OK)]
    [ProducesResponseType(StatusCodes.Status400BadRequest)]
    public async Task<ActionResult> Delete(int id)
    {
        var dato = await _unitOfWork.Clientes.GetByIdAsync(id);
        if (dato == null)
        {
            return BadRequest();
        }
        _unitOfWork.Clientes.Remove(dato);
        await _unitOfWork.SaveAsync();
        return NoContent();
    }
    [Authorize(Roles = "Administrador")]
    [HttpGet("Obtener/{id}")]
    [ProducesResponseType(StatusCodes.Status200OK)]
    [ProducesResponseType(StatusCodes.Status400BadRequest)]
    public async Task<ActionResult<InsumoDto>> GetById(int id)
    {
        var dato = await _unitOfWork.Insumos.GetByIdAsync(id);
        if (dato == null)
        {
            return BadRequest();
        }
        return _mapper.Map<InsumoDto>(dato);
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

}
