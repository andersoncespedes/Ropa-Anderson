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
    public class EmpleadoRepository : GenericRepository<Empleado>, IEmpleado
    {
        private readonly ApiContext _context;
        public EmpleadoRepository(ApiContext context) : base(context)
        {
            _context = context;
        }
        public async Task<IEnumerable<Cargo>> GetByCargo(){
            return await _context.Set<Cargo>()
            .Include(e => e.Empleados)
            .ToListAsync();
        }
        public async Task<Empleado> GetByIdEXP(int id){
            return await _context.Set<Empleado>()
            .Include(e => e.Ventas)
            .ThenInclude(E => E.DetalleVentas)
            .FirstAsync(e => e.Id == id);    
                }
    }
}