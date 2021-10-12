using Capa_Dto.DtoJornada;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Capa_Negocio
{
   public interface IJornadaService
    {
        Task<JornadaDtoResponse> ListAsync(string filter, int page, int rows);

        Task<BaseResponse<JornadaDto>> GetAsync(int id);

        Task<BaseResponse<string>> CreateAsync(JornadaDtoRequest request);

        Task<BaseResponse<string>> UpdateAsync(int id, JornadaDtoRequest request);

        Task<BaseResponse<string>> DeleteAsync(int id);
    }
}
