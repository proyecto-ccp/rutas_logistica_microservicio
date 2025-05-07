
using AutoMapper;
using MediatR;
using Rutas.Aplicacion.Comun;
using Rutas.Aplicacion.Rutas.Dto;
using Rutas.Dominio.Entidades;
using Rutas.Dominio.Servicios.Pedidos;
using Rutas.Dominio.Servicios.Rutas;
using System.Net;

namespace Rutas.Aplicacion.Rutas.Comandos
{
    public class AgregarPedidoComandoHandler : IRequestHandler<AgregarPedidoComando, RutaOut>
    {
        private readonly IMapper _mapper;
        private readonly ConsultarRuta _consultarRuta;
        private readonly AgregarPedido _agregarPedido;

        public AgregarPedidoComandoHandler(IMapper mapeador, ConsultarRuta consultarRuta, AgregarPedido agregarPedido)
        {
            _mapper = mapeador;
            _consultarRuta = consultarRuta;
            _agregarPedido = agregarPedido;
        }
        public async Task<RutaOut> Handle(AgregarPedidoComando request, CancellationToken cancellationToken)
        {
            RutaOut output = new()
            {
                Ruta = new RutaDto()
            };
            output.Ruta.Pedidos = [];
            
            try
            {
                var plan = await _consultarRuta.Ejecutar(request.IdRuta);

                if (plan is null)
                {
                    output.Resultado = Resultado.SinRegistros;
                    output.Mensaje = "No hay ruta de entrega creada";
                    output.Status = HttpStatusCode.NotFound;
                }
                else
                {
                    output.Ruta = _mapper.Map<RutaDto>(plan);
                    foreach (RutaPedidoIn pedido in request.Pedidos)
                    {
                        var productoAgregar = _mapper.Map<RutaPedido>(pedido);
                        productoAgregar.IdRuta = request.IdRuta;
                        productoAgregar.Estado = Estado.PENDIENTE.ToString();
                        await _agregarPedido.Ejecutar(productoAgregar);
                    }
                    output.Ruta.Pedidos = request.Pedidos;
                    output.Resultado = Resultado.Exitoso;
                    output.Mensaje = "Pedidos asociados correctamente";
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
