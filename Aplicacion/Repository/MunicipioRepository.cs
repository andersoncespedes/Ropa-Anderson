using Dominio.Interfaces;
using Dominio.Entities;
using Persistencia;

namespace Aplicacion.Repository
{
    public class MunicipioRepository : GenericRepository<Municipio>, IMunicipio
    {
        public MunicipioRepository(ApiContext context) : base(context)
        {
        }
    }
}