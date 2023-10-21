using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;
using Dominio.Entities;
using Microsoft.EntityFrameworkCore;
using Microsoft.EntityFrameworkCore.Metadata.Builders;

namespace Persistencia.Data.Configuration;

public class VentaConfiguration : IEntityTypeConfiguration<Venta>
{
    public void Configure(EntityTypeBuilder<Venta> builder)
    {
        builder.ToTable("venta");
        builder.Property(e => e.Fecha)
        .HasColumnType("date")
        .IsRequired();

        builder.HasOne(e => e.Empleado)
        .WithMany(e => e.Ventas)
        .HasForeignKey(e => e.IdEmpleadoFk);

        builder.HasOne(e => e.Cliente)
        .WithMany(e => e.Ventas)
        .HasForeignKey(e => e.IdClienteFk);

        builder.HasOne(e => e.FormaPago)
        .WithMany(e => e.Ventas)
        .HasForeignKey(e => e.IdFormaPagoFk);
    }
}
