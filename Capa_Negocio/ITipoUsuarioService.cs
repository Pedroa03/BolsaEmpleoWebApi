using Capa_Dto.DtoTipoUsuario;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Capa_Negocio
{
    public interface ITipoUsuarioService
    {
        Task<TipoUsuarioDtoResponse> ListAsync(string filter, int page, int rows);

        Task<BaseResponse<TipoUsuarioDto>> GetAsync(int id);

        Task<BaseResponse<string>> CreateAsync(TipoUsuarioDtoRequest request);

        Task<BaseResponse<string>> UpdateAsync(int id, TipoUsuarioDtoRequest request);

        Task<BaseResponse<string>> DeleteAsync(int id);
    }
}
