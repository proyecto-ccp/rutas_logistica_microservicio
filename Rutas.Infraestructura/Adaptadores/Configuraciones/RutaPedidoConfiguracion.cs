
using Microsoft.EntityFrameworkCore;
using Microsoft.EntityFrameworkCore.Metadata.Builders;
using Rutas.Dominio.Entidades;
using System.Diagnostics.CodeAnalysis;

namespace Rutas.Infraestructura.Adaptadores.Configuraciones
{
    [ExcludeFromCodeCoverage]
    public class RutaPedidoConfiguracion : IEntityTypeConfiguration<RutaPedido>
    {
        public void Configure(EntityTypeBuilder<RutaPedido> builder)
        {
            builder.ToTable("tbl_rutaspedidos");
            builder.HasKey(x => x.Id);
            builder.Property(x => x.Id).HasColumnName("id").IsRequired().ValueGeneratedOnAdd();

            builder.Property(x => x.IdRuta)
                .HasColumnName("idruta")
                .IsRequired();

            builder.Property(x => x.IdPedido)
                .HasColumnName("idpedido")
                .IsRequired();

            builder.Property(x => x.Estado)
                .HasColumnName("estado")
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
