
using Rutas.Dominio.Entidades;
using Rutas.Dominio.Puertos.Repositorios;

namespace Rutas.Dominio.Servicios.Rutas
{
    public class CrearRuta (IRutasRepositorio rutasRepositorio)
    {
        private readonly IRutasRepositorio _rutasRepositorio = rutasRepositorio;

        public async Task<Ruta> Ejecutar(Ruta ruta)
        {
            Ruta output;
            ruta.Id = Guid.NewGuid();
            ruta.FechaCreacion = DateTime.SpecifyKind(DateTime.UtcNow, DateTimeKind.Unspecified);

            output = await _rutasRepositorio.Crear(ruta);
            return output;
        }

    }
}
