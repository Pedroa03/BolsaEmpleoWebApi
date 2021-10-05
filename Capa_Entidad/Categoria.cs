using System;
using System.Collections.Generic;

#nullable disable

namespace Capa_Entidad
{
    public partial class Categoria:EntityBase
    {
        public Categoria()
        {
            Usuarios = new HashSet<Usuario>();
        }

        public int Id { get; set; }
        public string Descripcion { get; set; }

        public virtual ICollection<Usuario> Usuarios { get; set; }
    }
}
