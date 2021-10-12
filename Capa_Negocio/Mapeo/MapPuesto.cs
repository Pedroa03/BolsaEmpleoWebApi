using AutoMapper;
using Capa_Dto.DtoPuesto;
using Capa_Entidad;
using Capa_Entidad.Complejo;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Capa_Negocio.Mapeo
{
    public class MapPuesto: Profile
    {
        public MapPuesto()
        {
            CreateMap<PuestoInfo, PuestoDto>()
                .ForMember(o => o.Unique, d => d.MapFrom(x => x.Unique))
                .ForMember(o => o.IdPuesto, d => d.MapFrom(x => x.IdPuesto))
                .ForMember(o => o.Compañia, d => d.MapFrom(x => x.Compañia))
                .ForMember(o => o.TipoJornada, d => d.MapFrom(x => x.TipoJornada))
                .ForMember(o => o.Logo, d => d.MapFrom(x => x.Logo))
                .ForMember(o => o.Url, d => d.MapFrom(x => x.Url))
                .ForMember(o => o.Posicion, d => d.MapFrom(x => x.Posicion))
                .ForMember(o => o.Ubicacion, d => d.MapFrom(x => x.Ubicacion))
                .ForMember(o => o.Categoria, d => d.MapFrom(x => x.Categoria))
                .ForMember(o => o.Descripcion, d => d.MapFrom(x => x.Descripcion))
                .ForMember(o => o.CorreoContacto, d => d.MapFrom(x => x.CorreoContacto))
                .ForMember(o => o.Usuario, d => d.MapFrom(x => x.Usuario))
                .ForMember(o => o.Fecha, d => d.MapFrom(x => x.Fecha))
                .ReverseMap();

            CreateMap<Puesto, PuestoSingleDto>()
                .ForMember(o => o.Unique, d => d.MapFrom(x => x.Unique))
                .ForMember(o => o.IdPuesto, d => d.MapFrom(x => x.IdPuesto))
                .ForMember(o => o.Compañia, d => d.MapFrom(x => x.Compañia))
                .ForMember(o => o.TipoJornada, d => d.MapFrom(x => x.TipoJornada))
                .ForMember(o => o.Logo, d => d.MapFrom(x => x.Logo))
                .ForMember(o => o.Url, d => d.MapFrom(x => x.Url))
                .ForMember(o => o.Posicion, d => d.MapFrom(x => x.Posicion))
                .ForMember(o => o.Ubicacion, d => d.MapFrom(x => x.Ubicacion))
                .ForMember(o => o.Categoria, d => d.MapFrom(x => x.Categoria))
                .ForMember(o => o.Descripcion, d => d.MapFrom(x => x.Descripcion))
                .ForMember(o => o.CorreoContacto, d => d.MapFrom(x => x.CorreoContacto))
                .ForMember(o => o.Usuario, d => d.MapFrom(x => x.Usuario))
                .ForMember(o => o.Fecha, d => d.MapFrom(x => x.Fecha))
                .ReverseMap();

            CreateMap<Puesto, PuestoDtoRequest>()

                .ForMember(o => o.Compañia, d => d.MapFrom(x => x.Compañia))
                .ForMember(o => o.IdTipoJornada, d => d.MapFrom(x => x.IdTipoJornada))
                .ForMember(o => o.Logo, d => d.MapFrom(x => x.Logo))
                .ForMember(o => o.Url, d => d.MapFrom(x => x.Url))
                .ForMember(o => o.Posicion, d => d.MapFrom(x => x.Posicion))
                .ForMember(o => o.Ubicacion, d => d.MapFrom(x => x.Ubicacion))
                .ForMember(o => o.idCategoria, d => d.MapFrom(x => x.IdCategoria))
                .ForMember(o => o.Descripcion, d => d.MapFrom(x => x.Descripcion))
                .ForMember(o => o.CorreoContacto, d => d.MapFrom(x => x.CorreoContacto))
                .ForMember(o => o.idUsuario, d => d.MapFrom(x => x.IdUsuario))
                .ForMember(o => o.Fecha, d => d.MapFrom(x => x.Fecha))
                .ReverseMap();
        }
    }
}
