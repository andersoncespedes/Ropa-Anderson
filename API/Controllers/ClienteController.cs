using Microsoft.AspNetCore.Mvc;
using API.Dtos;
using API.Helpers;
using Dominio.Interfaces;
using Dominio.Entities;
using AutoMapper;
using Microsoft.AspNetCore.Authorization;
namespace API.Controllers;
[ApiVersion("1.0")]
[ApiVersion("1.1")]
public class ClienteController : BaseApiController
{
    private readonly IUnitOfWork _unitOfWork;
    private IMapper _mapper;
    public ClienteController(IUnitOfWork unitOfWork, IMapper mapper)
    {
        _unitOfWork = unitOfWork;
        _mapper = mapper;
    }
    [HttpGet]
    [ProducesResponseType(StatusCodes.Status200OK)]
    [ProducesResponseType(StatusCodes.Status400BadRequest)]
    public async Task<ActionResult<IEnumerable<ClienteDto>>> GetAll()
    {
        var datos = await _unitOfWork.Clientes.GetAllAsync();
        var mapeo = _mapper.Map<List<ClienteDto>>(datos);
        return mapeo;
    }
    [MapToApiVersion("1.1")]
    [HttpGet]
    [ProducesResponseType(StatusCodes.Status200OK)]
    [ProducesResponseType(StatusCodes.Status400BadRequest)]
    public async Task<ActionResult<Pager<ClienteDto>>> Paginacion([FromQuery] Params productParams)
    {
        var labs = await _unitOfWork.Clientes.paginacion(productParams.PageIndex, productParams.PageSize, productParams.Search);
        var mapeo = _mapper.Map<List<ClienteDto>>(labs.registros);
        return new Pager<ClienteDto>(mapeo, labs.totalRegistros, productParams.PageIndex, productParams.PageSize, productParams.Search);
    }

    [Authorize(Roles = "Administrador")]
    [HttpPost("create")]
    [ProducesResponseType(StatusCodes.Status201Created)]
    [ProducesResponseType(StatusCodes.Status400BadRequest)]
    public async Task<ActionResult<ClienteDto>> Post(ClienteDto dato)
    {
        var lab = _mapper.Map<Cliente>(dato);
        if (lab == null)
        {
            return BadRequest();
        }
        _unitOfWork.Clientes.Add(lab);
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
    public async Task<ActionResult<ClienteDto>> GetById(int id)
    {
        var dato = await _unitOfWork.Clientes.GetByIdAsync(id);
        if (dato == null)
        {
            return BadRequest();
        }
        return _mapper.Map<ClienteDto>(dato);
    }
    [Authorize(Roles = "Administrador")]
    [HttpPut("update")]
    [ProducesResponseType(StatusCodes.Status200OK)]
    [ProducesResponseType(StatusCodes.Status400BadRequest)]
    public async Task<ActionResult<ClienteDto>> Update(ClienteDto lab)
    {
        var dato = await _unitOfWork.Clientes.GetByIdAsync(lab.Id);
        if (dato == null)
        {
            return BadRequest();
        }
        var datMap = _mapper.Map<Cliente>(lab);
        _unitOfWork.Clientes.Update(datMap);
        await _unitOfWork.SaveAsync();
        return lab;
    }
    [HttpGet("getSDataById/{id}")]
    [ProducesResponseType(StatusCodes.Status200OK)]
    [ProducesResponseType(StatusCodes.Status400BadRequest)]
    public async Task<ActionResult<IEnumerable<ClienteExtendDto>>> getSDataById(int id)
    {
        var datos = await _unitOfWork.Clientes.FindIdExt(id);
        var mapeo = _mapper.Map<List<ClienteExtendDto>>(datos);
        return mapeo;
    }
}