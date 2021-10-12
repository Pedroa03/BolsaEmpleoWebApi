using System;
using System.Collections.Generic;

#nullable disable

namespace Capa_Entidad
{
    public partial class Jornada: EntityBase
    {
        public Jornada()
        {
            Puestos = new HashSet<Puesto>();
        }
        public int Id { get; set; }
        public string Descripcion { get; set; }

        public virtual ICollection<Puesto> Puestos { get; set; }
    }
}
