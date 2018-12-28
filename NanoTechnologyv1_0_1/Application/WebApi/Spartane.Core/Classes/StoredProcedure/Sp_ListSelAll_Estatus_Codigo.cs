using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Spartane.Core.Classes.StoredProcedure
{
   public class SpListSelAllEstatus_Codigo : BaseEntity
    {
        public Int64 RowNumber { get; set; }
        public int Estatus_Codigo_Clave { get; set; }
        public string Estatus_Codigo_Descripcion { get; set; }

    }
}
