

using Microsoft.EntityFrameworkCore;
using Microsoft.EntityFrameworkCore.Metadata.Builders;
using Rutas.Dominio.Entidades;
using System.Diagnostics.CodeAnalysis;

namespace Rutas.Infraestructura.Adaptadores.Configuraciones
{
    [ExcludeFromCodeCoverage]
    public class RutasConfiguracion : IEntityTypeConfiguration<Ruta>
    {
        public void Configure(EntityTypeBuilder<Ruta> builder)
        {
            builder.ToTable("tbl_ruta");
            builder.HasKey(x => x.Id);

            builder.Property(x => x.Id).HasColumnName("id").IsRequired().ValueGeneratedOnAdd();

            builder.Property(x => x.DireccionOrigen)
                .HasColumnName("direccionorigen")
                .IsRequired();

            builder.Property(x => x.DireccionDestino)
                .HasColumnName("direcciondestino")
                .IsRequired();

            builder.Property(x => x.TipoEntrega)
                .HasColumnName("tipoentrega")
                .IsRequired();

            builder.Property(x => x.MetodoTransporte)
                .HasColumnName("metodotransporte")
                .IsRequired();

            builder.Property(x => x.FechaCreacion)
                .HasColumnName("fecharegistro")
                .HasColumnType("timestamp(6)")
                .IsRequired();

            builder.Property(x => x.FechaModificacion)
                .HasColumnName("fechaactualizacion")
                .HasColumnType("timestamp(6)")
                .IsRequired(false);

        }
    }
}
