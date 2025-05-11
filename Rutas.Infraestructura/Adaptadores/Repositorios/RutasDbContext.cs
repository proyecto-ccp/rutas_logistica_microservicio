using Microsoft.EntityFrameworkCore;
using System.Diagnostics.CodeAnalysis;
using Rutas.Infraestructura.Adaptadores.Configuraciones;
using Rutas.Dominio.Entidades;
using Rutas.Dominio.ObjetoValor;

namespace PlanesVentas.Infraestructura.Adaptadores.Repositorios
{
    [ExcludeFromCodeCoverage]
    public class RutasDbContext : DbContext
    {
        public RutasDbContext(DbContextOptions<RutasDbContext> options): base(options){ }

        public DbSet<Ruta> Rutas { get; set; }
        public DbSet<RutaPedido> RutasPedidos { get; set; }
        public DbSet<Parametro> Parametros { get; set; }

        protected override void OnModelCreating(ModelBuilder modelBuilder)
        {
            modelBuilder.ApplyConfiguration(new RutasConfiguracion());
            modelBuilder.ApplyConfiguration(new RutaPedidoConfiguracion());
            modelBuilder.ApplyConfiguration(new ParametroConfiguracion());
        }
    }
}
