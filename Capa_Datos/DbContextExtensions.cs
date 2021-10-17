using Capa_Entidad;
using Microsoft.EntityFrameworkCore;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Capa_Datos
{
    public static class DbContextExtensions
    {
        
        public static async Task<string> Insert<TEntityBase>(this DbContext context, TEntityBase entity) where TEntityBase : EntityBase
        {
            await context.Set<TEntityBase>().AddAsync(entity);
            context.Entry(entity).State = EntityState.Added;
            await context.SaveChangesAsync();

            return entity.Unique;
        }

        //public static async Task<string> Insertar(this DbContext context , Aplicacion entity)
        //{
        //    await context.AddAsync(entity);
        //    context.Entry(entity).State = EntityState.Added;
        //    await context.SaveChangesAsync();
        //    return entity.Unique;

        //}


        public static async Task UpdateEntity<TRequest>(this DbContext context, TRequest entity) where TRequest : EntityBase
        {
            context.Set<TRequest>().Attach(entity);
            context.Entry(entity).State = EntityState.Modified;
            await context.SaveChangesAsync();
        }


        public static async Task Delete<TRequest>(this DbContext context, TRequest entity) where TRequest : EntityBase
        {
            var entidad = await context.Set<TRequest>().FindAsync(entity.Unique);
            if (entidad == null) return;
            context.Set<TRequest>().Remove(entidad);
            context.Entry(entidad).State = EntityState.Deleted;

            await context.SaveChangesAsync();
        }

        public static async Task<Usuario> LoginAsync(this DbContext context, string usuario, string clave)
        {
            var entity = await context.Set<Usuario>()
                .Where(s => s.Correo == usuario)
                .Where(r => r.Clave == clave)
                .FirstOrDefaultAsync();

            return entity;
        }


    }
}
