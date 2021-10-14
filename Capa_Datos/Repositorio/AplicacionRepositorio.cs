using Capa_Entidad;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Capa_Datos.Repositorio
{
    public class AplicacionRepositorio: BolsaEmpleoDbContextBase<Aplicacion>, IAplicacionRepositorio
    {
        public AplicacionRepositorio( BolsaEmpleoDBContext context): base(context)
        {

        }
        public async Task<string> CreateAsync(Aplicacion entity)
        {
            return await _context.Insert(entity);
        }

        //public async Task<string> CreateAsyncNew(Aplicacion entity)
        //{
        //   return await  _context.Insertar(entity);
        //}

        public async Task DeleteAsync(string unique)
        {
            await _context.Delete(new Aplicacion
            {
                Unique = unique
            });
        }

        public async Task<Aplicacion> GetAsync(string unique)
        {
            return await Select(unique);
        }

        public Task<(ICollection<Aplicacion> colletion, int total)> ListAsync(string filter, int page, int rows)
        {
            throw new NotImplementedException();
        }

        public async Task UpdateAsync(Aplicacion entity)
        {
            await _context.UpdateEntity(entity);
        }
    }
}
