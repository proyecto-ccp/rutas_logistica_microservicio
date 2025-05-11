
namespace Rutas.Dominio.Entidades
{
    public class Pedido
    {
        public Guid Id { get; set; }
        public Guid IdCliente { get; set; }
        public DateTime? FechaRealizado { get; set; }
        public DateTime FechaEntrega { get; set; }
        public string EstadoPedido { get; set; }
        public decimal ValorTotal { get; set; }
        public Guid? IdVendedor { get; set; }
        public string Comentarios { get; set; }
        public int IdMoneda { get; set; }
    }
}
