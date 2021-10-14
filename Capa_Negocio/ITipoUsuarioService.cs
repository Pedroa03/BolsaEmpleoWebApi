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

        Task<BaseResponse<TipoUsuarioDto>> GetAsync(string unique);

        Task<BaseResponse<string>> CreateAsync(TipoUsuarioDtoRequest request);

        Task<BaseResponse<string>> UpdateAsync(string unique, TipoUsuarioDtoRequest request);

        Task<BaseResponse<string>> DeleteAsync(string unique);
    }
}
