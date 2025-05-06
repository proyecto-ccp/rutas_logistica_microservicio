
using AutoMapper;
using MediatR;
using Rutas.Aplicacion.Comun;
using Rutas.Aplicacion.Rutas.Dto;
using Rutas.Dominio.Entidades;
using Rutas.Dominio.Servicios.Rutas;
using System.Net;

namespace Rutas.Aplicacion.Rutas.Comandos
{
    public class CrearRutaComandoHandler : IRequestHandler<CrearRutaComando, RutaOut>
    {
        private readonly IMapper _mapper;
        private readonly CrearRuta _servicio;

        public CrearRutaComandoHandler(IMapper mapper, CrearRuta servicio) 
        {
            _mapper = mapper;
            _servicio = servicio;
        }

        public async Task<RutaOut> Handle(CrearRutaComando request, CancellationToken cancellationToken)
        {
            RutaOut output = new();

            try
            {
                var ruta = _mapper.Map<Ruta>(request);
                output.Ruta = _mapper.Map<RutaDto>(await _servicio.Ejecutar(ruta));
                output.Resultado = Resultado.Exitoso;
                output.Mensaje = "Ruta de entrega creada correctamente";
                output.Status = HttpStatusCode.Created;
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
