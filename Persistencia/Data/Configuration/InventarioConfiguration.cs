using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;
using Dominio.Entities;
using Microsoft.EntityFrameworkCore;
using Microsoft.EntityFrameworkCore.Metadata.Builders;

namespace Persistencia.Data.Configuration;
public class InventarioConfiguration : IEntityTypeConfiguration<Inventario>
{
    public void Configure(EntityTypeBuilder<Inventario> builder)
    {
        builder.ToTable("inventario");

        builder.Property(e => e.ValorVtaCop)
        .HasColumnType("double")
        .HasPrecision(2,6)
        .IsRequired();
        builder.Property(e => e.ValorVtaUsd)
        .HasColumnType("double")
        .HasPrecision(2,6)
        .IsRequired();

        builder.HasOne(e => e.Prenda)
        .WithMany(e => e.Inventarios)
        .HasForeignKey(e => e.IdPrendaFk);

        builder.HasMany(e => e.Tallas)
        .WithMany(e => e.Inventarios)
        .UsingEntity<InventarioTalla>(
            j => j.HasOne(e => e.Talla)
                .WithMany(e => e.InventarioTallas)
                .HasForeignKey(e => e.IdTallaFk),

            j => j.HasOne(e => e.Inventario)
                .WithMany(e => e.InventarioTallas)
                .HasForeignKey(e => e.IdInvFk),
            j => {
                j.ToTable("inventario_talla");

                j.HasKey(e => new { e.IdInvFk, e.IdTallaFk});
            }
        );
    }
}
