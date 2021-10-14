using AutoMapper;
using Capa_Dto.DtoAplicacion;
using Capa_Entidad;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Capa_Negocio.Mapeo
{
    public class MapAplicacion: Profile
    {
        public MapAplicacion()
        {
            CreateMap<Aplicacion, AplicacionDto>()
              .ForMember(o => o.Id, d => d.MapFrom(x => x.Id))
              .ForMember(o => o.Unique, d => d.MapFrom(x => x.Unique))
              .ForMember(o => o.IdPuesto, d => d.MapFrom(x => x.IdPuesto))
              .ForMember(o => o.IdUsuario, d => d.MapFrom(x => x.IdUsuario))
              .ForMember(o => o.Fecha, d => d.MapFrom(x => x.Fecha))
              .ReverseMap();


            CreateMap<Aplicacion, AplicacionDtoRequest>()
              .ForMember(o => o.IdPuesto, d => d.MapFrom(x => x.IdPuesto))
              .ForMember(o => o.IdUsuario, d => d.MapFrom(x => x.IdUsuario))
              .ForMember(o => o.Fecha, d => d.MapFrom(x => x.Fecha))
              .ReverseMap();
        }
    }
}
