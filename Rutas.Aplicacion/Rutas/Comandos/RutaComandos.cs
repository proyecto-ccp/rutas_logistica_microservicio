

using MediatR;
using Rutas.Aplicacion.Rutas.Dto;
using System.ComponentModel.DataAnnotations;
using System.Diagnostics.CodeAnalysis;

namespace Rutas.Aplicacion.Rutas.Comandos
{
    [ExcludeFromCodeCoverage]
    public record CrearRutaComando(
        [Required(ErrorMessage = "El campo DireccionOrigen es obligatorio")]
        string DireccionOrigen,
        [Required(ErrorMessage = "El campo DireccionDestino es obligatorio")]
        string DireccionDestino,
        [Required(ErrorMessage = "El campo TipoEntrega es obligatorio")]
        string TipoEntrega,
        [Required(ErrorMessage = "El campo MetodoTransporte es obligatorio")]
        string MetodoTransporte
        ) : IRequest<RutaOut>;

}
