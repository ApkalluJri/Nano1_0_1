using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Spartane.Core.Classes.StoredProcedure
{
   public class SpListSelAllColor : BaseEntity
    {
        public Int64 RowNumber { get; set; }
        public int Color_Clave { get; set; }
        public string Color_Descripcion { get; set; }
        public string Color_Codigo_RGB { get; set; }

    }
}
