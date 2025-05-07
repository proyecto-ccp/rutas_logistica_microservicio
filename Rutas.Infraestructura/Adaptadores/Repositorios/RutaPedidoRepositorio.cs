
using Rutas.Dominio.Entidades;
using Rutas.Dominio.Puertos.Repositorios;
using Rutas.Infraestructura.Adaptadores.RepositorioGenerico;

namespace Rutas.Infraestructura.Adaptadores.Repositorios
{
    public class RutaPedidoRepositorio : IRutaPedidoRepositorio
    {
        private readonly IRepositorioBase<RutaPedido> _rutaPedidoRepositorio;

        public RutaPedidoRepositorio(IRepositorioBase<RutaPedido> rutaPedidoRepositorio)
        {
            _rutaPedidoRepositorio = rutaPedidoRepositorio;
        }
        public async Task<RutaPedido> Agregar(RutaPedido pedido)
        {
            return await _rutaPedidoRepositorio.Guardar(pedido);
        }

        public async Task<List<RutaPedido>> ObtenerRutasPorEstado(string estado)
        {
            return await _rutaPedidoRepositorio.DarListadoPorCampos(x => x.Estado == estado);
        }

        public async Task<List<RutaPedido>> ObtenerRutasPorIdRuta(Guid idRuta)
        {
            return await _rutaPedidoRepositorio.DarListadoPorCampos(x => x.IdRuta == idRuta);
        }
    }
}
