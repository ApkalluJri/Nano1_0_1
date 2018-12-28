using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Spartane.Core.Classes.StoredProcedure
{
   public class SpListSelAllSeccion : BaseEntity
    {
        public Int64 RowNumber { get; set; }
        public int Seccion_Clave { get; set; }
        public string Seccion_Descripcion { get; set; }

    }
}
