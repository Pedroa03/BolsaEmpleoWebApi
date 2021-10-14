using Capa_Entidad;
using Capa_Entidad.Complejo;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Capa_Datos.Repositorio
{
   public interface IUsuarioRepositorio
    {
        Task<(ICollection<UsuarioInfo> colletion, int total)> ListAsync(string filter, int page, int rows);
        Task<Usuario> GetAsync(string unique);
        Task<string> CreateAsync(Usuario entity);
        Task UpdateAsync(Usuario entity);
        Task DeleteAsync(string unique);
    }
}
