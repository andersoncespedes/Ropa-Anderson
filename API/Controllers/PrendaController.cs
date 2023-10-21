using Microsoft.AspNetCore.Mvc;
using API.Dtos;
using API.Helpers;
using Dominio.Interfaces;
using Dominio.Entities;
using AutoMapper;
using Microsoft.AspNetCore.Authorization;

namespace API.Controllers;
public class PrendaController : BaseApiController
{
    private readonly IUnitOfWork _unitOfWork;
    private IMapper _mapper;
    public PrendaController(IUnitOfWork unitOfWork, IMapper mapper)
    {
        _unitOfWork = unitOfWork;
        _mapper = mapper;
    }
    [HttpGet]
    [ProducesResponseType(StatusCodes.Status200OK)]
    [ProducesResponseType(StatusCodes.Status400BadRequest)]
    public async Task<ActionResult<IEnumerable<PrendaDto>>> GetAll()
    {
        var datos = await _unitOfWork.Prendas.GetAllAsync();
        var mapeo = _mapper.Map<List<PrendaDto>>(datos);
        return mapeo;
    }
    [MapToApiVersion("1.1")]
    [HttpGet]
    [ProducesResponseType(StatusCodes.Status200OK)]
    [ProducesResponseType(StatusCodes.Status400BadRequest)]
    public async Task<ActionResult<Pager<PrendaDto>>> Paginacion([FromQuery] Params productParams)
    {
        var labs = await _unitOfWork.Prendas.paginacion(productParams.PageIndex, productParams.PageSize, productParams.Search);
        var mapeo = _mapper.Map<List<PrendaDto>>(labs.registros);
        return new Pager<PrendaDto>(mapeo, labs.totalRegistros, productParams.PageIndex, productParams.PageSize, productParams.Search);
    }

    [Authorize(Roles = "Administrador")]
    [HttpPost("create")]
    [ProducesResponseType(StatusCodes.Status201Created)]
    [ProducesResponseType(StatusCodes.Status400BadRequest)]
    public async Task<ActionResult<PrendaDto>> Post(PrendaDto dato)
    {
        var lab = _mapper.Map<Prenda>(dato);
        if (lab == null)
        {
            return BadRequest();
        }
        _unitOfWork.Prendas.Add(lab);
        await _unitOfWork.SaveAsync();
        return dato;
    }
    [Authorize(Roles = "Administrador")]
    [HttpDelete("delete/{id}")]
    [ProducesResponseType(StatusCodes.Status200OK)]
    [ProducesResponseType(StatusCodes.Status400BadRequest)]
    public async Task<ActionResult> Delete(int id)
    {
        var dato = await _unitOfWork.Prendas.GetByIdAsync(id);
        if (dato == null)
        {
            return BadRequest();
        }
        _unitOfWork.Prendas.Remove(dato);
        await _unitOfWork.SaveAsync();
        return NoContent();
    }
    [Authorize(Roles = "Administrador")]
    [HttpGet("Obtener/{id}")]
    [ProducesResponseType(StatusCodes.Status200OK)]
    [ProducesResponseType(StatusCodes.Status400BadRequest)]
    public async Task<ActionResult<PrendaDto>> GetById(int id)
    {
        var dato = await _unitOfWork.Prendas.GetByIdAsync(id);
        if (dato == null)
        {
            return BadRequest();
        }
        return _mapper.Map<PrendaDto>(dato);
    }
    [Authorize(Roles = "Administrador")]
    [HttpPut("update")]
    [ProducesResponseType(StatusCodes.Status200OK)]
    [ProducesResponseType(StatusCodes.Status400BadRequest)]
    public async Task<ActionResult<PrendaDto>> Update(PrendaDto lab)
    {
        var dato = await _unitOfWork.Prendas.GetByIdAsync(lab.Id);
        if (dato == null)
        {
            return BadRequest();
        }
        var datMap = _mapper.Map<Prenda>(lab);
        _unitOfWork.Prendas.Update(datMap);
        await _unitOfWork.SaveAsync();
        return lab;
    }
    [HttpGet("getInsumo")]
    [ProducesResponseType(StatusCodes.Status200OK)]
    [ProducesResponseType(StatusCodes.Status400BadRequest)]
    public async Task<ActionResult<IEnumerable<InsumoDto>>> GetInsumo([FromQuery]QueryDto query)
    {
        var datos = await _unitOfWork.Prendas.FindPrenda(query.Codigo.ToString());
        var mapeo = _mapper.Map<List<InsumoDto>>(datos);
        return mapeo;
    }
}
