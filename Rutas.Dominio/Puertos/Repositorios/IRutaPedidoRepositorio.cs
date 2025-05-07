
using Rutas.Dominio.Entidades;

namespace Rutas.Dominio.Puertos.Repositorios
{
    public interface IRutaPedidoRepositorio
    {
        Task<List<RutaPedido>> ObtenerRutasPorEstado(string estado);
        Task<List<RutaPedido>> ObtenerRutasPorIdRuta(Guid idRuta);
        Task<RutaPedido> Agregar(RutaPedido pedido);

    }
}
