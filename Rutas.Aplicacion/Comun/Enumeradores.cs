
namespace Rutas.Aplicacion.Comun
{
    public enum Estado
    {
        PENDIENTE = 1,
        EN_RUTA = 2,
        ENTREGADO = 3,
        DEVOLUCION = 4
    }

    public enum TipoEntrega
    {
        NORMAL = 1,
        URGENTE = 2
    }

    public enum MetodoTransporte
    {
        CAMION = 1,
        FURGON = 2,
        AUTOMOVIL = 3
    }
}
