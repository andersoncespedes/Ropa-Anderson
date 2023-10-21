using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;
using Dominio.Entities;
using Dominio.Interfaces;
using Microsoft.EntityFrameworkCore;
using Persistencia;

namespace Aplicacion.Repository;
public class ClienteRepository : GenericRepository<Cliente>, ICliente
{
    private readonly ApiContext _context; 
    public ClienteRepository(ApiContext context) : base(context)
    {
        _context = context;
    }
    public async Task<Cliente> FindIdExt(int id){
        return  await _context.Set<Cliente>()
            .Include(E => E.Ordenes)
            .ThenInclude(e => e.Estado)
            .ThenInclude(e => e.DetalleOrdenes)
            .ThenInclude(e => e.Prenda)
            .FirstAsync(e => e.Id == id);
    }
}
