using Capa_Dto;
using Capa_Dto.DtoUsuario;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Capa_Negocio
{
    public interface IUsuarioService
    {
        Task<UsuarioDtoResponse> ListAsync(string filter, int page, int rows);

        Task<BaseResponse<UsuarioSingleDto>> GetAsync(string unique);

        Task<BaseResponse<string>> CreateAsync(UsuarioDtoRequest request);

        Task<BaseResponse<string>> UpdateAsync(string unique, UsuarioDtoRequest request);

        Task<BaseResponse<string>> DeleteAsync(string unique);
    }
}
