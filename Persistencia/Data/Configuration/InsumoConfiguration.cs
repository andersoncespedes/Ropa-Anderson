using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;
using Dominio.Entities;
using Microsoft.EntityFrameworkCore;
using Microsoft.EntityFrameworkCore.Metadata.Builders;

namespace Persistencia.Data.Configuration;
public class InsumoConfiguration : IEntityTypeConfiguration<Insumo>
{
    public void Configure(EntityTypeBuilder<Insumo> builder)
    {
        builder.ToTable("insumo");

        builder.Property(e => e.Nombre)
        .HasColumnName("nombre")
        .HasColumnType("varchar")
        .IsRequired()
        .HasMaxLength(50);

        builder.Property(e => e.ValorUnit)
        .HasColumnName("valor_unit")
        .HasColumnType("double")
        .HasPrecision(2,6)
        .IsRequired();

        builder.Property(e => e.StockMin)
        .HasColumnName("stock_min")
        .HasColumnType("double")
        .IsRequired()
        .HasPrecision(2,6);

        builder.Property(e => e.StockMax)
        .HasColumnName("stock_max")
        .HasColumnType("double")
        .IsRequired()
        .HasPrecision(2,6);

        builder.HasMany(e => e.Prendas)
        .WithMany(e => e.Insumos)
        .UsingEntity<InsumoPrenda>(
            j => j.HasOne(e => e.Prenda)
                .WithMany(e => e.InsumoPrendas)
                .HasForeignKey(e => e.IdPrendaFk),
            j => j.HasOne(e => e.Insumo)
                .WithMany(e => e.InsumoPrendas)
                .HasForeignKey(e => e.IdInsumoFk),
            j => {
                j.ToTable("insumo_prendas");
                j.HasKey(e => new {e.IdPrendaFk, e.IdInsumoFk});
            }
        );

        builder.HasMany(e => e.Proveedores)
        .WithMany(e => e.Insumos)
        .UsingEntity<InsumoProveedor>(
            j => j.HasOne(e => e.Proveedor)
            .WithMany(e => e.InsumoProveedores)
            .HasForeignKey(e => e.IdProveedorFk),

            j => j.HasOne(e => e.Insumo)
                .WithMany(e => e.InsumoProveedores)
                .HasForeignKey(e => e.IdInsumoFk),

            j => {
                j.ToTable("insumo_proveedor");
                j.HasKey(e => new {e.IdInsumoFk, e.IdProveedorFk});
            }
        );
    }
}
