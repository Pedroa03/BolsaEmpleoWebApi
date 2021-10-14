using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Capa_Dto.DtoAplicacion
{
    public class AplicacionDto: AplicacionDtoRequest
    {
        public string Unique { get; set; }
        public int Id { get; set; }
    }
}
