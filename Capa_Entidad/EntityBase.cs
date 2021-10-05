using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Capa_Entidad
{
    public class EntityBase
    {
        
        public string Unique { get; set; }

        public EntityBase()
        {
            Unique = Guid.NewGuid().ToString();
        }
    }
}
