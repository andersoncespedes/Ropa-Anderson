using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;

namespace Dominio.Entities;
    public class Color : BaseEntity
    {
        public string Descripcion {get; set;}
        public ICollection<DetalleOrden> DetalleOrdenes {get; set;}
    }
