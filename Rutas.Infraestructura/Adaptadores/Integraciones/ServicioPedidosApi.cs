
using Rutas.Dominio.Entidades;
using Rutas.Dominio.Puertos.Integraciones;
using System.Diagnostics.CodeAnalysis;
using System.Net.Http.Json;

namespace Rutas.Infraestructura.Adaptadores.Integraciones
{
    [ExcludeFromCodeCoverage]
    public class ServicioPedidosApi : IServicioPedidosApi
    {
        private readonly HttpClient _httpClient;

        public ServicioPedidosApi(HttpClient httpClient)
        {
            _httpClient = httpClient;
        }

        public async Task<bool> CambiarEstado(Guid idPedido, Pedido pedido, string uri)
        {
           var respuesta = await _httpClient.PutAsJsonAsync($"{uri}/{idPedido}", pedido);
           respuesta.EnsureSuccessStatusCode();
           await respuesta.Content.ReadFromJsonAsync<ActualizarOutput>();
           return true;
        }

        public async Task<Pedido> ObtenerPedidoPorId(Guid idPedido, string uri)
        {
            var respuesta = await _httpClient.GetAsync($"{uri}/{idPedido}");
            respuesta.EnsureSuccessStatusCode();
            var objRespuesta = await respuesta.Content.ReadFromJsonAsync<ObtenerPedidoOutput>();
            return objRespuesta?.Pedido;
        }
    }
}
