using Capa_Entidad;
using Capa_Entidad.Complejo;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Capa_Datos.Repositorio
{
   public interface IPuestoRepositorio
    {
        Task<(ICollection<PuestoInfo> colletion, int total)> ListAsync(string filter, int page, int rows);
        Task<Puesto> GetAsync(int id);
        Task<string> CreateAsync(Puesto entity);
        Task UpdateAsync(Puesto entity);
        Task DeleteAsync(int id);
    }
}
