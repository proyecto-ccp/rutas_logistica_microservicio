using Microsoft.EntityFrameworkCore;
using System.Diagnostics.CodeAnalysis;
using Rutas.Infraestructura.Adaptadores.Configuraciones;
using Rutas.Dominio.Entidades;

namespace PlanesVentas.Infraestructura.Adaptadores.Repositorios
{
    [ExcludeFromCodeCoverage]
    public class RutasDbContext : DbContext
    {
        public RutasDbContext(DbContextOptions<RutasDbContext> options): base(options){ }

        public DbSet<Ruta> Rutas { get; set; }
        public DbSet<RutaPedido> RutasPedidos { get; set; }

        protected override void OnModelCreating(ModelBuilder modelBuilder)
        {
            modelBuilder.ApplyConfiguration(new RutasConfiguracion());
            modelBuilder.ApplyConfiguration(new RutaPedidoConfiguracion());
        }
    }
}
