using Capa_Dto.DtoPuesto;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Capa_Negocio
{
   public interface IPuestoService
    {
        Task<PuestoDtoResponse> ListAsync(string filter, int page, int rows);

        Task<BaseResponse<PuestoSingleDto>> GetAsync(string unique);

        Task<BaseResponse<string>> CreateAsync(PuestoDtoRequest request);

        Task<BaseResponse<string>> UpdateAsync(string unique, PuestoDtoRequest request);

        Task<BaseResponse<string>> DeleteAsync(string unique);
    }
}
