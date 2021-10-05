using Capa_Dto;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Capa_Negocio
{
    public interface ICategoriaService
    {
        Task<CategoriaDtoResponse> ListAsync(string filter, int page, int rows);

        Task<BaseResponse<CategoriaDto>> GetAsync(int id);

        Task<BaseResponse<string>> CreateAsync(CategoriaDtoRequest request);

        Task<BaseResponse<string>> UpdateAsync(int id, CategoriaDtoRequest request);

        Task<BaseResponse<string>> DeleteAsync(int id);
    }
}
