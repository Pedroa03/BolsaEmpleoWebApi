using Capa_Entidad;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Capa_Datos.Repositorio
{
    public class JornadaRepositorio : BolsaEmpleoDbContextBase<Jornada>, IJornadaRepositorio
    {

        public JornadaRepositorio( BolsaEmpleoDBContext context) : base(context)
        {

        }

        public async Task<string> CreateAsync(Jornada entity)
        {
            return await _context.Insert(entity);
        }

        public async Task DeleteAsync(string unique)
        {
            await _context.Delete(new Jornada
            {
                Unique = unique
            });
        }

        public async Task<Jornada> GetAsync(string unique)
        {
            return await Select(unique);
        }

        public async Task<(ICollection<Jornada> colletion, int total)> ListAsync(string filter, int page, int rows)
        {
            return await ListCollection(p => p.Descripcion.Contains(filter), page, rows);
        }

        public async Task UpdateAsync(Jornada entity)
        {
            await _context.UpdateEntity(entity);
        }
    }
}
