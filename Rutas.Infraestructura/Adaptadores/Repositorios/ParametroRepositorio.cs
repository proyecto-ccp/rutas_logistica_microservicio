
using Rutas.Dominio.ObjetoValor;
using Rutas.Dominio.Puertos.Repositorios;
using Rutas.Infraestructura.Adaptadores.RepositorioGenerico;
using System.Diagnostics.CodeAnalysis;

namespace Rutas.Infraestructura.Adaptadores.Repositorios
{
    [ExcludeFromCodeCoverage]
    public class ParametroRepositorio : IParametroRepositorio
    {
        private readonly IRepositorioBase<Parametro> _repositorioParametro;

        public ParametroRepositorio(IRepositorioBase<Parametro> repositorioParametro)
        {
            _repositorioParametro = repositorioParametro;
        }
        public async Task<Parametro> DarParametro(string nombre)
        {
            return await _repositorioParametro.BuscarPorLlave(nombre);
        }
    }
}
