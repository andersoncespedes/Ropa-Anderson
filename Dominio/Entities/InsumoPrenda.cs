using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;

namespace Dominio.Entities;
public class InsumoPrenda
{
    public int IdInsumoFk {get; set;}
    public Insumo Insumo {get; set;}
    public int IdPrendaFk {get; set;}
    public Prenda Prenda {get; set;}
    public int Cantidad {get; set;}
}
