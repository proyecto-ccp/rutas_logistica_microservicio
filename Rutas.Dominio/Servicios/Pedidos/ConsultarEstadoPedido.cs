
using Rutas.Dominio.Entidades;
using Rutas.Dominio.Puertos.Repositorios;

namespace Rutas.Dominio.Servicios.Pedidos
{
    public class ConsultarEstadoPedido(IRutaPedidoRepositorio rutaPedidoRepositorio)
    {
        private readonly IRutaPedidoRepositorio _rutaPedidoRepositorio = rutaPedidoRepositorio;

        public async Task<List<RutaPedido>> Ejecutar(string estado)
        {
            var rutaPedido = await _rutaPedidoRepositorio.ObtenerRutasPorEstado(estado);
            return rutaPedido;
        }
    }
}
