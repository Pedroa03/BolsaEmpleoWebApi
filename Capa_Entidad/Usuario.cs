using System;
using System.Collections.Generic;

#nullable disable

namespace Capa_Entidad
{
    public partial class Usuario : EntityBase
    {
      
        public Usuario()
        {
            Puestos = new HashSet<Puesto>();
        }



        public int IdUsuario { get; set; }
        public string Nombre { get; set; }
        public string Apellido { get; set; }
        public int IdTipoUsuario { get; set; }
        public string Clave { get; set; }
        public string Correo { get; set; }
        public bool? Estatus { get; set; }
        public DateTime? FechaCreacion { get; set; }
        public int? IdCategoria { get; set; }
        public string Descripcion { get; set; }
        public string Logo { get; set; }
        public string Url { get; set; }

        public virtual Categoria Categoria { get; set; }
        public virtual TipoUsuario TipoUsuario { get; set; }
        public virtual ICollection<Puesto> Puestos { get; set; }
    }
}
