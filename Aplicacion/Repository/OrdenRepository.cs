using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;
using Dominio.Entities;
using Dominio.Interfaces;
using Microsoft.EntityFrameworkCore;
using Persistencia;

namespace Aplicacion.Repository
{
    public class OrdenRepository : GenericRepository<Orden>, IOrden
    {
        private  readonly ApiContext _context;

        public OrdenRepository(ApiContext context) : base(context)
        {
            _context = context;
        }
        public async Task<IEnumerable<Orden>> GetOrdenByEstado(){
            return await _context.Set<Orden>()
            .Include(e => e.Estado)
            .Where(o => o.Estado.Descripcion == "en proceso")
            .ToListAsync();
        }
    }
}