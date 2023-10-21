using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;
using Dominio.Interfaces;
using Dominio.Entities;
using Persistencia;

namespace Aplicacion.Repository;
public class PaisRepository : GenericRepository<Pais>, IPais
{
    public PaisRepository(ApiContext context) : base(context)
    {
    }
}
