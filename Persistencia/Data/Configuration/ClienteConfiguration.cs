using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;
using Dominio.Entities;
using Microsoft.EntityFrameworkCore;
using Microsoft.EntityFrameworkCore.Metadata;
using Microsoft.EntityFrameworkCore.Metadata.Builders;

namespace Persistencia.Data.Configuration;
public class ClienteConfiguration : IEntityTypeConfiguration<Cliente>
{
    public void Configure(EntityTypeBuilder<Cliente> builder)
    {
        builder.ToTable("cliente");

        builder.Property(e => e.Nombre)
        .HasColumnName("nombre")
        .HasColumnType("varchar")
        .IsRequired()
        .HasMaxLength(50);

        builder.Property(e => e.FechaRegistro)
        .HasColumnName("date")
        .IsRequired();

        builder.HasOne(e => e.TipoPersona)
        .WithMany(e => e.Clientes)
        .HasForeignKey(e => e.IdTipoPersonaFk);

        builder.HasOne(e => e.Municipio)
        .WithMany(e => e.Clientes)
        .HasForeignKey(e => e.IdMunicipioFk);
    }
}
