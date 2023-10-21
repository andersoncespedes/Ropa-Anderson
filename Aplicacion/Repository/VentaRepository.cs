using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;
using Dominio.Entities;
using Dominio.Interfaces;
using Persistencia;

namespace Aplicacion.Repository
{
    public class VentaRepository : GenericRepository<Venta>, IVenta
    {
        public VentaRepository(ApiContext context) : base(context)
        {
        }
    }
}