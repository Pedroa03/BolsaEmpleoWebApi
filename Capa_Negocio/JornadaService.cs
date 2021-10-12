using AutoMapper;
using Capa_Datos.Repositorio;
using Capa_Dto.DtoJornada;
using Capa_Entidad;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Capa_Negocio
{
    public class JornadaService : IJornadaService
    {
        private readonly IJornadaRepositorio _repositorio;
        private readonly IMapper _mapper;

        public JornadaService(IJornadaRepositorio repositorio, IMapper mapper)
        {
            _repositorio = repositorio;
            _mapper = mapper;
        }

        public async Task<BaseResponse<string>> CreateAsync(JornadaDtoRequest request)
        {
            var response = new BaseResponse<string>();
            try
            {
                response.Result = await _repositorio.CreateAsync(_mapper.Map<Jornada>(request));
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

        public async Task<BaseResponse<string>> DeleteAsync(int id)
        {
            var response = new BaseResponse<string>();

            try
            {
                await _repositorio.DeleteAsync(id);
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

        public async Task<BaseResponse<JornadaDto>> GetAsync(int id)
        {
            var response = new BaseResponse<JornadaDto>();

            try
            {
                var category = await _repositorio.GetAsync(id);

                if (category == null)
                {
                    response.Success = false;
                    response.ErrorMessage = Constants.NotFound;
                    return response;
                }


                response.Result = _mapper.Map<JornadaDto>(category);

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

        public async Task<JornadaDtoResponse> ListAsync(string filter, int page, int rows)
        {
            var response = new JornadaDtoResponse();
            try
            {
                var result = await _repositorio.ListAsync(filter ?? string.Empty, page, rows);

                response.Collection = result.colletion
                    .Select(p => _mapper.Map<JornadaDto>(p)).ToList();


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

        public async Task<BaseResponse<string>> UpdateAsync(int id, JornadaDtoRequest request)
        {
            var response = new BaseResponse<string>();
            try
            {

                var category = _mapper.Map<Jornada>(request);
                category.Id = id;

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
