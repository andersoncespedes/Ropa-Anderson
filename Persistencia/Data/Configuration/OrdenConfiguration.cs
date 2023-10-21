using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;
using Dominio.Entities;
using Microsoft.EntityFrameworkCore;
using Microsoft.EntityFrameworkCore.Metadata.Builders;

namespace Persistencia.Data.Configuration;
public class OrdenConfiguration : IEntityTypeConfiguration<Orden>
{
    public void Configure(EntityTypeBuilder<Orden> builder)
    {
        builder.ToTable("orden");

        builder.Property(e => e.Fecha)
        .HasColumnType("date")
        .HasColumnName("fecha")
        .IsRequired();

        builder.HasOne(e => e.Empleado)
        .WithMany(e => e.Ordenes)
        .HasForeignKey(e => e.IdEmpleadoFk);

        builder.HasOne(e => e.Cliente)
        .WithMany(e => e.Ordenes)
        .HasForeignKey(e => e.IdClienteFk);

        builder.HasOne(e => e.Estado)
        .WithMany(e => e.Ordenes)
        .HasForeignKey(e => e.IdEstadoFk);
    }
}
