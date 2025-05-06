
using AutoMapper;
using MediatR;
using Rutas.Aplicacion.Comun;
using Rutas.Aplicacion.Rutas.Dto;
using Rutas.Dominio.Servicios.Rutas;
using System.Net;

namespace Rutas.Aplicacion.Rutas.Consultas
{
    public class RutasConsultaHandler : IRequestHandler<RutasConsulta, RutasListOut>
    {
        private readonly IMapper _mapper;
        private readonly ObtenerRutas _servicio;

        public RutasConsultaHandler(IMapper mapper, ObtenerRutas servicio) 
        {
            _mapper = mapper;
            _servicio = servicio;
        }

        public async Task<RutasListOut> Handle(RutasConsulta request, CancellationToken cancellationToken)
        {
            RutasListOut output = new()
            {
                Rutas = []
            };

            try
            {

                var rutas = await _servicio.Ejecutar() ?? [];

                if (rutas.Count > 0)
                {
                    rutas.ForEach(plan => output.Rutas.Add(_mapper.Map<RutaDto>(plan)));
                    output.Resultado = Resultado.Exitoso;
                    output.Mensaje = "Consulta exitosa";
                    output.Status = HttpStatusCode.OK;
                }
                else
                {
                    output.Resultado = Resultado.SinRegistros;
                    output.Mensaje = "No hay rutas de entraga creadas";
                    output.Status = HttpStatusCode.NotFound;
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
