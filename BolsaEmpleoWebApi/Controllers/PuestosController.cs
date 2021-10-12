using Capa_Dto.DtoPuesto;
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
    public class PuestosController : ControllerBase
    {
        private readonly IPuestoService _service;

        public PuestosController(IPuestoService service)
        {
            _service = service;
        }

        [HttpGet]
        public async Task<ActionResult<PuestoDtoResponse>> Get(string filter, int page = 1, int rows = 10)
        {
            return Ok(await _service.ListAsync(filter, page, rows));

        }

        [HttpGet("{id}")]
        public async Task<ActionResult<Puesto>> GetPuesto(int id)
        {
            var response = await _service.GetAsync(id);

            if (response.Result == null)
            {
                return NotFound(response);
            }

            return Ok(response);
        }

        [HttpPut("{id}")]
        public async Task<IActionResult> PutPuesto(int id, PuestoDtoRequest request)
        {
            var response = await _service.UpdateAsync(id, request);

            return Ok(response);
        }

        [HttpPost]
        public async Task<ActionResult<Puesto>> PostPuesto([FromBody] PuestoDtoRequest request)
        {
            var response = await _service.CreateAsync(request);

            return CreatedAtAction("GetPuesto", new { id = response.Result }, response);
        }

        [HttpDelete("{id}")]
        public async Task<IActionResult> DeletePuesto(int id)
        {
            var response = await _service.DeleteAsync(id);
            return Ok(response);
        }
    }
}
