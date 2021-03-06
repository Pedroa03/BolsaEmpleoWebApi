using System;
using System.Collections.Generic;

#nullable disable

namespace Capa_Entidad
{
    public class Puesto: EntityBase
    {
        //public Puesto()
        //{
        //    DetallesAplicaciones = new HashSet<DetalleAplicacion>();
        //} 

        public int IdPuesto { get; set; }
        public string Compañia { get; set; }
        public int IdTipoJornada { get; set; }
        public string Logo { get; set; }
        public string Url { get; set; }
        public string Posicion { get; set; }
        public string Ubicacion { get; set; }
        public int IdCategoria { get; set; }
        public string Descripcion { get; set; }
        public string CorreoContacto { get; set; }
        public int IdUsuario { get; set; }
        public DateTime Fecha { get; set; }

        public virtual Jornada TipoJornada { get; set; }
        public virtual Usuario Usuario { get; set; }
        public virtual Categoria Categoria { get; set; }
        //public virtual ICollection<DetalleAplicacion> DetallesAplicaciones { get; set; }


    }
}
