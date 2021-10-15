using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Capa_Entidad.Complejo
{
    public class UsuarioInfo
    {
        public int IdUsuario { get; set; }
        public string Nombre { get; set; }
        public string Apellido { get; set; }
        public string TipoUsuario { get; set; }
        public string Clave { get; set; }
        public string Correo { get; set; }
        public bool? Estatus { get; set; }
        public DateTime? FechaCreacion { get; set; }
        public string Categoria { get; set; }
        public string Descripcion { get; set; }
        public string Logo { get; set; }
        public string Url { get; set; }
        public string Unique { get; set; }


    }
}
