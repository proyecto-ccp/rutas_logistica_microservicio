
using Rutas.Dominio.Entidades;
using Rutas.Dominio.Puertos.Repositorios;

namespace Rutas.Dominio.Servicios.Rutas
{
    public class ConsultarRuta(IRutasRepositorio rutasRepositorio)
    {
        private readonly IRutasRepositorio _rutasRepositorio = rutasRepositorio;

        public async Task<Ruta> Ejecutar(Guid idRuta)
        {
            return await _rutasRepositorio.ObtenerRutaPorId(idRuta);
        }
    }
}
