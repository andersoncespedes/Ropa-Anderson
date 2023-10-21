using Dominio.Interfaces;
using Dominio.Entities;
using Persistencia;


namespace Aplicacion.Repository;
public class InventarioRepository : GenericRepository<Inventario>, IInventario
{
    public InventarioRepository(ApiContext context) : base(context)
    {
    }
}
