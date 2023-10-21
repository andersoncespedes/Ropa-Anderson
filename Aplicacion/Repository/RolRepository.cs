using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;
using Dominio.Interfaces;
using Dominio.Entities;
using Persistencia;


namespace Aplicacion.Repository
{
    public class RolRepository : GenericRepository<Rol>, IRol
    {
        public RolRepository(ApiContext context) : base(context)
        {
        }
    }
}