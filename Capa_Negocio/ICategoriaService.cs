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

        Task<BaseResponse<CategoriaDto>> GetAsync(string unique);

        Task<BaseResponse<string>> CreateAsync(CategoriaDtoRequest request);

        Task<BaseResponse<string>> UpdateAsync(string unique, CategoriaDtoRequest request);

        Task<BaseResponse<string>> DeleteAsync(string unique);
    }
}
