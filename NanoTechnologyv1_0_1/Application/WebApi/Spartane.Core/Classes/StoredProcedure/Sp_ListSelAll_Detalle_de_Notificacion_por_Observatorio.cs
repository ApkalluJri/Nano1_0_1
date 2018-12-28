using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Spartane.Core.Classes.StoredProcedure
{
   public class SpListSelAllDetalle_de_Notificacion_por_Observatorio : BaseEntity
    {
        public Int64 RowNumber { get; set; }
        public int Detalle_de_Notificacion_por_Observatorio_Clave { get; set; }
        public int Detalle_de_Notificacion_por_Observatorio_Contenido { get; set; }
        public bool? Detalle_de_Notificacion_por_Observatorio_Notificar { get; set; }
        public int? Detalle_de_Notificacion_por_Observatorio_Observatorio { get; set; }
        public string Detalle_de_Notificacion_por_Observatorio_Observatorio_Nombre { get; set; }

    }
}
