using AutoMapper;
using Capa_Datos.Repositorio;
using Capa_Dto.DtoTipoUsuario;
using Capa_Entidad;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Capa_Negocio
{
   public class TipoUsuarioService : ITipoUsuarioService
    {
        private readonly ITipoUsuarioRepositorio _repositorio;
        private readonly IMapper _mapper;

        public TipoUsuarioService(ITipoUsuarioRepositorio repositorio, IMapper mapper)
        {
            _repositorio = repositorio;
            _mapper = mapper;
        }

        public async Task<BaseResponse<string>> CreateAsync(TipoUsuarioDtoRequest request)
        {
            var response = new BaseResponse<string>();
            try
            {
                response.Result = await _repositorio.CreateAsync(_mapper.Map<TipoUsuario>(request));
                response.Success = true;


            }
            catch (Exception ex)
            {
                // _logger.LogCritical(ex.Message);
                response.Success = false;
                response.ErrorMessage = ex.Message;
            }

            return response;
        }

        public async Task<BaseResponse<string>> DeleteAsync(string unique)
        {
            var response = new BaseResponse<string>();

            try
            {
                await _repositorio.DeleteAsync(unique);
                response.Success = true;
            }
            catch (Exception ex)
            {
                //_logger.LogCritical(ex.Message);
                response.Success = false;
                response.ErrorMessage = ex.Message;
            }
            return response;
        }

        public async Task<BaseResponse<TipoUsuarioDto>> GetAsync(string unique)
        {
            var response = new BaseResponse<TipoUsuarioDto>();

            try
            {
                var category = await _repositorio.GetAsync(unique);

                if (category == null)
                {
                    response.Success = false;
                    response.ErrorMessage = Constants.NotFound;
                    return response;
                }


                response.Result = _mapper.Map<TipoUsuarioDto>(category);

                response.Success = true;
            }
            catch (Exception ex)
            {
                //_logger.LogCritical(ex.Message);
                response.Success = false;
                response.ErrorMessage = ex.Message;
            }

            return response;
        }

        public async Task<TipoUsuarioDtoResponse> ListAsync(string filter, int page, int rows)
        {
            var response = new TipoUsuarioDtoResponse();
            try
            {
                var result = await _repositorio.ListAsync(filter ?? string.Empty, page, rows);

                response.Collection = result.colletion
                    .Select(p => _mapper.Map<TipoUsuarioDto>(p)).ToList();


                var totalPage = result.total / rows;

                if (result.total % rows > 0)
                    totalPage++;

                response.TotalPages = totalPage;
                response.Success = true;
            }
            catch (Exception ex)
            {

                //_logger.LogCritical(ex.Message);
                response.Success = false;
                response.ErrorMessage = ex.Message;
            }

            return response;
        }

        public async Task<BaseResponse<string>> UpdateAsync(string unique, TipoUsuarioDtoRequest request)
        {
            var response = new BaseResponse<string>();
            try
            {

                var category = _mapper.Map<TipoUsuario>(request);
                category.Unique = unique;

                await _repositorio.UpdateAsync(category);
                response.Success = true;
            }
            catch (Exception ex)
            {

                //_logger.LogCritical(ex.Message);
                response.Success = false;
                response.ErrorMessage = ex.Message;
            }

            return response;
        }
    }
}
