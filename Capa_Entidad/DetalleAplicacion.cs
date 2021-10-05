using System;
using System.Collections.Generic;

#nullable disable

namespace Capa_Entidad
{
    public partial class DetalleAplicacion
    {
        public int Id { get; set; }
        public string DetalleAplicacionPuesto { get; set; }
        public int? IdPuesto { get; set; }
        public int? FechaAplicacion { get; set; }
        public int? IdUsuario { get; set; }

        public virtual Puesto IdPuestoNavigation { get; set; }
        public virtual Usuario IdUsuarioNavigation { get; set; }
    }
}
