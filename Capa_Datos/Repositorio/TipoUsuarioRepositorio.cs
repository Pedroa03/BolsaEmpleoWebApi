using Capa_Entidad;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Capa_Datos.Repositorio
{
    public class TipoUsuarioRepositorio : BolsaEmpleoDbContextBase<TipoUsuario>, ITipoUsuarioRepositorio
    {

        public TipoUsuarioRepositorio(BolsaEmpleoDBContext context) : base(context)
        {

        }


        public async  Task<string> CreateAsync(TipoUsuario entity)
        {
            return await _context.Insert(entity);
        }

        public async Task DeleteAsync(int id)
        {
            await _context.Delete(new TipoUsuario { 
            Id = id
            });
        }

        public async Task<TipoUsuario> GetAsync(int id)
        {
            return await Select(id);
        }

        public async Task<(ICollection<TipoUsuario> colletion, int total)> ListAsync(string filter, int page, int rows)
        {
            return await ListCollection(p => p.Descripcion.Contains(filter), page, rows);
        }

        public async Task UpdateAsync(TipoUsuario entity)
        {
            await _context.UpdateEntity(entity);
        }
    }
}
