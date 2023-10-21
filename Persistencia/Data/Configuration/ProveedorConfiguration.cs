using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;
using Dominio.Entities;
using Microsoft.EntityFrameworkCore;
using Microsoft.EntityFrameworkCore.Metadata.Builders;

namespace Persistencia.Data.Configuration;
public class ProveedorConfiguration : IEntityTypeConfiguration<Proveedor>
{
    public void Configure(EntityTypeBuilder<Proveedor> builder)
    {
        builder.ToTable("proveedor");

        builder.Property(e => e.NitProveedor)
        .HasColumnType("varchar")
        .IsRequired()
        .HasMaxLength(50);

        builder.HasIndex(e => e.NitProveedor).IsUnique();

        builder.Property(e => e.Nombre)
        .HasColumnType("varchar")
        .HasMaxLength(50)
        .IsRequired();

        builder.HasOne(e => e.TipoPersona)
        .WithMany(e => e.Proveedores)
        .HasForeignKey(e => e.IdTipoPersona);

        builder.HasOne(e => e.Municipio)
        .WithMany(e => e.Proveedores)
        .HasForeignKey(e => e.IdMunicipioFk);
    }
}
