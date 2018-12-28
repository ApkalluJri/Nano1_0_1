using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Spartane.Core.Classes.StoredProcedure
{
    public class Sp_SelallDetalle_de_Notificacion_por_Usuario_Complete : BaseEntity
    {
        public int Clave { get; set; }
        public int Contenido { get; set; }
        public bool? Notificar { get; set; }
        public int? Observatorio { get; set; }
        public string Observatorio_Nombre { get; set; }
        public int? ID_del_Cliente { get; set; }
        public string Nombre { get; set; }

    }
}
