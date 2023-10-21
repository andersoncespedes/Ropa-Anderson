using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;
using Dominio.Entities;

namespace Dominio.Interfaces;
    public interface ICliente : IGenericRepo<Cliente>
    {
        Task<Cliente> FindIdExt(int id);
    }
