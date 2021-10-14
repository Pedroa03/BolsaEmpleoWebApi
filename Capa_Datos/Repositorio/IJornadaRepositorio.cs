using Capa_Entidad;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Capa_Datos.Repositorio
{
    public interface IJornadaRepositorio
    {
        Task<(ICollection<Jornada> colletion, int total)> ListAsync(string filter, int page, int rows);
        Task<Jornada> GetAsync(string unique);
        Task<string> CreateAsync(Jornada entity);
        Task UpdateAsync(Jornada entity);
        Task DeleteAsync(string unique);
    }
}
