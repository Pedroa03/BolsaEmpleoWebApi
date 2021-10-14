using Capa_Dto.DtoAplicacion;
using Capa_Entidad;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Capa_Negocio
{
    public interface IAplicacionService
    {
        Task<AplicacionDtoResponse> ListAsync(string filter, int page, int rows);

        Task<BaseResponse<AplicacionDto>> GetAsync(string unique);

        Task<BaseResponse<string>> CreateAsync(AplicacionDtoRequest request);

        Task<BaseResponse<string>> UpdateAsync(string unique, AplicacionDtoRequest request);

        Task<BaseResponse<string>> DeleteAsync(string unique);
    }
}
