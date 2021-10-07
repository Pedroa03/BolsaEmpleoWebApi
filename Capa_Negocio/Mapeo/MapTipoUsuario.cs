using AutoMapper;
using Capa_Dto;
using Capa_Dto.DtoTipoUsuario;
using Capa_Entidad;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Capa_Negocio.Mapeo
{
    public class MapTipoUsuario : Profile
    {
        public MapTipoUsuario()
        {
            CreateMap<TipoUsuario, TipoUsuarioDto>()
                .ForMember(o => o.Id, d => d.MapFrom(x => x.Id))
                .ForMember(o => o.Descripcion, d => d.MapFrom(x => x.Descripcion))
                .ForMember(o => o.Unique, d => d.MapFrom(x => x.Unique))
                .ReverseMap();


            CreateMap<TipoUsuario, TipoUsuarioDtoRequest>()
               .ForMember(origen => origen.Descripcion, destino => destino.MapFrom(x => x.Descripcion))
               .ReverseMap();
        }
    }
}
