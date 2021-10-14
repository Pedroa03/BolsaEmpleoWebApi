using Capa_Entidad;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Capa_Datos.Repositorio
{
   public interface IAplicacionRepositorio
    {
        Task<(ICollection<Aplicacion> colletion, int total)> ListAsync(string filter, int page, int rows);
        Task<Aplicacion> GetAsync(string unique);
        Task<string> CreateAsync(Aplicacion entity);
        Task UpdateAsync(Aplicacion entity);
        Task DeleteAsync(string unique);
    }
}
