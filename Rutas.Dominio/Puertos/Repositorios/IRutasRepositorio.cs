

using Rutas.Dominio.Entidades;

namespace Rutas.Dominio.Puertos.Repositorios
{
    public interface IRutasRepositorio
    {
        Task<Ruta> Crear(Ruta ruta);
        Task<List<Ruta>> ObtenerRutas();
        Task<Ruta> ObtenerRutaPorId(Guid id);
    }
}
