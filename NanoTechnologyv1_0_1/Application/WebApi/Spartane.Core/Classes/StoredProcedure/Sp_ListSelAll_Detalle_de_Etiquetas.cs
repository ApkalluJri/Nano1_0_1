using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Spartane.Core.Classes.StoredProcedure
{
   public class SpListSelAllDetalle_de_Etiquetas : BaseEntity
    {
        public Int64 RowNumber { get; set; }
        public int Detalle_de_Etiquetas_Clave { get; set; }
        public int Detalle_de_Etiquetas_Articulo { get; set; }
        public int? Detalle_de_Etiquetas_Etiqueta { get; set; }
        public string Detalle_de_Etiquetas_Etiqueta_Descripcion { get; set; }

    }
}
