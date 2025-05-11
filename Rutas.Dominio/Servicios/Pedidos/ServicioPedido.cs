
using Rutas.Dominio.Entidades;
using Rutas.Dominio.ObjetoValor;
using Rutas.Dominio.Puertos.Integraciones;
using Rutas.Dominio.Puertos.Repositorios;

namespace Rutas.Dominio.Servicios.Pedidos
{
    public class ServicioPedido(IServicioPedidosApi servicioPedidosApi, IParametroRepositorio parametros)
    {
        private readonly IServicioPedidosApi _servicioPedidosApi = servicioPedidosApi;
        private readonly IParametroRepositorio _parametros = parametros;

        public async Task<Pedido> ObtenerPedido(Guid idpedido) 
        {
            var urlBase = await DarParametro(EnumeradorParametros.pedidosUrlBase);
            var path = await DarParametro(EnumeradorParametros.consultarPedido);
            var uri = string.Concat(urlBase, path);

            return await _servicioPedidosApi.ObtenerPedidoPorId(idpedido, uri);

        }

        public async Task<bool> CambiarEstado(Pedido pedido)
        {
            var urlBase = await DarParametro(EnumeradorParametros.pedidosUrlBase);
            var path = await DarParametro(EnumeradorParametros.actualizarPedido);
            var uri = string.Concat(urlBase, path);
            
            return await _servicioPedidosApi.CambiarEstado(pedido.Id, pedido, uri);
        }

        private async Task<string> DarParametro(EnumeradorParametros parametro)
        {
            var parametroValor = await _parametros.DarParametro(parametro.ToString()) ?? throw new ArgumentNullException(parametro.ToString(), "El parametro no existe");

            return parametroValor.Valor;
        }
    }
}
