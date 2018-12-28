using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Spartane.Core.Classes.StoredProcedure
{
   public class SpListSelAllEtiquetas : BaseEntity
    {
        public Int64 RowNumber { get; set; }
        public int Etiquetas_Clave { get; set; }
        public string Etiquetas_Descripcion { get; set; }

    }
}
