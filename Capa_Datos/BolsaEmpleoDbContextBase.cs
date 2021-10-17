using Capa_Entidad;
using Microsoft.EntityFrameworkCore;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Linq.Expressions;
using System.Text;
using System.Threading.Tasks;

namespace Capa_Datos
{
   public class BolsaEmpleoDbContextBase<TEntityBase> where TEntityBase: EntityBase,new()
    {
        protected BolsaEmpleoDBContext _context;

        protected BolsaEmpleoDbContextBase( BolsaEmpleoDBContext context)
        {
            _context = context;
        }

        public virtual async Task<(ICollection<TEntityBase> collection, int total)>
            ListCollection(Expression<Func<TEntityBase, bool>> predicate, int page, int rows)
        {
            var collection = await _context.Set<TEntityBase>()
                .Where(predicate)
                .OrderBy(p => p.Unique)
                .AsNoTracking()
                .Skip((page - 1) * rows)
                .Take(rows)
                .ToListAsync();



            var totalCount = await _context.Set<TEntityBase>()
                .Where(predicate)
                .AsNoTracking()
                .CountAsync();


            return (collection.ToList(), totalCount);
        }

        public async Task<(ICollection<TInfo> collection, int total)> ListColllectionAsync<TInfo>
          (Expression<Func<TEntityBase, TInfo>> selector,
           Expression<Func<TEntityBase, bool>> predicate,
           int page,
           int rows)
           where TInfo : class, new()
        {
            var collection = await 
                _context.Set<TEntityBase>()
            .Where(predicate)
            .AsNoTracking()
            .Select(selector)
            .Skip((page - 1) * rows)
            .Take(rows)
            .ToListAsync();

            var totalcount = await _context.Set<TEntityBase>()
            .Where(predicate)
            .AsNoTracking()
            .CountAsync();

            return (collection.ToList(), totalcount);

        }

        public async Task<TEntityBase> Select(string unique)
        {
            var entity = await _context.Set<TEntityBase>().FirstOrDefaultAsync(e => e.Unique == unique);
            return entity;
        }


    }
}
