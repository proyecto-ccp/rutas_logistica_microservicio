
using MediatR;
using Microsoft.AspNetCore.Mvc;
using Rutas.Aplicacion.Comun;
using Rutas.Aplicacion.Rutas.Comandos;
using Rutas.Aplicacion.Rutas.Consultas;
using Rutas.Aplicacion.Rutas.Dto;

namespace Rutas.Api.Controllers
{
    /// <summary>
    /// Controlador de inventarios
    /// </summary>
    [ApiController]
    [Route("api/[controller]")]
    [Consumes("application/json")]
    [Produces("application/json")]
    public class RutasController : ControllerBase
    {
        private readonly IMediator _mediator;

        /// <summary>
        /// Constructor del controlador
        /// </summary>
        public RutasController(IMediator mediator)
        {
            _mediator = mediator;
        }

        /// <summary>
        /// Crear ruta de entrega de pedidos
        /// </summary>
        /// <response code="200"> 
        /// RutaOut: objeto de salida <br/>
        /// Resultado: Enumerador de la operación, Exitoso = 1, Error = 2, SinRegistros = 3 <br/>
        /// Mensaje: Mensaje de la operación <br/>
        /// Status: Código de estado HTTP <br/>
        /// </response>
        [HttpPost]
        [Route("")]
        [ProducesResponseType(typeof(RutaOut), 201)]
        [ProducesResponseType(StatusCodes.Status400BadRequest)]
        [ProducesResponseType(typeof(ProblemDetails), 401)]
        [ProducesResponseType(typeof(ProblemDetails), 500)]
        public async Task<IActionResult> Crear([FromBody] CrearRutaComando input)
        {
            var output = await _mediator.Send(input);

            if (output.Resultado != Resultado.Error)
            {
                return Created(string.Empty, output);
            }
            else
            {
                return Problem(output.Mensaje, statusCode: (int)output.Status);
            }
        }

        /// <summary>
        /// Consultar todas las rutas de entregas programadas
        /// </summary>
        /// <response code="200"> 
        /// RutaOut: objeto de salida <br/>
        /// Resultado: Enumerador de la operación, Exitoso = 1, Error = 2, SinRegistros = 3 <br/>
        /// Mensaje: Mensaje de la operación <br/>
        /// Status: Código de estado HTTP <br/>
        /// </response>
        [HttpGet]
        [Route("")]
        [ProducesResponseType(typeof(RutaOut), 200)]
        [ProducesResponseType(typeof(ProblemDetails), 401)]
        [ProducesResponseType(typeof(BaseOut), 404)]
        [ProducesResponseType(typeof(ProblemDetails), 500)]
        public async Task<IActionResult> ConsultarRutas()
        {
            var output = await _mediator.Send(new RutasConsulta());

            if (output.Resultado == Resultado.Exitoso)
            {
                return Ok(output);
            }
            else if (output.Resultado == Resultado.SinRegistros)
            {
                return NotFound(new { output.Resultado, output.Mensaje, output.Status });
            }
            else
            {
                return Problem(output.Mensaje, statusCode: (int)output.Status);
            }
        }

        /// <summary>
        /// Consultar una ruta de entrega
        /// </summary>
        /// <response code="200"> 
        /// RutaOut: objeto de salida <br/>
        /// Resultado: Enumerador de la operación, Exitoso = 1, Error = 2, SinRegistros = 3 <br/>
        /// Mensaje: Mensaje de la operación <br/>
        /// Status: Código de estado HTTP <br/>
        /// </response>
        [HttpGet]
        [Route("{IdRuta}")]
        [ProducesResponseType(typeof(RutasListOut), 200)]
        [ProducesResponseType(typeof(ProblemDetails), 401)]
        [ProducesResponseType(typeof(BaseOut), 404)]
        [ProducesResponseType(typeof(ProblemDetails), 500)]
        public async Task<IActionResult> ConsultaRuta([FromRoute] Guid IdRuta)
        {
            var output = await _mediator.Send(new RutaPorIdConsulta(IdRuta));

            if (output.Resultado == Resultado.Exitoso)
            {
                return Ok(output);
            }
            else if (output.Resultado == Resultado.SinRegistros)
            {
                return NotFound(new { output.Resultado, output.Mensaje, output.Status });
            }
            else
            {
                return Problem(output.Mensaje, statusCode: (int)output.Status);
            }
        }

        /// <summary>
        /// Asociar una lista de pedidos a una ruta de entrega
        /// </summary>
        /// <response code="200"> 
        /// RutaPedidoOut: objeto de salida <br/>
        /// Resultado: Enumerador de la operación, Exitoso = 1, Error = 2, SinRegistros = 3 <br/>
        /// Mensaje: Mensaje de la operación <br/>
        /// Status: Código de estado HTTP <br/>
        /// </response>
        [HttpPost]
        [Route("{IdRuta}/Pedidos")]
        [ProducesResponseType(typeof(RutaOut), 200)]
        [ProducesResponseType(StatusCodes.Status400BadRequest)]
        [ProducesResponseType(typeof(ProblemDetails), 401)]
        [ProducesResponseType(typeof(ProblemDetails), 500)]
        public async Task<IActionResult> AsociarPedidos([FromBody] List<RutaPedidoIn> pedidos, [FromRoute] Guid IdRuta)
        {
            var output = await _mediator.Send(new AgregarPedidoComando(IdRuta, pedidos));

            if (output.Resultado != Resultado.Error)
            {
                return Ok(output);
            }
            else
            {
                return Problem(output.Mensaje, statusCode: (int)output.Status);
            }
        }

    }
}
