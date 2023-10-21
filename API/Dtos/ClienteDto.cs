using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;

namespace API.Dtos
{
    public class ClienteDto
    {
        public int Id { get; set;}
        public string Nombre {get; set;}
    public string IdCliente {get; set;}
    public int IdTipoPersonaFk {get; set;}
    public DateOnly FechaRegistro {get; set;}
    public int IdMunicipioFk {get; set;}
    }
}