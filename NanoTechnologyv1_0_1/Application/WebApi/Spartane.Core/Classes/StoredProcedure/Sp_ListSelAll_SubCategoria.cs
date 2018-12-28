using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Spartane.Core.Classes.StoredProcedure
{
   public class SpListSelAllSubCategoria : BaseEntity
    {
        public Int64 RowNumber { get; set; }
        public int SubCategoria_Clave { get; set; }
        public string SubCategoria_Descripcion { get; set; }
        public int? SubCategoria_Categoria { get; set; }
        public string SubCategoria_Categoria_Descripcion { get; set; }

    }
}
