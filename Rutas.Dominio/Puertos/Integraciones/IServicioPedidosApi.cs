
using Rutas.Dominio.Entidades;

namespace Rutas.Dominio.Puertos.Integraciones
{
    public interface IServicioPedidosApi
    {
        Task<Pedido> ObtenerPedidoPorId(Guid idPedido, string uri);
        Task<bool> CambiarEstado(Guid idPedido, Pedido pedido, string uri);
    }
}
