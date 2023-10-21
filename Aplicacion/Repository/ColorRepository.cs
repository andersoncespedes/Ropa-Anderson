using System;
using System.Collections.Generic;
using Dominio.Entities;
using System.Linq;
using System.Threading.Tasks;
using Dominio.Interfaces;
using Persistencia;

namespace Aplicacion.Repository;
public class ColorRepository : GenericRepository<Color>, IColor
{
    public ColorRepository(ApiContext context) : base(context)
    {
    }
}
