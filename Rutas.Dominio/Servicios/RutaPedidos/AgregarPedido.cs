
using Rutas.Dominio.Entidades;
using Rutas.Dominio.Puertos.Repositorios;

namespace Rutas.Dominio.Servicios.RutaPedidos
{
    public class AgregarPedido(IRutaPedidoRepositorio rutaPedidoRepositorio)
    {
        private readonly IRutaPedidoRepositorio _rutaPedidoRepositorio = rutaPedidoRepositorio;

        public async Task<RutaPedido> Ejecutar(RutaPedido pedido)
        {
            pedido.FechaCreacion = DateTime.SpecifyKind(DateTime.UtcNow, DateTimeKind.Unspecified);
            var rutaPedido = await _rutaPedidoRepositorio.Agregar(pedido);
            return rutaPedido;
        }
    }
}
