using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Capa_Dto.DtoAplicacion
{
    public class AplicacionDtoRequest
    {
        public int IdPuesto { get; set; }
        public int IdUsuario { get; set; }
        public DateTime Fecha { get; set; }
    }
}
