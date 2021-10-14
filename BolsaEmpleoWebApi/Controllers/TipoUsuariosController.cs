using Capa_Dto.DtoTipoUsuario;
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
    public class TipoUsuariosController : ControllerBase
    {
        private readonly ITipoUsuarioService _service;

        public TipoUsuariosController(ITipoUsuarioService service)
        {
            _service = service;
        }

        [HttpGet]
        public async Task<ActionResult<TipoUsuarioDtoResponse>> Get(string filter, int page = 1, int rows = 10)
        {
            return Ok(await _service.ListAsync(filter, page, rows));

        }

        [HttpGet("{id}")]
        public async Task<ActionResult<TipoUsuario>> GetCategory(string id)
        {
            var response = await _service.GetAsync(id);

            if (response.Result == null)
            {
                return NotFound(response);
            }

            return Ok(response);
        }

        [HttpPut("{id}")]
        public async Task<IActionResult> PutCategory(string id, TipoUsuarioDtoRequest request)
        {
            var response = await _service.UpdateAsync(id, request);

            return Ok(response);
        }

        [HttpPost]
        public async Task<ActionResult<TipoUsuario>> PostCategory([FromBody] TipoUsuarioDtoRequest request)
        {
            var response = await _service.CreateAsync(request);

            return CreatedAtAction("GetCategory", new { id = response.Result }, response);
        }

        [HttpDelete("{id}")]
        public async Task<IActionResult> DeleteCategory(string id)
        {
            var response = await _service.DeleteAsync(id);
            return Ok(response);
        }
    }
}
