using Capa_Dto.DtoUsuario;
using Capa_Entidad;
using Capa_Negocio;
using Microsoft.AspNetCore.Cors;
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
    public class UsuarioController : ControllerBase
    {
        private readonly IUsuarioService _service;

        public UsuarioController(IUsuarioService service)
        {
            _service = service;
        }

        
        [HttpGet]
        public async Task<ActionResult<UsuarioDtoResponse>> Get(string filter, int page = 1, int rows = 100)
        {
            return Ok(await _service.ListAsync(filter, page, rows));

        }

        
        [HttpGet("{id}")]
        public async Task<ActionResult<Usuario>> GetUsuario(string id)
        {
            var response = await _service.GetAsync(id);

            if (response.Result == null)
            {
                return NotFound(response);
            }

            return Ok(response);
        }

        
        [HttpPut("{id}")]
        public async Task<IActionResult> PutUsuario(string id, UsuarioDtoRequest request)
        {
            var response = await _service.UpdateAsync(id, request);

            return Ok(response);
        }

       
        [HttpPost]
        public async Task<ActionResult<Usuario>> PostUsuario([FromBody] UsuarioDtoRequest request)
        {
            var response = await _service.CreateAsync(request);

            return CreatedAtAction("GetUsuario", new { id = response.Result }, response);
        }

        
        [HttpDelete("{id}")]
        public async Task<IActionResult> DeleteUsuario(string id)
        {
            var response = await _service.DeleteAsync(id);
            return Ok(response);
        }
        [HttpGet("{usuario},{clave}")]
        public async Task<ActionResult<UsuarioDtoResponse>> Login(string usuario, string clave )
        {
            return Ok(await _service.LoginAsync(usuario,clave));

        }




    }
}
