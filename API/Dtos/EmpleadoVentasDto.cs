using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;

namespace API.Dtos;

    public class EmpleadoVentasDto
    {
        public int Id { get; set;}
        public string Nombre { get; set; }
        public ICollection<FacturaDto> Facturas { get; set; }
    }
    public class FacturaDto{
        public int Id { get; set;}
        public DateOnly Fecha { get; set; }
        public double ValorUnit { get; set; }
    }