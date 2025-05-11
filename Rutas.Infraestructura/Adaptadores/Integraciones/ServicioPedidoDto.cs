
using Rutas.Dominio.Entidades;

namespace Rutas.Infraestructura.Adaptadores.Integraciones
{
    public class ObtenerPedidoOutput
    {
        public Pedido Pedido { get; set; }
        public int Resultado { get; set; }
        public string Mensaje { get; set; }
        public Guid? Id { get; set; }
        public int Status { get; set; }
    }

    public class ActualizarOutput
    {
        public int Resultado { get; set; }
        public string Mensaje { get; set; }
        public int Status { get; set; }
    }
}