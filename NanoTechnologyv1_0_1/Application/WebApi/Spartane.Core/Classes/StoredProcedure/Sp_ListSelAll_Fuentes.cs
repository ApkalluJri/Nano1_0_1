using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Spartane.Core.Classes.StoredProcedure
{
   public class SpListSelAllFuentes : BaseEntity
    {
        public Int64 RowNumber { get; set; }
        public int Fuentes_Clave { get; set; }
        public int Fuentes_Articulo { get; set; }
        public string Fuentes_Fuente { get; set; }

    }
}
