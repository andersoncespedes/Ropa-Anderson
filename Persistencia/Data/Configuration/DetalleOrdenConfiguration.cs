using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;
using Dominio.Entities;
using Microsoft.EntityFrameworkCore;
using Microsoft.EntityFrameworkCore.Metadata.Builders;

namespace Persistencia.Data.Configuration;
public class DetalleOrdenConfiguration : IEntityTypeConfiguration<DetalleOrden>
{
    public void Configure(EntityTypeBuilder<DetalleOrden> builder)
    {
        builder.ToTable("detalle_orden");

        builder.Property(e => e.CantidadProducir)
        .HasColumnType("int")
        .HasColumnName("cantidad_producir")
        .IsRequired();

        builder.Property(e => e.CantidadProducida)
        .HasColumnType("int")
        .HasColumnName("canridad_producida")
        .IsRequired();

        builder.HasOne(e => e.Orden)
        .WithMany(e => e.DetalleOrdenes)
        .HasForeignKey(e => e.IdOrdenFk);

        builder.HasOne(e => e.Color)
        .WithMany(e => e.DetalleOrdenes)
        .HasForeignKey(e => e.IdColorFk);

        builder.HasOne(e => e.Estado)
        .WithMany(e => e.DetalleOrdenes)
        .HasForeignKey(e => e.IdEstadoFk);
    }
}
