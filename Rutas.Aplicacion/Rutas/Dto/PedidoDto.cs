
using Rutas.Dominio.Entidades;

namespace Rutas.Aplicacion.Rutas.Dto
{
    public class PedidoDto
    {
        public Pedido Pedido { get; set; }
        public int Resultado { get; set; }
        public string Mensaje { get; set; }
        public Guid? Id { get; set; }
        public int Status { get; set; }
    }

}
