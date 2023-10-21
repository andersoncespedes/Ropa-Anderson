using Microsoft.AspNetCore.Mvc;
using API.Dtos;
using API.Helpers;
using Dominio.Interfaces;
using Dominio.Entities;
using AutoMapper;
using Microsoft.AspNetCore.Authorization;

namespace API.Controllers;
public class EmpleadoController : BaseApiController
{
    private readonly IUnitOfWork _unitOfWork;
    private IMapper _mapper;
    public EmpleadoController(IUnitOfWork unitOfWork, IMapper mapper)
    {
        _unitOfWork = unitOfWork;
        _mapper = mapper;
    }
    [HttpGet]
    [ProducesResponseType(StatusCodes.Status200OK)]
    [ProducesResponseType(StatusCodes.Status400BadRequest)]
    public async Task<ActionResult<IEnumerable<EmpleadoDto>>> GetAll()
    {
        var datos = await _unitOfWork.Empleados.GetAllAsync();
        var mapeo = _mapper.Map<List<EmpleadoDto>>(datos);
        return mapeo;
    }
    [MapToApiVersion("1.1")]
    [HttpGet]
    [ProducesResponseType(StatusCodes.Status200OK)]
    [ProducesResponseType(StatusCodes.Status400BadRequest)]
    public async Task<ActionResult<Pager<EmpleadoDto>>> Paginacion([FromQuery] Params productParams)
    {
        var labs = await _unitOfWork.Empleados.paginacion(productParams.PageIndex, productParams.PageSize, productParams.Search);
        var mapeo = _mapper.Map<List<EmpleadoDto>>(labs.registros);
        return new Pager<EmpleadoDto>(mapeo, labs.totalRegistros, productParams.PageIndex, productParams.PageSize, productParams.Search);
    }

    [Authorize(Roles = "Administrador")]
    [HttpPost("create")]
    [ProducesResponseType(StatusCodes.Status201Created)]
    [ProducesResponseType(StatusCodes.Status400BadRequest)]
    public async Task<ActionResult<EmpleadoDto>> Post(EmpleadoDto dato)
    {
        var lab = _mapper.Map<Empleado>(dato);
        if (lab == null)
        {
            return BadRequest();
        }
        _unitOfWork.Empleados.Add(lab);
        await _unitOfWork.SaveAsync();
        return dato;
    }
    [Authorize(Roles = "Administrador")]
    [HttpDelete("delete/{id}")]
    [ProducesResponseType(StatusCodes.Status200OK)]
    [ProducesResponseType(StatusCodes.Status400BadRequest)]
    public async Task<ActionResult> Delete(int id)
    {
        var dato = await _unitOfWork.Empleados.GetByIdAsync(id);
        if (dato == null)
        {
            return BadRequest();
        }
        _unitOfWork.Empleados.Remove(dato);
        await _unitOfWork.SaveAsync();
        return NoContent();
    }
    [Authorize(Roles = "Administrador")]
    [HttpGet("Obtener/{id}")]
    [ProducesResponseType(StatusCodes.Status200OK)]
    [ProducesResponseType(StatusCodes.Status400BadRequest)]
    public async Task<ActionResult<EmpleadoDto>> GetById(int id)
    {
        var dato = await _unitOfWork.Empleados.GetByIdAsync(id);
        if (dato == null)
        {
            return BadRequest();
        }
        return _mapper.Map<EmpleadoDto>(dato);
    }
    [Authorize(Roles = "Administrador")]
    [HttpPut("update")]
    [ProducesResponseType(StatusCodes.Status200OK)]
    [ProducesResponseType(StatusCodes.Status400BadRequest)]
    public async Task<ActionResult<EmpleadoDto>> Update(EmpleadoDto lab)
    {
        var dato = await _unitOfWork.Empleados.GetByIdAsync(lab.Id);
        if (dato == null)
        {
            return BadRequest();
        }
        var datMap = _mapper.Map<Empleado>(lab);
        _unitOfWork.Empleados.Update(datMap);
        await _unitOfWork.SaveAsync();
        return lab;
    }
    [HttpGet("getByCargo")]
    [ProducesResponseType(StatusCodes.Status200OK)]
    [ProducesResponseType(StatusCodes.Status400BadRequest)]
    public async Task<ActionResult<IEnumerable<CargoDto>>> GetByCargo()
    {
        var datos = await _unitOfWork.Empleados.GetByCargo();
        var mapeo = _mapper.Map<List<CargoDto>>(datos);
        return mapeo;
    }
    [HttpGet("getByVenta/{id}")]
    [ProducesResponseType(StatusCodes.Status200OK)]
    [ProducesResponseType(StatusCodes.Status400BadRequest)]
    public async Task<ActionResult<EmpleadoVentasDto>> GetByVenta(int id)
    {
        var datos = await _unitOfWork.Empleados.GetByIdEXP(id);
        var mapeo = _mapper.Map<EmpleadoVentasDto>(datos);
        return mapeo;
    }
}
