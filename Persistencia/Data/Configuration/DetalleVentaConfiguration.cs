using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;
using Dominio.Entities;
using Microsoft.EntityFrameworkCore;
using Microsoft.EntityFrameworkCore.Metadata.Builders;

namespace Persistencia.Data.Configuration;
public class DetalleVentaConfiguration : IEntityTypeConfiguration<DetalleVenta>
{
    public void Configure(EntityTypeBuilder<DetalleVenta> builder)
    {
        builder.ToTable("detalle_venta");
        builder.Property(e => e.Cantidad)
        .HasColumnType("int")
        .HasColumnName("cantidad")
        .IsRequired();

        builder.Property(e => e.ValorUnit)
        .HasColumnName("valor_unit")
        .HasColumnType("double")
        .HasPrecision(2,6)
        .IsRequired();

        builder.HasOne(e => e.Venta)
        .WithMany(e => e.DetalleVentas)
        .HasForeignKey(e => e.IdVentaFk);

        builder.HasOne(e => e.Talla)
        .WithMany(e => e.DetalleVentas)
        .HasForeignKey(e => e.IdTallaFk);

        builder.HasOne(e => e.Inventario)
        .WithMany(e => e.DetalleVentas
        ).HasForeignKey(e => e.IdProductoFk);
    }
}
