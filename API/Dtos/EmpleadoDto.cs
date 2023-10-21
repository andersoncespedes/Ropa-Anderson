using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;
using Dominio.Entities;
namespace API.Dtos;
    public class EmpleadoDto
    {
        public int Id { get; set;}
            public string Nombre {get; set;}
    public int IdCargoFk {get; set;}
    public Cargo Cargo {get; set;}
    public DateOnly FechaIngreso  {get; set;}
    public int IdMunicipioFk {get; set;}
    }
