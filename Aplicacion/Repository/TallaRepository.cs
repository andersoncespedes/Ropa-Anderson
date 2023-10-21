using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;
using Dominio.Entities;
using Dominio.Interfaces;
using Persistencia;

namespace Aplicacion.Repository
{
    public class TallaRepository : GenericRepository<Talla>, ITalla
    {
        public TallaRepository(ApiContext context) : base(context)
        {
        }
    }
}