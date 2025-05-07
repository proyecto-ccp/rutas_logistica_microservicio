
namespace Rutas.Dominio.Entidades
{
    public class RutaPedido : EntidadBaseInt
    {
        public Guid IdRuta { get; set; }
        public Guid IdPedido { get; set; }
        public string Estado { get; set; }

    }
}
