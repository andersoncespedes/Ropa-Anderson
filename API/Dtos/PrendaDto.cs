using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;
using Dominio.Entities;
namespace API.Dtos
{
    public class PrendaDto
    {
        public int Id { get; set; }
        public string Codigo { get; set; }
        public string Nombre { get; set; }
        public double ValorUnitCop { get; set; }
        public double ValorUnitUsd { get; set; }
        public int IdEstadoFk { get; set; }
        public Estado Estado { get; set; }
        public int IdTipoProteccion { get; set; }
        public TipoProteccion TipoProteccion { get; set; }
        public int IdGeneroFk { get; set; }
        public Genero Genero { get; set; }
    }
}