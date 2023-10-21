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
    public class ProveedorRepository : GenericRepository<Proveedor>, IProveedor
    {
        private readonly ApiContext _context;
        public ProveedorRepository(ApiContext context) : base(context)
        {
            _context = context; 
        }
        public async Task<IEnumerable<Insumo>> FindInsumo(string codigo){
            return  await _context.Set<Proveedor>().Include(e => e.Insumos)
            .Where(e => e.NitProveedor == codigo)
            .SelectMany(e => e.Insumos).ToListAsync();
        }
    }
}