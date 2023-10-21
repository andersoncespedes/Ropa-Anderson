using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;
using Dominio.Entities;
using Microsoft.EntityFrameworkCore;
using Microsoft.EntityFrameworkCore.Metadata.Builders;

namespace Persistencia.Data.Configuration;
public class EmpleadoConfiguration : IEntityTypeConfiguration<Empleado>
{
    public void Configure(EntityTypeBuilder<Empleado> builder)
    {
        builder.ToTable("empleado");

        builder.Property(e => e.Nombre)
        .HasColumnName("nombre")
        .HasColumnType("varchar")
        .IsRequired()
        .HasMaxLength(50);

        builder.Property(e => e.FechaIngreso)
        .HasColumnName("fecha_ingreso")
        .HasColumnType("date")
        .IsRequired();

        builder.HasOne(e => e.Cargo)
        .WithMany(e => e.Empleados)
        .HasForeignKey(e => e.IdCargoFk);

        builder.HasOne(e => e.Municipio)
        .WithMany(e => e.Empleados)
        .HasForeignKey(e => e.IdMunicipioFk);

        
    }
}
