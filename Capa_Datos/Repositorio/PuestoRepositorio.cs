using Capa_Entidad;
using Capa_Entidad.Complejo;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Capa_Datos.Repositorio
{
    public class PuestoRepositorio : BolsaEmpleoDbContextBase<Puesto>, IPuestoRepositorio
    {
        public PuestoRepositorio( BolsaEmpleoDBContext context): base(context)
        {

        }

        public async Task<string> CreateAsync(Puesto entity)
        {
            return await _context.Insert(entity);
        }

        public async Task DeleteAsync(int id)
        {
            await _context.Delete(new Puesto
            {

                IdPuesto = id
            });
        }

        public async Task<Puesto> GetAsync(int id)
        {
            return await Select(id);
        }

        public async Task<(ICollection<PuestoInfo> colletion, int total)> ListAsync(string filter, int page, int rows)
        {
            return await ListColllectionAsync(p => new PuestoInfo
            {
                IdPuesto = p.IdPuesto,
                Compañia = p.Compañia,
                TipoJornada = p.TipoJornada.Descripcion,
                Logo = p.Logo,
                Url = p.Url,
                Posicion = p.Posicion,
                Ubicacion = p.Ubicacion,
                Categoria = p.Categoria.Descripcion,
                Descripcion = p.Descripcion,
                CorreoContacto = p.CorreoContacto,
                Usuario = p.Usuario.Descripcion,
                Fecha = p.Fecha
                
            }, p => p.Descripcion.Contains(filter), page, rows);
        }

        public async Task UpdateAsync(Puesto entity)
        {
            await _context.UpdateEntity(entity);
        }
    }
}
