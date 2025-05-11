
using Rutas.Dominio.Entidades;
using Rutas.Dominio.Puertos.Repositorios;

namespace Rutas.Dominio.Servicios.RutaPedidos
{
    public class ConsultarIdPedido(IRutaPedidoRepositorio rutaPedidoRepositorio)
    {
        private readonly IRutaPedidoRepositorio _rutaPedidoRepositorio = rutaPedidoRepositorio;

        public async Task<List<RutaPedido>> Ejecutar(Guid idPedido)
        {
            var rutaPedido = await _rutaPedidoRepositorio.ObtenerRutasPorIdRuta(idPedido);
            return rutaPedido;
        }
    }
}
