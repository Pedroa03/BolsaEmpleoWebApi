using Capa_Dto;
using Capa_Dto.DtoJornada;
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
    public class JornadasController : ControllerBase
    {
        private readonly IJornadaService _service;

        public JornadasController(IJornadaService service)
        {
            _service = service;
        }

        [HttpGet]
        public async Task<ActionResult<JornadaDtoResponse>> Get(string filter, int page = 1, int rows = 10)
        {
            return Ok(await _service.ListAsync(filter, page, rows));

        }

        [HttpGet("{id}")]
        public async Task<ActionResult<Jornada>> GetCategory(int id)
        {
            var response = await _service.GetAsync(id);

            if (response.Result == null)
            {
                return NotFound(response);
            }

            return Ok(response);
        }

        [HttpPut("{id}")]
        public async Task<IActionResult> PutCategory(int id, JornadaDtoRequest request)
        {
            var response = await _service.UpdateAsync(id, request);

            return Ok(response);
        }

        [HttpPost]
        public async Task<ActionResult<Jornada>> PostCategory([FromBody] JornadaDtoRequest request)
        {
            var response = await _service.CreateAsync(request);

            return CreatedAtAction("GetCategory", new { id = response.Result }, response);
        }

        [HttpDelete("{id}")]
        public async Task<IActionResult> DeleteCategory(int id)
        {
            var response = await _service.DeleteAsync(id);
            return Ok(response);
        }
    }
}
