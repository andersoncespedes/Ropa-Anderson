using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;
using Dominio.Entities;
using Microsoft.EntityFrameworkCore;
using Microsoft.EntityFrameworkCore.Metadata.Builders;

namespace Persistencia.Data.Configuration;
public class EstadoConfiguration : IEntityTypeConfiguration<Estado>
{
    public void Configure(EntityTypeBuilder<Estado> builder)
    {
        builder.ToTable("estado");
        builder.Property(e => e.Descripcion)
        .HasColumnName("descripcion")
        .HasColumnType("varchar")
        .IsRequired()
        .HasMaxLength(50);

        builder.HasOne(e => e.TipoEstado)
        .WithMany( e => e.Estados)
        .HasForeignKey(e => e.IdTipoEstadoFk);
    }
}
