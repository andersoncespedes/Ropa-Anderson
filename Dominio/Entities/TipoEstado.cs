using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;

namespace Dominio.Entities;
    public class TipoEstado : BaseEntity
    {
        public string Descripcion {get; set;}
        public ICollection<Estado> Estados {get; set;}
    }
