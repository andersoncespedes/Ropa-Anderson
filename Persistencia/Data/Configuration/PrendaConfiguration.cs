using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;
using Dominio.Entities;
using Microsoft.EntityFrameworkCore;
using Microsoft.EntityFrameworkCore.Metadata.Builders;

namespace Persistencia.Data.Configuration;
public class PrendaConfiguration : IEntityTypeConfiguration<Prenda>
{
    public void Configure(EntityTypeBuilder<Prenda> builder)
    {
        builder.ToTable("prenda");

        builder.Property(e => e.Nombre)
        .HasColumnType("varchar")
        .HasMaxLength(50)
        .IsRequired();

        builder.Property(e => e.ValorUnitCop)
        .HasColumnType("double")
        .HasPrecision(2,6)
        .IsRequired();

        builder.Property(e => e.ValorUnitUsd)
        .HasColumnType("double")
        .HasPrecision(2,6)
        .IsRequired();

        builder.Property(e => e.Codigo)
        .HasMaxLength(50)
        .IsRequired();
        

        builder.HasOne(e => e.Estado)
        .WithMany(e => e.Prendas)
        .HasForeignKey(e => e.IdEstadoFk);

        builder.HasOne(e => e.TipoProteccion)
        .WithMany(e => e.Prendas)
        .HasForeignKey(e => e.IdTipoProteccion);

        builder.HasOne(e => e.Genero)
        .WithMany(e => e.Prendas)
        .HasForeignKey(e => e.IdGeneroFk);
    }
}
