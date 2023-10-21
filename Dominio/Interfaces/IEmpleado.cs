using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;
using Dominio.Entities;

namespace Dominio.Interfaces
{
    public interface IEmpleado : IGenericRepo<Empleado>
    {
        Task<IEnumerable<Cargo>> GetByCargo();
        Task<Empleado> GetByIdEXP(int id);
    }
}