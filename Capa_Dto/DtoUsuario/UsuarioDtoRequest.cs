using System;
using System.Collections.Generic;
using System.ComponentModel.DataAnnotations;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Capa_Dto.DtoUsuario
{
    public class UsuarioDtoRequest
    {
       
        [Required]
        public string Nombre { get; set; }
        [Required]
        public string Apellido { get; set; }
        [Required]
        public int IdTipoUsuario { get; set; }
        [Required]
        public string Clave { get; set; }
        public string Correo { get; set; }
        public bool Estatus { get; set; }
        public DateTime FechaCreacion { get; set; }
        [Required]
        public int IdCategoria { get; set; }
        public string Descripcion { get; set; }
        public string NombreArchivo { get; set; }
        public string Url { get; set; }
        public string Base64Image { get; set; }
    }
}
