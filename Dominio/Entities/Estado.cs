using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;

namespace Dominio.Entities;
public class Estado : BaseEntity
{
    public string Descripcion {get; set;}
    public ICollection<Prenda> Prendas {get; set;}
    public ICollection<Orden> Ordenes {get; set;}
    public ICollection<DetalleOrden> DetalleOrdenes {get; set;}
    public int IdTipoEstadoFk {get; set;}
    public TipoEstado TipoEstado {get; set;}
}
