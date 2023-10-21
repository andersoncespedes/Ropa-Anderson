using API.Dtos;
using AutoMapper;
using Dominio.Entities;

namespace API.Profiles;

public class MappingProfile : Profile
{
    public MappingProfile()
    {
        CreateMap<Insumo, InsumoDto>().ReverseMap();
        CreateMap<Cliente, ClienteDto>().ReverseMap();
        CreateMap<Prenda, PrendaDto>().ReverseMap();
        CreateMap<Orden, OrdenDto>().ReverseMap();
        CreateMap<Cliente, ClienteExtendDto>()
        .ForMember(e => e.Municipio, opt => opt.MapFrom(e => e.Municipio.Nombre))
        .ReverseMap();
        CreateMap<Orden, OrdenExp>()
        .ReverseMap();

        CreateMap<Empleado, EmpleadoVentasDto>().ReverseMap();

        CreateMap<Venta, FacturaDto>()
        .ForMember(e => e.ValorUnit, opt => opt.MapFrom(e => e.DetalleVentas.Select(e => e.ValorUnit).Sum()))
        .ReverseMap();
        

    }
}
