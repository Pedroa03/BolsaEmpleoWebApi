using Capa_Entidad;
using Capa_Entidad.Complejo;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Capa_Datos.Repositorio
{
    public class UsuarioRepositorio : BolsaEmpleoDbContextBase<Usuario>, IUsuarioRepositorio
    {
        public UsuarioRepositorio(BolsaEmpleoDBContext context) : base(context)
        {

        }

        public async Task<string> CreateAsync(Usuario entity)
        {
            return await _context.Insert(entity);
        }

        public async Task DeleteAsync(string unique)
        {
            await _context.Delete(new Usuario
            {

                Unique = unique
            });
        }

        public async Task<Usuario> GetAsync(string unique)
        {
            return await Select(unique);
        }

        public async Task<(ICollection<UsuarioInfo> colletion, int total)> ListAsync(string filter, int page, int rows)
        {
            return await ListColllectionAsync(p => new UsuarioInfo
            {
                IdUsuario = p.IdUsuario,
                Nombre = p.Nombre,
                Apellido = p.Apellido,
                TipoUsuario = p.TipoUsuario.Descripcion,
                Clave = p.Clave,
                Correo = p.Correo,
                FechaCreacion = p.FechaCreacion,
                Categoria = p.Categoria.Descripcion,
                Descripcion = p.Descripcion,
                Logo = p.Logo,
                Unique = p.Unique,
                Url = p.Url,
                Estatus = p.Estatus


            }, p => p.Nombre.Contains(filter),page,rows);
        }

        public async Task<Usuario> LoginAsync(string Usuario, string Clave)
        {
            return await _context.LoginAsync(Usuario, Clave);
        }

        public async Task UpdateAsync(Usuario entity)
        {
            await _context.UpdateEntity(entity);
        }
    }
}
