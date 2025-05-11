
using AutoMapper;
using MediatR;
using Rutas.Aplicacion.Comun;
using Rutas.Aplicacion.Rutas.Dto;
using Rutas.Dominio.Entidades;
using Rutas.Dominio.Servicios.Pedidos;
using Rutas.Dominio.Servicios.RutaPedidos;
using Rutas.Dominio.Servicios.Rutas;
using System.Net;

namespace Rutas.Aplicacion.Rutas.Comandos
{
    public class AgregarPedidoComandoHandler : IRequestHandler<AgregarPedidoComando, RutaOut>
    {
        private readonly IMapper _mapper;
        private readonly ConsultarRuta _consultarRuta;
        private readonly AgregarPedido _agregarPedido;
        private readonly ServicioPedido _servicioPedido;

        public AgregarPedidoComandoHandler(IMapper mapeador, ConsultarRuta consultarRuta, AgregarPedido agregarPedido, ServicioPedido servicioPedido)
        {
            _mapper = mapeador;
            _consultarRuta = consultarRuta;
            _agregarPedido = agregarPedido;
            _servicioPedido = servicioPedido;
        }
        public async Task<RutaOut> Handle(AgregarPedidoComando request, CancellationToken cancellationToken)
        {
            RutaOut output = new()
            {
                Ruta = new RutaDto()
            };
            output.Ruta.Pedidos = [];
            var errorEnPedido = false;

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
                    List<RutaPedidoIn> pedidosAgregados = [];
                    foreach (RutaPedidoIn pedido in request.Pedidos)
                    {
                        var procesoModificar = await ModificarPedido(pedido.IdPedido);

                        if (procesoModificar.Resultado == Resultado.Exitoso) 
                        {
                            var productoAgregar = _mapper.Map<RutaPedido>(pedido);
                            productoAgregar.IdRuta = request.IdRuta;
                            productoAgregar.Estado = Estado.PENDIENTE.ToString();
                            await _agregarPedido.Ejecutar(productoAgregar);
                            pedidosAgregados.Add(pedido);
                        }
                        else
                        {
                            errorEnPedido = true;
                        }
                    }
                    output.Ruta.Pedidos = pedidosAgregados;
                    output.Resultado = Resultado.Exitoso;
                    output.Mensaje = errorEnPedido ? "Al menos un pedido no fue asociado correctamente" : "Pedidos asociados correctamente";
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

        public async Task<BaseOut> ModificarPedido(Guid idpedido) 
        { 
            var output = new BaseOut();
            
            try
            {
                var pedido = await _servicioPedido.ObtenerPedido(idpedido);

                if (pedido != null)
                {
                    pedido.EstadoPedido = "EN TRANSITO";
                    pedido.FechaRealizado = DateTime.SpecifyKind(DateTime.UtcNow, DateTimeKind.Utc);
                    await _servicioPedido.CambiarEstado(pedido);
                    output.Mensaje = "Pedido actualizado correctamente";
                    output.Resultado = Resultado.Exitoso;
                    output.Status = HttpStatusCode.OK;
                }
                else
                {
                    output.Mensaje = "No se encontró el pedido";
                    output.Resultado = Resultado.SinRegistros;
                    output.Status = HttpStatusCode.NotFound;
                }
            }
            catch 
            {
                output.Mensaje = "Error al modificar pedido";
                output.Resultado = Resultado.Error;
                output.Status = HttpStatusCode.InternalServerError;
            }

            return output;
        }
    }
}
