using System;
using System.Collections.Generic;

#nullable disable

namespace Capa_Entidad
{
    public class Categoria:EntityBase
    {
        public Categoria()
        {
            Usuarios = new HashSet<Usuario>();
            Puestos = new HashSet<Puesto>();
        }

        public int Id { get; set; }
        public string Descripcion { get; set; }

        public virtual ICollection<Usuario> Usuarios { get; set; }
        public virtual ICollection<Puesto> Puestos { get; set; }
    }
}
