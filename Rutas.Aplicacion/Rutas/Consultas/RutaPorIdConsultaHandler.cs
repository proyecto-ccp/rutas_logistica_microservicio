

using AutoMapper;
using MediatR;
using Rutas.Aplicacion.Comun;
using Rutas.Aplicacion.Rutas.Dto;
using Rutas.Dominio.Servicios.Rutas;
using System.Net;

namespace Rutas.Aplicacion.Rutas.Consultas
{
    public class RutaPorIdConsultaHandler : IRequestHandler<RutaPorIdConsulta, RutaOut>
    {
        private readonly IMapper _mapper;
        private readonly ConsultarRuta _servicio;

        public RutaPorIdConsultaHandler(IMapper mapper, ConsultarRuta servicio) 
        {
            _mapper = mapper;
            _servicio = servicio;
        }
        public async Task<RutaOut> Handle(RutaPorIdConsulta request, CancellationToken cancellationToken)
        {
            RutaOut output = new();

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
