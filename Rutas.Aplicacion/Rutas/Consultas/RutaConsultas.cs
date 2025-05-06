
using MediatR;
using Rutas.Aplicacion.Rutas.Dto;
using System.ComponentModel.DataAnnotations;

namespace Rutas.Aplicacion.Rutas.Consultas
{
    public record RutasConsulta() : IRequest<RutasListOut>;
    public record RutaPorIdConsulta(
        [Required(ErrorMessage = "El campo IdRuta es obligatorio")]
        Guid IdRuta
        ) : IRequest<RutaOut>;


}

