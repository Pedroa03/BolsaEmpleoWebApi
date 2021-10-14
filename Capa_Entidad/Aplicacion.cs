using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Capa_Entidad
{
   public class Aplicacion: EntityBase
    {
        public int Id { get; set; }
        public int IdPuesto { get; set; }
        public int IdUsuario { get; set; }
        public DateTime Fecha { get; set; } 
    }
}
