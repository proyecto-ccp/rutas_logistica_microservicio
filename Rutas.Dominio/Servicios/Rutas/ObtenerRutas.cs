

using Rutas.Dominio.Entidades;
using Rutas.Dominio.Puertos.Repositorios;

namespace Rutas.Dominio.Servicios.Rutas
{
    public class ObtenerRutas(IRutasRepositorio rutasRepositorio)
    {
        private readonly IRutasRepositorio _rutasRepositorio = rutasRepositorio;

        public async Task<List<Ruta>> Ejecutar()
        {
            return await _rutasRepositorio.ObtenerRutas();
        }
    }
}
