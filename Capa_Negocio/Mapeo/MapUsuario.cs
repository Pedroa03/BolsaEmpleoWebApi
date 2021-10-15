using AutoMapper;
using Capa_Dto.DtoUsuario;
using Capa_Entidad;
using Capa_Entidad.Complejo;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Capa_Negocio.Mapeo
{
   public class MapUsuario: Profile
    {
        public MapUsuario()
        {
            CreateMap<UsuarioInfo, UsuarioDto>()
                .ForMember(o => o.Unique, d => d.MapFrom(x => x.Unique))
                .ForMember(o => o.IdUsuario, d => d.MapFrom(x => x.IdUsuario))
                .ForMember(o => o.Nombre, d => d.MapFrom(x => x.Nombre))
                .ForMember(o => o.Apellido, d => d.MapFrom(x => x.Apellido))
                .ForMember(o => o.TipoUsuario, d => d.MapFrom(x => x.TipoUsuario))
                .ForMember(o => o.Clave, d => d.MapFrom(x => x.Clave))
                .ForMember(o => o.Estatus, d => d.MapFrom(x => x.Estatus))
                .ForMember(o => o.FechaCreacion, d => d.MapFrom(x => x.FechaCreacion))
                .ForMember(o => o.Categoria, d => d.MapFrom(x => x.Categoria))
                .ForMember(o => o.Descripcion, d => d.MapFrom(x => x.Descripcion))
                .ForMember(o => o.Logo, d => d.MapFrom(x => x.Logo))
                .ForMember(o => o.Url, d => d.MapFrom(x => x.Url))
                .ReverseMap();

            CreateMap<Usuario, UsuarioSingleDto>()
                .ForMember(o => o.Unique, d => d.MapFrom(x => x.Unique))
                .ForMember(o => o.IdUsuario, d => d.MapFrom(x => x.IdUsuario))
                .ForMember(o => o.Nombre, d => d.MapFrom(x => x.Nombre))
                .ForMember(o => o.Apellido, d => d.MapFrom(x => x.Apellido))
                .ForMember(o => o.TipoUsuario, d => d.MapFrom(x => x.TipoUsuario))
                .ForMember(o => o.Clave, d => d.MapFrom(x => x.Clave))
                .ForMember(o => o.Estatus, d => d.MapFrom(x => x.Estatus))
                .ForMember(o => o.FechaCreacion, d => d.MapFrom(x => x.FechaCreacion))
                .ForMember(o => o.Categoria, d => d.MapFrom(x => x.Categoria))
                .ForMember(o => o.Descripcion, d => d.MapFrom(x => x.Descripcion))
                .ForMember(o => o.Logo, d => d.MapFrom(x => x.Logo))
                .ForMember(o => o.Url, d => d.MapFrom(x => x.Url))
                .ReverseMap();

            CreateMap<Usuario, UsuarioDtoRequest>()
                
                .ForMember(o => o.Nombre, d => d.MapFrom(x => x.Nombre))
                .ForMember(o => o.Apellido, d => d.MapFrom(x => x.Apellido))
                .ForMember(o => o.IdTipoUsuario, d => d.MapFrom(x => x.IdTipoUsuario))
                .ForMember(o => o.Clave, d => d.MapFrom(x => x.Clave))
                .ForMember(o => o.Estatus, d => d.MapFrom(x => x.Estatus))
                .ForMember(o => o.FechaCreacion, d => d.MapFrom(x => x.FechaCreacion))
                .ForMember(o => o.IdCategoria, d => d.MapFrom(x => x.IdCategoria))
                .ForMember(o => o.Descripcion, d => d.MapFrom(x => x.Descripcion))
                .ForMember(o => o.NombreArchivo, d => d.MapFrom(x => x.Logo))
                .ForMember(o => o.Url, d => d.MapFrom(x => x.Url))
                .ReverseMap();
        }
    }
}
