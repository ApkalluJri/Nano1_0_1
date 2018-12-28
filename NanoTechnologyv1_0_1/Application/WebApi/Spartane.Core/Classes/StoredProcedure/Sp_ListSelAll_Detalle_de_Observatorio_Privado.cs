using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Spartane.Core.Classes.StoredProcedure
{
   public class SpListSelAllDetalle_de_Observatorio_Privado : BaseEntity
    {
        public Int64 RowNumber { get; set; }
        public int Detalle_de_Observatorio_Privado_Clave { get; set; }
        public int Detalle_de_Observatorio_Privado_Observatorio { get; set; }
        public string Detalle_de_Observatorio_Privado_Codigo { get; set; }
        public int? Detalle_de_Observatorio_Privado_Estatus { get; set; }
        public string Detalle_de_Observatorio_Privado_Estatus_Descripcion { get; set; }
        public DateTime? Detalle_de_Observatorio_Privado_Expiracion { get; set; }
        public int? Detalle_de_Observatorio_Privado_Accesos { get; set; }

    }
}
