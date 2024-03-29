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
    public class InsumoRepository : GenericRepository<Insumo>, IInsumo
    {
        private readonly ApiContext _context;
        public InsumoRepository(ApiContext context) : base(context)
        {
            _context = context;
        }
       
    }
}