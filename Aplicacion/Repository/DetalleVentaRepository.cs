using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;
using Dominio.Entities;
using Dominio.Interfaces;
using Persistencia;

namespace Aplicacion.Repository;
public class DetalleVentaRepository : GenericRepository<DetalleVenta>, IDetalleVenta
{
    public DetalleVentaRepository(ApiContext context) : base(context)
    {
    }
}
