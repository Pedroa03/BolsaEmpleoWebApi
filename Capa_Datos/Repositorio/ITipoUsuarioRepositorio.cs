using Capa_Entidad;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Capa_Datos.Repositorio
{
    public interface ITipoUsuarioRepositorio
    {
        Task<(ICollection<TipoUsuario> colletion, int total)> ListAsync(string filter, int page, int rows);
        Task<TipoUsuario> GetAsync(string unique);
        Task<string> CreateAsync(TipoUsuario entity);
        Task UpdateAsync(TipoUsuario entity);
        Task DeleteAsync(string unique);
    }
}
