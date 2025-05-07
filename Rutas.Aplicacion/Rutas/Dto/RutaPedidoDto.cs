
using Rutas.Aplicacion.Comun;
using System.Diagnostics.CodeAnalysis;

namespace Rutas.Aplicacion.Rutas.Dto
{
    [ExcludeFromCodeCoverage]
    public class RutaPedidoDto
    {
        public int Id { get; set; }
        public Guid IdRuta { get; set; }
        public Guid IdPedido { get; set; }
        public Estado Estado { get; set; }
        public DateTime FechaCreacion { get; set; }
        public DateTime? FechaModificacion { get; set; }
    }

    [ExcludeFromCodeCoverage]
    public class RutaPedidoOut : BaseOut
    {
        public RutaPedidoDto RutaPedido { get; set; }
    }

    [ExcludeFromCodeCoverage]
    public class RutasPedidosListOut : BaseOut
    {
        public List<RutaPedidoDto> RutasPedidos { get; set; }
    }

    [ExcludeFromCodeCoverage]
    public class RutaPedidoIn 
    {
        public Guid IdPedido { get; set; }
    }
}
