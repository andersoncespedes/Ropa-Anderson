using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;

namespace Dominio.Entities;
public class Inventario : BaseEntity
{
    public string CodInv { get; set; }
    public int IdPrendaFk { get; set; }
    public Prenda Prenda { get; set; }
    public double ValorVtaCop { get; set; }
    public double ValorVtaUsd { get; set; }
    public ICollection<DetalleVenta> DetalleVentas { get; set; }
    public ICollection<Talla> Tallas {get; set;}
    public ICollection<InventarioTalla> InventarioTallas {get; set; }

}
