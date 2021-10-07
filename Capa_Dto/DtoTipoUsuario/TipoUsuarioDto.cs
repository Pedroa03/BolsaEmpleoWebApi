using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Capa_Dto.DtoTipoUsuario
{
    public class TipoUsuarioDto: TipoUsuarioDtoRequest
    {
        public string Unique { get; set; }
        public int Id { get; set; }
    }
}
