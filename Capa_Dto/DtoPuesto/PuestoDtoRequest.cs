using System;
using System.Collections.Generic;
using System.ComponentModel.DataAnnotations;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Capa_Dto.DtoPuesto
{
    public class PuestoDtoRequest
    {
        [Required]
        public string Compañia { get; set; }
        [Required]
        public int IdTipoJornada { get; set; }
        public string Logo { get; set; }
        public string Url { get; set; }
        [Required]
        public string Posicion { get; set; }
        public string Ubicacion { get; set; }
        [Required]
        public int idCategoria { get; set; }
        [Required]
        public string Descripcion { get; set; }
        public string CorreoContacto { get; set; }
        public int idUsuario { get; set; }
        public DateTime Fecha { get; set; }
    }
}
