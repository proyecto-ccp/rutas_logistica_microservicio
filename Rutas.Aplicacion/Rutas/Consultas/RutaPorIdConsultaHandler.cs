

using AutoMapper;
using MediatR;
using Rutas.Aplicacion.Comun;
using Rutas.Aplicacion.Rutas.Dto;
using Rutas.Dominio.Servicios.Pedidos;
using Rutas.Dominio.Servicios.Rutas;
using System.Net;

namespace Rutas.Aplicacion.Rutas.Consultas
{
    public class RutaPorIdConsultaHandler : IRequestHandler<RutaPorIdConsulta, RutaOut>
    {
        private readonly IMapper _mapper;
        private readonly ConsultarRuta _servicio;
        private readonly ConsultarIdPedido _servicioPedidos;

        public RutaPorIdConsultaHandler(IMapper mapper, ConsultarRuta servicio, ConsultarIdPedido servicioPedidos) 
        {
            _mapper = mapper;
            _servicio = servicio;
            _servicioPedidos = servicioPedidos;
        }
        public async Task<RutaOut> Handle(RutaPorIdConsulta request, CancellationToken cancellationToken)
        {
            RutaOut output = new()
            {
                Ruta = new RutaDto()
            };

            try
            {

                var ruta = await _servicio.Ejecutar(request.IdRuta);

                if (ruta is null)
                {
                    output.Resultado = Resultado.SinRegistros;
                    output.Mensaje = "La ruta no existe";
                    output.Status = HttpStatusCode.NotFound;

                }
                else
                {
                    output.Ruta = _mapper.Map<RutaDto>(ruta);

                    var pedidos = await _servicioPedidos.Ejecutar(request.IdRuta) ?? [];
                    output.Ruta.Pedidos = _mapper.Map<List<RutaPedidoIn>>(pedidos);
                    output.Resultado = Resultado.Exitoso;
                    output.Mensaje = "Consulta exitosa";
                    output.Status = HttpStatusCode.OK;

                }

            }
            catch (Exception ex)
            {
                output.Resultado = Resultado.Error;
                output.Mensaje = string.Concat("Message: ", ex.Message, ex.InnerException is null ? "" : "-InnerException-" + ex.InnerException.Message);
                output.Status = HttpStatusCode.InternalServerError;
            }

            return output;

        }
    }
}
