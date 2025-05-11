
using Rutas.Dominio.ObjetoValor;

namespace Rutas.Dominio.Puertos.Repositorios
{
    public interface IParametroRepositorio
    {
        Task<Parametro> DarParametro(string nombre);
    }
}
