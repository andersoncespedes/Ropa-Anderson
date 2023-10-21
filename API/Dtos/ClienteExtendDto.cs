using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;

namespace API.Dtos;
    public class ClienteExtendDto
    {
        public int Id { get; set;}
        public string Nombre { get; set;}
        public string Municipio { get; set;}
        public ICollection<OrdenExp> OrdenExp  { get; set;}
    }

public class OrdenExp
{
    public string NroOrden { get; set;}
    public DateOnly Fecha { get; set;}
    public string Estado {get; set;}
    public double Total {get; set;}
    public PrendaDto PrendaDto { get; set;}
}