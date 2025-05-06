

namespace Rutas.Dominio.Entidades
{
    public class Ruta : EntidadBaseGuid
    {
        public string DireccionOrigen { get; set; }
        public string DireccionDestino { get; set; }
        public string TipoEntrega { get; set; }
        public string MetodoTransporte { get; set; }

    }
}
