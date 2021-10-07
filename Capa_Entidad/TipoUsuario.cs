using System;
using System.Collections.Generic;

#nullable disable

namespace Capa_Entidad
{
    public partial class TipoUsuario: EntityBase
    {
        public TipoUsuario()
        {
            Usuarios = new HashSet<Usuario>();
        }

        public int Id { get; set; }
        public string Descripcion { get; set; }

        public virtual ICollection<Usuario> Usuarios { get; set; }
    }
}
