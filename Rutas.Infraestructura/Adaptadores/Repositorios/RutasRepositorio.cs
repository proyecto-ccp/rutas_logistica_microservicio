

using Rutas.Dominio.Entidades;
using Rutas.Dominio.Puertos.Repositorios;
using Rutas.Infraestructura.Adaptadores.RepositorioGenerico;
using System.Diagnostics.CodeAnalysis;

namespace PlanesVentas.Infraestructura.Adaptadores.Repositorios
{
    [ExcludeFromCodeCoverage]
    public class RutasRepositorio : IRutasRepositorio
    {
        private readonly IRepositorioBase<Ruta> _repositorioRutas;

        public RutasRepositorio(IRepositorioBase<Ruta> repositorioRutas)
        {
            _repositorioRutas = repositorioRutas;
        }

        public async Task<Ruta> Crear(Ruta ruta)
        {
            return await _repositorioRutas.Guardar(ruta);
        }

        public async Task<Ruta> ObtenerRutaPorId(Guid id)
        {
            return await _repositorioRutas.BuscarPorLlave(id);  
        }

        public async Task<List<Ruta>> ObtenerRutas()
        {
            return await _repositorioRutas.DarListado();
        }
    }
}
