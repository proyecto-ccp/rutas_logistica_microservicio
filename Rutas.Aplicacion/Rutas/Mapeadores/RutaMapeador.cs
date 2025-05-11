
using AutoMapper;
using Rutas.Aplicacion.Rutas.Comandos;
using Rutas.Aplicacion.Rutas.Dto;
using Rutas.Dominio.Entidades;

namespace Rutas.Aplicacion.Rutas.Mapeadores
{
    public class RutaMapeador : Profile
    {
        public RutaMapeador() 
        {
            CreateMap<Ruta, RutaDto>().ReverseMap();
            CreateMap<CrearRutaComando, Ruta>().ReverseMap();

            CreateMap<RutaPedidoIn, RutaPedido>().ReverseMap();

            CreateMap<RutaPedido, RutaPedidoDto>().ReverseMap();


        }
        
    }
}
