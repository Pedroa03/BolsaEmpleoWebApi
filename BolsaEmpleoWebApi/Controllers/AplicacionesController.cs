using Capa_Dto.DtoAplicacion;
using Capa_Entidad;
using Capa_Negocio;
using Microsoft.AspNetCore.Http;
using Microsoft.AspNetCore.Mvc;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;

namespace BolsaEmpleoWebApi.Controllers
{
    [Route("api/[controller]")]
    [ApiController]
    public class AplicacionesController : ControllerBase
    {
        private readonly IAplicacionService _service;

        public AplicacionesController(IAplicacionService service)
        {
            _service = service;
        }

        [HttpGet]
        public async Task<ActionResult<AplicacionDtoResponse>> Get(string filter, int page = 1, int rows = 10)
        {
            return Ok(await _service.ListAsync(filter, page, rows));

        }

        [HttpGet("{id}")]
        public async Task<ActionResult<Aplicacion>> GetCategory(string id)
        {
            var response = await _service.GetAsync(id);

            if (response.Result == null)
            {
                return NotFound(response);
            }

            return Ok(response);
        }

        [HttpPut("{id}")]
        public async Task<IActionResult> PutCategory(string id, AplicacionDtoRequest request)
        {
            var response = await _service.UpdateAsync(id, request);

            return Ok(response);
        }

        [HttpPost]
        public async Task<ActionResult<Aplicacion>> PostCategory([FromBody] AplicacionDtoRequest request)
        {
            var response = await _service.CreateAsync(request);

            return CreatedAtAction("GetCategory", new { id = response.Result }, response);
            //return Ok(response);
        }

        [HttpDelete("{id}")]
        public async Task<IActionResult> DeleteCategory(string id)
        {
            var response = await _service.DeleteAsync(id);
            return Ok(response);
        }
    }
}
