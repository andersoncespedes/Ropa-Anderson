using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;

namespace Dominio.Entities;
public class InventarioTalla
{
    public int IdInvFk {get; set;}
    public Inventario Inventario {get; set;}
    public int IdTallaFk {get; set;}
    public Talla Talla {get; set;}
}
