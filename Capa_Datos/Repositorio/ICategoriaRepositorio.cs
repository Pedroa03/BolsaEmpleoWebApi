using Capa_Entidad;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Capa_Datos.Repositorio
{
    public interface ICategoriaRepositorio
    {
        Task<(ICollection<Categoria> colletion, int total)> ListAsync(string filter, int page, int rows);
        Task<Categoria> GetAsync(int id);
        Task<string> CreateAsync(Categoria entity);
        Task UpdateAsync(Categoria entity);
        Task DeleteAsync(int id);
    }
}
