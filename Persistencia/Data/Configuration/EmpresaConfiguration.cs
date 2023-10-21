using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;
using Dominio.Entities;
using Microsoft.EntityFrameworkCore;
using Microsoft.EntityFrameworkCore.Metadata.Builders;

namespace Persistencia.Data.Configuration;
public class EmpresaConfiguration : IEntityTypeConfiguration<Empresa>
{
    public void Configure(EntityTypeBuilder<Empresa> builder)
    {
        builder.ToTable("empresa");

        builder.Property(e => e.Nit)
        .HasColumnType("varchar")
        .HasColumnName("nit")
        .IsRequired()
        .HasMaxLength(50);

        builder.Property(e => e.RepresentanteLegal)
        .HasColumnType("varchar")
        .HasColumnName("representante_legal")
        .IsRequired()
        .HasMaxLength(50);

        builder.Property(e => e.RazonSocial)
        .HasColumnType("text")
        .HasColumnName("razon_social")
        .IsRequired();

        builder.Property(e => e.FechaCreacion)
        .HasColumnType("date")
        .IsRequired();

        builder.HasOne(e => e.Municipio)
        .WithMany(e => e.Empresas)
        .HasForeignKey(e => e.IdMunicipioFk);
    }
}
