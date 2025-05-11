
using System.Diagnostics.CodeAnalysis;

namespace Rutas.Dominio.ObjetoValor
{
    [ExcludeFromCodeCoverage]
    public class Parametro
    {
        public string Id { get; set; }
        public string Valor { get; set; }
        public string Descripcion { get; set; }
    }
}
