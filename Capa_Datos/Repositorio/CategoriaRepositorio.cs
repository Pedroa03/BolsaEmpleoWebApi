using Capa_Entidad;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Capa_Datos.Repositorio
{
    public class CategoriaRepositorio : BolsaEmpleoDbContextBase<Categoria>, ICategoriaRepositorio
    {
        public CategoriaRepositorio(BolsaEmpleoDBContext context): base(context)
        {

        }


        public async Task<string> CreateAsync(Categoria entity)
        {
            return await _context.Insert(entity);
        }

        public async Task DeleteAsync(string unique)
        {
            await _context.Delete(new Categoria
            {
                Unique = unique
            });
        }

        public async Task<Categoria> GetAsync(string unique)
        {
            return await Select(unique);
        }

        public async Task<(ICollection<Categoria> colletion, int total)> ListAsync(string filter, int page, int rows)
        {
            return await ListCollection(p => p.Descripcion.Contains(filter), page, rows);
        }

        public async Task UpdateAsync(Categoria entity)
        {
            await _context.UpdateEntity(entity);
        }
    }
}
