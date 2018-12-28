using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Spartane.Core.Classes.StoredProcedure
{
   public class SpListSelAllDetalle_de_Asistentes_de_Observatorio : BaseEntity
    {
        public Int64 RowNumber { get; set; }
        public int Detalle_de_Asistentes_de_Observatorio_Clave { get; set; }
        public int Detalle_de_Asistentes_de_Observatorio_Observatorio { get; set; }
        public int? Detalle_de_Asistentes_de_Observatorio_Nombre { get; set; }
        public string Detalle_de_Asistentes_de_Observatorio_Nombre_Nombre { get; set; }
        public int? Detalle_de_Asistentes_de_Observatorio_Rol { get; set; }
        public string Detalle_de_Asistentes_de_Observatorio_Rol_Descripcion { get; set; }

    }
}
