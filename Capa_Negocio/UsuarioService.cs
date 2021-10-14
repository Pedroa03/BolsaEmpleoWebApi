using AutoMapper;
using Capa_Datos.Repositorio;
using Capa_Dto.DtoUsuario;
using Capa_Entidad;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Capa_Negocio
{
    public class UsuarioService : IUsuarioService
    {
        private readonly IUsuarioRepositorio _repositorio;
        private readonly IMapper _mapper;

        public UsuarioService(IUsuarioRepositorio repositorio, IMapper mapper)
        {
            _repositorio = repositorio;
            _mapper = mapper;
        }

        public async Task<BaseResponse<string>> CreateAsync(UsuarioDtoRequest request)
        {
            var response = new BaseResponse<string>();
            try
            {
                response.Result = await _repositorio.CreateAsync(_mapper.Map<Usuario>(request));
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

        public async Task<BaseResponse<UsuarioSingleDto>> GetAsync(string unique)
        {
            var response = new BaseResponse<UsuarioSingleDto>();

            try
            {
                var entidad = await _repositorio.GetAsync(unique);

                if (entidad == null)
                {
                    response.Success = false;
                    response.ErrorMessage = Constants.NotFound;
                    return response;
                }


                response.Result = _mapper.Map<UsuarioSingleDto>(entidad);

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

        public async Task<UsuarioDtoResponse> ListAsync(string filter, int page, int rows)
        {
            var response = new UsuarioDtoResponse();
            try
            {
                var result = await _repositorio.ListAsync(filter ?? string.Empty, page, rows);

                response.Collection = result.colletion
                    .Select(p => _mapper.Map<UsuarioDto>(p)).ToList();


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

        public async Task<BaseResponse<string>> UpdateAsync(string unique, UsuarioDtoRequest request)
        {
            var response = new BaseResponse<string>();
            try
            {

                var entidad = _mapper.Map<Usuario>(request);
                entidad.Unique = unique;

                await _repositorio.UpdateAsync(entidad);
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
