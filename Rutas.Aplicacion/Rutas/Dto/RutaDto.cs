
using Rutas.Aplicacion.Comun;
using System.Diagnostics.CodeAnalysis;

namespace Rutas.Aplicacion.Rutas.Dto
{
    [ExcludeFromCodeCoverage]
    public class RutaDto
    {
        public Guid Id { get; set; }
        public string DireccionOrigen { get; set; }
        public string DireccionDestino { get; set; }
        public string TipoEntrega { get; set; }
        public string MetodoTransporte { get; set; }
        public DateTime FechaCreacion { get; set; }
        public DateTime? FechaModificacion { get; set; }
    }

    [ExcludeFromCodeCoverage]
    public class RutaOut : BaseOut
    {
        public RutaDto Ruta { get; set; }
    }

    [ExcludeFromCodeCoverage]
    public class RutasListOut : BaseOut
    {
        public List<RutaDto> Rutas { get; set; }
    }
}
