using AutoMapper;
using Capa_Datos.Repositorio;
using Capa_Dto.DtoPuesto;
using Capa_Entidad;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Capa_Negocio
{
    public class PuestoService: IPuestoService
    {
        private readonly IPuestoRepositorio _repositorio;
        private readonly IMapper _mapper;

        public PuestoService(IPuestoRepositorio repositorio, IMapper mapper)
        {
            _repositorio = repositorio;
            _mapper = mapper;
        }

        public async Task<BaseResponse<string>> CreateAsync(PuestoDtoRequest request)
        {
            var response = new BaseResponse<string>();
            try
            {
                response.Result = await _repositorio.CreateAsync(_mapper.Map<Puesto>(request));
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

        public async Task<BaseResponse<PuestoSingleDto>> GetAsync(int id)
        {
            var response = new BaseResponse<PuestoSingleDto>();

            try
            {
                var entidad = await _repositorio.GetAsync(id);

                if (entidad == null)
                {
                    response.Success = false;
                    response.ErrorMessage = Constants.NotFound;
                    return response;
                }


                response.Result = _mapper.Map<PuestoSingleDto>(entidad);

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

        public async Task<PuestoDtoResponse> ListAsync(string filter, int page, int rows)
        {
            var response = new PuestoDtoResponse();
            try
            {
                var result = await _repositorio.ListAsync(filter ?? string.Empty, page, rows);

                response.Collection = result.colletion
                    .Select(p => _mapper.Map<PuestoDto>(p)).ToList();


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

        public async Task<BaseResponse<string>> UpdateAsync(int id, PuestoDtoRequest request)
        {
            var response = new BaseResponse<string>();
            try
            {

                var entidad = _mapper.Map<Puesto>(request);
                entidad.IdPuesto = id;

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
