

using System.Diagnostics.CodeAnalysis;

namespace Rutas.Dominio.Entidades
{
    [ExcludeFromCodeCoverage]
    public abstract class EntidadBaseInt
    {
        public int Id { get; set; }
        public DateTime FechaCreacion { get; set; }
        public DateTime? FechaModificacion { get; set; }
    }
}
