using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Spartane.Core.Classes.StoredProcedure
{
   public class SpListSelAllDetalle_de_Notificacion_por_Usuario : BaseEntity
    {
        public Int64 RowNumber { get; set; }
        public int Detalle_de_Notificacion_por_Usuario_Clave { get; set; }
        public int Detalle_de_Notificacion_por_Usuario_Contenido { get; set; }
        public bool? Detalle_de_Notificacion_por_Usuario_Notificar { get; set; }
        public int? Detalle_de_Notificacion_por_Usuario_Observatorio { get; set; }
        public string Detalle_de_Notificacion_por_Usuario_Observatorio_Nombre { get; set; }
        public int? Detalle_de_Notificacion_por_Usuario_ID_del_Cliente { get; set; }
        public string Detalle_de_Notificacion_por_Usuario_Nombre { get; set; }

    }
}
