using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Spartane.Core.Classes.StoredProcedure
{
   public class SpListSelAllDetalle_de_Codigo_Por_Cliente : BaseEntity
    {
        public Int64 RowNumber { get; set; }
        public int Detalle_de_Codigo_Por_Cliente_Clave { get; set; }
        public int Detalle_de_Codigo_Por_Cliente_Cliente { get; set; }
        public int? Detalle_de_Codigo_Por_Cliente_Observatorio { get; set; }
        public string Detalle_de_Codigo_Por_Cliente_Observatorio_Nombre { get; set; }
        public string Detalle_de_Codigo_Por_Cliente_Codigo { get; set; }
        public int? Detalle_de_Codigo_Por_Cliente_Estatus { get; set; }
        public string Detalle_de_Codigo_Por_Cliente_Estatus_Descripcion { get; set; }
        public DateTime? Detalle_de_Codigo_Por_Cliente_Expiracion { get; set; }
        public int? Detalle_de_Codigo_Por_Cliente_Accesos { get; set; }

    }
}
