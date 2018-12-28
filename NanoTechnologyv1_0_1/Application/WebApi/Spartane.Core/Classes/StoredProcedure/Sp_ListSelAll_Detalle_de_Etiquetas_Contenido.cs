using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Spartane.Core.Classes.StoredProcedure
{
   public class SpListSelAllDetalle_de_Etiquetas_Contenido : BaseEntity
    {
        public Int64 RowNumber { get; set; }
        public int Detalle_de_Etiquetas_Contenido_Clave { get; set; }
        public string Detalle_de_Etiquetas_Contenido_Descripcion { get; set; }

    }
}
