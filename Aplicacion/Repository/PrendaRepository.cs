using Dominio.Interfaces;
using Dominio.Entities;
using Persistencia;

using Microsoft.EntityFrameworkCore;
namespace Aplicacion.Repository;
public class PrendaRepository : GenericRepository<Prenda>, IPrenda

{
    private readonly ApiContext _context;
    public PrendaRepository(ApiContext context) : base(context)
    {
        _context = context;
    }
     public async Task<IEnumerable<Insumo>> FindPrenda(string nit){
            return await _context.Set<Prenda>().Include(e => e.Insumos)
            .Where(e => e.Codigo == nit)
            .SelectMany(e => e.Insumos).ToListAsync();
        }
}
